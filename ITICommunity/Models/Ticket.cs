using System;
using System.Collections.Generic;

namespace ITICommunity.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            AuditLog = new HashSet<AuditLog>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Status { get; set; }
        public string TicketsContent { get; set; }
        public DateTime? LastStatusChangedDate { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<AuditLog> AuditLog { get; set; }
    }
}
