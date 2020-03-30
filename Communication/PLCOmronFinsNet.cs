using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Profinet.Omron;
using HslCommunication;

namespace Communication
{
    public class PLCOmronFinsNet
    {
        private OmronFinsNet _OmronFinsNet;
        public object lockObj1 = new object();

        public bool PLCIsopen = false;

        public bool OpenPLC(string IPAddress,Byte sa1, Byte da1, Byte da2)
        {
            try
            {
                _OmronFinsNet = new OmronFinsNet(IPAddress, 9600);
                _OmronFinsNet.SA1 = sa1;
                _OmronFinsNet.DA1 = da1;
                _OmronFinsNet.DA2 = da2;

                //_OmronFinsNet.ConnectTimeOut = 5000;
                //_SiementsTcpNet.Port = 102;
                OperateResult result = _OmronFinsNet.ConnectServer();

                //MessageBox.Show((result.IsSuccess).ToString());

                if (result.IsSuccess)
                {

                    //AtuoRun = true;
                    //MessageBox.Show("连接PLC成功");

                    //NetLog.WriteTextLog("连接PLC成功");
                    PLCIsopen = result.IsSuccess;
                    return true;
                }
                else
                {
                    //MessageBox.Show("连接PLC失败");

                    //NetLog.WriteTextLog("连接PLC失败");
                    PLCIsopen = result.IsSuccess;
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
            if (_OmronFinsNet != null)
            {
                _OmronFinsNet.ConnectClose();
                _OmronFinsNet = null;
                PLCIsopen = false;
            }
        }

        public bool writeOrder(string address, string writeValue)
        {

            lock (lockObj1)
            {
                OperateResult result = _OmronFinsNet.Write(address, UInt16.Parse(writeValue));

                ////OperateResult result = _SiementsTcpNet.Write(Address, Convert.ToUInt32(writeValue));
                ////MessageBox.Show(result.IsSuccess.ToString());
                ////lblWriteStatus.Content = result.IsSuccess;
                //if (result.IsSuccess == false)
                //{
                //    MessageBox.Show("写入指令不成功，请检查PLC是否连接上");
                //}
                return result.IsSuccess;
            }


        }

        public UInt16 readOrder(string Address)
        {

            lock (lockObj1)
            {
                //OperateResult<UInt32> result = _SiementsTcpNet.ReadUInt32(Address);
                OperateResult<UInt16> result1 = _OmronFinsNet.ReadUInt16(Address);

                //uint readValue = result.Content;

                return result1.Content; ;
            }

        }

    }
}
