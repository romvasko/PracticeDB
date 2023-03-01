namespace PracticeDB.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int RoomCost { get; set; }
        public virtual ICollection<VisitLog>? VisitLogs { get; set; }
    }
}
