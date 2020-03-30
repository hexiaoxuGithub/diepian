using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using HalconDotNet;
using System.IO;

//本项目参数
namespace FileOperation
{
    [Serializable]
    public class GlobalThisProject
    {
        public string plcIP = "";
        public string TriggerShots = "";
        public string TirggerFeedback = "";
        public string ProcessingResult = "";
        public string Breathing = "";
   
        public Byte SA1 = 0;
        public Byte DA1 = 0;
        public Byte DA2 = 0;


        public double ElectricCoreLenghtMax = 0;
        public double ElectricCoreLenghtMin = 0;
        public double ElectricCoreToLengthMax = 0;
        public double ElectricCoreToLengthMin = 0;
        public double ElectricCoreToWidthMax = 0;
        public double ElectricCoreToWidthMin = 0;
        public double PolePitchMax = 0;
        public double PolePitchMin = 0;


        public short TriggerShotsValue = 0;
        public short TirggerFeedbackValue = 0;
        public short ProcessingResultOKValue = 0;
        public short ProcessingResultNGValue = 0;

        public  int rowNumber = 0;
        public  int OKNumber = 0;
        public  int NGNumber = 0;

        public double pieLeft = 0;
        public double pieRight = 0;

        public int AthresholdMax = 0;
        public int AthresholdMin = 0;
        public int BthresholdMax = 0;
        public int BthresholdMin = 0;
        public int CthresholdMax = 0;
        public int CthresholdMin = 0;
        public int DthresholdMax = 0;
        public int DthresholdMin = 0;


        public bool SaveDate()
        {

            if (!Directory.Exists("D:\\ParameterProject"))
            {
                Directory.CreateDirectory("D:\\ParameterProject");
                return false;
            }
            else
            {

                FileStream fsWriter = new FileStream("D:\\ParameterProject\\NewCaliperInterface.dat", FileMode.Create, FileAccess.Write, FileShare.Read);
                BinaryFormatter fmt = new BinaryFormatter();
                fmt.Serialize(fsWriter, this);
                fsWriter.Close();
                return true;
            }
        }
        public static GlobalThisProject LoadObj_GlobalNewCalip()
        {

            GlobalThisProject actionDoc;
            BinaryFormatter fmt = new BinaryFormatter();
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead("D:\\ParameterProject\\NewCaliperInterface.dat");
                actionDoc = (GlobalThisProject)fmt.Deserialize(fsReader);
                if (actionDoc == null)
                {
                    actionDoc = new GlobalThisProject();
                }
                else
                {
                    ;
                }
                fsReader.Close();
            }
            catch (Exception eMy)
            {
                //System.Windows.Forms.MessageBox.Show(eMy.Message);
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                actionDoc = new GlobalThisProject();

            }
            return actionDoc;



        }
    }
}
