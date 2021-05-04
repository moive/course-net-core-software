using course_net_core_software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software.ViewModels
{
    public class DetailsView
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public Friend Friend { get; set; }
    }
}
