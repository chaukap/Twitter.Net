using System.Collections.Generic;

namespace Twitter.Net.UserEntity
{
    public class UserEntityDescription
    {
        public List<UserEntityHashtag> Hashtags { get; set; }
        public List<UserEntityMeantions> UserEntityMeantions { get; set; }
    }
}