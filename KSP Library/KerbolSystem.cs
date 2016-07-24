using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP_Library
{
    namespace Systems
    {
        public class KerbolSystem : SolarSystem
        {
            public KerbolSystem()
            {
                bodies = new Body[17];
                bodies[0] = new Star
                {
                    Name = "KERBOL",
                    Radius = 261600000,
                    GM = BigGM.ENotation(1.1723328, 18)
                    //GM = 1172332800000000000
                };

                bodies[1] = new OrbitingBody
                {
                    Name = "MOHO",
                    Radius = 250000,
                    GM = 168609380000
                };

                bodies[2] = new OrbitingBody
                {
                    Name = "EVE",
                    Radius = 700000,
                    GM = 8171730200000
                };

                bodies[3] = new OrbitingBody
                {
                    Name = "GILLY",
                    Radius = 13000,
                    GM = 8289450
                    // Actual GM == 8289449.8
                };

                bodies[4] = new OrbitingBody
                {
                    Name = "KERBIN",
                    Radius = 600000,
                    GM = 3531600000000
                };

                bodies[5] = new OrbitingBody
                {
                    Name = "MUN",
                    Radius = 200000,
                    GM = 65138398000
                };

                bodies[6] = new OrbitingBody
                {
                    Name = "MINMUS",
                    Radius = 60000,
                    GM = 1765800000
                };

                bodies[7] = new OrbitingBody
                {
                    Name = "DUNA",
                    Radius = 320000,
                    GM = 301363210000
                };

                bodies[8] = new OrbitingBody
                {
                    Name = "IKE",
                    Radius = 130000,
                    GM = 18568369000
                };

                bodies[9] = new OrbitingBody
                {
                    Name = "DRES",
                    Radius = 138000,
                    GM = 21484489000
                };

                bodies[10] = new OrbitingBody
                {
                    Name = "JOOL",
                    Radius = 6000000,
                    GM = 282528000000000
                };

                bodies[11] = new OrbitingBody
                {
                    Name = "LAYTHE",
                    Radius = 500000,
                    GM = 1962000000000
                };

                bodies[12] = new OrbitingBody
                {
                    Name = "VALL",
                    Radius = 300000,
                    GM = 207481500000
                };

                bodies[13] = new OrbitingBody
                {
                    Name = "TYLO",
                    Radius = 600000,
                    GM = 2825280000000
                };

                bodies[14] = new OrbitingBody
                {
                    Name = "BOP",
                    Radius = 65000,
                    GM = 2486834900
                };

                bodies[15] = new OrbitingBody
                {
                    Name = "POL",
                    Radius = 44000,
                    GM = 721702080
                };

                bodies[16] = new OrbitingBody
                {
                    Name = "EELOO",
                    Radius = 210000,
                    GM = 74410815000
                };
            }
        }
    }
}