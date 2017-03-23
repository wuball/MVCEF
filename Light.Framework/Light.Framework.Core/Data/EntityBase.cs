using System;

namespace Light.Framework.Core.Data
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime EditTime { get; set; }

        public bool IsDeleted { get; set; }







        public bool IsNew => this.Id == Guid.Empty;

        public void NewId()
        {
            this.Id = Guid.NewGuid();
        }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
            AddTime = DateTime.Now;
            EditTime = DateTime.Now;
            IsDeleted = false;
        }
    }
}
