using System.Net;

namespace PlcNetLibraries
{
    public static class Helpers
    {
        public static bool IsStringIpAddress(this string text)
        {
            try
            {
                IPAddress x = IPAddress.Parse(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsStringInteger(this string text)
        {
            try
            {
                int x = int.Parse(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
