using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using FileOperation;

namespace HalconImageOperation
{
    public class NewCalipProcessing
    {

        
        /// <summary>
        /// 万能卡尺测量直线
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="hv_halconWindows"></param>
        /// <param name="DrawIndex"></param>
        /// <param name="ho_width"></param>
        /// <param name="ho_height"></param>
        public void CaliperFindLine(HObject ho_Image, HTuple hv_halconWindows, int DrawIndex, HTuple ho_width, HTuple ho_height,HTuple measure_transition,
            HTuple num_measures, HTuple num_instances, HTuple measure_sigma, HTuple measure_length1, HTuple measure_length2, HTuple measure_threshold,
             HTuple measure_interpolation, HTuple measure_select, HTuple min_score,HTuple mhv_Row1, HTuple mhv_Column1, HTuple mhv_Row2, HTuple mhv_Column2)
        {

            HObject ho_Contours = null, ho_Cross = null;
            HObject ho_Contour = null;


            HTuple hv_WindowHandle = new HTuple();
            //HTuple hv_Row1 = null, hv_Column1 = null, hv_Row2 = null;
            HTuple /*hv_Column2 = null, */hv_shapeParam = null, hv_MetrologyHandle = null;
            HTuple hv_Index = null, hv_Row = new HTuple();
            HTuple hv_Column = new HTuple(), hv_Parameter = new HTuple();
            // Initialize local and output iconic variables 
            //HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_Contours);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_Contour);



            try
            {
                HOperatorSet.SetColor(hv_halconWindows, "green");
                hv_shapeParam = new HTuple();
                hv_shapeParam = hv_shapeParam.TupleConcat(mhv_Row1);
                hv_shapeParam = hv_shapeParam.TupleConcat(mhv_Column1);
                hv_shapeParam = hv_shapeParam.TupleConcat(mhv_Row2);
                hv_shapeParam = hv_shapeParam.TupleConcat(mhv_Column2);

                //创建句柄
                HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, ho_width, ho_height);

                //添加线模型
                HOperatorSet.AddMetrologyObjectLineMeasure(hv_MetrologyHandle, mhv_Row1, mhv_Column1,
                     mhv_Row2, mhv_Column2, measure_length1, measure_length2, measure_sigma, measure_threshold, new HTuple(), new HTuple(), out hv_Index);


                //HOperatorSet.AddMetrologyObjectGeneric(hv_MetrologyHandle, "line", hv_shapeParam,
                //    mhv_Row1, mhv_Column1, mhv_Row2, mhv_Column2, new HTuple(), new HTuple(), out hv_Index);

                //HTuple measure_transition = combmeasure_transition.Text;
                //HTuple num_measures = int.Parse(textnum_measures.Text);
                //HTuple num_instances = int.Parse(textnum_instances.Text);
                //HTuple measure_sigma = int.Parse(textmeasure_sigma.Text);
                //HTuple measure_length1 = double.Parse(textmeasure_length1.Text);
                //HTuple measure_length2 = double.Parse(textmeasure_length2.Text);
                //HTuple measure_threshold = int.Parse(textmeasure_threshold.Text);
                //HTuple measure_interpolation = combmeasure_interpolation.Text;
                //HTuple measure_select = combmeasure_select.Text;
                //HTuple min_score = double.Parse(textmin_score.Text);

                //设置参数，这里根据自己需求设置，这一坨用的都是同一个算子
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_transition",
                   measure_transition);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "num_measures",
                    num_measures);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "num_instances",
                    num_instances);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_sigma",
                    measure_sigma);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_length1",
                    measure_length1);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_length2",
                    measure_length2);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_threshold",
                    measure_threshold);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_interpolation",
                    measure_interpolation);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_select",
                    measure_select);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "min_score",
                    min_score);

                switch (DrawIndex)
                {
                    case 1:
                        Intermediate.caliperFinds.hv_Row11 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column11 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row21 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column21 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition1 = measure_transition;
                        Intermediate.caliperFinds.num_measures1 = num_measures;
                        Intermediate.caliperFinds.num_instances1 = num_instances;
                        Intermediate.caliperFinds.measure_sigma1 = measure_sigma;
                        Intermediate.caliperFinds.measure_length11 = measure_length1;
                        Intermediate.caliperFinds.measure_length21 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold1 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation1 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select1 = measure_select;
                        Intermediate.caliperFinds.min_score1 = min_score;
                        break;
                    case 2:
                        Intermediate.caliperFinds.hv_Row12 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column12 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row22 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column22 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition2 = measure_transition;
                        Intermediate.caliperFinds.num_measures2 = num_measures;
                        Intermediate.caliperFinds.num_instances2 = num_instances;
                        Intermediate.caliperFinds.measure_sigma2 = measure_sigma;
                        Intermediate.caliperFinds.measure_length12 = measure_length1;
                        Intermediate.caliperFinds.measure_length22 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold2 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation2 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select2 = measure_select;
                        Intermediate.caliperFinds.min_score2 = min_score;
                        break;
                    case 3:
                        Intermediate.caliperFinds.hv_Row13 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column13 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row23 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column23 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition3 = measure_transition;
                        Intermediate.caliperFinds.num_measures3 = num_measures;
                        Intermediate.caliperFinds.num_instances3 = num_instances;
                        Intermediate.caliperFinds.measure_sigma3 = measure_sigma;
                        Intermediate.caliperFinds.measure_length13 = measure_length1;
                        Intermediate.caliperFinds.measure_length23 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold3 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation3 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select3 = measure_select;
                        Intermediate.caliperFinds.min_score3 = min_score;
                        break;
                    case 4:
                        Intermediate.caliperFinds.hv_Row14 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column14 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row24 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column24 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition4 = measure_transition;
                        Intermediate.caliperFinds.num_measures4 = num_measures;
                        Intermediate.caliperFinds.num_instances4 = num_instances;
                        Intermediate.caliperFinds.measure_sigma4 = measure_sigma;
                        Intermediate.caliperFinds.measure_length14 = measure_length1;
                        Intermediate.caliperFinds.measure_length24 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold4 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation4 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select4 = measure_select;
                        Intermediate.caliperFinds.min_score4 = min_score;
                        break;
                    case 5:
                        Intermediate.caliperFinds.hv_Row15 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column15 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row25 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column25 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition5 = measure_transition;
                        Intermediate.caliperFinds.num_measures5 = num_measures;
                        Intermediate.caliperFinds.num_instances5 = num_instances;
                        Intermediate.caliperFinds.measure_sigma5 = measure_sigma;
                        Intermediate.caliperFinds.measure_length15 = measure_length1;
                        Intermediate.caliperFinds.measure_length25 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold5 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation5 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select5 = measure_select;
                        Intermediate.caliperFinds.min_score5 = min_score;
                        break;
                    case 6:
                        Intermediate.caliperFinds.hv_Row16 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column16 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row26 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column26 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition6 = measure_transition;
                        Intermediate.caliperFinds.num_measures6 = num_measures;
                        Intermediate.caliperFinds.num_instances6 = num_instances;
                        Intermediate.caliperFinds.measure_sigma6 = measure_sigma;
                        Intermediate.caliperFinds.measure_length16 = measure_length1;
                        Intermediate.caliperFinds.measure_length26 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold6 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation6 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select6 = measure_select;
                        Intermediate.caliperFinds.min_score6 = min_score;
                        break;
                    case 7:
                        Intermediate.caliperFinds.hv_Row17 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column17 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row27 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column27 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition7 = measure_transition;
                        Intermediate.caliperFinds.num_measures7 = num_measures;
                        Intermediate.caliperFinds.num_instances7 = num_instances;
                        Intermediate.caliperFinds.measure_sigma7 = measure_sigma;
                        Intermediate.caliperFinds.measure_length17 = measure_length1;
                        Intermediate.caliperFinds.measure_length27 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold7 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation7 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select7 = measure_select;
                        Intermediate.caliperFinds.min_score7 = min_score;
                        break;
                    case 8:
                        Intermediate.caliperFinds.hv_Row18 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column18 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row28 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column28 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition8 = measure_transition;
                        Intermediate.caliperFinds.num_measures8 = num_measures;
                        Intermediate.caliperFinds.num_instances8 = num_instances;
                        Intermediate.caliperFinds.measure_sigma8 = measure_sigma;
                        Intermediate.caliperFinds.measure_length18 = measure_length1;
                        Intermediate.caliperFinds.measure_length28 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold8 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation8 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select8 = measure_select;
                        Intermediate.caliperFinds.min_score8 = min_score;
                        break;
                    case 9:
                        Intermediate.caliperFinds.hv_Row19 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column19 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row29 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column29 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition9 = measure_transition;
                        Intermediate.caliperFinds.num_measures9 = num_measures;
                        Intermediate.caliperFinds.num_instances9 = num_instances;
                        Intermediate.caliperFinds.measure_sigma9 = measure_sigma;
                        Intermediate.caliperFinds.measure_length19 = measure_length1;
                        Intermediate.caliperFinds.measure_length29 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold9 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation9 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select9 = measure_select;
                        Intermediate.caliperFinds.min_score9 = min_score;
                        break;
                    case 10:
                        Intermediate.caliperFinds.hv_Row110 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column110 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row210 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column210 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition10 = measure_transition;
                        Intermediate.caliperFinds.num_measures10 = num_measures;
                        Intermediate.caliperFinds.num_instances10 = num_instances;
                        Intermediate.caliperFinds.measure_sigma10 = measure_sigma;
                        Intermediate.caliperFinds.measure_length110 = measure_length1;
                        Intermediate.caliperFinds.measure_length210 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold10 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation10 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select10 = measure_select;
                        Intermediate.caliperFinds.min_score10 = min_score;
                        break;
                    case 11:
                        Intermediate.caliperFinds.hv_Row111 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column111 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row211 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column211 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition11 = measure_transition;
                        Intermediate.caliperFinds.num_measures11 = num_measures;
                        Intermediate.caliperFinds.num_instances11 = num_instances;
                        Intermediate.caliperFinds.measure_sigma11 = measure_sigma;
                        Intermediate.caliperFinds.measure_length111 = measure_length1;
                        Intermediate.caliperFinds.measure_length211 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold11 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation11 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select11 = measure_select;
                        Intermediate.caliperFinds.min_score11 = min_score;
                        break;
                    case 12:
                        Intermediate.caliperFinds.hv_Row112 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column112 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row212 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column212 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition12 = measure_transition;
                        Intermediate.caliperFinds.num_measures12 = num_measures;
                        Intermediate.caliperFinds.num_instances12 = num_instances;
                        Intermediate.caliperFinds.measure_sigma12 = measure_sigma;
                        Intermediate.caliperFinds.measure_length112 = measure_length1;
                        Intermediate.caliperFinds.measure_length212 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold12 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation12 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select12 = measure_select;
                        Intermediate.caliperFinds.min_score12 = min_score;
                        break;
                    case 13:
                        Intermediate.caliperFinds.hv_Row113 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column113 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row213 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column213 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition13 = measure_transition;
                        Intermediate.caliperFinds.num_measures13 = num_measures;
                        Intermediate.caliperFinds.num_instances13 = num_instances;
                        Intermediate.caliperFinds.measure_sigma13 = measure_sigma;
                        Intermediate.caliperFinds.measure_length113 = measure_length1;
                        Intermediate.caliperFinds.measure_length213 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold13 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation13 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select13 = measure_select;
                        Intermediate.caliperFinds.min_score13 = min_score;
                        break;
                    case 14:
                        Intermediate.caliperFinds.hv_Row114 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column114 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row214 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column214 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition14 = measure_transition;
                        Intermediate.caliperFinds.num_measures14 = num_measures;
                        Intermediate.caliperFinds.num_instances14 = num_instances;
                        Intermediate.caliperFinds.measure_sigma14 = measure_sigma;
                        Intermediate.caliperFinds.measure_length114 = measure_length1;
                        Intermediate.caliperFinds.measure_length214 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold14 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation14 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select14 = measure_select;
                        Intermediate.caliperFinds.min_score14 = min_score;
                        break;
                    case 15:
                        Intermediate.caliperFinds.hv_Row115 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column115 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row215 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column215 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition15 = measure_transition;
                        Intermediate.caliperFinds.num_measures15 = num_measures;
                        Intermediate.caliperFinds.num_instances15 = num_instances;
                        Intermediate.caliperFinds.measure_sigma15 = measure_sigma;
                        Intermediate.caliperFinds.measure_length115 = measure_length1;
                        Intermediate.caliperFinds.measure_length215 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold15 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation15 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select15 = measure_select;
                        Intermediate.caliperFinds.min_score15 = min_score;
                        break;
                    case 16:
                        Intermediate.caliperFinds.hv_Row116 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column116 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row216 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column216 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition16 = measure_transition;
                        Intermediate.caliperFinds.num_measures16 = num_measures;
                        Intermediate.caliperFinds.num_instances16 = num_instances;
                        Intermediate.caliperFinds.measure_sigma16 = measure_sigma;
                        Intermediate.caliperFinds.measure_length116 = measure_length1;
                        Intermediate.caliperFinds.measure_length216 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold16 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation16 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select16 = measure_select;
                        Intermediate.caliperFinds.min_score16 = min_score;
                        break;
                    case 17:
                        Intermediate.caliperFinds.hv_Row117 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column117 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row217 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column217 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition17 = measure_transition;
                        Intermediate.caliperFinds.num_measures17 = num_measures;
                        Intermediate.caliperFinds.num_instances17 = num_instances;
                        Intermediate.caliperFinds.measure_sigma17 = measure_sigma;
                        Intermediate.caliperFinds.measure_length117 = measure_length1;
                        Intermediate.caliperFinds.measure_length217 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold17 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation17 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select17 = measure_select;
                        Intermediate.caliperFinds.min_score17 = min_score;
                        break;
                    case 18:
                        Intermediate.caliperFinds.hv_Row118 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column118 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row218 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column218 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition18 = measure_transition;
                        Intermediate.caliperFinds.num_measures18 = num_measures;
                        Intermediate.caliperFinds.num_instances18 = num_instances;
                        Intermediate.caliperFinds.measure_sigma18 = measure_sigma;
                        Intermediate.caliperFinds.measure_length118 = measure_length1;
                        Intermediate.caliperFinds.measure_length218 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold18 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation18 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select18 = measure_select;
                        Intermediate.caliperFinds.min_score18 = min_score;
                        break;
                    case 19:
                        Intermediate.caliperFinds.hv_Row119 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column119 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row219 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column219 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition19 = measure_transition;
                        Intermediate.caliperFinds.num_measures19 = num_measures;
                        Intermediate.caliperFinds.num_instances19 = num_instances;
                        Intermediate.caliperFinds.measure_sigma19 = measure_sigma;
                        Intermediate.caliperFinds.measure_length119 = measure_length1;
                        Intermediate.caliperFinds.measure_length219 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold19 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation19 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select19 = measure_select;
                        Intermediate.caliperFinds.min_score19 = min_score;
                        break;
                    case 20:
                        Intermediate.caliperFinds.hv_Row120 = mhv_Row1;
                        Intermediate.caliperFinds.hv_Column120 = mhv_Column1;
                        Intermediate.caliperFinds.hv_Row220 = mhv_Row2;
                        Intermediate.caliperFinds.hv_Column220 = mhv_Column2;
                        Intermediate.caliperFinds.measure_transition20 = measure_transition;
                        Intermediate.caliperFinds.num_measures20 = num_measures;
                        Intermediate.caliperFinds.num_instances20 = num_instances;
                        Intermediate.caliperFinds.measure_sigma20 = measure_sigma;
                        Intermediate.caliperFinds.measure_length120 = measure_length1;
                        Intermediate.caliperFinds.measure_length220 = measure_length2;
                        Intermediate.caliperFinds.measure_threshold20 = measure_threshold;
                        Intermediate.caliperFinds.measure_interpolation20 = measure_interpolation;
                        Intermediate.caliperFinds.measure_select20 = measure_select;
                        Intermediate.caliperFinds.min_score20 = min_score;
                        break;
                }
                //开始找边缘，顺便把边缘上卡尺找到的所有点坐标输出在ROW,Column里面（数组形式）
                HOperatorSet.ApplyMetrologyModel(ho_Image, hv_MetrologyHandle);
                ho_Contours.Dispose();
                HOperatorSet.GetMetrologyObjectMeasures(out ho_Contours, hv_MetrologyHandle,
                    "all", "all", out hv_Row, out hv_Column);

                //把点显示出来
                ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row, hv_Column, 6, 0.785398);

                //得到线的起点和终点坐标并显示出来
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, "all", "all", "result_type",
                    "all_param", out hv_Parameter);
                ho_Contour.Dispose();
                HOperatorSet.GetMetrologyObjectResultContour(out ho_Contour, hv_MetrologyHandle,
                    "all", "all", 1.5);

                //HOperatorSet.WriteTuple(hv_MetrologyHandle, "D:\\FindLineModel\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".tuple");


                //释放测量句柄
                HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);

                HOperatorSet.DispObj(ho_Cross, hv_halconWindows);
                HOperatorSet.DispObj(ho_Contours, hv_halconWindows);
                HOperatorSet.SetColor(hv_halconWindows, "red");
                HOperatorSet.DispObj(ho_Contour, hv_halconWindows);
            }
            catch (Exception ee)
            {

            }

        //    HOperatorSet.DrawLine(hv_halconWindows, out hv_Row1, out hv_Column1, out hv_Row2,
        //out hv_Column2);



          
        }


        /// <summary>
        /// 万能卡尺找直线
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="hv_halconWindows"></param>
        /// <param name="DrawIndex"></param>
        /// <param name="ho_width"></param>
        /// <param name="ho_height"></param>
        /// <returns></returns>
        public void FindLines(HObject ho_Image, HTuple hv_halconWindows, int DrawIndex, HTuple ho_width, HTuple ho_height,
            out HTuple hv_RowBegin,out HTuple hv_ColBegin,out HTuple hv_RowEnd,out HTuple hv_ColEnd)
        {


            HObject ho_Contours = null, ho_Cross = null;
            HObject ho_Contour = null;

            HObject ho_SortedContours = new HObject();
            HTuple hv_Nr = new HTuple();
            HTuple hv_Nc = new HTuple(), hv_Dist = new HTuple();

            HTuple hv_WindowHandle = new HTuple();
            HTuple hv_Row1 = null, hv_Column1 = null, hv_Row2 = null;
            HTuple hv_Column2 = null, hv_shapeParam = null, hv_MetrologyHandle = null;
            HTuple hv_Index = null, hv_Row = new HTuple();
            HTuple hv_Column = new HTuple(), hv_Parameter = new HTuple();

            //HTuple hv_RowBegin = new HTuple();
            //HTuple hv_ColBegin = new HTuple(), hv_RowEnd = new HTuple();
            //HTuple hv_ColEnd = new HTuple();

            HTuple measure_transition = null;
            HTuple num_measures = null;
            HTuple num_instances = null;
            HTuple measure_sigma = null;
            HTuple measure_length1 = null;
            HTuple measure_length2 = null;
            HTuple measure_threshold = null;
            HTuple measure_interpolation = null;
            HTuple measure_select = null;
            HTuple min_score = null;


            // Initialize local and output iconic variables 
            //HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_Contours);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_Contour);

            try
            {

                #region
                //string strFileName = "";

                //OpenFileDialog ofd = new OpenFileDialog();

                //ofd.Filter = "标定文件(*.tuple;*.tuple)|*.tuple;*.tuple|word文档(*.doc;*.docx)|*.doc;*.docx|所有文件|*.*";

                //ofd.ValidateNames = true; // 验证用户输入是否是一个有效的Windows文件名

                //ofd.CheckFileExists = true; //验证路径的有效性

                //ofd.CheckPathExists = true;//验证路径的有效性

                //if (ofd.ShowDialog() == DialogResult.OK) //用户点击确认按钮，发送确认消息
                //{
                //    strFileName = ofd.FileName;//获取在文件对话框中选定的路径或者字符串
                //    HOperatorSet.ReadTuple(strFileName, out hv_MetrologyHandle);
                //}
                #endregion


                switch (DrawIndex)
                {
                    case 1:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row11;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column11;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row21;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column21;
                        measure_transition = Intermediate.caliperFinds.measure_transition1;
                        num_measures = Intermediate.caliperFinds.num_measures1;
                        num_instances = Intermediate.caliperFinds.num_instances1;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma1;
                        measure_length1 = Intermediate.caliperFinds.measure_length11;
                        measure_length2 = Intermediate.caliperFinds.measure_length21;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold1;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation1;
                        measure_select = Intermediate.caliperFinds.measure_select1;
                        min_score = Intermediate.caliperFinds.min_score1;
                        break;
                    case 2:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row12;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column12;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row22;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column22;
                        measure_transition = Intermediate.caliperFinds.measure_transition2;
                        num_measures = Intermediate.caliperFinds.num_measures2;
                        num_instances = Intermediate.caliperFinds.num_instances2;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma2;
                        measure_length1 = Intermediate.caliperFinds.measure_length12;
                        measure_length2 = Intermediate.caliperFinds.measure_length22;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold2;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation2;
                        measure_select = Intermediate.caliperFinds.measure_select2;
                        min_score = Intermediate.caliperFinds.min_score2;
                        break;
                    case 3:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row13;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column13;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row23;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column23;
                        measure_transition = Intermediate.caliperFinds.measure_transition3;
                        num_measures = Intermediate.caliperFinds.num_measures3;
                        num_instances = Intermediate.caliperFinds.num_instances3;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma3;
                        measure_length1 = Intermediate.caliperFinds.measure_length13;
                        measure_length2 = Intermediate.caliperFinds.measure_length23;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold3;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation3;
                        measure_select = Intermediate.caliperFinds.measure_select3;
                        min_score = Intermediate.caliperFinds.min_score3;
                        break;
                    case 4:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row14;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column14;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row24;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column24;
                        measure_transition = Intermediate.caliperFinds.measure_transition4;
                        num_measures = Intermediate.caliperFinds.num_measures4;
                        num_instances = Intermediate.caliperFinds.num_instances4;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma4;
                        measure_length1 = Intermediate.caliperFinds.measure_length14;
                        measure_length2 = Intermediate.caliperFinds.measure_length24;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold4;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation4;
                        measure_select = Intermediate.caliperFinds.measure_select4;
                        min_score = Intermediate.caliperFinds.min_score4;
                        break;
                    case 5:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row15;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column15;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row25;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column25;
                        measure_transition = Intermediate.caliperFinds.measure_transition5;
                        num_measures = Intermediate.caliperFinds.num_measures5;
                        num_instances = Intermediate.caliperFinds.num_instances5;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma5;
                        measure_length1 = Intermediate.caliperFinds.measure_length15;
                        measure_length2 = Intermediate.caliperFinds.measure_length25;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold5;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation5;
                        measure_select = Intermediate.caliperFinds.measure_select5;
                        min_score = Intermediate.caliperFinds.min_score5;
                        break;
                    case 6:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row16;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column16;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row26;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column26;
                        measure_transition = Intermediate.caliperFinds.measure_transition6;
                        num_measures = Intermediate.caliperFinds.num_measures6;
                        num_instances = Intermediate.caliperFinds.num_instances6;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma6;
                        measure_length1 = Intermediate.caliperFinds.measure_length16;
                        measure_length2 = Intermediate.caliperFinds.measure_length26;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold6;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation6;
                        measure_select = Intermediate.caliperFinds.measure_select6;
                        min_score = Intermediate.caliperFinds.min_score6;
                        break;
                    case 7:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row17;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column17;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row27;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column27;
                        measure_transition = Intermediate.caliperFinds.measure_transition7;
                        num_measures = Intermediate.caliperFinds.num_measures7;
                        num_instances = Intermediate.caliperFinds.num_instances7;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma7;
                        measure_length1 = Intermediate.caliperFinds.measure_length17;
                        measure_length2 = Intermediate.caliperFinds.measure_length27;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold7;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation7;
                        measure_select = Intermediate.caliperFinds.measure_select7;
                        min_score = Intermediate.caliperFinds.min_score7;
                        break;
                    case 8:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row18;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column18;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row28;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column28;
                        measure_transition = Intermediate.caliperFinds.measure_transition8;
                        num_measures = Intermediate.caliperFinds.num_measures8;
                        num_instances = Intermediate.caliperFinds.num_instances8;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma8;
                        measure_length1 = Intermediate.caliperFinds.measure_length18;
                        measure_length2 = Intermediate.caliperFinds.measure_length28;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold8;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation8;
                        measure_select = Intermediate.caliperFinds.measure_select8;
                        min_score = Intermediate.caliperFinds.min_score8;
                        break;
                    case 9:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row19;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column19;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row29;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column29;
                        measure_transition = Intermediate.caliperFinds.measure_transition9;
                        num_measures = Intermediate.caliperFinds.num_measures9;
                        num_instances = Intermediate.caliperFinds.num_instances9;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma9;
                        measure_length1 = Intermediate.caliperFinds.measure_length19;
                        measure_length2 = Intermediate.caliperFinds.measure_length29;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold9;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation9;
                        measure_select = Intermediate.caliperFinds.measure_select9;
                        min_score = Intermediate.caliperFinds.min_score9;
                        break;
                    case 10:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row110;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column110;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row210;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column210;
                        measure_transition = Intermediate.caliperFinds.measure_transition10;
                        num_measures = Intermediate.caliperFinds.num_measures10;
                        num_instances = Intermediate.caliperFinds.num_instances10;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma10;
                        measure_length1 = Intermediate.caliperFinds.measure_length110;
                        measure_length2 = Intermediate.caliperFinds.measure_length210;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold10;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation10;
                        measure_select = Intermediate.caliperFinds.measure_select10;
                        min_score = Intermediate.caliperFinds.min_score10;
                        break;
                    case 11:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row111;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column111;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row211;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column211;
                        measure_transition = Intermediate.caliperFinds.measure_transition11;
                        num_measures = Intermediate.caliperFinds.num_measures11;
                        num_instances = Intermediate.caliperFinds.num_instances11;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma11;
                        measure_length1 = Intermediate.caliperFinds.measure_length111;
                        measure_length2 = Intermediate.caliperFinds.measure_length211;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold11;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation11;
                        measure_select = Intermediate.caliperFinds.measure_select11;
                        min_score = Intermediate.caliperFinds.min_score11;
                        break;
                    case 12:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row112;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column112;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row212;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column212;
                        measure_transition = Intermediate.caliperFinds.measure_transition12;
                        num_measures = Intermediate.caliperFinds.num_measures12;
                        num_instances = Intermediate.caliperFinds.num_instances12;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma12;
                        measure_length1 = Intermediate.caliperFinds.measure_length112;
                        measure_length2 = Intermediate.caliperFinds.measure_length212;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold12;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation12;
                        measure_select = Intermediate.caliperFinds.measure_select12;
                        min_score = Intermediate.caliperFinds.min_score12;
                        break;
                    case 13:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row113;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column113;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row213;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column213;
                        measure_transition = Intermediate.caliperFinds.measure_transition13;
                        num_measures = Intermediate.caliperFinds.num_measures13;
                        num_instances = Intermediate.caliperFinds.num_instances13;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma13;
                        measure_length1 = Intermediate.caliperFinds.measure_length113;
                        measure_length2 = Intermediate.caliperFinds.measure_length213;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold13;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation13;
                        measure_select = Intermediate.caliperFinds.measure_select13;
                        min_score = Intermediate.caliperFinds.min_score13;
                        break;
                    case 14:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row114;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column114;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row214;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column214;
                        measure_transition = Intermediate.caliperFinds.measure_transition14;
                        num_measures = Intermediate.caliperFinds.num_measures14;
                        num_instances = Intermediate.caliperFinds.num_instances14;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma14;
                        measure_length1 = Intermediate.caliperFinds.measure_length114;
                        measure_length2 = Intermediate.caliperFinds.measure_length214;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold14;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation14;
                        measure_select = Intermediate.caliperFinds.measure_select14;
                        min_score = Intermediate.caliperFinds.min_score14;
                        break;
                    case 15:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row115;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column115;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row215;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column215;
                        measure_transition = Intermediate.caliperFinds.measure_transition15;
                        num_measures = Intermediate.caliperFinds.num_measures15;
                        num_instances = Intermediate.caliperFinds.num_instances15;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma15;
                        measure_length1 = Intermediate.caliperFinds.measure_length115;
                        measure_length2 = Intermediate.caliperFinds.measure_length215;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold15;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation15;
                        measure_select = Intermediate.caliperFinds.measure_select15;
                        min_score = Intermediate.caliperFinds.min_score15;
                        break;
                    case 16:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row116;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column116;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row216;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column216;
                        measure_transition = Intermediate.caliperFinds.measure_transition16;
                        num_measures = Intermediate.caliperFinds.num_measures16;
                        num_instances = Intermediate.caliperFinds.num_instances16;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma16;
                        measure_length1 = Intermediate.caliperFinds.measure_length116;
                        measure_length2 = Intermediate.caliperFinds.measure_length216;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold16;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation16;
                        measure_select = Intermediate.caliperFinds.measure_select16;
                        min_score = Intermediate.caliperFinds.min_score16;
                        break;
                    case 17:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row117;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column117;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row217;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column217;
                        measure_transition = Intermediate.caliperFinds.measure_transition17;
                        num_measures = Intermediate.caliperFinds.num_measures17;
                        num_instances = Intermediate.caliperFinds.num_instances17;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma17;
                        measure_length1 = Intermediate.caliperFinds.measure_length117;
                        measure_length2 = Intermediate.caliperFinds.measure_length217;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold17;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation17;
                        measure_select = Intermediate.caliperFinds.measure_select17;
                        min_score = Intermediate.caliperFinds.min_score17;
                        break;
                    case 18:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row118;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column118;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row218;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column218;
                        measure_transition = Intermediate.caliperFinds.measure_transition18;
                        num_measures = Intermediate.caliperFinds.num_measures18;
                        num_instances = Intermediate.caliperFinds.num_instances18;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma18;
                        measure_length1 = Intermediate.caliperFinds.measure_length118;
                        measure_length2 = Intermediate.caliperFinds.measure_length218;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold18;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation18;
                        measure_select = Intermediate.caliperFinds.measure_select18;
                        min_score = Intermediate.caliperFinds.min_score18;
                        break;
                    case 19:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row119;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column119;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row219;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column219;
                        measure_transition = Intermediate.caliperFinds.measure_transition19;
                        num_measures = Intermediate.caliperFinds.num_measures19;
                        num_instances = Intermediate.caliperFinds.num_instances19;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma19;
                        measure_length1 = Intermediate.caliperFinds.measure_length119;
                        measure_length2 = Intermediate.caliperFinds.measure_length219;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold19;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation19;
                        measure_select = Intermediate.caliperFinds.measure_select19;
                        min_score = Intermediate.caliperFinds.min_score19;
                        break;
                    case 20:
                        hv_Row1 = Intermediate.caliperFinds.hv_Row120;
                        hv_Column1 = Intermediate.caliperFinds.hv_Column120;
                        hv_Row2 = Intermediate.caliperFinds.hv_Row220;
                        hv_Column2 = Intermediate.caliperFinds.hv_Column220;
                        measure_transition = Intermediate.caliperFinds.measure_transition20;
                        num_measures = Intermediate.caliperFinds.num_measures20;
                        num_instances = Intermediate.caliperFinds.num_instances20;
                        measure_sigma = Intermediate.caliperFinds.measure_sigma20;
                        measure_length1 = Intermediate.caliperFinds.measure_length120;
                        measure_length2 = Intermediate.caliperFinds.measure_length220;
                        measure_threshold = Intermediate.caliperFinds.measure_threshold20;
                        measure_interpolation = Intermediate.caliperFinds.measure_interpolation20;
                        measure_select = Intermediate.caliperFinds.measure_select20;
                        min_score = Intermediate.caliperFinds.min_score20;
                        break;
                }


                //     HOperatorSet.DrawLine(hv_halconWindows, out hv_Row1, out hv_Column1, out hv_Row2,
                //out hv_Column2);

                //     HOperatorSet.GenRegionLine();

                hv_shapeParam = new HTuple();
                hv_shapeParam = hv_shapeParam.TupleConcat(hv_Row1);
                hv_shapeParam = hv_shapeParam.TupleConcat(hv_Column1);
                hv_shapeParam = hv_shapeParam.TupleConcat(hv_Row2);
                hv_shapeParam = hv_shapeParam.TupleConcat(hv_Column2);

                //创建句柄
                HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, ho_width, ho_height);

                //添加线模型
                HOperatorSet.AddMetrologyObjectGeneric(hv_MetrologyHandle, "line", hv_shapeParam,
                    20, 5, 1, 30, new HTuple(), new HTuple(), out hv_Index);

                //设置参数，这里根据自己需求设置，这一坨用的都是同一个算子
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_transition",
                   measure_transition);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "num_measures",
                    num_measures);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "num_instances",
                    num_instances);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_sigma",
                    measure_sigma);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_length1",
                    measure_length1);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_length2",
                    measure_length2);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_threshold",
                    measure_threshold);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_interpolation",
                    measure_interpolation);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_select",
                    measure_select);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "min_score",
                    min_score);





                //开始找边缘，顺便把边缘上卡尺找到的所有点坐标输出在ROW,Column里面（数组形式）
                HOperatorSet.ApplyMetrologyModel(ho_Image, hv_MetrologyHandle);
                ho_Contours.Dispose();
                HOperatorSet.GetMetrologyObjectMeasures(out ho_Contours, hv_MetrologyHandle,
                    "all", "all", out hv_Row, out hv_Column);

                //把点显示出来
                ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row, hv_Column, 6, 0.785398);

                //得到线的起点和终点坐标并显示出来
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, "all", "all", "result_type",
                    "all_param", out hv_Parameter);
                if (hv_Parameter.Length!=0)
                {

                ho_Contour.Dispose();
                HOperatorSet.GetMetrologyObjectResultContour(out ho_Contour, hv_MetrologyHandle,
                    "all", "all", 1.5);
                HOperatorSet.SortContoursXld(ho_Contour, out ho_SortedContours, "character",
       "true", "row");
                HOperatorSet.FitLineContourXld(ho_SortedContours, "tukey", -1, 0, 5, 2, out hv_RowBegin,
                    out hv_ColBegin, out hv_RowEnd, out hv_ColEnd, out hv_Nr, out hv_Nc, out hv_Dist);
                }
                else
                {
                    hv_RowBegin = 0;
                    hv_ColBegin = 0;
                    hv_RowEnd = 0;
                    hv_ColEnd = 0;
                }


                //HObject ho_sortContorl = new HObject();
                //HOperatorSet.SortContoursXld(ho_Contour,out ho_sortContorl);

                ////获取测量结果里的开始行坐标
                //HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index,
                //    "all", "result_type", "row_begin", out hv_RowBegin);
                ////获取测量结果里的开始列坐标
                //HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index,
                //    "all", "result_type", "column_begin", out hv_ColBegin);
                ////获取测量结果里的结束行坐标
                //HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index,
                //    "all", "result_type", "row_end", out hv_RowEnd);
                ////获取测量结果里的结束列坐标
                //HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index,
                //    "all", "result_type", "column_end", out hv_ColEnd);


                double[] aaasss = hv_Parameter;
                //label11.Text = aaasss[0].ToString("#0.0000");
                //label12.Text = aaasss[1].ToString("#0.0000");


                //释放测量句柄
                HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);

                HOperatorSet.SetColor(hv_halconWindows,"green");
                HOperatorSet.DispObj(ho_Contour, hv_halconWindows);


                //return aaasss;
            }
            catch (Exception ee)
            {
                hv_RowBegin = 0;
                hv_ColBegin = 0;
                hv_RowEnd = 0;
                hv_ColEnd = 0;
                //return null;
            }


        }





        /// <summary>
        /// 卡尺测量直线
        /// </summary>
        /// <param name="halconWindows"></param>halcon显示的窗体
        /// <param name="ho_Image"></param>图像（HObject）
        /// <param name="hv_Width"></param>图像宽
        /// <param name="hv_Height"></param>图像高
        /// <param name="hv_Row1"></param>直线起点row坐标
        /// <param name="hv_Column1"></param>直线起点col坐标
        /// <param name="hv_Row2"></param>直线终点row坐标
        /// <param name="hv_Column2"></param>直线终点col坐标
        public void CalipMeasureProssing(HTuple halconWindows,HObject ho_Image, HTuple hv_Width,HTuple hv_Height, 
            HTuple hv_Row1,HTuple hv_Column1,HTuple hv_Row2, HTuple hv_Column2,HTuple measure_length1, HTuple measure_length2,
            HTuple measure_sigma, HTuple measure_threshold,int DrawIndex)
        {

            HTuple hv_Index;
            HObject ho_Contours;
            HTuple  hv_Row;
            HTuple hv_Column, hv_MetrologyHandle;
            try
            {
                HOperatorSet.SetColor(halconWindows, "green");
                HObject ho_Contour = new HObject(), ho_Cross = new HObject();

                //HTuple ht;
                //ht = ((ROI)roiController.getROIList()[0]).getModelData();
                //HTuple h_row1, h_col1;

                HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);
                HOperatorSet.AddMetrologyObjectLineMeasure(hv_MetrologyHandle, hv_Row1, hv_Column1,
                     hv_Row2, hv_Column2, measure_length1, measure_length2, measure_sigma, measure_threshold, new HTuple(), new HTuple(), out hv_Index);
                HOperatorSet.ApplyMetrologyModel(ho_Image, hv_MetrologyHandle);
                //ho_Contours.Dispose();
                HOperatorSet.GetMetrologyObjectMeasures(out ho_Contours, hv_MetrologyHandle,
                    "all", "all", out hv_Row, out hv_Column);
                ho_Contour.Dispose();
                HOperatorSet.GetMetrologyObjectResultContour(out ho_Contour, hv_MetrologyHandle,
                    "all", "all", 1.5);
                ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row, hv_Column, 20, 0.785398);



                HOperatorSet.DispObj(ho_Cross, halconWindows);
                HOperatorSet.DispObj(ho_Contours, halconWindows);
                HOperatorSet.SetColor(halconWindows,"red");
                HOperatorSet.DispObj(ho_Contour, halconWindows);

                switch (DrawIndex)
                {
                    case 1:
                        Intermediate.newCaliperFinds.hv_Row11 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column11 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row21 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column21 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma1 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length11 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length21 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold1 = measure_threshold;
                        break;
                    case 2:
                        Intermediate.newCaliperFinds.hv_Row12 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column12 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row22 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column22 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma2 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length12 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length22 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold2 = measure_threshold;
                        break;
                    case 3:
                        Intermediate.newCaliperFinds.hv_Row13 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column13 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row23 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column23 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma3 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length13 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length23 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold3 = measure_threshold;
                        break;
                    case 4:
                        Intermediate.newCaliperFinds.hv_Row14 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column14 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row24 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column24 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma4 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length14 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length24 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold4 = measure_threshold;
                        break;
                    case 5:
                        Intermediate.newCaliperFinds.hv_Row15 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column15 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row25 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column25 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma5 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length15 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length25 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold5 = measure_threshold;
                        break;
                    case 6:
                        Intermediate.newCaliperFinds.hv_Row16 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column16 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row26 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column26 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma6 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length16 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length26 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold6 = measure_threshold;
                        break;
                    case 7:
                        Intermediate.newCaliperFinds.hv_Row17 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column17 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row27 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column27 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma7 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length17 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length27 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold7 = measure_threshold;
                        break;
                    case 8:
                        Intermediate.newCaliperFinds.hv_Row18 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column18 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row28 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column28 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma8 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length18 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length28 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold8 = measure_threshold;
                        break;
                    case 9:
                        Intermediate.newCaliperFinds.hv_Row19 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column19 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row29 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column29 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma9 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length19 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length29 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold9 = measure_threshold;
                        break;
                    case 10:
                        Intermediate.newCaliperFinds.hv_Row110 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column110 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row210 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column210 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma10 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length110 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length210 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold10 = measure_threshold;
                        break;
                    case 11:
                        Intermediate.newCaliperFinds.hv_Row111 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column111 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row211 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column211 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma11 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length111 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length211 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold11 = measure_threshold;
                        break;
                    case 12:
                        Intermediate.newCaliperFinds.hv_Row112 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column112 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row212 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column212 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma12 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length112 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length212 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold12 = measure_threshold;
                        break;
                    case 13:
                        Intermediate.newCaliperFinds.hv_Row113 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column113 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row213 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column213 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma13 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length113 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length213 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold13 = measure_threshold;
                        break;
                    case 14:
                        Intermediate.newCaliperFinds.hv_Row114 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column114 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row214 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column214 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma14 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length114 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length214 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold14 = measure_threshold;
                        break;
                    case 15:
                        Intermediate.newCaliperFinds.hv_Row115 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column115 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row215 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column215 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma15 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length115 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length215 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold15 = measure_threshold;
                        break;
                    case 16:
                        Intermediate.newCaliperFinds.hv_Row116 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column116 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row216 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column216 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma16 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length116 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length216 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold16 = measure_threshold;
                        break;
                    case 17:
                        Intermediate.newCaliperFinds.hv_Row117 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column117 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row217 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column217 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma17 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length117 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length217 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold17 = measure_threshold;
                        break;
                    case 18:
                        Intermediate.newCaliperFinds.hv_Row118 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column118 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row218 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column218 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma18 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length118 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length218 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold18 = measure_threshold;
                        break;
                    case 19:
                        Intermediate.newCaliperFinds.hv_Row119 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column119 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row219 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column219 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma19 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length119 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length219 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold19 = measure_threshold;
                        break;
                    case 20:
                        Intermediate.newCaliperFinds.hv_Row120 = hv_Row1;
                        Intermediate.newCaliperFinds.hv_Column120 = hv_Column1;
                        Intermediate.newCaliperFinds.hv_Row220 = hv_Row2;
                        Intermediate.newCaliperFinds.hv_Column220 = hv_Column2;
                        Intermediate.newCaliperFinds.measure_sigma20 = measure_sigma;
                        Intermediate.newCaliperFinds.measure_length120 = measure_length1;
                        Intermediate.newCaliperFinds.measure_length220 = measure_length2;
                        Intermediate.newCaliperFinds.measure_threshold20 = measure_threshold;
                        break;
                }

                HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);

                //HObject ho_objectConcat = new HObject();
                //HOperatorSet.ConcatObj(ho_Contour, ho_Cross,out ho_objectConcat);
                //HOperatorSet.ConcatObj(ho_objectConcat, ho_Contours,out ho_objectConcat);

                //viewController.addIconicVar(ho_objectConcat);
                //viewController.addIconicVar(ho_Cross);
                //viewController.addIconicVar(ho_Contours);

                //viewController.repaint();
                //viewController.addIconicVar(ho_Contour);
                //viewController.addIconicVar(ho_Cross);
                //viewController.addIconicVar(ho_Contours);
                //viewController.repaint();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 卡尺找直线
        /// </summary>
        /// <param name="ho_Image"></param>图像（HObject）
        /// <param name="halconWindows"></param>halcon显示的窗体
        /// <param name="hv_Width"></param>图像宽
        /// <param name="hv_Height"></param>图像高
        /// <param name="DrawIndex"></param>想找的直线序号
        public double [] FindCalipMeasure(HObject ho_Image,HTuple halconWindows,HTuple hv_Width,HTuple hv_Height, int DrawIndex)
        {
            HTuple measure_sigma = null;
            HTuple measure_length1 = null;
            HTuple measure_length2 = null;
            HTuple measure_threshold = null;


            HTuple hv_Row1 = null, hv_Column1 = null, hv_Row2 = null,hv_Column2=null;


            HTuple hv_Index;
            HObject ho_Contours=new HObject();
            HTuple hv_Row;
            HTuple hv_Column, hv_MetrologyHandle;
            HObject ho_Contour=new HObject(), ho_Cross=new HObject() ;


            HTuple row_begin = new HTuple();
            HTuple column_begin = new HTuple();
            HTuple row_end = new HTuple();
            HTuple column_end = new HTuple();

            double[] calipResult = new double[4];

            try
            {
                switch (DrawIndex)
                {
                    case 1:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row11;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column11;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row21;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column21;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma1;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length11;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length21;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold1;
                        break;
                    case 2:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row12;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column12;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row22;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column22;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma2;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length12;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length22;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold2;
                        break;
                    case 3:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row13;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column13;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row23;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column23;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma3;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length13;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length23;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold3;
                        break;
                    case 4:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row14;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column14;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row24;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column24;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma4;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length14;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length24;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold4;
                        break;
                    case 5:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row15;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column15;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row25;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column25;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma5;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length15;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length25;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold5;
                        break;
                    case 6:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row16;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column16;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row26;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column26;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma6;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length16;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length26;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold6;
                        break;
                    case 7:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row17;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column17;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row27;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column27;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma7;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length17;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length27;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold7;
                        break;
                    case 8:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row18;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column18;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row28;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column28;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma8;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length18;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length28;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold8;
                        break;
                    case 9:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row19;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column19;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row29;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column29;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma9;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length19;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length29;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold9;
                        break;
                    case 10:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row110;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column110;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row210;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column210;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma10;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length110;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length210;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold10;
                        break;
                    case 11:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row111;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column111;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row211;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column211;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma11;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length111;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length211;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold11;
                        break;
                    case 12:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row112;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column112;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row212;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column212;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma12;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length112;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length212;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold12;
                        break;
                    case 13:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row113;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column113;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row213;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column213;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma13;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length113;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length213;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold13;
                        break;
                    case 14:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row114;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column114;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row214;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column214;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma14;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length114;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length214;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold14;
                        break;
                    case 15:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row115;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column115;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row215;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column215;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma15;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length115;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length215;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold15;
                        break;
                    case 16:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row116;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column116;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row216;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column216;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma16;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length116;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length216;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold16;
                        break;
                    case 17:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row117;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column117;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row217;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column217;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma17;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length117;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length217;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold17;
                        break;
                    case 18:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row118;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column118;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row218;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column218;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma18;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length118;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length218;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold18;
                        break;
                    case 19:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row119;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column119;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row219;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column219;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma19;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length119;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length219;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold19;
                        break;
                    case 20:
                        hv_Row1 = Intermediate.newCaliperFinds.hv_Row120;
                        hv_Column1 = Intermediate.newCaliperFinds.hv_Column120;
                        hv_Row2 = Intermediate.newCaliperFinds.hv_Row220;
                        hv_Column2 = Intermediate.newCaliperFinds.hv_Column220;
                        measure_sigma = Intermediate.newCaliperFinds.measure_sigma20;
                        measure_length1 = Intermediate.newCaliperFinds.measure_length120;
                        measure_length2 = Intermediate.newCaliperFinds.measure_length220;
                        measure_threshold = Intermediate.newCaliperFinds.measure_threshold20;
                        break;
                }
                HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);
                HOperatorSet.AddMetrologyObjectLineMeasure(hv_MetrologyHandle, hv_Row1, hv_Column1,
                     hv_Row2, hv_Column2, measure_length1, measure_length2, measure_sigma, measure_threshold, new HTuple(), new HTuple(), out hv_Index);
                HOperatorSet.ApplyMetrologyModel(ho_Image, hv_MetrologyHandle);
                //ho_Contours.Dispose();
                HOperatorSet.GetMetrologyObjectMeasures(out ho_Contours, hv_MetrologyHandle,
                    "all", "all", out hv_Row, out hv_Column);


                //得到线的起点和终点坐标并显示出来
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, "all", "all", "result_type",
                    "row_begin", out row_begin);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, "all", "all", "result_type",
                    "column_begin", out column_begin);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, "all", "all", "result_type",
                    "row_end", out row_end);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, "all", "all", "result_type",
                    "column_end", out column_end);
                calipResult[0] = row_begin;
                calipResult[1] = column_begin;
                calipResult[2] = row_end;
                calipResult[3] = column_end;

                //ho_Contour.Dispose();
                HOperatorSet.GetMetrologyObjectResultContour(out ho_Contour, hv_MetrologyHandle,
                    "all", "all", 1.5);
                //ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row, hv_Column, 20, 0.785398);

                HOperatorSet.SetColor(halconWindows,"green");
                HOperatorSet.SetLineWidth(halconWindows,3);
                HOperatorSet.DispObj(ho_Contour, halconWindows);
                //HOperatorSet.DispObj(ho_Cross, halconWindows);
                //HOperatorSet.DispObj(ho_Contours, halconWindows);
                HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);
                return calipResult;
            }
            catch
            {
                return null;
            }

           
        }


        /// <summary>
        /// 测量直线
        /// </summary>
        /// <param name="rowA1"></param>
        /// <param name="colA1"></param>
        /// <param name="rowA2"></param>
        /// <param name="colA2"></param>
        /// <param name="rowB1"></param>
        /// <param name="colB1"></param>
        /// <param name="rowB2"></param>
        /// <param name="colB2"></param>
        /// <param name="distancemin"></param>
        /// <param name="distancemax"></param>
        public void DistanceCalipLineandLine(HTuple rowA1,HTuple colA1,HTuple rowA2,HTuple colA2,
            HTuple rowB1,HTuple colB1, HTuple rowB2, HTuple colB2,out HTuple distancemin,out HTuple distancemax)
        {
            HOperatorSet.DistanceSs(rowA1, colA1, rowA2, colA2, rowB1, colB1, rowB2, colB2,out distancemin,out distancemax);
        }

        /// <summary>
        /// 找两条直线的角度
        /// </summary>
        /// <param name="rowA1"></param>
        /// <param name="colA1"></param>
        /// <param name="rowA2"></param>
        /// <param name="colA2"></param>
        /// <param name="rowB1"></param>
        /// <param name="colB1"></param>
        /// <param name="rowB2"></param>
        /// <param name="colB2"></param>
        /// <param name="hv_angle"></param>
        public void AngleCalipLineandLine(HTuple rowA1, HTuple colA1, HTuple rowA2, HTuple colA2,
            HTuple rowB1, HTuple colB1, HTuple rowB2, HTuple colB2,out HTuple hv_angle)
        {
            HTuple angleLineAndLine = new HTuple();
            HOperatorSet.AngleLl(rowA1, colA1, rowA2, colA2, rowB1, colB1, rowB2, colB2, out angleLineAndLine);
            HOperatorSet.TupleDeg(angleLineAndLine, out hv_angle);
        }
    }
}
