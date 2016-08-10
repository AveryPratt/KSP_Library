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
                    // physical characteristics
                    Name = "SUN",
                    Radius = 695700000,
                    GM = BigGM.ENotation(1.32712440018, 20),
                    SidRotPeriod = 2164320, // at equator
                    //GM = 132712440018000000000
                    
                    ReferencePlane = new Plane(270, 23.439291, 0, 0),
                    EqPlane = new Plane(((Star)Bodies[0]).ReferencePlane, 286.13, 63.87),
                };

                Bodies[1] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "MERCURY",
                    Radius = 2439700,
                    GM = 22032000000000,
                    SidRotPeriod = 5067031.68,

                    EqPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    281.01,
                    61.41
                    ),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 57909226542,
                    Eccentricity = 0.20563593,
                    Inclination = 7.00497902,
                    ArgPer = 29.12703035,
                    LongAsc = 48.33076593,

                    OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[1]).LongAsc, 
                    ((OrbitingBody)Bodies[1]).Inclination, 
                    ((Star)Bodies[0]).ReferencePlane
                    ),
                };

                Bodies[2] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "VENUS",
                    Radius = 6051800,
                    GM = 324859000000000,
                    SidRotPeriod = -20996755.2,

                    EqPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    272.76, //92.76 for counterclockwise pole
                    67.16 //-67.16 for counterclockwise pole
                    ),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 108209474537,
                    Eccentricity = 0.00677672,
                    Inclination = 3.39467605,
                    ArgPer = 54.92262463,
                    LongAsc = 76.67984255,

                    OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[2]).LongAsc,
                    ((OrbitingBody)Bodies[2]).Inclination,
                    ((Star)Bodies[0]).ReferencePlane
                    ),
                };

                Bodies[3] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "EARTH",
                    Radius = 6374327, //6371000avg
                    GM = 398600441800000,
                    SidRotPeriod = 0.99726968,

                    EqPlane = new Plane(),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 149598261150,
                    Eccentricity = 0.01671123,
                    Inclination = 0,
                    ArgPer = 102.93768193,
                    LongAsc = 0,

                    OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[3]).LongAsc,
                    ((OrbitingBody)Bodies[3]).Inclination,
                    ((Star)Bodies[0]).ReferencePlane
                    ),
                };

                Bodies[4] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "MOON",
                    Radius = 1737000,
                    GM = 4904869500000,

                    // orbital characteristics
                    ParentBody = Bodies[3],
                    SemiMajorAxis = 384399000,
                    Eccentricity = .0549,
                    Inclination = 5.145
                };

                Bodies[5] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "MARS",
                    Radius = 3389500,
                    GM = 42828370000000,
                    SidRotPeriod = 88642.664064,

                    EqPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    317.68,
                    52.89
                    ),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 227943822428,
                    Eccentricity = 0.09339410,
                    Inclination = 1.84969142,
                    ArgPer = 286.4968315,
                    LongAsc = 49.55953891,

                    OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[5]).LongAsc,
                    ((OrbitingBody)Bodies[5]).Inclination,
                    ((Star)Bodies[0]).ReferencePlane
                    ),
                };

                Bodies[6] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "PHOBOS",
                    Radius = 11266,
                    GM = 711390,
                    //NPRightAsc = 317.68143,
                    //NPDeclination = 52.88650,
                    SidRotPeriod = 27553.843872,

                    // orbital characteristics
                    ParentBody = Bodies[5],
                    SemiMajorAxis = 9376000,
                    Eccentricity = .0151,
                    Inclination = .046 // to local laplace plane
                };

                Bodies[7] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "DEIMOS",
                    Radius = 6200,
                    GM = 98523,
                    //NPRightAsc = 317.68143,
                    //NPDeclination = 52.88650,
                    SidRotPeriod = 109123.2,

                    // orbital characteristics
                    ParentBody = Bodies[5],
                    SemiMajorAxis = 23463200,
                    Eccentricity = .00033,
                    Inclination = 1.791 // to local laplace plane
                };

                Bodies[8] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "JUPITER",
                    Radius = 69911000,
                    GM = 126686534000000000,
                    SidRotPeriod = 35729.856,

                    EqPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    268.06,
                    64.50
                    ),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 778340817000,
                    Eccentricity = 0.04838624,
                    Inclination = 1.30439695,
                    ArgPer = 274.25457074,
                    LongAsc = 100.47390909,

                    OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[8]).LongAsc,
                    ((OrbitingBody)Bodies[8]).Inclination,
                    ((Star)Bodies[0]).ReferencePlane
                    ),
                };

                Bodies[9] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "IO",
                    Radius = 1821600,
                    GM = 5961246900000,

                    // orbital characteristics
                    ParentBody = Bodies[8],
                    SemiMajorAxis = 57909050000,
                    Eccentricity = .0041,
                };

                Bodies[10] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "EUROPA",
                    Radius = 1560800,
                    GM = 3203454300000,

                    // orbital characteristics
                    ParentBody = Bodies[8],
                    SemiMajorAxis = 670900000,
                    Eccentricity = .009,
                };

                Bodies[11] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "GANYMEDE",
                    Radius = 2634100,
                    GM = 9890319200000,

                    // orbital characteristics
                    ParentBody = Bodies[8],
                    SemiMajorAxis = 1070400000,
                    Eccentricity = .0013,
                };

                Bodies[12] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "CALLISTO",
                    Radius = 2410300,
                    GM = 7180896300000,

                    // orbital characteristics
                    ParentBody = Bodies[8],
                    SemiMajorAxis = 1882700000,
                    Eccentricity = .0074,
                };

                Bodies[13] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "SATURN",
                    Radius = 58232000,
                    GM = 37931187000000000,
                    SidRotPeriod = 38362.464,

                    EqPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    40.60,
                    83.54
                    ),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 1426666414180,
                    Eccentricity = 0.05386179,
                    Inclination = 2.48599187,
                    ArgPer = 338.93645383,
                    LongAsc = 113.66242448,

                    OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[13]).LongAsc,
                    ((OrbitingBody)Bodies[13]).Inclination,
                    ((Star)Bodies[0]).ReferencePlane
                    ),
                };

                Bodies[14] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "MIMAS",
                    Radius = 198200,
                    GM = 2502312814,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 185539000,
                    Eccentricity = .0196,
                    Inclination = 1.574 // to Saturn's Equator
                };

                Bodies[15] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "ENCELADUS",
                    Radius = 252100,
                    GM = 7209474698,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 237948000,
                    Eccentricity = .0047,
                    Inclination = 0.019 // to Saturn's Equator
                };

                Bodies[16] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "TETHYS",
                    Radius = 531100,
                    GM = 41209040219,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 294619000,
                    Eccentricity = .0001,
                    Inclination = 1.12 // to Saturn's Equator
                };

                Bodies[17] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "DIONE",
                    Radius = 561400,
                    GM = 73111342842,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 377396000,
                    Eccentricity = .0022,
                    Inclination = .019 // to Saturn's Equator
                };

                Bodies[18] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "RHEA",
                    Radius = 763800,
                    GM = 153938856534,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 527108000,
                    Eccentricity = .0012583,
                    Inclination = .345 // to Saturn's Equator
                };

                Bodies[19] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "TITAN",
                    Radius = 2575500,
                    GM = 8977972400000,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 1221870000,
                    Eccentricity = .0288,
                    Inclination = .34854 // to Saturn's Equator
                };

                Bodies[20] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "IAPETUS",
                    Radius = 734500,
                    GM = 120509524408,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 3560820000,
                    Eccentricity = .0286125,
                    Inclination = 17.28 // to ecliptic
                    // 15.47 to Saturn's equator
                };

                Bodies[21] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "URANUS",
                    Radius = 25362000,
                    GM = 5793939000000000,
                    SidRotPeriod = -62063.712,

                    EqPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    257.31,
                    -15.18
                    ),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 2870658170656,
                    Eccentricity = 0.04725744,
                    Inclination = 0.77263783,
                    ArgPer = 96.93735127,
                    LongAsc = 74.01692503,

                    OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[21]).LongAsc,
                    ((OrbitingBody)Bodies[21]).Inclination,
                    ((Star)Bodies[0]).ReferencePlane
                    ),
                };

                Bodies[22] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "MIRANDA",
                    Radius = 235800,
                    GM = 4398218720,

                    // orbital characteristics
                    ParentBody = Bodies[21],
                    SemiMajorAxis = 129390000,
                    Eccentricity = .0013,
                    Inclination = 4.232 // to Uranus's Equator
                };

                Bodies[23] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "ARIEL",
                    Radius = 578900,
                    GM = 90300302400,

                    // orbital characteristics
                    ParentBody = Bodies[21],
                    SemiMajorAxis = 191020000,
                    Eccentricity = .0012,
                    Inclination = .260 // to Uranus's Equator
                };

                Bodies[24] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "UMBRIEL",
                    Radius = 584700,
                    GM = 78220217600,

                    // orbital characteristics
                    ParentBody = Bodies[21],
                    SemiMajorAxis = 266000000,
                    Eccentricity = .0039,
                    Inclination = .128 // to Uranus's Equator
                };

                Bodies[25] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "TITANIA",
                    Radius = 788400,
                    GM = 235394801600,

                    // orbital characteristics
                    ParentBody = Bodies[21],
                    SemiMajorAxis = 435910000,
                    Eccentricity = .0011,
                    Inclination = .340 // to Uranus's Equator
                };

                Bodies[26] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "OBERON",
                    Radius = 761400,
                    GM = 201156771200,

                    // orbital characteristics
                    ParentBody = Bodies[21],
                    SemiMajorAxis = 583520000,
                    Eccentricity = .0014,
                    Inclination = .058 // to Uranus's Equator
                };

                Bodies[27] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "NEPTUNE",
                    Radius = 24622000,
                    GM = 6836529000000000,
                    SidRotPeriod = 57996,

                    EqPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    299.36,
                    43.46
                    ),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 4498396417010,
                    Eccentricity = 0.00859048,
                    Inclination = 1.77004347,
                    ArgPer = 276.18053653,
                    LongAsc = 131.78422574,

                    OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[27]).LongAsc,
                    ((OrbitingBody)Bodies[27]).Inclination,
                    ((Star)Bodies[0]).ReferencePlane
                    ),
                };

                Bodies[29] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "TRITON",
                    Radius = 1353400,
                    GM = 1428253100000,

                    // orbital characteristics
                    ParentBody = Bodies[27],
                    SemiMajorAxis = 354759000,
                    Eccentricity = .000016,
                    Inclination = 129.812 // to ecliptic
                    // 156.885 to Neptune's Equator
                };

                Bodies[29] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "NEREID",
                    Radius = 170000,
                    GM = 2060000000,

                    // orbital characteristics
                    ParentBody = Bodies[27],
                    SemiMajorAxis = 354759000,
                    Eccentricity = .000016,
                    Inclination = 129.812 // to ecliptic
                    // 156.885 to Neptune's Equator
                };

                Bodies[28] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "PROTEUS",
                    Radius = 210000,
                    GM = 2936595200,

                    // orbital characteristics
                    ParentBody = Bodies[27],
                    SemiMajorAxis = 117647000,
                    Eccentricity = .00053,
                    Inclination = .524 // to Neptune's Equator
                };

                Bodies[30] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "PLUTO",
                    Radius = 1187000,
                    GM = 871000000000,
                    SidRotPeriod = -6.3872,

                    EqPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    132.99,
                    -6.16
                    ),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 5906440596529,
                    Eccentricity = 0.24882730,
                    Inclination = 17.14001206,
                    ArgPer = 113.76497945,
                    LongAsc = 110.30393684,

                    OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[27]).LongAsc,
                    ((OrbitingBody)Bodies[27]).Inclination,
                    ((Star)Bodies[0]).ReferencePlane
                    ),
                };

                Bodies[31] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "CHARON",
                    Radius = 606000,
                    GM = 105850908800,

                    // orbital characteristics
                    ParentBody = Bodies[30],
                    SemiMajorAxis = 19571000, // to Pluto's center of mass
                    // 17536000 to system barycenter
                    Eccentricity = .00,
                    Inclination = 112.783, // to ecliptic
                    // 119.591 to Pluto's Orbit
                    LongAsc = 223.046
                };
            }
        }
    }
}
