using Robot.Enums;

namespace Robot.Models.Robot
{
    public class GiantKillerRobot : BaseRobot
    {
        public GiantKillerRobot(string name = "Giant Killer Robot") : base(name)
        {
            EyeLaserIntensity = Intensity.Hard;
        }
    }
}
