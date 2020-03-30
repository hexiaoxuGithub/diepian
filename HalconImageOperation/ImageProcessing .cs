using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace HalconImageOperation
{
    public class ImageProcessing
    {
        public HObject m_objDisp = new HObject();			//用于显示图形的对象
        public HTuple m_ImageRow0 = new HTuple();			//当前在窗口显示的图像的左上角坐标y(图像坐标系)
        public HTuple m_ImageCol0 = new HTuple();			//当前在窗口显示的图像的左上角坐标x(图像坐标系)
        public HTuple m_ImageRow1 = new HTuple();			//当前在窗口显示的图像的右下角坐标y(图像坐标系)
        public HTuple m_ImageCol1 = new HTuple();       //当前在窗口显示的图像的右下角坐标x(图像坐标系)

        //图像宽、高
        public HTuple width = new HTuple();
        public HTuple height = new HTuple();

        HTuple hv_Button; //返回键值
        HTuple ptX, ptY; //图像像素坐标
        HTuple grayval = new HTuple();//灰度值

        #region 缩放
        public void Zoom(HObject Image, HObject objDisp, HTuple hWindowHandle, ref HTuple ImageRow0, ref HTuple ImageCol0,
       ref HTuple ImageRow1, ref HTuple ImageCol1, HMouseEventArgs e)
        {
            try
            {

                HTuple hv_Row, hv_Col, hv_Button;

                HTuple ImagePtX, ImagePtY;
                HTuple Row0_1, Col0_1, Row1_1, Col1_1;
                HTuple Width, Height;
                HTuple Scale = 0.1;	//缩放步长
                HTuple MaxScale = 40;//最大放大系数
                HTuple ptX, ptY;

                try
                {
                    HOperatorSet.GetMposition(hWindowHandle, out ptY, out ptX, out hv_Button);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    ptX = -1;
                    ptY = -1;
                    hv_Button = -1;
                }


                //获取图像尺寸
                HOperatorSet.GetImageSize(Image, out Width, out Height);

                //判断鼠标右键是否按下
                //         1:Left button, 
                //         2:Middle button, 
                //         4:Right button. 
                if (hv_Button == 4)
                {
                    //显示的图像区域的左上角坐标
                    ImageRow0 = 0;
                    ImageCol0 = 0;
                    //显示的图像区域的右下角坐标
                    ImageRow1 = Height - 1;
                    ImageCol1 = Width - 1;
                    HOperatorSet.ClearWindow(hWindowHandle);
                    //设置颜色
                    HOperatorSet.SetColor(hWindowHandle, "red");
                    //设置在图形窗口中显示局部图像
                    HOperatorSet.SetPart(hWindowHandle, ImageRow0, ImageCol0, ImageRow1, ImageCol1);
                    //刷新图形
                    UpdateImage(Image, ref objDisp, hWindowHandle, false);
                    return;
                }
                //判断鼠标左键是否按下
                if (hv_Button == 1)
                {
                    HTuple x, y;
                    HTuple Grey;
                    HObject Cross;
                    HOperatorSet.GenEmptyObj(out Cross);
                    try
                    {

                        //获取灰度值
                        HOperatorSet.GetGrayval(Image, ptY, ptX, out Grey);
                        //设置在图形窗口中显示局部图像
                        HOperatorSet.SetPart(hWindowHandle, ImageRow0, ImageCol0, ImageRow1, ImageCol1);
                        //设置颜色
                        HOperatorSet.SetColor(hWindowHandle, "red");
                        //刷新图形
                        UpdateImage(Image, ref objDisp, hWindowHandle, false);
                        //产生并显示+表示当前坐标
                        HOperatorSet.SetColor(hWindowHandle, "red");
                        HOperatorSet.GenCrossContourXld(out Cross, ptY, ptX, 5, 0);
                        HOperatorSet.DispObj(Cross, hWindowHandle);
                        //显示坐标值，灰度值
                        disp_message(hWindowHandle, "(x=" + ptX + ",y=" + ptY + ")grayval=" + Grey, "image", ptY, ptX, "green", "false");
                        Cross.Dispose();
                        return;
                    }
                    catch (HalconException ex)
                    {
                        Cross.Dispose();
                        throw ex;
                    }
                }
                else
                {

                    //向上滑动滚轮，图像缩小。以当前鼠标的坐标为支点进行缩小或放大
                    if (e.Delta > 0)
                    {

                        ImagePtX = ptX;
                        ImagePtY = ptY;
                        //重新计算缩小后的图像区域
                        Row0_1 = ImagePtY - 1 / (1 - Scale) * (ImagePtY - ImageRow0);
                        Row1_1 = ImagePtY - 1 / (1 - Scale) * (ImagePtY - ImageRow1);
                        Col0_1 = ImagePtX - 1 / (1 - Scale) * (ImagePtX - ImageCol0);
                        Col1_1 = ImagePtX - 1 / (1 - Scale) * (ImagePtX - ImageCol1);
                        //限定缩小范围
                        if ((Col1_1 - Col0_1).TupleAbs() / Width <= 52)
                        {
                            //设置在图形窗口中显示局部图像
                            ImageRow0 = Row0_1;
                            ImageCol0 = Col0_1;
                            ImageRow1 = Row1_1;
                            ImageCol1 = Col1_1;
                        }

                    }
                    //向下滑动滚轮，图像放大
                    else
                    {
                        ImagePtX = ptX;
                        ImagePtY = ptY;
                        //重新计算放大后的图像区域
                        Row0_1 = ImagePtY - 1 / (1 + Scale) * (ImagePtY - ImageRow0);
                        Row1_1 = ImagePtY - 1 / (1 + Scale) * (ImagePtY - ImageRow1);
                        Col0_1 = ImagePtX - 1 / (1 + Scale) * (ImagePtX - ImageCol0);
                        Col1_1 = ImagePtX - 1 / (1 + Scale) * (ImagePtX - ImageCol1);
                        //限定放大范围
                        if ((Width / (Col1_1 - Col0_1).TupleAbs()) <= MaxScale)
                        {
                            //设置在图形窗口中显示局部图像
                            ImageRow0 = Row0_1;
                            ImageCol0 = Col0_1;
                            ImageRow1 = Row1_1;
                            ImageCol1 = Col1_1;
                        }

                    }
                    HOperatorSet.ClearWindow(hWindowHandle);
                    HOperatorSet.SetColor(hWindowHandle, "red");
                    HOperatorSet.SetPart(hWindowHandle, ImageRow0, ImageCol0, ImageRow1, ImageCol1);
                    UpdateImage(Image, ref objDisp, hWindowHandle, false);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 显示
        public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
                                 HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {


            // Local control variables 

            HTuple hv_Red, hv_Green, hv_Blue, hv_Row1Part;
            HTuple hv_Column1Part, hv_Row2Part, hv_Column2Part, hv_RowWin;
            HTuple hv_ColumnWin, hv_WidthWin, hv_HeightWin, hv_MaxAscent;
            HTuple hv_MaxDescent, hv_MaxWidth, hv_MaxHeight, hv_R1 = new HTuple();
            HTuple hv_C1 = new HTuple(), hv_FactorRow = new HTuple(), hv_FactorColumn = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Index = new HTuple(), hv_Ascent = new HTuple();
            HTuple hv_Descent = new HTuple(), hv_W = new HTuple(), hv_H = new HTuple();
            HTuple hv_FrameHeight = new HTuple(), hv_FrameWidth = new HTuple();
            HTuple hv_R2 = new HTuple(), hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
            HTuple hv_Exception = new HTuple(), hv_CurrentColor = new HTuple();

            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
            HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

            // Initialize local and output iconic variables 

            //This procedure displays text in a graphics window.
            //
            //Input parameters:
            //WindowHandle: The WindowHandle of the graphics window, where
            //   the message should be displayed
            //String: A tuple of strings containing the text message to be displayed
            //CoordSystem: If set to 'window', the text position is given
            //   with respect to the window coordinate system.
            //   If set to 'image', image coordinates are used.
            //   (This may be useful in zoomed images.)
            //Row: The row coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Column: The column coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Color: defines the color of the text as string.
            //   If set to [], '' or 'auto' the currently set color is used.
            //   If a tuple of strings is passed, the colors are used cyclically
            //   for each new textline.
            //Box: If set to 'true', the text is written within a white box.
            //
            //prepare window
            HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
            HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part, out hv_Row2Part,
                out hv_Column2Part);
            HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
                out hv_WidthWin, out hv_HeightWin);
            HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
            //
            //default settings
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
            {
                hv_Color_COPY_INP_TMP = "";
            }
            //
            hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
            //
            //Estimate extentions of text depending on font size.
            HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
                out hv_MaxWidth, out hv_MaxHeight);
            if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
            {
                hv_R1 = hv_Row_COPY_INP_TMP.Clone();
                hv_C1 = hv_Column_COPY_INP_TMP.Clone();
            }
            else
            {
                //transform image to window coordinates
                hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
                hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
                hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
                hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
            }
            //
            //display text box depending on text size
            if ((int)(new HTuple(hv_Box.TupleEqual("true"))) != 0)
            {
                //calculate box extents
                hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
                hv_Width = new HTuple();
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                        hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                    hv_Width = hv_Width.TupleConcat(hv_W);
                }
                hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    ));
                hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                hv_R2 = hv_R1 + hv_FrameHeight;
                hv_C2 = hv_C1 + hv_FrameWidth;
                //display rectangles
                HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
                HOperatorSet.SetDraw(hv_WindowHandle, "fill");
                HOperatorSet.SetColor(hv_WindowHandle, "light gray");
                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 3, hv_C1 + 3, hv_R2 + 3, hv_C2 + 3);
                HOperatorSet.SetColor(hv_WindowHandle, "white");
                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
            }
            else if ((int)(new HTuple(hv_Box.TupleNotEqual("false"))) != 0)
            {
                hv_Exception = "Wrong value of control parameter Box";
                throw new HalconException(hv_Exception);
            }
            //Write text.
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                )) - 1); hv_Index = (int)hv_Index + 1)
            {
                hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                    )));
                if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                    "auto")))) != 0)
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
                }
                else
                {
                    HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
                }
                hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
                HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
                HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                    hv_Index));
            }
            //reset changed window settings
            HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
            HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
                hv_Column2Part);

            return;
        }


        #endregion

        #region 刷新图像

        public void UpdateImage(HObject Image,          //图像
                ref HObject objDisp,        //显示图形
                 HTuple hWindowHandle,  //窗口句柄
                 bool bInitial = false          //是否对图形进行初始化操作
                 )
        {

            //复位显示图形
            if (bInitial == true)
            {
                objDisp.Dispose();
                HOperatorSet.GenEmptyObj(out objDisp);
            }
            //清楚显示窗口
            HOperatorSet.ClearWindow(hWindowHandle);
            //显示图像
            HOperatorSet.DispObj(Image, hWindowHandle);
            //显示图形
            if (objDisp.IsInitialized() && !bInitial)
            {
                HOperatorSet.DispObj(objDisp, hWindowHandle);
                // HOperatorSet.ReduceDomain(m_Image, objDisp, out ho_TemplateImage);
            }


        }

        public void UpdateImage1(HObject Image,          //图像
               ref HObject objDisp,        //显示图形
                HTuple hWindowHandle,  //窗口句柄
                out HObject ho_TemplateImage,
                bool bInitial = false          //是否对图形进行初始化操作
               )
        {
            HOperatorSet.SetColor(hWindowHandle,"blue");
            //复位显示图形
            if (bInitial == true)
            {
                objDisp.Dispose();
                HOperatorSet.GenEmptyObj(out objDisp);
            }
            //清楚显示窗口
            HOperatorSet.ClearWindow(hWindowHandle);
            //显示图像
            HOperatorSet.DispObj(Image, hWindowHandle);
            //显示图形
            if (objDisp.IsInitialized() && !bInitial)
            {
                HOperatorSet.DispObj(objDisp, hWindowHandle);
                HOperatorSet.ReduceDomain(Image, objDisp, out ho_TemplateImage);
            }
            else
            {
                HOperatorSet.ReduceDomain(Image, objDisp, out ho_TemplateImage);
            }


        }

        #endregion

        #region 重置窗口
        public void ResetWindow(HTuple myhWindowHandle,HObject myImage)
        {
            if (myImage == null)
                return;
            //m_ImagePart_Row1 = 0;
            //m_ImagePart_Col1 = 0;
            //m_ImagePart_Row2 = Height(0).D() - 1;
            //m_ImagePart_Col2 = Width(0).D() - 1;

            //HOperatorSet.SetPart(hWindowControl1.HalconWindow, m_ImagePart_Row1, m_ImagePart_Col1, m_ImagePart_Row2, m_ImagePart_Col2)
            //HOperatorSet.SetPart(hWindowControl1.HalconWindow, m_ImagePart_Row1, m_ImagePart_Col1, m_ImagePart_Row2, m_ImagePart_Col2)
            //hWindowControl1.Focus();
            HTuple Width, Height;

            //获取图像大小
            HOperatorSet.GetImageSize(myImage, out Width, out Height);

            //显示全图
            //以适应窗口方式显示图像
            HOperatorSet.SetPart(myhWindowHandle, 0, 0, Height, Width);
            m_ImageRow0 = 0;
            m_ImageRow1 = Height - 1;
            m_ImageCol0 = 0;
            m_ImageCol1 = Width - 1;

            HOperatorSet.SetPart(myhWindowHandle, 0, 0, Height, Width);
            HOperatorSet.DispObj(myImage, myhWindowHandle);
        }
        #endregion

        #region 弹出对话框
        public void POP( HTuple myhWindowHandle,HObject m_image)
        {
            
            OpenFileDialog Dlg = new OpenFileDialog();

            Dlg.Filter = "(*.bmp; *.png; *.jpg;*.jpeg; *.tif)|*.bmp; *.png; *.jpg;*.jpeg; *.tif";
            Dlg.Multiselect = false;

            if (Dlg.ShowDialog() == DialogResult.OK)
            {

                try
                {

                    m_objDisp.Dispose();
                    m_image.Dispose();
                    //hWindowControl1.Focus();
                    Read_Image(ref m_image, Dlg.FileName);

                    HTuple Width, Height;

                    //获取图像大小
                    HOperatorSet.GetImageSize(m_image, out Width, out Height);
                    width = Width;
                    height = Height;


                    //显示全图
                    //以适应窗口方式显示图像
                    HOperatorSet.SetPart(myhWindowHandle, 0, 0, Height, Width);
                    m_ImageRow0 = 0;
                    m_ImageRow1 = Height - 1;
                    m_ImageCol0 = 0;
                    m_ImageCol1 = Width - 1;

                    HOperatorSet.SetPart(myhWindowHandle, 0, 0, Height, Width);
                    HOperatorSet.DispObj(m_image, myhWindowHandle);
            }
                catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
            //Dlg.Dispose();
        }



        #endregion

        #region 文件是否存在
        public bool Read_Image(ref HObject Image, string Path)
        {
            try
            {
                if (!FileExist(Path))
                {
                    return false;
                }
                else
                {
                    //Image.Dispose();
                    HOperatorSet.ReadImage(out Image, Path);
                }


            }
            catch (Exception ee)
            {
                System.Windows.Forms.MessageBox.Show(ee.Message);
            }
            //文件是否存在
            return true;
        }
        public bool FileExist(string FileName)
        {
            HTuple hv_flag;
            HOperatorSet.FileExists(FileName, out hv_flag);
            return hv_flag;
        }
        #endregion

        public void Concat_Obj(ref HObject Obj1, ref HObject Obj2, ref HObject Obj3)
        {
            if (!Obj1.IsInitialized())
            {
                HOperatorSet.GenEmptyObj(out Obj1);
            }
            if (!Obj2.IsInitialized())
            {
                HOperatorSet.GenEmptyObj(out Obj2);
            }
            //             if (!(Obj1.IsInitialized()) || (Obj1.CountObj() < 1))
            //             {
            //                 HOperatorSet.CopyObj(Obj1,out Obj3,1,-1);
            //             }
            //             else
            {
                HOperatorSet.ConcatObj(Obj1, Obj2, out Obj3);
                HTuple Count = Obj3.CountObj();
            }
        }

        public bool ObjectValided(HObject Obj)
        {

            if (!Obj.IsInitialized())
            {
                return false;
            }
            if (Obj.CountObj() < 1)
            {
                return false;
            }
            return true;
        }

        #region 获取像素坐标
        public HTuple [] halconMouseMove(HTuple myhWindowHandle,HObject m_Image)
        {
            HTuple[] Hpoint = new HTuple[2];
            try
            {
                
                HOperatorSet.GetMposition(myhWindowHandle, out ptY, out ptX, out hv_Button);

                if (hv_Button == 0)
                {
                    Hpoint[0] = ptX;
                    Hpoint[1] = ptY;
                    

                }
                return Hpoint;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return Hpoint;
            }
        }
        #endregion

        #region 获取灰度值
        public HTuple GetGrayval(HObject m_Image)
        {
            HOperatorSet.GetGrayval(m_Image, ptY, ptX, out grayval);
            return grayval;
        }
        #endregion

        #region 保存模板句柄
        public void Write_Model(HTuple ModelID, string path)
        {
            //模板为空不保存
            if (ModelID == null)
            {
                return;
            }
            HOperatorSet.WriteShapeModel(ModelID, path);
        }
        #endregion

        #region 加载模板句柄
        public void Read_Model(out HTuple ModelID, string path)
        {
            if (!File.Exists(path))
            {
                ModelID = null;
                return;
            }
            HOperatorSet.ReadShapeModel(path, out ModelID);

        }
        #endregion

        #region 保存区域
        public void Write_Region(HObject Region, string path)
        {
            //区域不为空
            if (Region == null)
            {
                return;
            }
            HOperatorSet.WriteRegion(Region, path);
        }
        #endregion

        #region 加载区域
        public void Read_Region(out HObject Region, string path)
        {
            if (!File.Exists(path))
            {
                Region = null;
                return;
            }
            HOperatorSet.ReadRegion(out Region, path);
        }
        #endregion

        #region 保存测量句柄
        public void Write_MetrologyModel(HTuple MetrologyModel, string path)
        {
            //测量句柄不为空保存
            if (MetrologyModel == null)
            {
                return;
            }
            HOperatorSet.WriteMetrologyModel(MetrologyModel, path);
        }
        #endregion

        #region 加载测量句柄
        public void Read_MetrologyModel(out HTuple MetrologyModel, string path)
        {
            if (!File.Exists(path))
            {
                MetrologyModel = null;
                return;
            }
            HOperatorSet.ReadMetrologyModel(path, out MetrologyModel);
        }
        #endregion

        #region 保存Tuple
        public void Write_Tuple(HTuple Tuple, string path)
        {
            //Tuple为空 不保存
            if (Tuple == null)
            {
                return;
            }
            HOperatorSet.WriteTuple(Tuple, path);
        }
        #endregion

        #region 加载Tuple
        public void Read_Tuple(out HTuple Tuple, string path)
        {
            if (!File.Exists(path))
            {
                Tuple = null;
                return;
            }
            HOperatorSet.ReadTuple(path, out Tuple);
        }
        #endregion

        #region  字体设置和显示
        // Procedures 
        // External procedures 
        // Chapter: Graphics / Text
        // Short Description: This procedure writes a text message. 
        public void disp_message1(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
            HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
            HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
            HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
            HTuple hv_WidthWin = new HTuple(), hv_HeightWin = null;
            HTuple hv_MaxAscent = null, hv_MaxDescent = null, hv_MaxWidth = null;
            HTuple hv_MaxHeight = null, hv_R1 = new HTuple(), hv_C1 = new HTuple();
            HTuple hv_FactorRow = new HTuple(), hv_FactorColumn = new HTuple();
            HTuple hv_UseShadow = null, hv_ShadowColor = null, hv_Exception = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
            HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
            HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
            HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
            HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
            HTuple hv_CurrentColor = new HTuple();
            HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
            HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

            // Initialize local and output iconic variables 
            //This procedure displays text in a graphics window.
            //
            //Input parameters:
            //WindowHandle: The WindowHandle of the graphics window, where
            //   the message should be displayed
            //String: A tuple of strings containing the text message to be displayed
            //CoordSystem: If set to 'window', the text position is given
            //   with respect to the window coordinate system.
            //   If set to 'image', image coordinates are used.
            //   (This may be useful in zoomed images.)
            //Row: The row coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Column: The column coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Color: defines the color of the text as string.
            //   If set to [], '' or 'auto' the currently set color is used.
            //   If a tuple of strings is passed, the colors are used cyclically
            //   for each new textline.
            //Box: If Box[0] is set to 'true', the text is written within an orange box.
            //     If set to' false', no box is displayed.
            //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
            //       the text is written in a box of that color.
            //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
            //       'true' -> display a shadow in a default color
            //       'false' -> display no shadow (same as if no second value is given)
            //       otherwise -> use given string as color string for the shadow color
            //
            //Prepare window
            HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
            HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part,
                out hv_Row2Part, out hv_Column2Part);
            HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
                out hv_WidthWin, out hv_HeightWin);
            HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
            //
            //default settings
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
            {
                hv_Color_COPY_INP_TMP = "";
            }
            //
            hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
            //
            //Estimate extentions of text depending on font size.
            HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
                out hv_MaxWidth, out hv_MaxHeight);
            if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
            {
                hv_R1 = hv_Row_COPY_INP_TMP.Clone();
                hv_C1 = hv_Column_COPY_INP_TMP.Clone();
            }
            else
            {
                //Transform image to window coordinates
                hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
                hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
                hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
                hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
            }
            //
            //Display text box depending on text size
            hv_UseShadow = 1;
            hv_ShadowColor = "gray";
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
            {
                if (hv_Box_COPY_INP_TMP == null)
                    hv_Box_COPY_INP_TMP = new HTuple();
                hv_Box_COPY_INP_TMP[0] = "#fce9d4";
                hv_ShadowColor = "#f28d26";
            }
            if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
                1))) != 0)
            {
                if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
                {
                    //Use default ShadowColor set above
                }
                else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
                    "false"))) != 0)
                {
                    hv_UseShadow = 0;
                }
                else
                {
                    hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
                    //Valid color?
                    try
                    {
                        HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                            1));
                    }
                    // catch (Exception) 
                    catch (HalconException HDevExpDefaultException1)
                    {
                        HDevExpDefaultException1.ToHTuple(out hv_Exception);
                        hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
                        throw new HalconException(hv_Exception);
                    }
                }
            }
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
            {
                //Valid color?
                try
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                        0));
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
                    throw new HalconException(hv_Exception);
                }
                //Calculate box extents
                hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
                hv_Width = new HTuple();
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                        hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                    hv_Width = hv_Width.TupleConcat(hv_W);
                }
                hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    ));
                hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                hv_R2 = hv_R1 + hv_FrameHeight;
                hv_C2 = hv_C1 + hv_FrameWidth;
                //Display rectangles
                HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
                HOperatorSet.SetDraw(hv_WindowHandle, "fill");
                //Set shadow color
                HOperatorSet.SetColor(hv_WindowHandle, hv_ShadowColor);
                if ((int)(hv_UseShadow) != 0)
                {
                    HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1,
                        hv_C2 + 1);
                }
                //Set box color
                HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                    0));
                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
            }
            //Write text.
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                )) - 1); hv_Index = (int)hv_Index + 1)
            {
                hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                    )));
                if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                    "auto")))) != 0)
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
                }
                else
                {
                    HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
                }
                hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
                HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
                HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                    hv_Index));
            }
            //Reset changed window settings
            HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
            HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
                hv_Column2Part);

            return;
        }

        // Chapter: Graphics / Text
        // Short Description: Set font independent of OS 
        public void set_display_font(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font,
            HTuple hv_Bold, HTuple hv_Slant)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_OS = null, hv_BufferWindowHandle = new HTuple();
            HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Height = new HTuple();
            HTuple hv_Scale = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_SubFamily = new HTuple(), hv_Fonts = new HTuple();
            HTuple hv_SystemFonts = new HTuple(), hv_Guess = new HTuple();
            HTuple hv_I = new HTuple(), hv_Index = new HTuple(), hv_AllowedFontSizes = new HTuple();
            HTuple hv_Distances = new HTuple(), hv_Indices = new HTuple();
            HTuple hv_FontSelRegexp = new HTuple(), hv_FontsCourier = new HTuple();
            HTuple hv_Bold_COPY_INP_TMP = hv_Bold.Clone();
            HTuple hv_Font_COPY_INP_TMP = hv_Font.Clone();
            HTuple hv_Size_COPY_INP_TMP = hv_Size.Clone();
            HTuple hv_Slant_COPY_INP_TMP = hv_Slant.Clone();

            // Initialize local and output iconic variables 
            //This procedure sets the text font of the current window with
            //the specified attributes.
            //It is assumed that following fonts are installed on the system:
            //Windows: Courier New, Arial Times New Roman
            //Mac OS X: CourierNewPS, Arial, TimesNewRomanPS
            //Linux: courier, helvetica, times
            //Because fonts are displayed smaller on Linux than on Windows,
            //a scaling factor of 1.25 is used the get comparable results.
            //For Linux, only a limited number of font sizes is supported,
            //to get comparable results, it is recommended to use one of the
            //following sizes: 9, 11, 14, 16, 20, 27
            //(which will be mapped internally on Linux systems to 11, 14, 17, 20, 25, 34)
            //
            //Input parameters:
            //WindowHandle: The graphics window for which the font will be set
            //Size: The font size. If Size=-1, the default of 16 is used.
            //Bold: If set to 'true', a bold font is used
            //Slant: If set to 'true', a slanted font is used
            //
            HOperatorSet.GetSystem("operating_system", out hv_OS);
            // dev_get_preferences(...); only in hdevelop
            // dev_set_preferences(...); only in hdevelop
            if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
            {
                hv_Size_COPY_INP_TMP = 16;
            }
            if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
            {
                //Set font on Windows systems
                try
                {
                    //Check, if font scaling is switched on
                    //open_window(...);
                    HOperatorSet.SetFont(hv_WindowHandle, "-Consolas-16-*-0-*-*-1-");
                    HOperatorSet.GetStringExtents(hv_WindowHandle, "test_string", out hv_Ascent,
                        out hv_Descent, out hv_Width, out hv_Height);
                    //Expected width is 110
                    hv_Scale = 110.0 / hv_Width;
                    hv_Size_COPY_INP_TMP = ((hv_Size_COPY_INP_TMP * hv_Scale)).TupleInt();
                    //close_window(...);
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    //throw (Exception)
                }
                if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))).TupleOr(
                    new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Courier New";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Consolas";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Arial";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Times New Roman";
                }
                if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = 1;
                }
                else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = 0;
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = 1;
                }
                else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = 0;
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                try
                {
                    HOperatorSet.SetFont(hv_WindowHandle, ((((((("-" + hv_Font_COPY_INP_TMP) + "-") + hv_Size_COPY_INP_TMP) + "-*-") + hv_Slant_COPY_INP_TMP) + "-*-*-") + hv_Bold_COPY_INP_TMP) + "-");
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    //throw (Exception)
                }
            }
            else if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Dar"))) != 0)
            {
                //Set font on Mac OS X systems. Since OS X does not have a strict naming
                //scheme for font attributes, we use tables to determine the correct font
                //name.
                hv_SubFamily = 0;
                if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_SubFamily = hv_SubFamily.TupleBor(1);
                }
                else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_SubFamily = hv_SubFamily.TupleBor(2);
                }
                else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Menlo-Regular";
                    hv_Fonts[1] = "Menlo-Italic";
                    hv_Fonts[2] = "Menlo-Bold";
                    hv_Fonts[3] = "Menlo-BoldItalic";
                }
                else if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))).TupleOr(
                    new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "CourierNewPSMT";
                    hv_Fonts[1] = "CourierNewPS-ItalicMT";
                    hv_Fonts[2] = "CourierNewPS-BoldMT";
                    hv_Fonts[3] = "CourierNewPS-BoldItalicMT";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "ArialMT";
                    hv_Fonts[1] = "Arial-ItalicMT";
                    hv_Fonts[2] = "Arial-BoldMT";
                    hv_Fonts[3] = "Arial-BoldItalicMT";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "TimesNewRomanPSMT";
                    hv_Fonts[1] = "TimesNewRomanPS-ItalicMT";
                    hv_Fonts[2] = "TimesNewRomanPS-BoldMT";
                    hv_Fonts[3] = "TimesNewRomanPS-BoldItalicMT";
                }
                else
                {
                    //Attempt to figure out which of the fonts installed on the system
                    //the user could have meant.
                    HOperatorSet.QueryFont(hv_WindowHandle, out hv_SystemFonts);
                    hv_Fonts = new HTuple();
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Regular");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "MT");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[0] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                    //Guess name of slanted font
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Italic");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-ItalicMT");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Oblique");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[1] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                    //Guess name of bold font
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Bold");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldMT");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[2] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                    //Guess name of bold slanted font
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldItalic");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldItalicMT");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldOblique");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[3] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                }
                hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(hv_SubFamily);
                try
                {
                    HOperatorSet.SetFont(hv_WindowHandle, (hv_Font_COPY_INP_TMP + "-") + hv_Size_COPY_INP_TMP);
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    //throw (Exception)
                }
            }
            else
            {
                //Set font for UNIX systems
                hv_Size_COPY_INP_TMP = hv_Size_COPY_INP_TMP * 1.25;
                hv_AllowedFontSizes = new HTuple();
                hv_AllowedFontSizes[0] = 11;
                hv_AllowedFontSizes[1] = 14;
                hv_AllowedFontSizes[2] = 17;
                hv_AllowedFontSizes[3] = 20;
                hv_AllowedFontSizes[4] = 25;
                hv_AllowedFontSizes[5] = 34;
                if ((int)(new HTuple(((hv_AllowedFontSizes.TupleFind(hv_Size_COPY_INP_TMP))).TupleEqual(
                    -1))) != 0)
                {
                    hv_Distances = ((hv_AllowedFontSizes - hv_Size_COPY_INP_TMP)).TupleAbs();
                    HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                    hv_Size_COPY_INP_TMP = hv_AllowedFontSizes.TupleSelect(hv_Indices.TupleSelect(
                        0));
                }
                if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))).TupleOr(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(
                    "Courier")))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "courier";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "helvetica";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "times";
                }
                if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = "bold";
                }
                else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = "medium";
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("times"))) != 0)
                    {
                        hv_Slant_COPY_INP_TMP = "i";
                    }
                    else
                    {
                        hv_Slant_COPY_INP_TMP = "o";
                    }
                }
                else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = "r";
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                try
                {
                    HOperatorSet.SetFont(hv_WindowHandle, ((((((("-adobe-" + hv_Font_COPY_INP_TMP) + "-") + hv_Bold_COPY_INP_TMP) + "-") + hv_Slant_COPY_INP_TMP) + "-normal-*-") + hv_Size_COPY_INP_TMP) + "-*-*-*-*-*-*-*");
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    if ((int)((new HTuple(((hv_OS.TupleSubstr(0, 4))).TupleEqual("Linux"))).TupleAnd(
                        new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
                    {
                        HOperatorSet.QueryFont(hv_WindowHandle, out hv_Fonts);
                        hv_FontSelRegexp = (("^-[^-]*-[^-]*[Cc]ourier[^-]*-" + hv_Bold_COPY_INP_TMP) + "-") + hv_Slant_COPY_INP_TMP;
                        hv_FontsCourier = ((hv_Fonts.TupleRegexpSelect(hv_FontSelRegexp))).TupleRegexpMatch(
                            hv_FontSelRegexp);
                        if ((int)(new HTuple((new HTuple(hv_FontsCourier.TupleLength())).TupleEqual(
                            0))) != 0)
                        {
                            hv_Exception = "Wrong font name";
                            //throw (Exception)
                        }
                        else
                        {
                            try
                            {
                                HOperatorSet.SetFont(hv_WindowHandle, (((hv_FontsCourier.TupleSelect(
                                    0)) + "-normal-*-") + hv_Size_COPY_INP_TMP) + "-*-*-*-*-*-*-*");
                            }
                            // catch (Exception) 
                            catch (HalconException HDevExpDefaultException2)
                            {
                                HDevExpDefaultException2.ToHTuple(out hv_Exception);
                                //throw (Exception)
                            }
                        }
                    }
                    //throw (Exception)
                }
            }
            // dev_set_preferences(...); only in hdevelop

            return;
        }
        #endregion

        #region 图片保存
        public void SaveImage(HTuple halcon_windows, int index)
        {
            try
            {
                string strPath = "D:\\AllImage\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                DirectoryInfo dirInfo1 = new DirectoryInfo("D:\\AllImage\\");
                if (!dirInfo1.Exists)
                {
                    dirInfo1.Create();
                }
                DirectoryInfo dirInfo = new DirectoryInfo(strPath);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                if (index == 1)
                {
                    string strPath1 = "D:\\AllImage\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + "Left" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff") + ".png";
                    HObject ho_image = new HObject();
                    HOperatorSet.DumpWindowImage(out ho_image, halcon_windows);
                    HOperatorSet.WriteImage(ho_image, "png", 0, strPath1);
                }
                if (index == 2)
                {
                    string strPath1 = "D:\\AllImage\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + "Right" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff") + ".png";
                    HObject ho_image = new HObject();
                    HOperatorSet.DumpWindowImage(out ho_image, halcon_windows);
                    HOperatorSet.WriteImage(ho_image, "png", 0, strPath1);
                }
            }
            catch
            {

            }

        }
        public void SaveImageNG(HTuple halcon_windows, int index)
        {
            try
            {
                //string strPath = "D:\\NGImage\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".tif";
                DirectoryInfo dirInfo1 = new DirectoryInfo("D:\\NGImage\\");
                if (!dirInfo1.Exists)
                {
                    dirInfo1.Create();
                }
                if (index == 1)
                {
                    string strPath = "D:\\NGImage\\" + "Left" + DateTime.Now.ToString("yyyy-MM-dd") + ".png";
                    HObject ho_image = new HObject();
                    HOperatorSet.DumpWindowImage(out ho_image, halcon_windows);
                    HOperatorSet.WriteImage(ho_image, "png", 0, strPath);
                }
                if (index == 2)
                {
                    string strPath = "D:\\NGImage\\" + "Right" + DateTime.Now.ToString("yyyy-MM-dd") + ".png";
                    HObject ho_image = new HObject();
                    HOperatorSet.DumpWindowImage(out ho_image, halcon_windows);
                    HOperatorSet.WriteImage(ho_image, "png", 0, strPath);
                }
            }
            catch
            {

            }

        }
        #endregion

    }
}
