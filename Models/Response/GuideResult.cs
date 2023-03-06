using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models.Response
{
    public class GuideResult
    {
        public List<GuidesRS>  guidesRs { get; set; }
        public decimal totalCost { get; set; }
        public List<guidesTotal> guidesTotals { get; set; }
    }
}