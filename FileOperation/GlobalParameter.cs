using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using HalconDotNet;

//系统参数
namespace FileOperation
{
    [Serializable]
    public class GlobalSystemParameter
    {
        public string engineerPassword = "";
        public string administratorsPassword = "";
        public string operatorPassword = "";


        public string allImageRoute = "";

        public string NGImageRoute = "";

        public HTuple threadMax = null;
        public HTuple threadMin = null;
        public HTuple AreaMax = null;
        public HTuple AreaMin = null;

        public HTuple hv_Row1 = null;
        public HTuple hv_Column1 = null;
        public HTuple hv_Row2 = null;
        public HTuple hv_Column2 = null;


        public int setExposure1 = 0;
        public int setExposure2 = 0;
        public int setExposure3 = 0;
        public int setExposure4 = 0;
        public int setExposure5 = 0;
        public int setExposure6 = 0;



        public HTuple MeanWidth = null;
        public HTuple MeanHeight = null;
        public HTuple dyn_thresholdOffset = null;
        public HTuple LightDark = null;
        public HTuple MinArea = null;
        public HTuple MaxArea = null;
        public HTuple Radius = null;


        public string LocatingPhotoAddress = null;
        public string XoffsetAddress = null;
        public string YoffsetAddress = null;
        public string AngleOffsetAddress = null;

        public double LocatingPhotoValue = 0;
        public string DetectionPhotoAddress = null;
        public string DetectionResult = null;
        public double DetectionPhotoValue = 0;
        public double DetectionOK = 0;
        public double DetectionNG = 0;

        public  bool SaveDate()
        {

            if (!Directory.Exists("D:\\ParameterProject"))
            {
                Directory.CreateDirectory("D:\\ParameterProject");
                return false;
            }
            else
            {

                FileStream fsWriter = new FileStream("D:\\ParameterProject\\GlobalSystem.dat", FileMode.Create, FileAccess.Write, FileShare.Read);
                BinaryFormatter fmt = new BinaryFormatter();
                fmt.Serialize(fsWriter, this);
                fsWriter.Close();
                return true;
            }
        }

        public static GlobalSystemParameter LoadObj_GlobalCaliperFinds()
        {

            GlobalSystemParameter actionDoc;
            BinaryFormatter fmt = new BinaryFormatter();
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead("D:\\ParameterProject\\GlobalSystem.dat");
                actionDoc = (GlobalSystemParameter)fmt.Deserialize(fsReader);
                if (actionDoc == null)
                {
                    actionDoc = new GlobalSystemParameter();
                }
                else
                {
                    ;
                }
                fsReader.Close();
            }
            catch (Exception eMy)
            {
                NetLog.WriteTextLog(eMy.Message);
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                actionDoc = new GlobalSystemParameter();

            }
            return actionDoc;



        }
    }
}
