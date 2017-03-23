using System;
using Light.Framework.Data.Entities;

namespace Light.Framework.Service.Dtos
{
    public class SessionUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string NickName { get; set; }
        public string[] Roles { get; set; }

        public SessionUser(User user, string[] roles)
        {
            Id = user.Id;
            Roles = roles;
            Username = user.Username;
            NickName = user.NickName;
        }
    }
}
