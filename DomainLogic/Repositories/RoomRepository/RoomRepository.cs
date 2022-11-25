using Beckend.DataLayer.Models;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DomainLayer.Repositories.RoomRepository
{
    public class RoomRepository : IRoomRepository
    {
        private DatabaseContext _context;

        public RoomRepository(DatabaseContext database)
        {
            _context = database;
        }
        public void CreateRoom(Room Room)
        {
            if (Room == null)
            {
                throw new ArgumentNullException(nameof(Room));
            }
            _context.Add(Room);

        }
        public void DeleteRoom(Room Room)
        {
            if (Room == null)
            {
                throw new ArgumentNullException(nameof(Room));
            }
            _context.Rooms.Remove(Room);
        }

        public Room GetRoomById(int id)
        {
            return _context.Rooms.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public bool SaveRoomChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateRoom(Room Room)
        {
            _context.Update(Room);
        }

        public IEnumerable<Training> GetAllRoomTrainings(int id)
        {
            var trainings = _context.Rooms.Include(p => p.Trainings).Where(p => p.Id == id).First().Trainings.AsEnumerable();
            return trainings;
        }
    }
}
