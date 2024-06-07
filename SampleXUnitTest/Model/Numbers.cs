using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleXUnitTest.Model
{
    public class Numbers
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public bool Expected {  get; set; }
        public static IEnumerable<object[]> numbers = new List<object[]>
        {
            new object[]{10,10,true},
            new object[]{20,20,true},
            new object[]{0,0,false}
        };
    }
}
