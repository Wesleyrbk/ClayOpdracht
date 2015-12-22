using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deur.Models
{
    interface IRepository
    {
        void AddDoor(string name);
        void SetDoorList(List<Door> doorList);
        void SetHistoryList(List<string> historyList);
        List<Door> GetAllDoors();      
        List<string> GetHistory();
        List<Door> OpenDoor(int id, List<Door> doorList, bool tag, int? tagcode);
        User DefineUser(int id);           
    }
}
