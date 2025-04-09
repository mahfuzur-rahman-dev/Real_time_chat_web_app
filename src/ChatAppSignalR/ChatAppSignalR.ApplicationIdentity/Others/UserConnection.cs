using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.ApplicationIdentity.Manager;

namespace ChatAppSignalR.ApplicationIdentity.Others
{
    public class UserConnection
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string ConnectedUserId { get; set; }
        public ApplicationUser ConnectedUser { get; set; }

        public DateTime ConnectedOn { get; set; } = DateTime.UtcNow;
    }
}
