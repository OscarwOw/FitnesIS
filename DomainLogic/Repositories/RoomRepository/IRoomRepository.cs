using Beckend.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DomainLayer.Repositories.RoomRepository
{
    public interface IRoomRepository
    {
        bool SaveRoomChanges();

        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int id);
        void CreateRoom(Room Room);
        void UpdateRoom(Room Room);
        void DeleteRoom(Room Room);
        IEnumerable<Training> GetAllRoomTrainings(int id);
    }
}
