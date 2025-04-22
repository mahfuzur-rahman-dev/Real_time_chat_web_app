

using System.ComponentModel.DataAnnotations;

namespace ChatAppSignalR.Models.Entities
{
    public class User
    {
        [Key]
        public string IdentityUserId { get; set; }
        public string FullName { get; set; }
    }
}
