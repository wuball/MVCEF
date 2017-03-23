using System;
using System.Linq;
using Light.Framework.Core.Models;
using Light.Framework.Core.Security;
using Light.Framework.Service.Admin.Dtos;
using Light.Framework.Service.Dtos;

namespace Light.Framework.Service.Admin.Implementations
{
    public class UserService : ServiceBase
    {
        public StandardResult<SessionUser> Login(LoginDto dto)
        {
            using (var db = base.NewDB())
            {
                dto.Password = dto.Password.Md5HashEncrypt();

                var result = new StandardResult<SessionUser>();

                var user = db.Users.FirstOrDefault(m => m.Username == dto.LoginName && m.Password == dto.Password);
                if (user == null)
                {
                    result.Success = false;
                    result.Fail("账号或密码错误");
                    return result;
                }
                user.LastLoginTime = DateTime.Now;
                db.SaveChanges();

                result.Success = true;
                result.Value = new SessionUser(user, user.Roles.Select(m => m.Id.ToString()).ToArray());
                return result;
            }

        }
    }
}