namespace Robot.Models
{
    public class BaseAnimal : BaseEntity
    {
        #region Constants

        const int HP_MIN = 10;
        const int HP_MAX = 50;

        const int MP_MIN = 0;
        const int MP_MAX = 10;

        const int DMG_MIN = 2;
        const int DMG_MAX = 30;

        const int STAMINA_MIN = 4;
        const int STAMINA_MAX = 15;

        const int RANGE_MIN = 2;
        const int RANGE_MAX = 10;

        const int INT_MIN = 1;
        const int INT_MAX = 50;

        const int STR_MIN = 10;
        const int STR_MAX = 100;

        const int AGI_MIN = 10;
        const int AGI_MAX = 100;

        #endregion

        public BaseAnimal(string Name = "Base Animal") : base(Name,
            Utility.Rng.Next(HP_MIN, HP_MAX),
            Utility.Rng.Next(MP_MIN, MP_MAX),
            Utility.Rng.Next(STAMINA_MIN, STAMINA_MAX),
            Utility.Rng.Next(DMG_MIN, DMG_MAX),
            Utility.Rng.Next(RANGE_MIN, RANGE_MAX),
            Utility.Rng.Next(INT_MIN, INT_MAX),
            Utility.Rng.Next(STR_MIN, STR_MAX),
            Utility.Rng.Next(AGI_MIN, AGI_MAX))
        { }
    }
}
