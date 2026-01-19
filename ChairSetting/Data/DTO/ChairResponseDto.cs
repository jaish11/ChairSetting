namespace ChairSetting.Data.DTO
{
    public class ChairResponseDto
    {
        public int Id { get; set; }
        public string ChairNumber { get; set; }
        public bool IsOccupied { get; set; }
        public string OccupiedByUsername { get; set; }
    }
}
