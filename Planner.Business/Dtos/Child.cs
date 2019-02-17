using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Business.Dtos
{
    public class Text
    {
        public string name { get; set; }
    }

    public class Child
    {
        public Child()
        {
            children = new List<Child>();
        }
        public Text text { get; set; }
        public List<Child> children { get; set; }
    }

    //public class NodeStructure
    //{
    //    public Text text { get; set; }
    //    public string HTMLclass { get; set; }
    //    public List<Child> children { get; set; }
    //}
}
