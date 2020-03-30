using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileOperation;


namespace FileOperation
{
    public class Intermediate
    {
        public static GlobalSystemParameter globalParameter = GlobalSystemParameter.LoadObj_GlobalCaliperFinds();//系统参数
        public static GlobalCaliperFinds caliperFinds = GlobalCaliperFinds.LoadObj_GlobalCaliperFinds();//卡尺参数
        public static ModelParameter modelParameter = ModelParameter.LoadObj_1();//模板参数
        public static GlobalNewCalip newCaliperFinds = GlobalNewCalip.LoadObj_GlobalNewCalip();//新卡尺参数
        public static GlobalThisProject thisProject = GlobalThisProject.LoadObj_GlobalNewCalip();//本项目参数
        public static GlobMesurePointToPoint pointToPoint = GlobMesurePointToPoint.LoadObj_1();//一维测量参数
        public Intermediate()
        {

        }
        public static void DeserializeParameter()
        {

        }
    }
}
