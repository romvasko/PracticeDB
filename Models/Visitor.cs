namespace PracticeDB.Models
{
    public class Visitor
    {
        public int VisitorId { get; set; }
        public string VisitorName { get; set; }
        public int VisitorPassport { get; set; }
        public virtual ICollection<VisitLog>? VisitLogs { get; set; }
   
    }
}
