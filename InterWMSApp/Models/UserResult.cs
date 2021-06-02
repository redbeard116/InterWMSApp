using System;

namespace InterWMSApp.Models
{
    public class UserResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Login { get; set; }
        public long AuthTime { get; set; }
        public string Token { get; set; }
    }
}
