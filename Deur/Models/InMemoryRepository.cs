using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deur.Models
{
    class InMemoryRepository : IRepository
    {
        private List<Door> doorList;
        private List<string> historyList;
        private Door door;

        public void AddDoor(string name)
        {
            if (doorList == null)
            {
                doorList = new List<Door>();
            }
            door = new Door(name, 1234, false);
            doorList.Add(door);
        }

        public List<Door> GetAllDoors()
        {
            return doorList;
        }

        //This is only used for the simulation.
        public User DefineUser(int id)
        {
            User user;
            if (id == 1)
            {
                user = new User(1, true, 1234);
            }
            else if (id == 2)
            {
                user = new User(1, true, 4321);
            }
            else
            {
                user = new User(1, false, null);
            }

            return user;
        }

        public List<Door> OpenDoor(int id, List<Door> doorList, bool tag, int? tagcode)
        {
            string message;
            Door door = doorList[id];
            if (historyList == null)
            {
                historyList = new List<string>();
            }          
            if (tag == true) {
                if (door.Code == tagcode)
                {
                    if (door.Open == false)
                    {
                        message = door.Name + " is opening. Please wait a moment.";
                    }
                    else
                    {
                        message = door.Name + " is closing. Please wait a moment.";
                    }
                    
                    door.Open = !door.Open;
                    doorList[id] = door;
                }
                else
                {
                    message = "Tag detected. But code is invalid.";
                }
            }
            else
            {
                message = "No tag detected.";
            }
            historyList.Add(message);
            return doorList;
        }

        public void SetDoorList(List<Door> doorlist)
        {
            doorList = doorlist;
        }

        public void SetHistoryList(List<string> historylist)
        {
            historyList = historylist;
        }

        public List<string> GetHistory()
        {
            return historyList;
        }

    }
}
