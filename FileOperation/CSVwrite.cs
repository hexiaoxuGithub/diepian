using System;
using System.IO;
using dataStorage__fu;

namespace FileOperation
{

     public class CSVwrite
     {
        private CSVwrite ()
        {

        }

        public static void ImportCSV(string[] ls)
        {
            string[] strArrange = new string[15];

            string strFileName = "D:\\ExcelData\\Left\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";

            //string strFileName = Path1;
            //string strFileName1 = Path2;

            FileInfo fileInfo = new FileInfo(strFileName);
            if (!fileInfo.Exists)
            {
                DirectoryInfo dirInfo = new DirectoryInfo("D:\\ExcelData\\Left\\");

                //DirectoryInfo dirInfo = new DirectoryInfo(strFileName1);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }

                strArrange[0] = "序号";
                strArrange[1] = "结果";
                strArrange[2] = "A";
                strArrange[3] = "B";
                strArrange[4] = "C";
                strArrange[5] = "D";
                strArrange[6] = "距离1";
                strArrange[7] = "距离2";
                strArrange[8] = "距离3";
                strArrange[9] = "距离4";
                strArrange[10] = "角度1";
                strArrange[11] = "角度2";
                strArrange[12] = "角度3";
                strArrange[13] = "角度4";
                strArrange[14] = "时间";
                CSVUtil.WriteCSV(strFileName, strArrange);


                strArrange[0] = "";
                strArrange[1] = ls[1];
                strArrange[2] = ls[2];
                strArrange[3] = ls[3];
                strArrange[4] = ls[4];
                strArrange[5] = ls[5];
                strArrange[6] = ls[6];
                strArrange[1] = ls[7];
                strArrange[2] = ls[8];
                strArrange[3] = ls[9];
                strArrange[4] = ls[10];
                strArrange[5] = ls[11];
                strArrange[6] = ls[12];
                strArrange[5] = ls[13];
                strArrange[6] = ls[14];
                CSVUtil.WriteCSV(strFileName, strArrange);
            }
            else
            {
                strArrange[0] = "";
                strArrange[1] = ls[1];
                strArrange[2] = ls[2];
                strArrange[3] = ls[3];
                strArrange[4] = ls[4];
                strArrange[5] = ls[5];
                strArrange[6] = ls[6];
                strArrange[1] = ls[7];
                strArrange[2] = ls[8];
                strArrange[3] = ls[9];
                strArrange[4] = ls[10];
                strArrange[5] = ls[11];
                strArrange[6] = ls[12];
                strArrange[5] = ls[13];
                strArrange[6] = ls[14];
                CSVUtil.WriteCSV(strFileName, strArrange);
            }
        }

        public static void ImportCSV1(string[] ls)
        {
            string[] strArrange = new string[7];

            string strFileName = "D:\\ExcelData\\Right\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";

            //string strFileName = Path1;
            //string strFileName1 = Path2;

            FileInfo fileInfo = new FileInfo(strFileName);
            if (!fileInfo.Exists)
            {
                DirectoryInfo dirInfo = new DirectoryInfo("D:\\ExcelData\\Right\\");

                //DirectoryInfo dirInfo = new DirectoryInfo(strFileName1);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }

                strArrange[0] = "序号";
                strArrange[1] = "结果";
                strArrange[2] = "电芯宽度";
                strArrange[3] = "电芯长度";
                strArrange[4] = "电芯侧边到极耳距离";
                strArrange[5] = "极耳大小";
                strArrange[6] = "时间";
                CSVUtil.WriteCSV(strFileName, strArrange);


                strArrange[0] = "";
                strArrange[1] = ls[1];
                strArrange[2] = ls[2];
                strArrange[3] = ls[3];
                strArrange[4] = ls[4];
                strArrange[5] = ls[5];
                strArrange[6] = ls[6];
                CSVUtil.WriteCSV(strFileName, strArrange);
            }
            else
            {
                strArrange[0] = "";
                strArrange[1] = ls[1];
                strArrange[2] = ls[2];
                strArrange[3] = ls[3];
                strArrange[4] = ls[4];
                strArrange[5] = ls[5];
                strArrange[6] = ls[6];
                CSVUtil.WriteCSV(strFileName, strArrange);
            }
        }
    }
}
