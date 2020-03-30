using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace HalconImageOperation
{
    public class CalibClass
    {
        HTuple hv_WindowHandle = new HTuple();
        HTuple hv_Row = new HTuple();
        HTuple hv_Column = new HTuple(), hv_Radius = new HTuple();
        HTuple hv_Row1 = new HTuple(), hv_Column1 = new HTuple();
        HTuple hv_Radius1 = null, hv_StartPhi = null, hv_EndPhi = null;
        HTuple hv_PointOrder = null;

        HObject ho_Circle = null, ho_ImageReduced = null;
        HObject ho_Regions = null, ho_RegionClosing = null, ho_Contours = null;

        public double[] Calib(HObject ho_Image,HTuple hv_ExpDefaultWinHandle)
        {
            double[] fitCircleResult = new double[3];
            HOperatorSet.GenCircle(out ho_Circle, hv_Row, hv_Column, hv_Radius);

            HOperatorSet.ReduceDomain(ho_Image, ho_Circle, out ho_ImageReduced);

            HOperatorSet.Threshold(ho_ImageReduced, out ho_Regions, 37, 237);

            HOperatorSet.ClosingCircle(ho_Regions, out ho_RegionClosing, 3.5);

            HOperatorSet.GenContourRegionXld(ho_RegionClosing, out ho_Contours, "border");
            HOperatorSet.FitCircleContourXld(ho_Contours, "algebraic", -1, 0, 0, 3, 2,
                out hv_Row1, out hv_Column1, out hv_Radius1, out hv_StartPhi, out hv_EndPhi,
                out hv_PointOrder);
            fitCircleResult[0] = hv_Row1;
            fitCircleResult[1] = hv_Column1;
            fitCircleResult[2] = hv_Radius1;
            HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "red");
            HOperatorSet.DispObj(ho_Contours, hv_ExpDefaultWinHandle);
            return fitCircleResult;
        }
    }
}
