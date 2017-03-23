using System;
using System.Collections.Generic;
using Light.Framework.Core.Data;
using Light.Framework.Core.Enums;

namespace Light.Framework.Data.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            Id = Guid.NewGuid();
            Gender = Gender.Unknown;
            Roles = new List<Role>();
        }

        public string Username { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public string NickName { get; set; }

        public string ImageKey { get; set; }

        public int Age { get; set; }

        public string Signature { get; set; }

        public Gender Gender { get; set; }

        public string RegisterIp { get; set; }

        public string RegisterAddress { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public string InternalNotes { get; set; }

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        public bool IsSuperMan { get; set; }

        /// <summary>
        /// 用户拥有的角色
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }


    }
}
