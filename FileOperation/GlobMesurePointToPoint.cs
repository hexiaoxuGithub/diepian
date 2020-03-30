using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace FileOperation
{
    [Serializable]
    public class GlobMesurePointToPoint
    {
        #region 
        public HTuple Sigma = null;
        public HTuple Threshold = null;
        public HTuple Transition = null;
        public HTuple bSelect = null;
        public HTuple Interpolation = null;
        public HTuple MeauserHID = null;
        public HTuple hv_Row = null, hv_Column = null, hv_Phi = null, hv_Length1 = null, hv_Length2 = null,
        width = null, height = null;

        public HTuple Sigma0 = null;
        public HTuple Threshold0 = null;
        public HTuple Transition0 = null;
        public HTuple bSelect0 = null;
        public HTuple Interpolation0 = null;
        public HTuple MeauserHID0 = null;
        public HTuple hv_Row0 = null, hv_Column0 = null, hv_Phi0 = null, hv_Length10 = null, hv_Length20 = null,
        width0 = null, height0 = null;

        //找直线
        public HTuple Sigma1 = null;
        public HTuple Threshold1 = null;
        public HTuple Transition1 = null;
        public HTuple bSelect1 = null;
        public HTuple Interpolation1 = null;
        public HTuple hv_Row1 = null, hv_Column1 = null, hv_Phi1 = null, hv_Length11 = null, hv_Length21 = null,
        width1 = null, height1 = null;

        public HTuple Sigma2 = null;
        public HTuple Threshold2 = null;
        public HTuple Transition2 = null;
        public HTuple bSelect2 = null;
        public HTuple Interpolation2 = null;
        public HTuple hv_Row2 = null, hv_Column2 = null, hv_Phi2 = null, hv_Length12 = null, hv_Length22 = null,
        width2 = null, height2 = null;

        public HTuple Sigma3 = null;
        public HTuple Threshold3 = null;
        public HTuple Transition3 = null;
        public HTuple bSelect3 = null;
        public HTuple Interpolation3 = null;
        public HTuple hv_Row3 = null, hv_Column3 = null, hv_Phi3 = null, hv_Length13 = null, hv_Length23 = null,
        width3 = null, height3 = null;

        public HTuple Sigma4 = null;
        public HTuple Threshold4 = null;
        public HTuple Transition4 = null;
        public HTuple bSelect4 = null;
        public HTuple Interpolation4 = null;
        public HTuple hv_Row4 = null, hv_Column4 = null, hv_Phi4 = null, hv_Length14 = null, hv_Length24 = null,
        width4 = null, height4 = null;

        public HTuple Sigma5 = null;
        public HTuple Threshold5 = null;
        public HTuple Transition5 = null;
        public HTuple bSelect5 = null;
        public HTuple Interpolation5 = null;
        public HTuple hv_Row5 = null, hv_Column5 = null, hv_Phi5 = null, hv_Length15 = null, hv_Length25 = null,
        width5 = null, height5 = null;

        public HTuple Sigma6 = null;
        public HTuple Threshold6 = null;
        public HTuple Transition6 = null;
        public HTuple bSelect6 = null;
        public HTuple Interpolation6 = null;
        public HTuple hv_Row6 = null, hv_Column6 = null, hv_Phi6 = null, hv_Length16 = null, hv_Length26 = null,
        width6 = null, height6 = null;

        public HTuple Sigma7 = null;
        public HTuple Threshold7 = null;
        public HTuple Transition7 = null;
        public HTuple bSelect7 = null;
        public HTuple Interpolation7 = null;
        public HTuple hv_Row7 = null, hv_Column7 = null, hv_Phi7 = null, hv_Length17 = null, hv_Length27 = null,
        width7 = null, height7 = null;

        public HTuple Sigma8 = null;
        public HTuple Threshold8 = null;
        public HTuple Transition8 = null;
        public HTuple bSelect8 = null;
        public HTuple Interpolation8 = null;
        public HTuple hv_Row8 = null, hv_Column8 = null, hv_Phi8 = null, hv_Length18 = null, hv_Length28 = null,
        width8 = null, height8 = null;

        public HTuple Sigma9 = null;
        public HTuple Threshold9 = null;
        public HTuple Transition9 = null;
        public HTuple bSelect9 = null;
        public HTuple Interpolation9 = null;
        public HTuple hv_Row9 = null, hv_Column9 = null, hv_Phi9 = null, hv_Length19 = null, hv_Length29 = null,
        width9 = null, height9 = null;

        public HTuple Sigma10 = null;
        public HTuple Threshold10 = null;
        public HTuple Transition10 = null;
        public HTuple bSelect10 = null;
        public HTuple Interpolation10 = null;
        public HTuple hv_Row10 = null, hv_Column10 = null, hv_Phi10 = null, hv_Length110 = null, hv_Length210 = null,
        width10 = null, height10 = null;

        public HTuple Sigma11 = null;
        public HTuple Threshold11 = null;
        public HTuple Transition11 = null;
        public HTuple bSelect11 = null;
        public HTuple Interpolation11 = null;
        public HTuple hv_Row11 = null, hv_Column11 = null, hv_Phi11 = null, hv_Length111 = null, hv_Length211 = null,
        width11 = null, height11 = null;



        //边缘对测量

        public HTuple Sigma111 = null;
        public HTuple Threshold111 = null;
        public HTuple Transition111 = null;
        public HTuple bSelect111 = null;
        public HTuple Interpolation111 = null;
        public HTuple hv_Row111 = null, hv_Column111 = null, hv_Phi111 = null, hv_Length1111 = null, hv_Length2111 = null,
        width111 = null, height111 = null;


        public HTuple Sigma121 = null;
        public HTuple Threshold121 = null;
        public HTuple Transition121 = null;
        public HTuple bSelect121 = null;
        public HTuple Interpolation121 = null;
        public HTuple hv_Row121 = null, hv_Column121 = null, hv_Phi121 = null, hv_Length1121 = null, hv_Length2121 = null,
        width121 = null, height121 = null;


        //像素单量

        public double Pixel_equivalent = 0;

        #endregion


        #region 
        public double WeldingSpotMin1 = 0;
        public double WeldingSpotMin2 = 0;
        public double WeldingSpotMin3 = 0;
        public double WeldingSpotMin4 = 0;

        public double WeldingSpotMax1 = 0;
        public double WeldingSpotMax2 = 0;
        public double WeldingSpotMax3 = 0;
        public double WeldingSpotMax4 = 0;

        public double LenghtMin = 0;
        public double LenghtMax = 0;
        public double WideMin = 0;
        public double WideMax = 0;

        public double AngleMin1 = 0;
        public double AngleMin2 = 0;
        public double AngleMax1 = 0;
        public double AngleMax2 = 0;

        public double SpacingMin = 0;
        public double SpacingMax = 0;

        public double ReachLenghtMin1 = 0;
        public double ReachLenghtMin2 = 0;
        public double ReachLenghtMax1 = 0;
        public double ReachLenghtMax2 = 0;

        public double SideDistanceMin1 = 0;
        public double SideDistanceMin2 = 0;
        public double SideDistanceMax1 = 0;
        public double SideDistanceMax2 = 0;
        #endregion


        public string IPAdress = null;
        public string Port = null;



        public bool SaveDate()
        {
            //"D:\\ExcelData\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv"
            if (!Directory.Exists("D:\\ParameterDate\\"))
            {
                Directory.CreateDirectory("D:\\ParameterDate\\");
                return false;
            }
            else
            {

                FileStream fsWriter = new FileStream("D:\\ParameterDate\\ToolSystem.dat", FileMode.Create, FileAccess.Write, FileShare.Read);
                BinaryFormatter fmt = new BinaryFormatter();
                fmt.Serialize(fsWriter, this);
                fsWriter.Close();
                return true;
            }

        }
        public static GlobMesurePointToPoint LoadObj_1()
        {
            GlobMesurePointToPoint actionDoc;
            BinaryFormatter fmt = new BinaryFormatter();
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead("D:\\ParameterDate\\ToolSystem.dat");
                actionDoc = (GlobMesurePointToPoint)fmt.Deserialize(fsReader);
                if (actionDoc == null)
                {
                    actionDoc = new GlobMesurePointToPoint();
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
                actionDoc = new GlobMesurePointToPoint();

            }
            return actionDoc;
        }


    }
}
