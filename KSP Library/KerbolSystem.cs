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
                Bodies[0] = new Star
                {
                    Name = "KERBOL",
                    Radius = 261600000,
                    GM = BigGM.ENotation(1.1723328, 18),
                    //GM = 1172332800000000000
                    HasAtmosphere = true,
                    AtmosphereHeight = 600000
                };

                Bodies[1] = new OrbitingBody
                {
                    Name = "MOHO",
                    Radius = 250000,
                    GM = 168609380000,
                    HasAtmosphere = false,
                    SOI = 9646663
                };

                Bodies[2] = new OrbitingBody
                {
                    Name = "EVE",
                    Radius = 700000,
                    GM = 8171730200000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 90000,
                    SOI = 85109365
                };

                Bodies[3] = new OrbitingBody
                {
                    Name = "GILLY",
                    Radius = 13000,
                    GM = 8289450, //49.8
                    HasAtmosphere = false,
                    SOI = 126123 //.27
                };

                Bodies[4] = new OrbitingBody
                {
                    Name = "KERBIN",
                    Radius = 600000,
                    GM = 3531600000000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 70000,
                    SOI = 84159286
                };

                Bodies[5] = new OrbitingBody
                {
                    Name = "MUN",
                    Radius = 200000,
                    GM = 65138398000,
                    HasAtmosphere = false,
                    SOI = 2429559 //.1
                };

                Bodies[6] = new OrbitingBody
                {
                    Name = "MINMUS",
                    Radius = 60000,
                    GM = 1765800000,
                    HasAtmosphere = false,
                    SOI = 2247428 //.4
                };

                Bodies[7] = new OrbitingBody
                {
                    Name = "DUNA",
                    Radius = 320000,
                    GM = 301363210000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 50000,
                    SOI = 47921949
                };

                Bodies[8] = new OrbitingBody
                {
                    Name = "IKE",
                    Radius = 130000,
                    GM = 18568369000,
                    HasAtmosphere = false,
                    SOI = 1049599 //8.9
                };

                Bodies[9] = new OrbitingBody
                {
                    Name = "DRES",
                    Radius = 138000,
                    GM = 21484489000,
                    HasAtmosphere = false,
                    SOI = 32832840
                };

                Bodies[10] = new OrbitingBody
                {
                    Name = "JOOL",
                    Radius = 6000000,
                    GM = 282528000000000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 200000,
                    SOI = 2455985200
                };

                Bodies[11] = new OrbitingBody
                {
                    Name = "LAYTHE",
                    Radius = 500000,
                    GM = 1962000000000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 50000,
                    SOI = 3723646 //5.8
                };

                Bodies[12] = new OrbitingBody
                {
                    Name = "VALL",
                    Radius = 300000,
                    GM = 207481500000,
                    HasAtmosphere = false,
                    SOI = 2406401 //.4
                };

                Bodies[13] = new OrbitingBody
                {
                    Name = "TYLO",
                    Radius = 600000,
                    GM = 2825280000000,
                    HasAtmosphere = false,
                    SOI = 10856518
                };

                Bodies[14] = new OrbitingBody
                {
                    Name = "BOP",
                    Radius = 65000,
                    GM = 2486834900,
                    HasAtmosphere = false,
                    SOI = 1221061 //0.9
                };

                Bodies[15] = new OrbitingBody
                {
                    Name = "POL",
                    Radius = 44000,
                    GM = 721702080,
                    HasAtmosphere = false,
                    SOI = 1042139 // 8.9
                };

                Bodies[16] = new OrbitingBody
                {
                    Name = "EELOO",
                    Radius = 210000,
                    GM = 74410815000,
                    HasAtmosphere = false,
                    SOI = 119082940
                };
            }
        }
    }
}