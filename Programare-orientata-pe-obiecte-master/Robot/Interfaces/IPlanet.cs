using System.Collections.Generic;

namespace Robot.Interfaces
{
    public interface IPlanet
    {
        public int Hp { get; set; }
        public bool ContainsLife { get; set; }
        public List<IEntity> Inhabitants { get; set; }
    }
}
