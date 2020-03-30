using HslCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HslCommunication.Profinet.Siemens;

namespace Communication
{
    public class PLCSiementsTcpNet
    {
        private SiemensS7Net _SiementsTcpNet;
        public object lockObj1 = new object();

        public bool PLCIsopen = false;

        public bool OpenPLC(string IPAddress)
        {
            try
            {

                _SiementsTcpNet = new SiemensS7Net(SiemensPLCS.S1200, IPAddress);
                _SiementsTcpNet.ConnectTimeOut = 5000;
                _SiementsTcpNet.Port = 102;
                OperateResult result = _SiementsTcpNet.ConnectServer();

                //MessageBox.Show((result.IsSuccess).ToString());

                if (result.IsSuccess)
                {
                    
                    //AtuoRun = true;
                    //MessageBox.Show("连接PLC成功");

                    //NetLog.WriteTextLog("连接PLC成功");
                    PLCIsopen = true;
                    return true;
                }
                else
                {
                    //MessageBox.Show("连接PLC失败");

                    //NetLog.WriteTextLog("连接PLC失败");
                    PLCIsopen = false;
                    return false;
                }


            }
            catch (Exception ex)
            {
                PLCIsopen = false;
                //MessageBox.Show(ex.Message);

                //NetLog.WriteTextLog("连接PLC错误"+ex.Message);
                return false;
            }
        }

        public void ClosePLC()
        {
            if (_SiementsTcpNet != null)
            {
                _SiementsTcpNet.ConnectClose();
                _SiementsTcpNet = null;
                PLCIsopen = false;
            }
        }

        public bool writeOrder(string address, string writeValue)
        {

            lock (lockObj1)
            {
                OperateResult result = _SiementsTcpNet.Write(address, Int16.Parse(writeValue));

                ////OperateResult result = _SiementsTcpNet.Write(Address, Convert.ToUInt32(writeValue));
                ////MessageBox.Show(result.IsSuccess.ToString());
                ////lblWriteStatus.Content = result.IsSuccess;
                //if (result.IsSuccess == false)
                //{
                //    //MessageBox.Show("写入指令不成功，请检查PLC是否连接上");
                //}
                return result.IsSuccess;
            }


        }

        public Int16 readOrder(string Address)
        {

            lock (lockObj1)
            {
                //OperateResult<UInt32> result = _SiementsTcpNet.ReadUInt32(Address);
                OperateResult<Int16> result1 = _SiementsTcpNet.ReadInt16(Address);

                //uint readValue = result.Content;

                return result1.Content; ;
            }

        }

    }
}

