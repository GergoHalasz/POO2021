using Robot.Enums;
using Robot.Interfaces;

namespace Robot.Models
{
    public class BaseRobot : BaseEntity
    {
        #region Constants

        const int HP_MIN = 200;
        const int HP_MAX = 400;

        const int MP_MIN = 50;
        const int MP_MAX = 100;

        const int DMG_MIN = 15;
        const int DMG_MAX = 50;

        const int STAMINA_MIN = 20;
        const int STAMINA_MAX = 60;

        const int RANGE_MIN = 20;
        const int RANGE_MAX = 100;

        const int INT_MIN = 150;
        const int INT_MAX = 300;

        const int STR_MIN = 150;
        const int STR_MAX = 300;

        const int AGI_MIN = 20;
        const int AGI_MAX = 50;

        #endregion

        public Intensity EyeLaserIntensity { get; set; }

        public BaseRobot(string Name = "Base Robot") : base(
            Name,
            Utility.Rng.Next(HP_MIN, HP_MAX),
            Utility.Rng.Next(MP_MIN, MP_MAX),
            Utility.Rng.Next(STAMINA_MIN, STAMINA_MAX),
            Utility.Rng.Next(DMG_MIN, DMG_MAX),
            Utility.Rng.Next(RANGE_MIN, RANGE_MAX),
            Utility.Rng.Next(INT_MIN, INT_MAX),
            Utility.Rng.Next(STR_MIN, STR_MAX),
            Utility.Rng.Next(AGI_MIN, AGI_MAX)
            )
        {
            EyeLaserIntensity = Intensity.Normal;
        }
    }
}
