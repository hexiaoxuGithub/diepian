using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using HalconDotNet;
using System.IO;

//卡尺参数
namespace FileOperation
{
    [Serializable]
    public class GlobalCaliperFinds
    {
        #region 
        public HTuple measure_transition1 = null;
        public HTuple num_measures1 = null;
        public HTuple num_instances1 = null;
        public HTuple measure_sigma1 = null;
        public HTuple measure_length11 = null;
        public HTuple measure_length21 = null;
        public HTuple measure_threshold1 = null;
        public HTuple measure_interpolation1 = null;
        public HTuple measure_select1 = null;
        public HTuple min_score1 = null;
        public HTuple hv_Row11 = null;
        public HTuple hv_Column11 = null;
        public HTuple hv_Row21 = null;
        public HTuple hv_Column21 = null;

        public HTuple measure_transition2 = null;
        public HTuple num_measures2 = null;
        public HTuple num_instances2 = null;
        public HTuple measure_sigma2 = null;
        public HTuple measure_length12 = null;
        public HTuple measure_length22 = null;
        public HTuple measure_threshold2 = null;
        public HTuple measure_interpolation2 = null;
        public HTuple measure_select2 = null;
        public HTuple min_score2 = null;
        public HTuple hv_Row12 = null;
        public HTuple hv_Column12 = null;
        public HTuple hv_Row22 = null;
        public HTuple hv_Column22 = null;

        public HTuple measure_transition3 = null;
        public HTuple num_measures3 = null;
        public HTuple num_instances3 = null;
        public HTuple measure_sigma3 = null;
        public HTuple measure_length13 = null;
        public HTuple measure_length23 = null;
        public HTuple measure_threshold3 = null;
        public HTuple measure_interpolation3 = null;
        public HTuple measure_select3 = null;
        public HTuple min_score3 = null;
        public HTuple hv_Row13 = null;
        public HTuple hv_Column13 = null;
        public HTuple hv_Row23 = null;
        public HTuple hv_Column23 = null;

        public HTuple measure_transition4 = null;
        public HTuple num_measures4 = null;
        public HTuple num_instances4 = null;
        public HTuple measure_sigma4 = null;
        public HTuple measure_length14 = null;
        public HTuple measure_length24 = null;
        public HTuple measure_threshold4 = null;
        public HTuple measure_interpolation4 = null;
        public HTuple measure_select4 = null;
        public HTuple min_score4 = null;
        public HTuple hv_Row14 = null;
        public HTuple hv_Column14 = null;
        public HTuple hv_Row24 = null;
        public HTuple hv_Column24 = null;

        public HTuple measure_transition5 = null;
        public HTuple num_measures5 = null;
        public HTuple num_instances5 = null;
        public HTuple measure_sigma5 = null;
        public HTuple measure_length15 = null;
        public HTuple measure_length25 = null;
        public HTuple measure_threshold5 = null;
        public HTuple measure_interpolation5 = null;
        public HTuple measure_select5 = null;
        public HTuple min_score5 = null;
        public HTuple hv_Row15 = null;
        public HTuple hv_Column15 = null;
        public HTuple hv_Row25 = null;
        public HTuple hv_Column25 = null;

         public HTuple measure_transition6 = null;
         public HTuple num_measures6 = null;
         public HTuple num_instances6 = null;
         public HTuple measure_sigma6 = null;
         public HTuple measure_length16 = null;
         public HTuple measure_length26 = null;
         public HTuple measure_threshold6 = null;
         public HTuple measure_interpolation6 = null;
         public HTuple measure_select6 = null;
         public HTuple min_score6 = null;
         public HTuple hv_Row16 = null;
         public HTuple hv_Column16 = null;
         public HTuple hv_Row26 = null;
         public HTuple hv_Column26 = null;

         public HTuple measure_transition7 = null;
         public HTuple num_measures7 = null;
         public HTuple num_instances7 = null;
         public HTuple measure_sigma7 = null;
         public HTuple measure_length17 = null;
         public HTuple measure_length27 = null;
         public HTuple measure_threshold7 = null;
         public HTuple measure_interpolation7 = null;
         public HTuple measure_select7 = null;
         public HTuple min_score7 = null;
         public HTuple hv_Row17 = null;
         public HTuple hv_Column17 = null;
         public HTuple hv_Row27 = null;
         public HTuple hv_Column27 = null;

         public HTuple measure_transition8 = null;
         public HTuple num_measures8 = null;
         public HTuple num_instances8 = null;
         public HTuple measure_sigma8 = null;
         public HTuple measure_length18 = null;
         public HTuple measure_length28 = null;
         public HTuple measure_threshold8 = null;
         public HTuple measure_interpolation8 = null;
         public HTuple measure_select8 = null;
         public HTuple min_score8 = null;
         public HTuple hv_Row18 = null;
         public HTuple hv_Column18 = null;
         public HTuple hv_Row28 = null;
         public HTuple hv_Column28 = null;

         public HTuple measure_transition9 = null;
         public HTuple num_measures9 = null;
         public HTuple num_instances9 = null;
         public HTuple measure_sigma9 = null;
         public HTuple measure_length19 = null;
         public HTuple measure_length29 = null;
         public HTuple measure_threshold9 = null;
         public HTuple measure_interpolation9 = null;
         public HTuple measure_select9 = null;
         public HTuple min_score9 = null;
         public HTuple hv_Row19 = null;
         public HTuple hv_Column19 = null;
         public HTuple hv_Row29 = null;
         public HTuple hv_Column29 = null;

         public HTuple measure_transition10 = null;
         public HTuple num_measures10 = null;
         public HTuple num_instances10 = null;
         public HTuple measure_sigma10 = null;
         public HTuple measure_length110 = null;
         public HTuple measure_length210 = null;
         public HTuple measure_threshold10 = null;
         public HTuple measure_interpolation10 = null;
         public HTuple measure_select10 = null;
         public HTuple min_score10 = null;
         public HTuple hv_Row110 = null;
         public HTuple hv_Column110 = null;
         public HTuple hv_Row210 = null;
         public HTuple hv_Column210 = null;

         public HTuple measure_transition11 = null;
         public HTuple num_measures11 = null;
         public HTuple num_instances11 = null;
         public HTuple measure_sigma11 = null;
         public HTuple measure_length111 = null;
         public HTuple measure_length211 = null;
         public HTuple measure_threshold11 = null;
         public HTuple measure_interpolation11 = null;
         public HTuple measure_select11 = null;
         public HTuple min_score11 = null;
         public HTuple hv_Row111 = null;
         public HTuple hv_Column111 = null;
         public HTuple hv_Row211 = null;
         public HTuple hv_Column211 = null;

         public HTuple measure_transition12 = null;
         public HTuple num_measures12 = null;
         public HTuple num_instances12 = null;
         public HTuple measure_sigma12 = null;
         public HTuple measure_length112 = null;
         public HTuple measure_length212 = null;
         public HTuple measure_threshold12 = null;
         public HTuple measure_interpolation12 = null;
         public HTuple measure_select12 = null;
         public HTuple min_score12 = null;
         public HTuple hv_Row112 = null;
         public HTuple hv_Column112 = null;
         public HTuple hv_Row212 = null;
         public HTuple hv_Column212 = null;

         public HTuple measure_transition13 = null;
         public HTuple num_measures13 = null;
         public HTuple num_instances13 = null;
         public HTuple measure_sigma13 = null;
         public HTuple measure_length113 = null;
         public HTuple measure_length213 = null;
         public HTuple measure_threshold13 = null;
         public HTuple measure_interpolation13 = null;
         public HTuple measure_select13 = null;
         public HTuple min_score13 = null;
         public HTuple hv_Row113 = null;
         public HTuple hv_Column113 = null;
         public HTuple hv_Row213 = null;
         public HTuple hv_Column213 = null;

         public HTuple measure_transition14 = null;
         public HTuple num_measures14 = null;
         public HTuple num_instances14 = null;
         public HTuple measure_sigma14 = null;
         public HTuple measure_length114 = null;
         public HTuple measure_length214 = null;
         public HTuple measure_threshold14 = null;
         public HTuple measure_interpolation14 = null;
         public HTuple measure_select14 = null;
         public HTuple min_score14 = null;
         public HTuple hv_Row114 = null;
         public HTuple hv_Column114 = null;
         public HTuple hv_Row214 = null;
         public HTuple hv_Column214 = null;

         public HTuple measure_transition15 = null;
         public HTuple num_measures15 = null;
         public HTuple num_instances15 = null;
         public HTuple measure_sigma15 = null;
         public HTuple measure_length115 = null;
         public HTuple measure_length215 = null;
         public HTuple measure_threshold15 = null;
         public HTuple measure_interpolation15 = null;
         public HTuple measure_select15 = null;
         public HTuple min_score15 = null;
         public HTuple hv_Row115 = null;
         public HTuple hv_Column115 = null;
         public HTuple hv_Row215 = null;
         public HTuple hv_Column215 = null;

         public HTuple measure_transition16 = null;
         public HTuple num_measures16 = null;
         public HTuple num_instances16 = null;
         public HTuple measure_sigma16 = null;
         public HTuple measure_length116 = null;
         public HTuple measure_length216 = null;
         public HTuple measure_threshold16 = null;
         public HTuple measure_interpolation16 = null;
         public HTuple measure_select16 = null;
         public HTuple min_score16 = null;
         public HTuple hv_Row116 = null;
         public HTuple hv_Column116 = null;
         public HTuple hv_Row216 = null;
         public HTuple hv_Column216 = null;

         public HTuple measure_transition17 = null;
         public HTuple num_measures17 = null;
         public HTuple num_instances17 = null;
         public HTuple measure_sigma17 = null;
         public HTuple measure_length117 = null;
         public HTuple measure_length217 = null;
         public HTuple measure_threshold17 = null;
         public HTuple measure_interpolation17 = null;
         public HTuple measure_select17 = null;
         public HTuple min_score17 = null;
         public HTuple hv_Row117 = null;
         public HTuple hv_Column117 = null;
         public HTuple hv_Row217 = null;
         public HTuple hv_Column217 = null;

         public HTuple measure_transition18 = null;
         public HTuple num_measures18 = null;
         public HTuple num_instances18 = null;
         public HTuple measure_sigma18 = null;
         public HTuple measure_length118 = null;
         public HTuple measure_length218 = null;
         public HTuple measure_threshold18 = null;
         public HTuple measure_interpolation18 = null;
         public HTuple measure_select18 = null;
         public HTuple min_score18 = null;
         public HTuple hv_Row118 = null;
         public HTuple hv_Column118 = null;
         public HTuple hv_Row218 = null;
         public HTuple hv_Column218 = null;

         public HTuple measure_transition19 = null;
         public HTuple num_measures19 = null;
         public HTuple num_instances19 = null;
         public HTuple measure_sigma19 = null;
         public HTuple measure_length119 = null;
         public HTuple measure_length219 = null;
         public HTuple measure_threshold19 = null;
         public HTuple measure_interpolation19 = null;
         public HTuple measure_select19 = null;
         public HTuple min_score19 = null;
         public HTuple hv_Row119 = null;
         public HTuple hv_Column119 = null;
         public HTuple hv_Row219 = null;
         public HTuple hv_Column219 = null;

         public HTuple measure_transition20 = null;
         public HTuple num_measures20 = null;
         public HTuple num_instances20 = null;
         public HTuple measure_sigma20 = null;
         public HTuple measure_length120 = null;
         public HTuple measure_length220 = null;
         public HTuple measure_threshold20 = null;
         public HTuple measure_interpolation20 = null;
         public HTuple measure_select20 = null;
         public HTuple min_score20 = null;
         public HTuple hv_Row120 = null;
         public HTuple hv_Column120 = null;
         public HTuple hv_Row220 = null;
         public HTuple hv_Column220 = null;

        #endregion

        public bool SaveDate()
        {

            if (!Directory.Exists("D:\\ParameterProject"))
            {
                Directory.CreateDirectory("D:\\ParameterProject");
                return false;
            }
            else
            {

                FileStream fsWriter = new FileStream("D:\\ParameterProject\\CaliperInterface.dat", FileMode.Create, FileAccess.Write, FileShare.Read);
                BinaryFormatter fmt = new BinaryFormatter();
                fmt.Serialize(fsWriter, this);
                fsWriter.Close();
                return true;
            }
        }
        public static GlobalCaliperFinds LoadObj_GlobalCaliperFinds()
        {

            GlobalCaliperFinds actionDoc;
            BinaryFormatter fmt = new BinaryFormatter();
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead("D:\\ParameterProject\\CaliperInterface.dat");
                actionDoc = (GlobalCaliperFinds)fmt.Deserialize(fsReader);
                if (actionDoc == null)
                {
                    actionDoc = new GlobalCaliperFinds();
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
                actionDoc = new GlobalCaliperFinds();

            }
            return actionDoc;



        }
    }
}
