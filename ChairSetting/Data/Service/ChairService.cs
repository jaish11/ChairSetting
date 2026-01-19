using ChairSetting.Data.DTO;
using ChairSetting.Data.Interface;
using ChairSetting.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ChairSetting.Data.Service
{
    public class ChairService : IChairService
    {
        private readonly AppDbContext _context;

        public ChairService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ChairResponseDto> GetAll()
        {
            return _context.Chairs
                .Include(c => c.OccupiedByUser)
                .Select(c => new ChairResponseDto
                {
                    Id = c.Id,
                    ChairNumber = c.ChairNumber,
                    IsOccupied = c.IsOccupied,
                    OccupiedByUsername = c.OccupiedByUser != null
                        ? c.OccupiedByUser.Username
                        : null
                })
                .ToList();
        }


        public Chair AddChair(string chairNumber)
        {
            var chair = new Chair
            {
                ChairNumber = chairNumber,
                IsOccupied = false
            };
            _context.Chairs.Add(chair);
            _context.SaveChanges();
            return chair;
        }

        public Chair UpdateChair(int id, string chairNumber)
        {
            var chair = _context.Chairs.Find(id);
            chair.ChairNumber = chairNumber;
            _context.SaveChanges();
            return chair;
        }

        public void DeleteChair(int id)
        {
            var chair = _context.Chairs.Find(id);
            _context.Chairs.Remove(chair);
            _context.SaveChanges();
        }

        public void AssignChair(int chairId, int userId)
        {
            var chair = _context.Chairs.Find(chairId);
            chair.OccupiedByUserId = userId;
            _context.SaveChanges();
        }

        public void OccupyChair(int chairId, int userId)
        {
            var chair = _context.Chairs.Find(chairId);

            if (chair == null)
                throw new Exception("Chair not found");

            if (chair.IsOccupied && chair.OccupiedByUserId != userId)
                throw new Exception("Chair already occupied by another user");

            if (chair.IsOccupied && chair.OccupiedByUserId == userId)
                throw new Exception("You already occupied this chair");

            chair.IsOccupied = true;
            chair.OccupiedByUserId = userId;

            _context.SaveChanges();
        }
        public void ReleaseChair(int chairId, int userId)
        {
            var chair = _context.Chairs.Find(chairId);

            if (chair == null)
                throw new Exception("Chair not found");

            if (!chair.IsOccupied)
                throw new Exception("Chair is already free");

            if (chair.OccupiedByUserId != userId)
                throw new Exception("You cannot release another user's chair");

            chair.IsOccupied = false;
            chair.OccupiedByUserId = null;

            _context.SaveChanges();
        }


    }

}
