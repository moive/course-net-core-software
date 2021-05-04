using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software.Models
{
    public interface IStockFriend
    {
        Friend giveMeDataFriend(int Id);
        List<Friend> getAllFriend();
    }
}
