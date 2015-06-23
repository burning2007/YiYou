using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yiyou.Model
{
    public class GlobalConstant
    {
        public static Dictionary<int, string> dicApplicationStatus = new Dictionary<int, string>{
            {0,"未提交"}, 
            {1,"已提交"}, 
            {2,"已接受"}, 
            {3,"已付初审费"}, 
            {4,"初审中"},
            {5,"已初审"},
            {6,"已付会诊费"}, 
            {7,"会诊中"}, 
            {8,"已出结论"},
            {9,"已翻译"},
            {99,"已完成"}
        };
    }
}
