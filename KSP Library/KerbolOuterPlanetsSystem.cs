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
                Bodies[0] = new Star
                {
                    Name = "KERBOL",
                    Radius = 261600000,
                    GM = BigGM.ENotation(1.1723328, 18),
                    //GM = 1172332800000000000
                    HasAtmosphere = true,
                    AtmosphereHeight = 600000,
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
                    Name = "SARNUS",
                    Radius = 5300000,
                    GM = 82117744000000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 580000,
                    SOI = 2740501100,
                    
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 125798522368,
                    Eccentricity = .05,
                    Inclination = 2.02,
                    ArgPer = 0,
                    LongAsc = 184
                };

                Bodies[17] = new OrbitingBody
                {
                    Name = "HALE",
                    Radius = 6000,
                    GM = 812268,
                    HasAtmosphere = false,
                    SOI = 6589, //8.8129

                    ParentBody = Bodies[16],
                    SemiMajorAxis = 10488231,
                    Eccentricity = 0,
                    Inclination = 1,
                    ArgPer = 0,
                    LongAsc = 55
                };

                Bodies[18] = new OrbitingBody
                {
                    Name = "OVOK",
                    Radius = 26000,
                    GM = 13263120,
                    HasAtmosphere = false,
                    SOI = 23364, //.318

                    ParentBody = Bodies[16],
                    SemiMajorAxis = 12169413,
                    Eccentricity = .01,
                    Inclination = 1.5,
                    ArgPer = 0,
                    LongAsc = 55
                };

                Bodies[19] = new OrbitingBody
                {
                    Name = "EELOO",
                    Radius = 210000,
                    GM = 74410815000,
                    HasAtmosphere = false,
                    SOI = 1158908, //7.8

                    ParentBody = Bodies[16],
                    SemiMajorAxis = 19105978,
                    Eccentricity = 0,
                    Inclination = 2.3,
                    ArgPer = 260,
                    LongAsc = 55
                };

                Bodies[20] = new OrbitingBody
                {
                    Name = "SLATE",
                    Radius = 540000,
                    GM = 2431506600000,
                    HasAtmosphere = false,
                    SOI = 10421088,

                    ParentBody = Bodies[16],
                    SemiMajorAxis = 42592946,
                    Eccentricity = .04,
                    Inclination = 2.3,
                    ArgPer = 0,
                    LongAsc = 55
                };

                Bodies[21] = new OrbitingBody
                {
                    Name = "TEKTO",
                    Radius = 280000,
                    GM = 192506730000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 95000,
                    SOI = 8637005, //.2

                    ParentBody = Bodies[16],
                    SemiMajorAxis = 97355304,
                    Eccentricity = .03,
                    Inclination = 9.4,
                    ArgPer = 0,
                    LongAsc = 55
                };

                Bodies[22] = new OrbitingBody
                {
                    Name = "URLUM",
                    Radius = 2177000,
                    GM = 11948654000000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 325000,
                    SOI = 2526107000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 254317012787,
                    Eccentricity = .05,
                    Inclination = .64,
                    ArgPer = 0,
                    LongAsc = 61
                };

                Bodies[23] = new OrbitingBody
                {
                    Name = "POLTA",
                    Radius = 220000,
                    GM = 90212760000,
                    HasAtmosphere = false,
                    SOI = 1661115, //4.9

                    ParentBody = Bodies[22],
                    SemiMajorAxis = 11727895,
                    Eccentricity = 0,
                    Inclination = 2.45,
                    ArgPer = 60,
                    LongAsc = 40
                };

                Bodies[24] = new OrbitingBody
                {
                    Name = "PRIAX",
                    Radius = 74000,
                    GM = 338433230,
                    HasAtmosphere = false,
                    SOI = 446768, //7.6

                    ParentBody = Bodies[22],
                    SemiMajorAxis = 11727895,
                    Eccentricity = 0,
                    Inclination = 2.5,
                    ArgPer = 0,
                    LongAsc = 40
                };

                Bodies[25] = new OrbitingBody
                {
                    Name = "WAL",
                    Radius = 370000,
                    GM = 496905930000,
                    HasAtmosphere = false,
                    SOI = 18933505,

                    ParentBody = Bodies[22],
                    SemiMajorAxis = 67553668,
                    Eccentricity = .02,
                    Inclination = 1.9,
                    ArgPer = 0,
                    LongAsc = 40
                };

                Bodies[26] = new OrbitingBody
                {
                    Name = "TAL",
                    Radius = 22000,
                    GM = 21366180,
                    HasAtmosphere = false,
                    SOI = 139967, //6.65

                    ParentBody = Bodies[25],
                    SemiMajorAxis = 3109163,
                    Eccentricity = 0,
                    Inclination = 1.9,
                    ArgPer = 0,
                    LongAsc = 40
                };

                Bodies[27] = new OrbitingBody
                {
                    Name = "NEIDON",
                    Radius = 2145000,
                    GM = 14172721000000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 260000,
                    SOI = 4416327100,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 409355191706,
                    Eccentricity = .01,
                    Inclination = 1.27,
                    ArgPer = 0,
                    LongAsc = 259
                };

                Bodies[28] = new OrbitingBody
                {
                    Name = "THATMO",
                    Radius = 286000,
                    GM = 186161150000,
                    HasAtmosphere = true,
                    AtmosphereHeight = 35000,
                    SOI = 5709379, //.1

                    ParentBody = Bodies[27],
                    SemiMajorAxis = 32300895,
                    Eccentricity = 0,
                    Inclination = 161.1,
                    ArgPer = 0,
                    LongAsc = 66
                };

                Bodies[29] = new OrbitingBody
                {
                    Name = "NISSEE",
                    Radius = 30000,
                    GM = 39730500,
                    HasAtmosphere = false,
                    SOI = 7366477, //6.6

                    ParentBody = Bodies[27],
                    SemiMajorAxis = 487743514,
                    Eccentricity = .72,
                    Inclination = 29.56,
                    ArgPer = 0,
                    LongAsc = 66
                };

                Bodies[30] = new OrbitingBody
                {
                    Name = "PLOCK",
                    Radius = 189000,
                    GM = 51862605000,
                    HasAtmosphere = false,
                    SOI = 61284606,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 535833706086,
                    Eccentricity = .26,
                    Inclination = 6.15,
                    ArgPer = 50,
                    LongAsc = 260
                };

                Bodies[31] = new OrbitingBody
                {
                    Name = "KAREN",
                    Radius = 85050,
                    GM = 468340350,
                    HasAtmosphere = false,
                    SOI = 939354, //.32

                    ParentBody = Bodies[30],
                    SemiMajorAxis = 2457800,
                    Eccentricity = 0,
                    Inclination = 0,
                    ArgPer = 50,
                    LongAsc = 260
                };
            }
        }
    }
}