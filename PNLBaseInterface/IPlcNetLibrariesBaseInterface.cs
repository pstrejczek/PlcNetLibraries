using System;

namespace PNLBaseInterface
{
    public interface IPlcNetLibrariesBaseInterface
    {
        string IpAddress { get; set; }
        int Rack { get; set; }
        int Slot { get; set; }

        event EventHandler DataReadHandler;
        event EventHandler ConnectedHandler;
        event EventHandler DisconnectedHandler;

        void RaiseDataReaded();
        void RaiseIsConnected();
        void RaiseIsDisconnected();

        bool Connect();

        bool SetStart();
        bool SetStop();

        bool SetSetPoint(int value);
    }
}
