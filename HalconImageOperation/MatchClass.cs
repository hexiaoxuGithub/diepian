using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;

namespace HalconImageOperation
{
    public class MatchClass
    {
        ImageProcessing imageProcessing = new ImageProcessing();
        //public static HObject m_objDisp = new HObject();           //用于显示图形的对象

        List<HObject> hv_region = new List<HObject>();

        #region 计数
        void roi_nms(int nms,ComboBox comboBox1)
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < nms; i++)
            {
                comboBox1.Text = i.ToString();
                comboBox1.Items.Add(i);
            }
        }
        #endregion

        #region 矩形
        public void Retance_1(HTuple m_hWindowHandle,HObject m_Image,HObject m_objDisp, out HObject ho_Rectangle)
        {
            try
            {
                HTuple hv_Row1 = new HTuple();
                HTuple hv_Column1 = new HTuple();
                HTuple hv_Row2 = new HTuple();
                HTuple hv_Column2 = new HTuple();

                HOperatorSet.DrawRectangle1(m_hWindowHandle, out hv_Row1, out hv_Column1, out hv_Row2, out hv_Column2);
                //ho_Rectangle.Dispose();
                HOperatorSet.SetColor(m_hWindowHandle, "red");
                HOperatorSet.SetDraw(m_hWindowHandle, "margin");
                HOperatorSet.GenRectangle1(out ho_Rectangle, hv_Row1, hv_Column1, hv_Row2, hv_Column2);

                hv_region.Add(ho_Rectangle);
                // HOperatorSet.DispObj(ho_Rectangle, m_hWindowHandle);
                imageProcessing.Concat_Obj(ref m_objDisp, ref ho_Rectangle, ref m_objDisp);
                imageProcessing.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle);
            }
            catch (Exception ee)
            {
                ho_Rectangle = null;
            }
        }


        #endregion

        #region 角度矩形
        public void Retance_2(HTuple m_hWindowHandle, HObject m_Image, HObject m_objDisp, out HObject ho_Rectangle1)
        {
            try
            {
                HTuple hv_Row = new HTuple();
                HTuple hv_Column = new HTuple();
                HTuple hv_Phi = new HTuple();
                HTuple hv_Length1 = new HTuple();
                HTuple hv_Length2 = new HTuple();


                HOperatorSet.DrawRectangle2(m_hWindowHandle, out hv_Row, out hv_Column, out hv_Phi, out hv_Length1, out hv_Length2);
                // ho_Rectangle1.Dispose();
                HOperatorSet.SetColor(m_hWindowHandle, "red");
                HOperatorSet.SetDraw(m_hWindowHandle, "margin");
                HOperatorSet.GenRectangle2(out ho_Rectangle1, hv_Row, hv_Column, hv_Phi, hv_Length1, hv_Length2);
                //hv_region.Add(ho_Rectangle1);
                //roi_nms(hv_region.Count);
                //  HOperatorSet.DispObj(ho_Rectangle1, m_hWindowHandle);
                imageProcessing.Concat_Obj(ref m_objDisp, ref ho_Rectangle1, ref m_objDisp);
                imageProcessing.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle);
            }
            catch (Exception ee)
            {
                ho_Rectangle1 = null;
            }
        }
        #endregion

        #region 圆
        public void Cricle(HTuple m_hWindowHandle, HObject m_Image, HObject m_objDisp, out HObject ho_Circle)
        {
            try
            {
                HTuple hv_Row3 = new HTuple();
                HTuple hv_Column3 = new HTuple();
                HTuple hv_Radius = new HTuple();

                HOperatorSet.DrawCircle(m_hWindowHandle, out hv_Row3, out hv_Column3, out hv_Radius);
                // ho_Circle.Dispose();
                HOperatorSet.SetColor(m_hWindowHandle, "red");
                HOperatorSet.SetDraw(m_hWindowHandle, "margin");
                HOperatorSet.GenCircle(out ho_Circle, hv_Row3, hv_Column3, hv_Radius);

                // HOperatorSet.DispObj(ho_Circle, m_hWindowHandle);
                imageProcessing.Concat_Obj(ref m_objDisp, ref ho_Circle, ref m_objDisp);
                imageProcessing.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle);
            }
            catch (Exception ee)
            {
                ho_Circle = null;
            }
        }
        #endregion

        #region 椭圆
        public void Ellipse(HTuple m_hWindowHandle, HObject m_Image, HObject m_objDisp, out HObject ho_Ellipse)
        {
            try
            {
                HTuple hv_Row4 = new HTuple();
                HTuple hv_Column4 = new HTuple();
                HTuple hv_Phi1 = new HTuple();
                HTuple hv_Radius1 = new HTuple();
                HTuple hv_Radius2 = new HTuple();

                HOperatorSet.DrawEllipse(m_hWindowHandle, out hv_Row4, out hv_Column4, out hv_Phi1, out hv_Radius1, out hv_Radius2);
                //  ho_Ellipse.Dispose();
                HOperatorSet.SetColor(m_hWindowHandle, "red");
                HOperatorSet.SetDraw(m_hWindowHandle, "margin");
                HOperatorSet.GenEllipse(out ho_Ellipse, hv_Row4, hv_Column4, hv_Phi1, hv_Radius1, hv_Radius2);
                //  HOperatorSet.DispObj(ho_Ellipse, m_hWindowHandle);
                imageProcessing.Concat_Obj(ref m_objDisp, ref ho_Ellipse, ref m_objDisp);
                imageProcessing.UpdateImage(m_Image, ref m_objDisp, m_hWindowHandle);
            }
            catch (Exception ee)
            {
                ho_Ellipse = null;
            }
        }
        #endregion

    }
}
