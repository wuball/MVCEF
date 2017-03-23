using System.Collections.Generic;
using Light.Framework.Core.Core;
using Light.Framework.Core.Data;

namespace Light.Framework.Data.Entities
{
    public class Role : EntityBase
    {
        public Role()
        {
            Users = new List<User>();
            Menus = new List<Menu>();
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 用户角色关系
        /// </summary>
        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// 角色菜单关系
        /// </summary>
        public virtual ICollection<Menu> Menus { get; set; }

        //public class Names
        //{
        //    public const string SuperAdmin = "SuperAdmin";
        //    public const string SaleAgent = "SaleAgent";
        //    public const string Dealer = "Dealer";
        //    public const string Customer = "Customer";
        //}
    }
}
