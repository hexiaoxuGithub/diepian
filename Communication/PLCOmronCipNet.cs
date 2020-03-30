using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIRP.Sockets;

namespace Communication
{
    public class PLCOmronCipNet
    {
        public bool PLCIsopen = false;
        public OmronCip Cip;

        public bool OpenPLC(string Address)
        {
            try
            {
                Cip = new OmronCip(Address, 44818, "PLC连接");
                Cip.Open();
                //OmronCip Cip = new OmronCip(IPAddress, 9600, "PLC连接");
                PLCIsopen = true;
                return true;
            }
            catch
            {
                PLCIsopen = false;
                return false;
            }

        }
        public void ClosePLC()
        {
            Cip.Close();
            PLCIsopen = false;
        }

        public bool writeOrder(string address, string writeValue)
        {
            if (Cip.Write(address, Int16.Parse(writeValue)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Int16 readOrder(string Address)
        {
            try
            {
                string result = Cip.Read(Address);
                return Convert.ToInt16(result);
            }
            catch (Exception xx)
            {
                return 0;
            }

        }

    }
}
