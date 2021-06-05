using System;
using Robot.Interfaces;

namespace Robot.Models
{
    public class BaseEntity : IEntity
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }
        public int Dmg { get; set; }
        public int Stamina { get; set; }
        public int Range { get; set; }
        public int Int { get; set; }
        public int Str { get; set; }
        public int Agi { get; set; }
        public bool IsAlive { get => Hp <= 0; set { } }
        public IEntity Target { get; set; }

        public BaseEntity(
            string name = "Base Entity",
            int hp = 100,
            int mp = 100,
            int stamina = 10,
            int dmg = 10,
            int range = 2,
            int Int = 10,
            int str = 10,
            int agi = 10
            )
        {
            Name = name;
            Hp = hp;
            Mp = mp;
            Stamina = stamina;
            Dmg = dmg;
            Range = range;
            this.Int = Int;
            Str = str;
            Agi = agi;
            IsAlive = true;
        }

        public void Attack(IEntity entity) => entity.Hp -= Dmg;

        public override string ToString() => Name;
    }
}
