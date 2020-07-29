using System;
using System.Collections.Generic;

namespace ITICommunity.Models
{
    public partial class User
    {
        public User()
        {
            AuditLog = new HashSet<AuditLog>();
            Ticket = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public virtual ICollection<AuditLog> AuditLog { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
