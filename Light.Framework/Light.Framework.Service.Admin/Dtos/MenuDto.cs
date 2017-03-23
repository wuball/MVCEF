using System;
using Light.Framework.Core.Enums;
using Light.Framework.Core.Extensions;

namespace Light.Framework.Service.Admin.Dtos
{
    /// <summary>
    /// 菜单模型
    /// </summary>
    public class MenuDto
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 上级菜单名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 排序越大越靠后
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 菜单类型
        /// </summary>
        public MenuType Type { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 菜单类型名称
        /// </summary>
        public string TypeName => Type.ToDescription();
    }
}
