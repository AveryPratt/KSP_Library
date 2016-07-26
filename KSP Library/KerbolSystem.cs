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
                    SOI = 9646663,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 5263138304,
                    Eccentricity = .2,
                    Inclination = 7,
                    ArgPer = 15,
                    LongAsc = 70
                };

                Bodies[2] = new OrbitingBody
                {
                    Name = "EVE",
                    Radius = 700000,
                    GM = 8171730200000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 90000,
                    SOI = 85109365,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 9832684544,
                    Eccentricity = .01,
                    Inclination = 2.1,
                    ArgPer = 0,
                    LongAsc = 15
                };

                Bodies[3] = new OrbitingBody
                {
                    Name = "GILLY",
                    Radius = 13000,
                    GM = 8289450, //49.8
                    HasAtmosphere = false,
                    SOI = 126123, //.27

                    ParentBody = Bodies[2],
                    SemiMajorAxis = 31500000,
                    Eccentricity = .55,
                    Inclination = 12,
                    ArgPer = 10,
                    LongAsc = 80
                };

                Bodies[4] = new OrbitingBody
                {
                    Name = "KERBIN",
                    Radius = 600000,
                    GM = 3531600000000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 70000,
                    SOI = 84159286,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 13599840256,
                    Eccentricity = 0,
                    Inclination = 0,
                    ArgPer = 0,
                    LongAsc = 0
                };

                Bodies[5] = new OrbitingBody
                {
                    Name = "MUN",
                    Radius = 200000,
                    GM = 65138398000,
                    HasAtmosphere = false,
                    SOI = 2429559, //.1

                    ParentBody = Bodies[4],
                    SemiMajorAxis = 12000000,
                    Eccentricity = 0,
                    Inclination = 0,
                    ArgPer = 0,
                    LongAsc = 0
                };

                Bodies[6] = new OrbitingBody
                {
                    Name = "MINMUS",
                    Radius = 60000,
                    GM = 1765800000,
                    HasAtmosphere = false,
                    SOI = 2247428, //.4

                    ParentBody = Bodies[4],
                    SemiMajorAxis = 47000000,
                    Eccentricity = 0,
                    Inclination = 6,
                    ArgPer = 38,
                    LongAsc = 78
                };

                Bodies[7] = new OrbitingBody
                {
                    Name = "DUNA",
                    Radius = 320000,
                    GM = 301363210000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 50000,
                    SOI = 47921949,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 20726155264,
                    Eccentricity = .05,
                    Inclination = .06,
                    ArgPer = 0,
                    LongAsc = 135.5
                };

                Bodies[8] = new OrbitingBody
                {
                    Name = "IKE",
                    Radius = 130000,
                    GM = 18568369000,
                    HasAtmosphere = false,
                    SOI = 1049599, //8.9

                    ParentBody = Bodies[7],
                    SemiMajorAxis = 3200000,
                    Eccentricity = .03,
                    Inclination = .2,
                    ArgPer = 0,
                    LongAsc = 0
                };

                Bodies[9] = new OrbitingBody
                {
                    Name = "DRES",
                    Radius = 138000,
                    GM = 21484489000,
                    HasAtmosphere = false,
                    SOI = 32832840,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 40839348203,
                    Eccentricity = .14,
                    Inclination = 5,
                    ArgPer = 90,
                    LongAsc = 280
                };

                Bodies[10] = new OrbitingBody
                {
                    Name = "JOOL",
                    Radius = 6000000,
                    GM = 282528000000000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 200000,
                    SOI = 2455985200,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 68773560320,
                    Eccentricity = .05,
                    Inclination = 1.304,
                    ArgPer = 0,
                    LongAsc = 52
                };

                Bodies[11] = new OrbitingBody
                {
                    Name = "LAYTHE",
                    Radius = 500000,
                    GM = 1962000000000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 50000,
                    SOI = 3723646, //5.8

                    ParentBody = Bodies[10],
                    SemiMajorAxis = 27184000,
                    Eccentricity = 0,
                    Inclination = 0,
                    ArgPer = 0,
                    LongAsc = 0
                };

                Bodies[12] = new OrbitingBody
                {
                    Name = "VALL",
                    Radius = 300000,
                    GM = 207481500000,
                    HasAtmosphere = false,
                    SOI = 2406401, //.4

                    ParentBody = Bodies[10],
                    SemiMajorAxis = 43152000,
                    Eccentricity = 0,
                    Inclination = 0,
                    ArgPer = 0,
                    LongAsc = 0
                };

                Bodies[13] = new OrbitingBody
                {
                    Name = "TYLO",
                    Radius = 600000,
                    GM = 2825280000000,
                    HasAtmosphere = false,
                    SOI = 10856518,

                    ParentBody = Bodies[10],
                    SemiMajorAxis = 68500000,
                    Eccentricity = 0,
                    Inclination = .025,
                    ArgPer = 0,
                    LongAsc = 0
                };

                Bodies[14] = new OrbitingBody
                {
                    Name = "BOP",
                    Radius = 65000,
                    GM = 2486834900,
                    HasAtmosphere = false,
                    SOI = 1221061, //0.9

                    ParentBody = Bodies[10],
                    SemiMajorAxis = 128500000,
                    Eccentricity = .24,
                    Inclination = 15,
                    ArgPer = 25,
                    LongAsc = 10
                };

                Bodies[15] = new OrbitingBody
                {
                    Name = "POL",
                    Radius = 44000,
                    GM = 721702080,
                    HasAtmosphere = false,
                    SOI = 1042139, // 8.9

                    ParentBody = Bodies[10],
                    SemiMajorAxis = 179890000,
                    Eccentricity = .17,
                    Inclination = 4.25,
                    ArgPer = 15,
                    LongAsc = 2
                };

                Bodies[16] = new OrbitingBody
                {
                    Name = "EELOO",
                    Radius = 210000,
                    GM = 74410815000,
                    HasAtmosphere = false,
                    SOI = 119082940,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 90118820000,
                    Eccentricity = .26,
                    Inclination = 6.15,
                    ArgPer = 260,
                    LongAsc = 50
                };
            }
        }
    }
}