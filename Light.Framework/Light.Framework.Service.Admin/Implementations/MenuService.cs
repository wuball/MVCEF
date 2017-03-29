using System;
using System.Collections.Generic;
using System.Linq;
using Light.Framework.Core.Enums;
using Light.Framework.Core.Extensions;
using Light.Framework.Service.Admin.Dtos;

namespace Light.Framework.Service.Admin.Implementations
{
    public class MenuService : ServiceBase
    {

        /// <summary>
        /// 获取用户拥有的权限菜单（不包含按钮）
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public List<MenuDto> GetMyMenus(Guid userId)
        {
            using (var db = NewDB())
            {
                var user = db.Users.Find(userId);
                if (user.Roles.AnyOne())
                {
                    var roleIds = user.Roles.Select(x => x.Id);
                    var query = db.Menus.Where(x =>
                        !x.IsDeleted &&
                        x.Type != (byte)MenuType.Button &&
                        x.Roles.Any(r => roleIds.Contains(r.Id)));
                    return query.OrderBy(x => x.Order).Select(item => new MenuDto
                    {
                        Id = item.Id,
                        ParentId = item.ParentId,
                        Name = item.Name,
                        Url = item.Url,
                        Order = item.Order,
                        Icon = item.Icon,
                        Type = (MenuType)item.Type
                    }).ToList();
                }
                return null;
            }
        }

        public string GetRolesString(string url)
        {
            using (var db = NewDB())
            {
                var vms = db.Menus.AsNoTracking()
                    .FirstOrDefault(m => m.Url == url)
                    ?.Roles.Select(m => m.Name);

                return vms == null ? "" : vms.EnumerableToString();
            }
        }
    }
}