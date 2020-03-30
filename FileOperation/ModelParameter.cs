using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//模板参数
namespace FileOperation
{
    [Serializable]
    public class ModelParameter
    {
        public double coreRow = 0;//模板中心Row
        public double coreCol = 0;//模板中心Col

        public int number = 0;

        public double Greediness = 0;

        public double MinScore = 0;

        public int modelNum = 0;

        public bool SaveDate()
        {

            if (!Directory.Exists("D:\\ParameterProject\\"))
            {
                Directory.CreateDirectory("D:\\ParameterProject\\");
                return false;
            }
            else
            {

                FileStream fsWriter = new FileStream("D:\\ParameterProject\\ModelInterface.dat", FileMode.Create, FileAccess.Write, FileShare.Read);
                BinaryFormatter fmt = new BinaryFormatter();
                fmt.Serialize(fsWriter, this);
                fsWriter.Close();
                return true;
            }

        }
        public static ModelParameter LoadObj_1()
        {
            ModelParameter actionDoc;
            BinaryFormatter fmt = new BinaryFormatter();
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead("D:\\ParameterProject\\ModelInterface.dat");
                actionDoc = (ModelParameter)fmt.Deserialize(fsReader);
                if (actionDoc == null)
                {
                    actionDoc = new ModelParameter();
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
                actionDoc = new ModelParameter();

            }
            return actionDoc;
        }
    }
}
