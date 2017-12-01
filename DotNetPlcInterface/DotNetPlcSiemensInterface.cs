using DotNetSiemensPLCToolBoxLibrary.Communication;
using DotNetSiemensPLCToolBoxLibrary.DataTypes;
using PNLBaseInterface;
using System;
using System.Timers;

namespace DotNetPlcInterface
{
    public class DotNetPlcSiemensInterface : IPlcNetLibrariesBaseInterface
    {
        public string IpAddress { get; set; }
        public int Rack { get; set; }
        public int Slot { get; set; }
        public string PlcLastErrorMessage { get; set; }

        private readonly Timer _dataReadTimer;
        private readonly object _lockObject = new object();
        private int _currentReadValue = 0;

        private readonly PLCConnection _plcConnection;

        public event EventHandler DataReadHandler;
        public event EventHandler ConnectedHandler;
        public event EventHandler DisconnectedHandler;
        public event EventHandler ErrorHandler;

        public DotNetPlcSiemensInterface(string ipAddress, int rack, int slot)
        {
            IpAddress = ipAddress;
            Rack = rack;
            Slot = slot;

            var cfg = new PLCConnectionConfiguration
            {
                CpuIP = ipAddress,
                Port = 102,
                CpuRack = rack,
                CpuSlot = slot,
                TimeoutIPConnect = TimeSpan.FromSeconds(5),
                Timeout = TimeSpan.FromSeconds(5),
                ConnectionType = LibNodaveConnectionTypes.ISO_over_TCP,
                ConnectionName = "S7_Connection",
                Routing = false,
                RoutingDestinationRack = 0,
                RoutingDestinationSlot = 0,
                RoutingDestination = String.Empty
            };

            cfg.SaveConfiguration();

            _plcConnection = new PLCConnection(cfg);

            _dataReadTimer = new Timer(500);
            _dataReadTimer.Elapsed += _dataReadTimer_Elapsed;
            _dataReadTimer.Start();
        }

        private void _dataReadTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

            if (!_plcConnection.Connected)
            {
                RaiseIsDisconnected();
                return;
            }

            // Do the read
            lock (_lockObject)
            {
                _currentReadValue = (short)_plcConnection.ReadValue("DB10.DBW4", TagDataType.Int);
            }

            RaiseDataReaded();
        }

        private bool IsPlcConnected()
        {
            if (_plcConnection.Connected) return true;

            PlcLastErrorMessage = "PLC not connected";
            RaiseError();
            RaiseIsDisconnected();

            return false;
        }

        public void RaiseDataReaded()
        {
            DataReadHandler?.Invoke(this, new EventArgs());
        }

        public void RaiseIsConnected()
        {
            ConnectedHandler?.Invoke(this, new EventArgs());
        }

        public void RaiseIsDisconnected()
        {
            DisconnectedHandler?.Invoke(this, new EventArgs());
        }

        public void RaiseError()
        {
            ErrorHandler?.Invoke(this, new EventArgs());
        }


        public bool Connect()
        {
            _plcConnection.Connect();

            if (!_plcConnection.Connected) RaiseError();
            else RaiseIsConnected();

            _dataReadTimer.Start();

            return _plcConnection.Connected;
        }

        public bool Disconnect()
        {
            if (!_plcConnection.Connected) return false;

            _dataReadTimer.Stop();
            _plcConnection.Disconnect();

            RaiseIsDisconnected();
            return true;
        }

        public bool SetStart()
        {
            if (!IsPlcConnected()) return false;

            var tag = new PLCTag("DB10.DBX0.0", TagDataType.Bool) { Value = 1 };

            lock (_lockObject)
            {
                _plcConnection.WriteValue(tag);
            }

            return true;
        }

        public bool SetStop()
        {
            if (!IsPlcConnected()) return false;

            var tag = new PLCTag("DB10.DBX0.1", TagDataType.Bool) { Value = 1 };

            lock (_lockObject)
            {
                _plcConnection.WriteValue(tag);
            }

            return true;
        }

        public bool SetSetPoint(int value)
        {
            if (!IsPlcConnected()) return false;

            var tag = new PLCTag("DB10.DBW2", TagDataType.Int) { Value = value };

            lock (_lockObject)
            {
                _plcConnection.WriteValue(tag);
            }

            return true;
        }

        public int GetLastReadedValue()
        {
            return _currentReadValue;
        }
    }
}
