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
                Bodies = new Body[32];
                Bodies[0] = new Star
                {
                    Name = "SUN",
                    Radius = 695700000,
                    GM = BigGM.ENotation(1.32712440018, 20),
                    NPRA = 286.13,
                    NPDecl = 63.87,
                    SidRotPeriod = 2164320 // at equator
                    //GM = 132712440018000000000
                };

                Bodies[1] = new OrbitingBody
                {
                    Name = "MERCURY",
                    Radius = 2440000,
                    GM = 22032000000000,
                    NPRA = 281.01,
                    NPDecl = 61.45,
                    SidRotPeriod = 5067014.4,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 57909050000,
                    Eccentricity = .205630,
                    Inclination = 7.005,
                    ArgPer = 29.124,
                    LongAsc = 48.331

                    //AxialTilt = .034,
                };

                Bodies[2] = new OrbitingBody
                {
                    Name = "VENUS",
                    Radius = 6052000,
                    GM = 324859000000000,
                    NPRA = 272.76,
                    NPDecl = 67.16,
                    SidRotPeriod = 1210000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 108208000000,
                    Eccentricity = .006772,
                    Inclination = 3.39458,
                    ArgPer = 54.884,
                    LongAsc = 76.680

                    //AxialTilt = 177.36,
                };

                Bodies[3] = new OrbitingBody
                {
                    Name = "EARTH",
                    Radius = 6374327,
                    GM = 398600441800000,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 149598023000,
                    Eccentricity = .0167086,
                    Inclination = 0,
                    ArgPer = 114.20783,
                    LongAsc = 348.73936 //-11.26064

                    //AxialTilt = 23.4392811,
                };

                Bodies[4] = new OrbitingBody
                {
                    Name = "MOON",
                    Radius = 1737000,
                    GM = 4904869500000,

                    ParentBody = Bodies[3],
                    SemiMajorAxis = 384399000,
                    Eccentricity = .0549,
                    Inclination = 5.145
                };

                Bodies[5] = new OrbitingBody
                {
                    Name = "MARS",
                    Radius = 3390000,
                    GM = 42828370000000,
                    NPRA = 317.68143,
                    NPDecl = 52.88650,
                    SidRotPeriod = 88642,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 227939200000,
                    Eccentricity = .0934,
                    Inclination = 1.850,
                    ArgPer = 286.502,
                    LongAsc = 49.558

                    //AxialTilt = 25.19,
                };

                Bodies[6] = new OrbitingBody
                {
                    Name = "PHOBOS",
                    Radius = 11266,
                    GM = 711390,
                    //NPRightAsc = 317.68143,
                    //NPDeclination = 52.88650,
                    SidRotPeriod = 27553.843872,

                    ParentBody = Bodies[5],
                    SemiMajorAxis = 9376000,
                    Eccentricity = .0151,
                    Inclination = .046 // to local laplace plane
                };

                Bodies[7] = new OrbitingBody
                {
                    Name = "DEIMOS",
                    Radius = 6200,
                    GM = 98523,
                    //NPRightAsc = 317.68143,
                    //NPDeclination = 52.88650,
                    SidRotPeriod = 109123.2,

                    ParentBody = Bodies[5],
                    SemiMajorAxis = 23463200,
                    Eccentricity = .00033,
                    Inclination = 1.791 // to local laplace plane
                };

                Bodies[8] = new OrbitingBody
                {
                    Name = "JUPITER",
                    Radius = 69911000,
                    GM = 126686534000000000,
                    NPRA = 268.057,
                    NPDecl = 64.496,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 778299000000,
                    Eccentricity = .048498,
                    Inclination = 1.303, // to ecliptic
                    ArgPer = 273.867,
                    LongAsc = 100.464

                    //AxialTilt = 3.13,
                };

                Bodies[9] = new OrbitingBody
                {
                    Name = "IO",
                    Radius = 1821600,
                    GM = 5961246900000,

                    ParentBody = Bodies[8],
                    SemiMajorAxis = 57909050000,
                    Eccentricity = .0041,
                };

                Bodies[10] = new OrbitingBody
                {
                    Name = "EUROPA",
                    Radius = 1560800,
                    GM = 3203454300000,

                    ParentBody = Bodies[8],
                    SemiMajorAxis = 670900000,
                    Eccentricity = .009,
                };

                Bodies[11] = new OrbitingBody
                {
                    Name = "GANYMEDE",
                    Radius = 2634100,
                    GM = 9890319200000,

                    ParentBody = Bodies[8],
                    SemiMajorAxis = 1070400000,
                    Eccentricity = .0013,
                };

                Bodies[12] = new OrbitingBody
                {
                    Name = "CALLISTO",
                    Radius = 2410300,
                    GM = 7180896300000,

                    ParentBody = Bodies[8],
                    SemiMajorAxis = 1882700000,
                    Eccentricity = .0074,
                };

                Bodies[13] = new OrbitingBody
                {
                    Name = "SATURN",
                    Radius = 58232000,
                    GM = 37931187000000000,
                    NPRA = 40.589,
                    NPDecl = 83.537,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 1429390000000,
                    Eccentricity = .05555,
                    Inclination = 2.485240,
                    ArgPer = 339.392,
                    LongAsc = 113.665

                    //AxialTilt = 26.73,
                };

                Bodies[14] = new OrbitingBody
                {
                    Name = "MIMAS",
                    Radius = 198200,
                    GM = 2502312814,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 185539000,
                    Eccentricity = .0196,
                    Inclination = 1.574 // to Saturn's Equator
                };

                Bodies[15] = new OrbitingBody
                {
                    Name = "ENCELADUS",
                    Radius = 252100,
                    GM = 7209474698,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 237948000,
                    Eccentricity = .0047,
                    Inclination = 0.019 // to Saturn's Equator
                };

                Bodies[16] = new OrbitingBody
                {
                    Name = "TETHYS",
                    Radius = 531100,
                    GM = 41209040219,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 294619000,
                    Eccentricity = .0001,
                    Inclination = 1.12 // to Saturn's Equator
                };

                Bodies[17] = new OrbitingBody
                {
                    Name = "DIONE",
                    Radius = 561400,
                    GM = 73111342842,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 377396000,
                    Eccentricity = .0022,
                    Inclination = .019 // to Saturn's Equator
                };

                Bodies[18] = new OrbitingBody
                {
                    Name = "RHEA",
                    Radius = 763800,
                    GM = 153938856534,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 527108000,
                    Eccentricity = .0012583,
                    Inclination = .345 // to Saturn's Equator
                };

                Bodies[19] = new OrbitingBody
                {
                    Name = "TITAN",
                    Radius = 2575500,
                    GM = 8977972400000,

                    ParentBody = Bodies[13],
                    SemiMajorAxis = 1221870000,
                    Eccentricity = .0288,
                    Inclination = .34854 // to Saturn's Equator
                };

                Bodies[20] = new OrbitingBody
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

                Bodies[21] = new OrbitingBody
                {
                    Name = "URANUS",
                    Radius = 25362000,
                    GM = 5793939000000000,
                    NPRA = 257.311,
                    NPDecl = -15.175,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 2875040000000,
                    Eccentricity = .046381,
                    Inclination = .773,
                    ArgPer = 96.998857,
                    LongAsc = 74.006

                    //AxialTilt = 97.77,
                };

                Bodies[22] = new OrbitingBody
                {
                    Name = "MIRANDA",
                    Radius = 235800,
                    GM = 4398218720,

                    ParentBody = Bodies[21],
                    SemiMajorAxis = 129390000,
                    Eccentricity = .0013,
                    Inclination = 4.232 // to Uranus's Equator
                };

                Bodies[23] = new OrbitingBody
                {
                    Name = "ARIEL",
                    Radius = 578900,
                    GM = 90300302400,

                    ParentBody = Bodies[21],
                    SemiMajorAxis = 191020000,
                    Eccentricity = .0012,
                    Inclination = .260 // to Uranus's Equator
                };

                Bodies[24] = new OrbitingBody
                {
                    Name = "UMBRIEL",
                    Radius = 584700,
                    GM = 78220217600,

                    ParentBody = Bodies[21],
                    SemiMajorAxis = 266000000,
                    Eccentricity = .0039,
                    Inclination = .128 // to Uranus's Equator
                };

                Bodies[25] = new OrbitingBody
                {
                    Name = "TITANIA",
                    Radius = 788400,
                    GM = 235394801600,

                    ParentBody = Bodies[21],
                    SemiMajorAxis = 435910000,
                    Eccentricity = .0011,
                    Inclination = .340 // to Uranus's Equator
                };

                Bodies[26] = new OrbitingBody
                {
                    Name = "OBERON",
                    Radius = 761400,
                    GM = 201156771200,

                    ParentBody = Bodies[21],
                    SemiMajorAxis = 583520000,
                    Eccentricity = .0014,
                    Inclination = .058 // to Uranus's Equator
                };

                Bodies[27] = new OrbitingBody
                {
                    Name = "NEPTUNE",
                    Radius = 24622000,
                    GM = 6836529000000000,
                    NPRA = 299.3,
                    NPDecl = 42.950,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 4504450000000,
                    Eccentricity = .009456,
                    Inclination = 1.767975,
                    ArgPer = 276.336,
                    LongAsc = 131.784

                    //AxialTilt = 28.32,
                };

                Bodies[29] = new OrbitingBody
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

                Bodies[29] = new OrbitingBody
                {
                    Name = "NEREID",
                    Radius = 170000,
                    GM = 2060000000,

                    ParentBody = Bodies[27],
                    SemiMajorAxis = 354759000,
                    Eccentricity = .000016,
                    Inclination = 129.812 // to ecliptic
                    // 156.885 to Neptune's Equator
                };

                Bodies[28] = new OrbitingBody
                {
                    Name = "PROTEUS",
                    Radius = 210000,
                    GM = 2936595200,

                    ParentBody = Bodies[27],
                    SemiMajorAxis = 117647000,
                    Eccentricity = .00053,
                    Inclination = .524 // to Neptune's Equator
                };
            }
        }
    }
}
