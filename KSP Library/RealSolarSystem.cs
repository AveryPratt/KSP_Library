using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KSP_Library
{
    namespace Systems
    {
        public class RealSolarSystem : SolarSystem
        {
            public RealSolarSystem()
            {
                Bodies[0] = new Star
                {
                    Name = "SUN",
                    Radius = 695700000,
                    GM = BigGM.ENotation(1.32712440018, 20)
                    //GM = 132712440018000000000
                };

                Bodies[1] = new OrbitingBody
                {
                    Name = "MERCURY",
                    Radius = 2440000,
                    GM = 22032000000000
                };

                Bodies[2] = new OrbitingBody
                {
                    Name = "VENUS",
                    Radius = 6052000,
                    GM = 324859000000000
                };

                Bodies[3] = new OrbitingBody
                {
                    Name = "EARTH",
                    Radius = 6374327,
                    GM = 398600441800000
                };

                Bodies[4] = new OrbitingBody
                {
                    Name = "MOON",
                    Radius = 1737000,
                    GM = 4904869500000
                };

                Bodies[5] = new OrbitingBody
                {
                    Name = "MARS",
                    Radius = 3390000,
                    GM = 42828370000000
                };

                Bodies[6] = new OrbitingBody
                {
                    Name = "PHOBOS",
                    Radius = 11266,
                    GM = 711390
                };

                Bodies[7] = new OrbitingBody
                {
                    Name = "DEIMOS",
                    Radius = 6200,
                    GM = 98523
                };

                Bodies[8] = new OrbitingBody
                {
                    Name = "JUPITER",
                    Radius = 69911000,
                    GM = 126686534000000000
                };

                Bodies[9] = new OrbitingBody
                {
                    Name = "IO",
                    Radius = 1821600,
                    GM = 5961246900000
                };

                Bodies[10] = new OrbitingBody
                {
                    Name = "EUROPA",
                    Radius = 1560800,
                    GM = 3203454300000
                };

                Bodies[11] = new OrbitingBody
                {
                    Name = "GANYMEDE",
                    Radius = 2634100,
                    GM = 9890319200000
                };

                Bodies[12] = new OrbitingBody
                {
                    Name = "CALLISTO",
                    Radius = 2410300,
                    GM = 7180896300000
                };

                Bodies[13] = new OrbitingBody
                {
                    Name = "SATURN",
                    Radius = 58232000,
                    GM = 37931187000000000
                };

                Bodies[14] = new OrbitingBody
                {
                    Name = "MIMAS",
                    Radius = 198200,
                    GM = 2502312814
                };

                Bodies[15] = new OrbitingBody
                {
                    Name = "ENCELADUS",
                    Radius = 252100,
                    GM = 7209474698
                };

                Bodies[16] = new OrbitingBody
                {
                    Name = "TETHYS",
                    Radius = 531100,
                    GM = 41209040219
                };

                Bodies[17] = new OrbitingBody
                {
                    Name = "DIONE",
                    Radius = 561400,
                    GM = 73111342842
                };

                Bodies[18] = new OrbitingBody
                {
                    Name = "RHEA",
                    Radius = 763800,
                    GM = 153938856534
                };

                Bodies[19] = new OrbitingBody
                {
                    Name = "TITAN",
                    Radius = 2575500,
                    GM = 8977972400000
                };

                Bodies[20] = new OrbitingBody
                {
                    Name = "IAPETUS",
                    Radius = 734500,
                    GM = 120509524408
                };

                Bodies[21] = new OrbitingBody
                {
                    Name = "URANUS",
                    Radius = 25362000,
                    GM = 5793939000000000
                };

                Bodies[22] = new OrbitingBody
                {
                    Name = "MIRANDA",
                    Radius = 235800,
                    GM = 4398218720
                };

                Bodies[23] = new OrbitingBody
                {
                    Name = "ARIEL",
                    Radius = 578900,
                    GM = 90300302400
                };

                Bodies[24] = new OrbitingBody
                {
                    Name = "UMBRIEL",
                    Radius = 584700,
                    GM = 78220217600
                };

                Bodies[25] = new OrbitingBody
                {
                    Name = "TITANIA",
                    Radius = 788400,
                    GM = 235394801600
                };

                Bodies[26] = new OrbitingBody
                {
                    Name = "OBERON",
                    Radius = 761400,
                    GM = 201156771200
                };

                Bodies[27] = new OrbitingBody
                {
                    Name = "NEPTUNE",
                    Radius = 24622000,
                    GM = 6836529000000000
                };

                Bodies[28] = new OrbitingBody
                {
                    Name = "PROTEUS",
                    Radius = 210000,
                    GM = 2936595200
                };

                Bodies[29] = new OrbitingBody
                {
                    Name = "TRITON",
                    Radius = 1353400,
                    GM = 1428253100000
                };

                Bodies[30] = new OrbitingBody
                {
                    Name = "PLUTO",
                    Radius = 1187000,
                    GM = 871000000000
                };

                Bodies[31] = new OrbitingBody
                {
                    Name = "CHARON",
                    Radius = 606000,
                    GM = 105850908800
                };
            }
        }
    }
}
