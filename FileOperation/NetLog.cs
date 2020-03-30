using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileOperation
{
    public class NetLog
    {
        /// <summary>
        /// 写入日志到文本文件
        /// </summary>
        /// <param name="strMessage">日志内容</param>
        public static void WriteTextLog(string strMessage)
        {
            string path = "D:\\ProjectLOG\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            DateTime time = DateTime.Now;
            string fileFullPath = path + time.ToString("yyyy -MM-dd") + ".System.txt";
            StringBuilder str = new StringBuilder();

            //str.Append("Time:" + time + ";Message: " + strMessage + "\r\n");
            str.Append("Time:" + time + ";Message: " + strMessage);
            StreamWriter sw;
            if (!File.Exists(fileFullPath))
            {
                sw = File.CreateText(fileFullPath);
            }
            else
            {
                sw = File.AppendText(fileFullPath);
            }
            sw.WriteLine(str.ToString());
            sw.Close();
        }
    }
}
