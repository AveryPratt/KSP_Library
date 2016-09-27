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
        public class RealSolarSystemExt : SolarSystem
        {
            public RealSolarSystemExt()
            {
                Bodies = new Body[41];
                Bodies[0] = new Star
                {
                    Name = "SUN",
                    Radius = 695700000,
                    GM = BigGM.ENotation(1.32712440018, 20)
                    //GM = 132712440018000000000
                };

                Bodies[1] = new FixedOrbitingBody
                {
                    Name = "MERCURY",
                    Radius = 2440000,
                    GM = 22032000000000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 57909050000,
                    Eccentricity = .205630,
                    Inclination = 7.005,
                    ArgPer = 29.124,
                    LongAsc = 48.331,

                    //AxialTilt = .034,
                };

                Bodies[2] = new FixedOrbitingBody
                {
                    Name = "VENUS",
                    Radius = 6052000,
                    GM = 324859000000000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 108208000000,
                    Eccentricity = .006772,
                    Inclination = 3.39458,
                    ArgPer = 54.884,
                    LongAsc = 76.680,

                    //AxialTilt = 177.36,
                };

                Bodies[3] = new FixedOrbitingBody
                {
                    Name = "EARTH",
                    Radius = 6374327,
                    GM = 398600441800000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 149598023000,
                    Eccentricity = .0167086,
                    Inclination = 0,
                    ArgPer = 114.20783,
                    LongAsc = 348.73936, //-11.26064

                    //AxialTilt = 23.4392811,
                };

                Bodies[4] = new FixedOrbitingBody
                {
                    Name = "MOON",
                    Radius = 1737000,
                    GM = 4904869500000,

                    ParentBody = Bodies[3],
                    SemiMajorAxis = 384399000,
                    Eccentricity = .0549,
                    Inclination = 5.145
                };

                Bodies[5] = new FixedOrbitingBody
                {
                    Name = "MARS",
                    Radius = 3390000,
                    GM = 42828370000000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 227939200000,
                    Eccentricity = .0934,
                    Inclination = 1.850,
                    ArgPer = 286.502,
                    LongAsc = 49.558,

                    //AxialTilt = 25.19,
                };

                Bodies[6] = new FixedOrbitingBody
                {
                    Name = "PHOBOS",
                    Radius = 11266,
                    GM = 711390,

                    ParentBody = Bodies[5],
                    SemiMajorAxis = 9376000,
                    Eccentricity = .0151,
                    Inclination = 26.04
                };

                Bodies[7] = new FixedOrbitingBody
                {
                    Name = "DEIMOS",
                    Radius = 6200,
                    GM = 98523,

                    ParentBody = Bodies[5],
                    SemiMajorAxis = 23463200,
                    Eccentricity = .00033,
                    Inclination = 27.58
                };

                Bodies[8] = new FixedOrbitingBody
                {
                    Name = "VESTA",
                    Radius = 262700,
                    GM = 17290939500,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 353318755000,
                    Eccentricity = .08874,
                    Inclination = 7.14043,
                    ArgPer = 151.19853,
                    LongAsc = 103.85136
                };

                Bodies[9] = new FixedOrbitingBody
                {
                    Name = "CERES",
                    Radius = 473000,
                    GM = 62689633440,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 414010000000,
                    Eccentricity = .075823,
                    Inclination = 10.593,
                    ArgPer = 72.5220,
                    LongAsc = 80.3293
                };

                Bodies[10] = new FixedOrbitingBody
                {
                    Name = "PALLAS",
                    Radius = 512000,
                    GM = 14082308800,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 414700000000,
                    Eccentricity = .23127363,
                    Inclination = 34.840998,
                    ArgPer = 309.930328,
                    LongAsc = 173.096248
                };

                Bodies[11] = new FixedOrbitingBody
                {
                    Name = "INTERAMNIA",
                    Radius = 158310,
                    GM = 2602891200,

                    ParentBody = Bodies[0],
                    SemiMajorAxis =457400000000,
                    Eccentricity =.15431,
                    Inclination = 17.309,
                    ArgPer = 95.208,
                    LongAsc = 280.30
                };

                Bodies[12] = new FixedOrbitingBody
                {
                    Name = "HYGIEA",
                    Radius = 431000,
                    GM = 5786427360,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 470051470000,
                    Eccentricity = .1146,
                    Inclination = 3.8377,
                    ArgPer = 312.10,
                    LongAsc = 283.41
                };

                Bodies[8] = new FixedOrbitingBody
                {
                    Name = "JUPITER",
                    Radius = 69911000,
                    GM = 126686534000000000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 778299000000,
                    Eccentricity = .048498,
                    Inclination = 1.303,
                    ArgPer = 273.867,
                    LongAsc = 100.464,

                    //AxialTilt = 3.13,
                };

                Bodies[9] = new FixedOrbitingBody
                {
                    Name = "IO",
                    Radius = 1821600,
                    GM = 5961246900000,

                    ParentBody = Bodies[8],
                    SemiMajorAxis = 57909050000,
                    Eccentricity = .0041,
                    Inclination = 2.213
                };

                Bodies[10] = new FixedOrbitingBody
                {
                    Name = "EUROPA",
                    Radius = 1560800,
                    GM = 3203454300000,

                    ParentBody = Bodies[8],
                    SemiMajorAxis = 670900000,
                    Eccentricity = .009,
                    Inclination = 1.791
                };

                Bodies[11] = new FixedOrbitingBody
                {
                    Name = "GANYMEDE",
                    Radius = 2634100,
                    GM = 9890319200000,

                    ParentBody = Bodies[8],
                    SemiMajorAxis = 1070400000,
                    Eccentricity = .0013,
                    Inclination = 2.214
                };

                Bodies[12] = new FixedOrbitingBody
                {
                    Name = "CALLISTO",
                    Radius = 2410300,
                    GM = 7180896300000,

                    ParentBody = Bodies[8],
                    SemiMajorAxis = 1882700000,
                    Eccentricity = .0074,
                    Inclination = 2.017
                };

                Bodies[13] = new FixedOrbitingBody
                {
                    Name = "SATURN",
                    Radius = 58232000,
                    GM = 3793118700000000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 1429390000000,
                    Eccentricity = .05555,
                    Inclination = 2.485240,
                    ArgPer = 339.392,
                    LongAsc = 113.665,

                    //AxialTilt = 26.73,
                };

                Bodies[14] = new FixedOrbitingBody
                {
                    Name = "MIMAS",
                    Radius = 198200,
                    GM = 2502312814,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 185539000,
                    Eccentricity = .0196,
                    Inclination = 1.574 // to Saturn's Equator
                };

                Bodies[15] = new FixedOrbitingBody
                {
                    Name = "ENCELADUS",
                    Radius = 252100,
                    GM = 7209474698,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 237948000,
                    Eccentricity = .0047,
                    Inclination = 0.019 // to Saturn's Equator
                };

                Bodies[16] = new FixedOrbitingBody
                {
                    Name = "TETHYS",
                    Radius = 531100,
                    GM = 41209040219,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 294619000,
                    Eccentricity = .0001,
                    Inclination = 1.12 // to Saturn's Equator
                };

                Bodies[17] = new FixedOrbitingBody
                {
                    Name = "DIONE",
                    Radius = 561400,
                    GM = 73111342842,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 377396000,
                    Eccentricity = .0022,
                    Inclination = .019 // to Saturn's Equator
                };

                Bodies[18] = new FixedOrbitingBody
                {
                    Name = "RHEA",
                    Radius = 763800,
                    GM = 153938856534,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 527108000,
                    Eccentricity = .0012583,
                    Inclination = .345 // to Saturn's Equator
                };

                Bodies[19] = new FixedOrbitingBody
                {
                    Name = "TITAN",
                    Radius = 2575500,
                    GM = 8977972400000,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 1221870000,
                    Eccentricity = .0288,
                    Inclination = .34854 // to Saturn's Equator
                };

                Bodies[20] = new FixedOrbitingBody
                {
                    Name = "IAPETUS",
                    Radius = 734500,
                    GM = 120509524408,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 3560820000,
                    Eccentricity = .0286125,
                    Inclination = 17.28 // to ecliptic
                    // 15.47 to Saturn's equator
                };

                Bodies[21] = new FixedOrbitingBody
                {
                    Name = "URANUS",
                    Radius = 25362000,
                    GM = 5793939000000000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 2875040000000,
                    Eccentricity = .046381,
                    Inclination = .773,
                    ArgPer = 96.998857,
                    LongAsc = 74.006,

                    //AxialTilt = 97.77,
                };

                Bodies[22] = new FixedOrbitingBody
                {
                    Name = "MIRANDA",
                    Radius = 235800,
                    GM = 4398218720,

                    ParentBody = Bodies[21],
                    SemiMajorAxis = 129390000,
                    Eccentricity = .0013,
                    Inclination = 4.232 // to Uranus's Equator
                };

                Bodies[23] = new FixedOrbitingBody
                {
                    Name = "ARIEL",
                    Radius = 578900,
                    GM = 90300302400,

                    ParentBody = Bodies[21],
                    SemiMajorAxis = 191020000,
                    Eccentricity = .0012,
                    Inclination = .260 // to Uranus's Equator
                };

                Bodies[24] = new FixedOrbitingBody
                {
                    Name = "UMBRIEL",
                    Radius = 584700,
                    GM = 78220217600,

                    ParentBody = Bodies[21],
                    SemiMajorAxis = 266000000,
                    Eccentricity = .0039,
                    Inclination = .128 // to Uranus's Equator
                };

                Bodies[25] = new FixedOrbitingBody
                {
                    Name = "TITANIA",
                    Radius = 788400,
                    GM = 235394801600,

                    ParentBody = Bodies[21],
                    SemiMajorAxis = 435910000,
                    Eccentricity = .0011,
                    Inclination = .340 // to Uranus's Equator
                };

                Bodies[26] = new FixedOrbitingBody
                {
                    Name = "OBERON",
                    Radius = 761400,
                    GM = 201156771200,

                    ParentBody = Bodies[21],
                    SemiMajorAxis = 583520000,
                    Eccentricity = .0014,
                    Inclination = .058 // to Uranus's Equator
                };

                Bodies[27] = new FixedOrbitingBody
                {
                    Name = "NEPTUNE",
                    Radius = 24622000,
                    GM = 6836529000000000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 4504450000000,
                    Eccentricity = .009456,
                    Inclination = 1.767975,
                    ArgPer = 276.336,
                    LongAsc = 131.784,

                    //AxialTilt = 28.32,
                };

                Bodies[28] = new FixedOrbitingBody
                {
                    Name = "PROTEUS",
                    Radius = 210000,
                    GM = 2936595200,

                    ParentBody = Bodies[27],
                    SemiMajorAxis = 117647000,
                    Eccentricity = .00053,
                    Inclination = .524 // to Neptune's Equator
                };

                Bodies[29] = new FixedOrbitingBody
                {
                    Name = "TRITON",
                    Radius = 1353400,
                    GM = 1428253100000,

                    ParentBody = Bodies[27],
                    SemiMajorAxis = 354759000,
                    Eccentricity = .000016,
                    Inclination = 129.812 // to ecliptic
                    // 156.885 to Neptune's Equator
                };

                Bodies[30] = new FixedOrbitingBody
                {
                    Name = "PLUTO",
                    Radius = 1187000,
                    GM = 871000000000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 5915000000000,
                    Eccentricity = .24905,
                    Inclination = 17.1405,
                    ArgPer = 113.834,
                    LongAsc = 110.299,

                    //AxialTilt = 119.591,
                };

                Bodies[31] = new FixedOrbitingBody
                {
                    Name = "CHARON",
                    Radius = 606000,
                    GM = 105850908800,

                    ParentBody = Bodies[30],
                    SemiMajorAxis = 19571000, // to Pluto's center of mass
                    // 17536000 to system barycenter
                    Eccentricity = .00,
                    Inclination = 112.783, // to ecliptic
                    // 119.591 to Pluto's Orbit
                    LongAsc = 223.046
                };

                Bodies[38] = new FixedOrbitingBody
                {
                    Name = "HAUMEA",
                    Radius = 620000,
                    GM = 267363644800,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 6465321000000,
                    Eccentricity = .19126,
                    Inclination = 28.19,
                    ArgPer = 240.20,
                    LongAsc = 121.79
                };

                Bodies[39] = new FixedOrbitingBody
                {
                    Name = "MAKEMAKE",
                    Radius = 715000,
                    GM = 293659520000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 6838867000000,
                    Eccentricity = .15586,
                    Inclination = 29.00685,
                    ArgPer = 297.240,
                    LongAsc = 79.3659
                };

                Bodies[40] = new FixedOrbitingBody
                {
                    Name = "ERIS",
                    Radius = 1163000,
                    GM = 1108000000000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 10139890000000,
                    Eccentricity = .44068,
                    Inclination = 44.0445,
                    ArgPer = 150.977,
                    LongAsc = 35.9531
                };
            }
        }
    }
}
