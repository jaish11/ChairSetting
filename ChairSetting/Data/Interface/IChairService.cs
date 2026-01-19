using ChairSetting.Data.DTO;
using ChairSetting.Data.Model;

namespace ChairSetting.Data.Interface
{
    public interface IChairService
    {
        IEnumerable<ChairResponseDto> GetAll();
        Chair AddChair(string chairNumber);
        Chair UpdateChair(int id, string chairNumber);
        void DeleteChair(int id);
        void AssignChair(int chairId, int userId);
        void OccupyChair(int chairId, int userId);
        void ReleaseChair(int chairId, int userId);

    }
}
