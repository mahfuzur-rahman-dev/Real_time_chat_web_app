using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.Models.Entities;
using ChatAppSignalR.Models.Others;
using Microsoft.AspNetCore.Identity;

namespace ChatAppSignalR.ApplicationIdentity.Manager
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public User User { get; set; }
        public ICollection<UserConnection> Connections { get; set; }
        public ICollection<UserConnection> ConnectedToMe { get; set; }

    }
}
