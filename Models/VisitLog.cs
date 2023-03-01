using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeDB.Models
{
    public class VisitLog
    {
        public int VisitLogId { get; set; }
        [ForeignKey("VisitorId")]
        public int VisitorId { get; set; }
        [ForeignKey("RoomId")]
        public int RoomId { get; set; }
        public virtual Room? Room { get; set; } = null;
        public virtual Visitor? Visitor { get; set; } = null;
    }
}
