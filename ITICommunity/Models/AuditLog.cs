using System;
using System.Collections.Generic;

namespace ITICommunity.Models
{
    public partial class AuditLog
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime? LogDateTime { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
    }
}
