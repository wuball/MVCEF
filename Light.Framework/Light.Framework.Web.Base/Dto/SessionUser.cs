using System;

namespace Light.Framework.Web.Base.Dto
{
    public class SessionUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string NickName { get; set; }
        public string[] Roles { get; set; }

    }
}
