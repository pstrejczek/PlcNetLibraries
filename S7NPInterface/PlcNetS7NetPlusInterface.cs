using PNLBaseInterface;
using S7.Net;
using System;
using System.Timers;

namespace S7NPInterface
{
    public class PlcNetS7NetPlusInterface : IPlcNetLibrariesBaseInterface
    {
        public string IpAddress { get; set; }
        public int Rack { get; set; }
        public int Slot { get; set; }
        public string PlcLastErrorMessage { get; set; }

        private readonly Timer _dataReadTimer;
        private readonly Plc _s7Plc;
        private readonly object _lockObject = new object();
        private int _currentReadValue = 0;

        public event EventHandler DataReadHandler;
        public event EventHandler ConnectedHandler;
        public event EventHandler DisconnectedHandler;
        public event EventHandler ErrorHandler;

        public PlcNetS7NetPlusInterface(string ipAddress, int rack, int slot)
        {
            IpAddress = ipAddress;
            Rack = rack;
            Slot = slot;

            _s7Plc = new Plc(CpuType.S71200, IpAddress, (short)rack, (short)slot);

            _dataReadTimer = new Timer(500);
            _dataReadTimer.Elapsed += _dataReadTimer_Elapsed;
            _dataReadTimer.Start();
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

        private void _dataReadTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!_s7Plc.IsConnected)
            {
                RaiseIsDisconnected();
                return;
            }

            // Do the read
            lock (_lockObject)
            {
                var readResult = ((ushort)_s7Plc.Read("DB10.DBW4")).ConvertToShort();
                _currentReadValue = readResult;
            }

            RaiseDataReaded();
        }

        private bool IsPlcConnected()
        {
            if (_s7Plc.IsConnected) return true;

            PlcLastErrorMessage = "PLC not connected";
            RaiseError();
            RaiseIsDisconnected();

            return false;
        }

        public bool Connect()
        {
            if (!_s7Plc.IsAvailable)
            {
                PlcLastErrorMessage = "Connection not avaiable !";
                RaiseError();
            }

            var result = _s7Plc.Open();
            PlcLastErrorMessage = Enum.GetName(typeof(ErrorCode), result);

            if (result != ErrorCode.NoError) RaiseError();
            else RaiseIsConnected();

            _dataReadTimer.Start();

            return result == ErrorCode.NoError;
        }

        public bool Disconnect()
        {
            if (!IsPlcConnected()) return false;

            _dataReadTimer.Stop();
            _s7Plc.Close();

            RaiseIsDisconnected();
            return true;
        }

        public bool SetStart()
        {
            if (!IsPlcConnected()) return false;

            lock (_lockObject)
            {
                var result = _s7Plc.Write("DB10.DBX0.0", 1);

                if (result != ErrorCode.NoError)
                {
                    PlcLastErrorMessage = _s7Plc.LastErrorString;
                    RaiseError();
                }
            }

            return true;
        }

        public bool SetStop()
        {
            if (!IsPlcConnected()) return false;

            lock (_lockObject)
            {
                var result = _s7Plc.Write("DB10.DBX0.1", 1);

                if (result != ErrorCode.NoError)
                {
                    PlcLastErrorMessage = _s7Plc.LastErrorString;
                    RaiseError();
                }
            }

            return true;
        }

        public bool SetSetPoint(int value)
        {
            if (!IsPlcConnected()) return false;

            lock (_lockObject)
            {
                var result = _s7Plc.Write("DB10.DBw2", ((ushort)value).ConvertToShort());

                if (result != ErrorCode.NoError)
                {
                    PlcLastErrorMessage = _s7Plc.LastErrorString;
                    RaiseError();
                }
            }

            return true;
        }

        public int GetLastReadedValue()
        {
            return _currentReadValue;
        }
    }
}
