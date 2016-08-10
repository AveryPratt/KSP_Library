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
                Bodies = new Body[32];
                Bodies[0] = new Star
                {
                    ID = 1,
                    Name = "KERBOL",
                    Radius = 261600000,
                    GM = BigGM.ENotation(1.1723328, 18), //1172332800000000000
                    AtmosphereHeight = 600000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 432000
                };

                Bodies[1] = new OrbitingBody
                {
                    ID = 2,
                    Name = "MOHO",
                    Radius = 250000,
                    GM = 168609380000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 1210000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 5263138304,
                    Eccentricity = .2,
                    Inclination = 7,
                    ArgPer = 15,
                    LongAsc = 70,
                    SOIRad = 9646663
                };

                Bodies[2] = new OrbitingBody
                {
                    ID = 3,
                    Name = "EVE",
                    Radius = 700000,
                    GM = 8171730200000,
                    AtmosphereHeight = 90000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 80500,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 9832684544,
                    Eccentricity = .01,
                    Inclination = 2.1,
                    ArgPer = 0,
                    LongAsc = 15,
                    SOIRad = 85109365
                };

                Bodies[3] = new OrbitingBody
                {
                    ID = 4,
                    Name = "GILLY",
                    Radius = 13000,
                    GM = 8289450, //49.8
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 28255,

                    ParentBody = Bodies[2],
                    SemiMajorAxis = 31500000,
                    Eccentricity = .55,
                    Inclination = 12,
                    ArgPer = 10,
                    LongAsc = 80,
                    SOIRad = 126123 //.27
                };

                Bodies[4] = new OrbitingBody
                {
                    ID = 5,
                    Name = "KERBIN",
                    Radius = 600000,
                    GM = 3531600000000,
                    AtmosphereHeight = 70000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 21549.425,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 13599840256,
                    Eccentricity = 0,
                    Inclination = 0,
                    ArgPer = 0,
                    LongAsc = 0,
                    SOIRad = 84159286
                };

                Bodies[5] = new OrbitingBody
                {
                    ID = 6,
                    Name = "MUN",
                    Radius = 200000,
                    GM = 65138398000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 138984.38,

                    ParentBody = Bodies[4],
                    SemiMajorAxis = 12000000,
                    Eccentricity = 0,
                    Inclination = 0,
                    ArgPer = 0,
                    LongAsc = 0,
                    SOIRad = 2429559 //.1
                };

                Bodies[6] = new OrbitingBody
                {
                    ID = 7,
                    Name = "MINMUS",
                    Radius = 60000,
                    GM = 1765800000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 40400,

                    ParentBody = Bodies[4],
                    SemiMajorAxis = 47000000,
                    Eccentricity = 0,
                    Inclination = 6,
                    ArgPer = 38,
                    LongAsc = 78,
                    SOIRad = 2247428 //.4
                };

                Bodies[7] = new OrbitingBody
                {
                    ID = 8,
                    Name = "DUNA",
                    Radius = 320000,
                    GM = 301363210000,
                    AtmosphereHeight = 50000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 65517.859,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 20726155264,
                    Eccentricity = .05,
                    Inclination = .06,
                    ArgPer = 0,
                    LongAsc = 135.5,
                    SOIRad = 47921949
                };

                Bodies[8] = new OrbitingBody
                {
                    ID = 9,
                    Name = "IKE",
                    Radius = 130000,
                    GM = 18568369000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 65517.862,

                    ParentBody = Bodies[7],
                    SemiMajorAxis = 3200000,
                    Eccentricity = .03,
                    Inclination = .2,
                    ArgPer = 0,
                    LongAsc = 0,
                    SOIRad = 1049599 //8.9
                };

                Bodies[9] = new OrbitingBody
                {
                    ID = 10,
                    Name = "DRES",
                    Radius = 138000,
                    GM = 21484489000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 34800,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 40839348203,
                    Eccentricity = .14,
                    Inclination = 5,
                    ArgPer = 90,
                    LongAsc = 280,
                    SOIRad = 32832840
                };

                Bodies[10] = new OrbitingBody
                {
                    ID = 11,
                    Name = "JOOL",
                    Radius = 6000000,
                    GM = 282528000000000,
                    AtmosphereHeight = 200000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 36000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 68773560320,
                    Eccentricity = .05,
                    Inclination = 1.304,
                    ArgPer = 0,
                    LongAsc = 52,
                    SOIRad = 2455985200
                };

                Bodies[11] = new OrbitingBody
                {
                    ID = 12,
                    Name = "LAYTHE",
                    Radius = 500000,
                    GM = 1962000000000,
                    AtmosphereHeight = 50000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 52980.879,

                    ParentBody = Bodies[10],
                    SemiMajorAxis = 27184000,
                    Eccentricity = 0,
                    Inclination = 0,
                    ArgPer = 0,
                    LongAsc = 0,
                    SOIRad = 3723646 //5.8
                };

                Bodies[12] = new OrbitingBody
                {
                    ID = 13,
                    Name = "VALL",
                    Radius = 300000,
                    GM = 207481500000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 105962.09,

                    ParentBody = Bodies[10],
                    SemiMajorAxis = 43152000,
                    Eccentricity = 0,
                    Inclination = 0,
                    ArgPer = 0,
                    LongAsc = 0,
                    SOIRad = 2406401 //.4
                };

                Bodies[13] = new OrbitingBody
                {
                    ID = 14,
                    Name = "TYLO",
                    Radius = 600000,
                    GM = 2825280000000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 211926.36,

                    ParentBody = Bodies[10],
                    SemiMajorAxis = 68500000,
                    Eccentricity = 0,
                    Inclination = .025,
                    ArgPer = 0,
                    LongAsc = 0,
                    SOIRad = 10856518
                };

                Bodies[14] = new OrbitingBody
                {
                    ID = 15,
                    Name = "BOP",
                    Radius = 65000,
                    GM = 2486834900,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 544507.43,

                    ParentBody = Bodies[10],
                    SemiMajorAxis = 128500000,
                    Eccentricity = .24,
                    Inclination = 15,
                    ArgPer = 25,
                    LongAsc = 10,
                    SOIRad = 1221061 //0.9
                };

                Bodies[15] = new OrbitingBody
                {
                    ID = 16,
                    Name = "POL",
                    Radius = 44000,
                    GM = 721702080,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 901902.62,

                    ParentBody = Bodies[10],
                    SemiMajorAxis = 179890000,
                    Eccentricity = .17,
                    Inclination = 4.25,
                    ArgPer = 15,
                    LongAsc = 2,
                    SOIRad = 1042139 // 8.9
                };

                Bodies[16] = new OrbitingBody
                {
                    ID = 17,
                    Name = "SARNUS",
                    Radius = 5300000,
                    GM = 82117744000000,
                    AtmosphereHeight = 580000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 285000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 125798522368,
                    Eccentricity = .05,
                    Inclination = 2.02,
                    ArgPer = 0,
                    LongAsc = 184,
                    SOIRad = 2740501100
                };

                Bodies[17] = new OrbitingBody
                {
                    ID = 18,
                    Name = "HALE",
                    Radius = 6000,
                    GM = 812268,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 23551.292,

                    ParentBody = Bodies[16],
                    SemiMajorAxis = 10488231,
                    Eccentricity = 0,
                    Inclination = 1,
                    ArgPer = 0,
                    LongAsc = 55,
                    SOIRad = 6589 //8.8129
                };

                Bodies[18] = new OrbitingBody
                {
                    ID = 19,
                    Name = "OVOK",
                    Radius = 26000,
                    GM = 13263120,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 29435.120,

                    ParentBody = Bodies[16],
                    SemiMajorAxis = 12169413,
                    Eccentricity = .01,
                    Inclination = 1.5,
                    ArgPer = 0,
                    LongAsc = 55,
                    SOIRad = 23364 //.318
                };

                Bodies[19] = new OrbitingBody
                {
                    ID = 20,
                    Name = "EELOO",
                    Radius = 210000,
                    GM = 74410815000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 57904.894,

                    ParentBody = Bodies[16],
                    SemiMajorAxis = 19105978,
                    Eccentricity = 0,
                    Inclination = 2.3,
                    ArgPer = 260,
                    LongAsc = 55,
                    SOIRad = 1158908 //7.8
                };

                Bodies[20] = new OrbitingBody
                {
                    ID = 21,
                    Name = "SLATE",
                    Radius = 540000,
                    GM = 2431506600000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 192738.24,

                    ParentBody = Bodies[16],
                    SemiMajorAxis = 42592946,
                    Eccentricity = .04,
                    Inclination = 2.3,
                    ArgPer = 0,
                    LongAsc = 55,
                    SOIRad = 10421088
                };

                Bodies[21] = new OrbitingBody
                {
                    ID = 22,
                    Name = "TEKTO",
                    Radius = 280000,
                    GM = 192506730000,
                    AtmosphereHeight = 95000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 666040.73,

                    ParentBody = Bodies[16],
                    SemiMajorAxis = 97355304,
                    Eccentricity = .03,
                    Inclination = 9.4,
                    ArgPer = 0,
                    LongAsc = 55,
                    SOIRad = 8637005 //.2
                };

                Bodies[22] = new OrbitingBody
                {
                    ID = 23,
                    Name = "URLUM",
                    Radius = 2177000,
                    GM = 11948654000000,
                    AtmosphereHeight = 325000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 41000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 254317012787,
                    Eccentricity = .05,
                    Inclination = .64,
                    ArgPer = 0,
                    LongAsc = 61,
                    SOIRad = 2526107000
                };

                Bodies[23] = new OrbitingBody
                {
                    ID = 24,
                    Name = "POLTA",
                    Radius = 220000,
                    GM = 90212760000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 73004.642,

                    ParentBody = Bodies[22],
                    SemiMajorAxis = 11727895,
                    Eccentricity = 0,
                    Inclination = 2.45,
                    ArgPer = 60,
                    LongAsc = 40,
                    SOIRad = 1661115 //4.9
                };

                Bodies[24] = new OrbitingBody
                {
                    ID = 25,
                    Name = "PRIAX",
                    Radius = 74000,
                    GM = 338433230,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 73004.642,

                    ParentBody = Bodies[22],
                    SemiMajorAxis = 11727895,
                    Eccentricity = 0,
                    Inclination = 2.5,
                    ArgPer = 0,
                    LongAsc = 40,
                    SOIRad = 446768 //7.6
                };

                Bodies[25] = new OrbitingBody
                {
                    ID = 26,
                    Name = "WAL",
                    Radius = 370000,
                    GM = 496905930000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 1009238.4,

                    ParentBody = Bodies[22],
                    SemiMajorAxis = 67553668,
                    Eccentricity = .02,
                    Inclination = 1.9,
                    ArgPer = 0,
                    LongAsc = 40,
                    SOIRad = 18933505
                };

                Bodies[26] = new OrbitingBody
                {
                    ID = 27,
                    Name = "TAL",
                    Radius = 22000,
                    GM = 21366180,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 48866.138,

                    ParentBody = Bodies[25],
                    SemiMajorAxis = 3109163,
                    Eccentricity = 0,
                    Inclination = 1.9,
                    ArgPer = 0,
                    LongAsc = 40,
                    SOIRad = 139967 //6.65
                };

                Bodies[27] = new OrbitingBody
                {
                    ID = 28,
                    Name = "NEIDON",
                    Radius = 2145000,
                    GM = 14172721000000,
                    AtmosphereHeight = 260000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 40250,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 409355191706,
                    Eccentricity = .01,
                    Inclination = 1.27,
                    ArgPer = 0,
                    LongAsc = 259,
                    SOIRad = 4416327100
                };

                Bodies[28] = new OrbitingBody
                {
                    ID = 29,
                    Name = "THATMO",
                    Radius = 286000,
                    GM = 186161150000,
                    AtmosphereHeight = 35000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 306390.35,

                    ParentBody = Bodies[27],
                    SemiMajorAxis = 32300895,
                    Eccentricity = 0,
                    Inclination = 161.1,
                    ArgPer = 0,
                    LongAsc = 66,
                    SOIRad = 5709379 //.1
                };

                Bodies[29] = new OrbitingBody
                {
                    ID = 30,
                    Name = "NISSEE",
                    Radius = 30000,
                    GM = 39730500,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 27924.872,

                    ParentBody = Bodies[27],
                    SemiMajorAxis = 487743514,
                    Eccentricity = .72,
                    Inclination = 29.56,
                    ArgPer = 0,
                    LongAsc = 66,
                    SOIRad = 7366477 //6.6
                };

                Bodies[30] = new OrbitingBody
                {
                    ID = 31,
                    Name = "PLOCK",
                    Radius = 189000,
                    GM = 51862605000,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 106309.61,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 535833706086,
                    Eccentricity = .26,
                    Inclination = 6.15,
                    ArgPer = 50,
                    LongAsc = 260,
                    SOIRad = 61284606
                };

                Bodies[31] = new OrbitingBody
                {
                    ID = 32,
                    Name = "KAREN",
                    Radius = 85050,
                    GM = 468340350,
                    EqPlane = new Plane(0, 0, 0, 0),
                    SidRotPeriod = 106309.61,

                    ParentBody = Bodies[30],
                    SemiMajorAxis = 2457800,
                    Eccentricity = 0,
                    Inclination = 0,
                    ArgPer = 50,
                    LongAsc = 260,
                    SOIRad = 939354 //.32
                };
            }
        }
    }
}