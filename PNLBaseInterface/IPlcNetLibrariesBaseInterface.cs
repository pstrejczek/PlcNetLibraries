using System;

namespace PNLBaseInterface
{
    public interface IPlcNetLibrariesBaseInterface
    {
        string IpAddress { get; set; }
        int Rack { get; set; }
        int Slot { get; set; }

        string PlcLastErrorMessage { get; set; }

        event EventHandler DataReadHandler;
        event EventHandler ConnectedHandler;
        event EventHandler DisconnectedHandler;
        event EventHandler ErrorHandler;

        void RaiseDataReaded();
        void RaiseIsConnected();
        void RaiseIsDisconnected();
        void RaiseError();

        bool Connect();
        bool Disconnect();

        bool SetStart();
        bool SetStop();

        bool SetSetPoint(int value);

        int GetLastReadedValue();
    }
}
