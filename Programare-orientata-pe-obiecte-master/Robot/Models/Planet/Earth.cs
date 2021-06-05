using System.Collections.Generic;
using Robot.Interfaces;

namespace Robot.Models.Planet
{
    public class Earth : BasePlanet
    {
        public Earth(int humansCount = 0, int animalCount = 0) : base(500)
        {
            for (int i = 0; i < humansCount; i++)
                Inhabitants.Add(new BaseHuman());

            for (int i = 0; i < animalCount; i++)
                Inhabitants.Add(new BaseAnimal());
        }
    }
}
