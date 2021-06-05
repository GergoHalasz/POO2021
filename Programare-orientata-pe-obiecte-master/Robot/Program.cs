using System;
using Robot.Enums;
using Robot.Interfaces;
using Robot.Models.Planet;
using Robot.Models.Robot;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            GiantKillerRobot robot = new GiantKillerRobot();
            IPlanet earth = new Earth(10, 10);

            int targetIndex = 0;
            robot.Target = earth.Inhabitants[targetIndex++];
            robot.EyeLaserIntensity = Intensity.Kill;

            if (robot.IsAlive && earth.ContainsLife)
                if (robot.Target.IsAlive)
                    robot.Attack(robot.Target);
                else
                    robot.Target = earth.Inhabitants[targetIndex++];

        }
    }
}
