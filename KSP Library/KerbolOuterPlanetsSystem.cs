using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP_Library
{
    namespace Systems
    {
        public class KerbolOuterPlanetsSystem : SolarSystem
        {
            public KerbolOuterPlanetsSystem()
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
                    GM = 3531600000000 //12
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
                    GM = 282528000000000 //14
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
                    Name = "SARNUS",
                    Radius = 5300000,
                    GM = 82117744000000 //13
                };

                bodies[17] = new OrbitingBody
                {
                    Name = "HALE",
                    Radius = 6000,
                    GM = 812268
                };

                bodies[18] = new OrbitingBody
                {
                    Name = "OVOK",
                    Radius = 26000,
                    GM = 13263120
                };

                bodies[19] = new OrbitingBody
                {
                    Name = "EELOO",
                    Radius = 210000,
                    GM = 74410815000
                };

                bodies[20] = new OrbitingBody
                {
                    Name = "SLATE",
                    Radius = 540000,
                    GM = 2431506600000
                };

                bodies[21] = new OrbitingBody
                {
                    Name = "TEKTO",
                    Radius = 280000,
                    GM = 192506730000
                };

                bodies[22] = new OrbitingBody
                {
                    Name = "URLUM",
                    Radius = 2177000,
                    GM = 11948654000000 //13
                };

                bodies[23] = new OrbitingBody
                {
                    Name = "POLTA",
                    Radius = 220000,
                    GM = 90212760000
                };

                bodies[24] = new OrbitingBody
                {
                    Name = "PRIAX",
                    Radius = 74000,
                    GM = 338433230
                };

                bodies[25] = new OrbitingBody
                {
                    Name = "WAL",
                    Radius = 370000,
                    GM = 496905930000
                };

                bodies[26] = new OrbitingBody
                {
                    Name = "TAL",
                    Radius = 22000,
                    GM = 21366180
                };

                bodies[27] = new OrbitingBody
                {
                    Name = "NEIDON",
                    Radius = 2145000,
                    GM = 14172721000000 //13
                };

                bodies[28] = new OrbitingBody
                {
                    Name = "THATMO",
                    Radius = 286000,
                    GM = 186161150000
                };

                bodies[29] = new OrbitingBody
                {
                    Name = "NISSEE",
                    Radius = 30000,
                    GM = 39730500
                };

                bodies[30] = new OrbitingBody
                {
                    Name = "PLOCK",
                    Radius = 189000,
                    GM = 51862605000
                };

                bodies[31] = new OrbitingBody
                {
                    Name = "KAREN",
                    Radius = 85050,
                    GM = 468340350
                };
            }
        }
    }
}