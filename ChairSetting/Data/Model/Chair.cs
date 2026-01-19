namespace ChairSetting.Data.Model
{
    public class Chair
    {
        public int Id { get; set; }
        public string ChairNumber { get; set; }
        public bool IsOccupied { get; set; }
        public int? OccupiedByUserId { get; set; }

        public User OccupiedByUser { get; set; }
    }
}
