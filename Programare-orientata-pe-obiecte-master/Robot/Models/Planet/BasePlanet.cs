using System.Collections.Generic;
using Robot.Interfaces;

namespace Robot.Models.Planet
{
    public class BasePlanet : IPlanet
    {
        public int Hp { get; set; }
        public bool ContainsLife { get; set; }
        public List<IEntity> Inhabitants { get; set; }

        public BasePlanet(int hp = 200)
        {
            Hp = hp;
            ContainsLife = false;
            Inhabitants = new List<IEntity>();
        }
    }
}
