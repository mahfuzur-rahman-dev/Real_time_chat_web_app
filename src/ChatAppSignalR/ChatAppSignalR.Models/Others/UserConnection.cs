

namespace ChatAppSignalR.Models.Others
{
    public class UserConnection
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ConnectedUserId { get; set; }
        public DateTime ConnectedOn { get; set; } = DateTime.UtcNow;
    }
}
