using System;
using System.Collections.Generic;
using Light.Framework.Core.Data;

namespace Light.Framework.Data.Entities
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu : EntityBase
    {
        public Menu()
        {
            Roles = new List<Role>();
        }

        /// <summary>
        /// 上级ID
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 排序越大越靠后
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 菜单类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 所属角色
        /// </summary>
        public ICollection<Role> Roles { get; set; }
    }
}
