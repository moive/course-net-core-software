using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software.Models
{
    public class SQLFriendRepository:IStockFriend
    {
        private readonly AppDbContext context;
        private List<Friend> listFriends;

        public SQLFriendRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Friend newFriend(Friend friend) {
            context.Friends.Add(friend);
            context.SaveChanges();
            return friend;
        }

        public Friend delete(int Id) {
            Friend friend = context.Friends.Find(Id);
            if (friend != null)
            {
                context.Friends.Remove(friend);
                context.SaveChanges();
            }

            return friend;
        }

        public List<Friend> getAllFriend() {
            listFriends = context.Friends.ToList<Friend>();
            return listFriends;
        }

        public Friend giveMeDataFriend(int Id) {
            return context.Friends.Find(Id);
        }

        public Friend update(Friend friend) {
            var employee = context.Friends.Attach(friend);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return friend;
        }
    }
}
