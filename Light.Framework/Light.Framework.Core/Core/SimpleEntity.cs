using System;

namespace Light.Framework.Core.Core
{
    public interface ISimpleEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }

    public class SimpleEntity : ISimpleEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public SimpleEntity()
        {
            
        }

        public SimpleEntity(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
