using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareApp
{
    public class ComparisonResult
    {
        public string PropertyName { get; set; }
        public object Value1 { get; set; }
        public object Value2 { get; set; }
        public string Status { get; set; }  
    }

}
