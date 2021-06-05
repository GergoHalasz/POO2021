namespace Robot.Interfaces
{
    public interface IEntity
    {
        public int Hp { get; set; }
        public int Mp { get; set; }
        public int Dmg { get; set; }
        public int Range { get; set; }
        public bool IsAlive { get; set; }
        public IEntity Target { get; set; }
        void Attack(IEntity entity);
    }
}
