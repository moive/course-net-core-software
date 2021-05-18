using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software.Models
{
    public class EditFriendModel:CreateFriendModel
    {
        public int Id { get; set; }
        public string PhotoExistingRoute { get; set; }
    }
}
