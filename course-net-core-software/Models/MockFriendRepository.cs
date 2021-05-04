using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_net_core_software.Models
{
    public class MockFriendRepository: IStockFriend
    {
        private List<Friend> listFriend;

        public MockFriendRepository()
        {
            listFriend = new List<Friend>();
            listFriend.Add(new Friend() {Id=1, Name="Moises", City="Sihuas", Email="mvelasquez@test.com" });
            listFriend.Add(new Friend() {Id=2, Name="Veronika", City="Lima", Email="vchancafe@test.com" });
            listFriend.Add(new Friend() {Id=3, Name="Daniela", City="Ventanilla", Email="dvelasquez@test.com" });
            listFriend.Add(new Friend() {Id=4, Name="Gabriela", City="Callao", Email="gvelasquez@test.com" });
        }

        public List<Friend> getAllFriend()
        {
            return listFriend;
        }

        public Friend giveMeDataFriend(int Id)
        {
            return this.listFriend.FirstOrDefault(e=>e.Id == Id);
        }
    }
}
