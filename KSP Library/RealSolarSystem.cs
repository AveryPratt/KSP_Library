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
                };
                ((Star)Bodies[0]).ReferencePlane = new Plane(
                    new VecSphere() { RA = 270, Decl = 23.439291 },
                    "Earth Ecliptic"
                    );
                Bodies[0].EqPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    286.13,
                    63.87,
                    "Sun Equator"
                    );

                Bodies[1] = new FixedOrbitingBody
                {
                    // physical characteristics
                    Name = "MERCURY",
                    Radius = 2439700,
                    GM = 22032000000000,
                    SidRotPeriod = 5067031.68,

                    EqPlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        281.01,
                        61.41,
                        "Mercury Equator"
                        ),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 57909226542,
                    Eccentricity = 0.20563593,
                    Inclination = 7.00497902,
                    ArgPer = 29.12703035,
                    LongAsc = 48.33076593
                };
                ((FixedOrbitingBody)Bodies[1]).OrbitalPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    ((FixedOrbitingBody)Bodies[1]).LongAsc,
                    ((FixedOrbitingBody)Bodies[1]).Inclination,
                    "Mercury Orbit"
                    );

                Bodies[2] = new FixedOrbitingBody
                {
                    // physical characteristics
                    Name = "VENUS",
                    Radius = 6051800,
                    GM = 324859000000000,
                    SidRotPeriod = -20996755.2,

                    EqPlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        272.76, //92.76 for counterclockwise pole
                        67.16, //-67.16 for counterclockwise pole
                        "Venus Equator"
                        ),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 108209474537,
                    Eccentricity = 0.00677672,
                    Inclination = 3.39467605,
                    ArgPer = 54.92262463,
                    LongAsc = 76.67984255,
                };
                ((FixedOrbitingBody)Bodies[2]).OrbitalPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    ((FixedOrbitingBody)Bodies[2]).LongAsc,
                    ((FixedOrbitingBody)Bodies[2]).Inclination,
                    "Venus Orbit"
                    );

                Bodies[3] = new FixedOrbitingBody
                {
                    // physical characteristics
                    Name = "EARTH",
                    Radius = 6374327, //6371000avg
                    GM = 398600441800000,
                    SidRotPeriod = 0.99726968,

                    EqPlane = new Plane("Celestial Sphere"),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 149598261150,
                    Eccentricity = 0.01671123,
                    Inclination = 0,
                    ArgPer = 102.93768193,
                    LongAsc = 0,

                    OrbitalPlane = ((Star)Bodies[0]).ReferencePlane
                };

                Bodies[4] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "MOON",
                    Radius = 1737500,
                    GM = 4902801000000,
                    SidRotPeriod = 2360591.5104,

                    // orbital characteristics
                    ParentBody = Bodies[3],
                    SemiMajorAxis = 384400000,
                    Eccentricity = 0.0554,
                    Inclination = 5.16,
                    ArgPer = 318.15,
                    LongAsc = 125.08,

                    LaplacePlane = ((FixedOrbitingBody)Bodies[3]).OrbitalPlane
                };
                ((FixedOrbitingBody)Bodies[4]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[4]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[4]).LongAsc,
                    ((FixedOrbitingBody)Bodies[4]).Inclination,
                    "Moon Orbit"
                    );

                Bodies[5] = new FixedOrbitingBody
                {
                    // physical characteristics
                    Name = "MARS",
                    Radius = 3389500,
                    GM = 42828370000000,
                    SidRotPeriod = 88642.664064,

                    EqPlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        317.68,
                        52.89,
                        "Mars Equator"
                        ),

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 227943822428,
                    Eccentricity = 0.09339410,
                    Inclination = 1.84969142,
                    ArgPer = 286.4968315,
                    LongAsc = 49.55953891
                };
                ((FixedOrbitingBody)Bodies[5]).OrbitalPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    ((FixedOrbitingBody)Bodies[5]).LongAsc,
                    ((FixedOrbitingBody)Bodies[5]).Inclination,
                    "Mars Orbit"
                    );

                Bodies[6] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "PHOBOS",
                    Radius = 11100,
                    GM = 711200,
                    SidRotPeriod = 27553.843872,

                    // orbital characteristics
                    ParentBody = Bodies[5],
                    SemiMajorAxis = 9376000,
                    Eccentricity = 0.0151,
                    Inclination = 1.075, // to local laplace plane
                    ArgPer = 150.057,
                    LongAsc = 207.784,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 317.671,
                            Decl = 52.893
                        },
                        "Phobos Laplace"
                        )
                };
                ((OrbitingBody)Bodies[6]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[6]).LaplacePlane,
                    ((OrbitingBody)Bodies[6]).LongAsc,
                    ((OrbitingBody)Bodies[6]).Inclination,
                    "Phobos Orbit"
                    );

                Bodies[7] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "DEIMOS",
                    Radius = 6200,
                    GM = 98500,
                    SidRotPeriod = 109123.2,

                    // orbital characteristics
                    ParentBody = Bodies[5],
                    SemiMajorAxis = 23458000,
                    Eccentricity = 0.0002,
                    Inclination = 1.788, // to local laplace plane
                    ArgPer = 260.729,
                    LongAsc = 24.525,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 316.657,
                            Decl = 53.529
                        },
                        "Deimos Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[7]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[7]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[7]).LongAsc,
                    ((FixedOrbitingBody)Bodies[7]).Inclination,
                    "Deimos Orbit"
                    );

                Bodies[8] = new FixedOrbitingBody
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
                    LongAsc = 100.47390909
                };
                ((FixedOrbitingBody)Bodies[8]).OrbitalPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    ((FixedOrbitingBody)Bodies[8]).LongAsc,
                    ((FixedOrbitingBody)Bodies[8]).Inclination,
                    "Jupiter Orbit"
                    );

                Bodies[9] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "IO",
                    Radius = 1821600,
                    GM = 5959916000000,

                    // orbital characteristics
                    ParentBody = Bodies[8],
                    SemiMajorAxis = 421800000,
                    Eccentricity = 0.0041,
                    Inclination = 0.036,
                    ArgPer = 84.129,
                    LongAsc = 43.977,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 268.057,
                            Decl = 64.495
                        },
                        "Io Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[9]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[9]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[9]).LongAsc,
                    ((FixedOrbitingBody)Bodies[9]).Inclination,
                    "Io Orbit"
                    );

                Bodies[10] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "EUROPA",
                    Radius = 1560800,
                    GM = 3202739000000,

                    // orbital characteristics
                    ParentBody = Bodies[8],
                    SemiMajorAxis = 671100000,
                    Eccentricity = 0.0094,
                    Inclination = 0.466,
                    ArgPer = 88.970,
                    LongAsc = 219.106,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 268.084,
                            Decl = 64.506
                        },
                        "Europa Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[10]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[10]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[10]).LongAsc,
                    ((FixedOrbitingBody)Bodies[10]).Inclination,
                    "Europa Orbit"
                    );

                Bodies[11] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "GANYMEDE",
                    Radius = 2631200,
                    GM = 9887834000000,

                    // orbital characteristics
                    ParentBody = Bodies[8],
                    SemiMajorAxis = 1070400000,
                    Eccentricity = 0.0013,
                    Inclination = 0.177,
                    ArgPer = 192.417,
                    LongAsc = 63.552,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 268.168,
                            Decl = 64.543
                        },
                        "Ganymede Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[11]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[11]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[11]).LongAsc,
                    ((FixedOrbitingBody)Bodies[11]).Inclination,
                    "Ganymede Orbit"
                    );

                Bodies[12] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "CALLISTO",
                    Radius = 2410300,
                    GM = 7179289000000,

                    // orbital characteristics
                    ParentBody = Bodies[8],
                    SemiMajorAxis = 1882700000,
                    Eccentricity = 0.0074,
                    Inclination = 0.192,
                    ArgPer = 52.643,
                    LongAsc = 298.848,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 268.639,
                            Decl = 64.749
                        },
                        "Callisto Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[12]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[12]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[12]).LongAsc,
                    ((FixedOrbitingBody)Bodies[12]).Inclination,
                    "Callisto Orbit"
                    );

                Bodies[13] = new FixedOrbitingBody
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
                    LongAsc = 113.66242448
                };
                ((FixedOrbitingBody)Bodies[13]).OrbitalPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    ((FixedOrbitingBody)Bodies[13]).LongAsc,
                    ((FixedOrbitingBody)Bodies[13]).Inclination,
                    "Saturn Orbit"
                    );

                Bodies[14] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "MIMAS",
                    Radius = 198200,
                    GM = 2502600000,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 185539000,
                    Eccentricity = 0.0196,
                    Inclination = 1.574,
                    ArgPer = 332.499,
                    LongAsc = 173.027,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 40.589,
                            Decl = 83.536
                        },
                        "Mimas Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[14]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[14]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[14]).LongAsc,
                    ((FixedOrbitingBody)Bodies[14]).Inclination,
                    "Mimas Orbit"
                    );

                Bodies[15] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "ENCELADUS",
                    Radius = 252100,
                    GM = 7202700000,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 238042,
                    Eccentricity = 0,
                    Inclination = 0.003,
                    ArgPer = 0.076,
                    LongAsc = 342.507,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 40.586,
                            Decl = 83.536
                        },
                        "Enceladus Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[15]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[15]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[15]).LongAsc,
                    ((FixedOrbitingBody)Bodies[15]).Inclination,
                    "Enceladus Orbit"
                    );

                Bodies[16] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "TETHYS",
                    Radius = 533000,
                    GM = 41206700000,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 294672000,
                    Eccentricity = 0.0001,
                    Inclination = 1.091,
                    ArgPer = 45.202,
                    LongAsc = 259.842,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 40.578,
                            Decl = 83.537
                        },
                        "Tethys Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[16]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[16]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[16]).LongAsc,
                    ((FixedOrbitingBody)Bodies[16]).Inclination,
                    "Tethys Orbit"
                    );

                Bodies[17] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "DIONE",
                    Radius = 561700,
                    GM = 73114600000,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 377415000,
                    Eccentricity = 0.0022,
                    Inclination = 0.028,
                    ArgPer = 284.315,
                    LongAsc = 290.415,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 40.544,
                            Decl = 83.540
                        },
                        "Dione Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[17]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[17]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[17]).LongAsc,
                    ((FixedOrbitingBody)Bodies[17]).Inclination,
                    "Dione Orbit"
                    );

                Bodies[18] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "RHEA",
                    Radius = 764300,
                    GM = 153942600000,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 527068000,
                    Eccentricity = 0.0002,
                    Inclination = 0.333,
                    ArgPer = 241.619,
                    LongAsc = 351.042,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 40.328,
                            Decl = 83.559
                        },
                        "Rhea Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[18]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[18]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[18]).LongAsc,
                    ((FixedOrbitingBody)Bodies[18]).Inclination,
                    "Rhea Orbit"
                    );

                Bodies[19] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "TITAN",
                    Radius = 2574730,
                    GM = 8978138200000,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 1221865000,
                    Eccentricity = 0.0288,
                    Inclination = 0.306,
                    ArgPer = 180.532,
                    LongAsc = 28.060,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 36.214,
                            Decl = 83.949
                        },
                        "Titan Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[19]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[19]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[19]).LongAsc,
                    ((FixedOrbitingBody)Bodies[19]).Inclination,
                    "Titan Orbit"
                    );

                Bodies[20] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "IAPETUS",
                    Radius = 735600,
                    GM = 120503800000,

                    // orbital characteristics
                    ParentBody = Bodies[13],
                    SemiMajorAxis = 3560854000,
                    Eccentricity = 0.0293,
                    Inclination = 8.298,
                    ArgPer = 271.606,
                    LongAsc = 81.105,
                    // Inclination = 17.28 to ecliptic
                    // 15.47 to Saturn's equator

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 284.715,
                            Decl = 78.749
                        },
                        "Iapetus Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[20]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[20]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[20]).LongAsc,
                    ((FixedOrbitingBody)Bodies[20]).Inclination,
                    "Iapetus Orbit"
                    );

                Bodies[21] = new FixedOrbitingBody
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
                    LongAsc = 74.01692503
                };
                ((FixedOrbitingBody)Bodies[21]).OrbitalPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    ((FixedOrbitingBody)Bodies[21]).LongAsc,
                    ((FixedOrbitingBody)Bodies[21]).Inclination,
                    "Uranus Orbit"
                    );

                Bodies[22] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "MIRANDA",
                    Radius = 235800,
                    GM = 4400000000,

                    // orbital characteristics
                    ParentBody = Bodies[21],
                    SemiMajorAxis = 129900000,
                    Eccentricity = 0.0013,
                    Inclination = 4.338,
                    ArgPer = 68.312,
                    LongAsc = 326.438,

                    LaplacePlane = ((FixedOrbitingBody)Bodies[21]).OrbitalPlane
                };
                ((FixedOrbitingBody)Bodies[22]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[22]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[22]).LongAsc,
                    ((FixedOrbitingBody)Bodies[22]).Inclination,
                    "Miranda Orbit"
                    );

                Bodies[23] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "ARIEL",
                    Radius = 578900,
                    GM = 86400000000,

                    // orbital characteristics
                    ParentBody = Bodies[21],
                    SemiMajorAxis = 190900000,
                    Eccentricity = 0.0012,
                    Inclination = 0.041,
                    ArgPer = 115.349,
                    LongAsc = 22.394,

                    LaplacePlane = ((FixedOrbitingBody)Bodies[21]).OrbitalPlane
                };
                ((FixedOrbitingBody)Bodies[23]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[23]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[23]).LongAsc,
                    ((FixedOrbitingBody)Bodies[23]).Inclination,
                    "Ariel Orbit"
                    );

                Bodies[24] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "UMBRIEL",
                    Radius = 584700,
                    GM = 81500000000,

                    // orbital characteristics
                    ParentBody = Bodies[21],
                    SemiMajorAxis = 266000000,
                    Eccentricity = 0.0039,
                    Inclination = 0.128,
                    ArgPer = 84.709,
                    LongAsc = 33.485,

                    LaplacePlane = ((FixedOrbitingBody)Bodies[21]).OrbitalPlane
                };
                ((FixedOrbitingBody)Bodies[24]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[24]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[24]).LongAsc,
                    ((FixedOrbitingBody)Bodies[24]).Inclination,
                    "Umbriel Orbit"
                    );

                Bodies[25] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "TITANIA",
                    Radius = 788900,
                    GM = 228200000000,

                    // orbital characteristics
                    ParentBody = Bodies[21],
                    SemiMajorAxis = 436300000,
                    Eccentricity = 0.0011,
                    Inclination = 0.079,
                    ArgPer = 284.400,
                    LongAsc = 99.771,

                    LaplacePlane = ((FixedOrbitingBody)Bodies[21]).OrbitalPlane
                };
                ((FixedOrbitingBody)Bodies[25]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[25]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[25]).LongAsc,
                    ((FixedOrbitingBody)Bodies[25]).Inclination,
                    "Titania Orbit"
                    );

                Bodies[26] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "OBERON",
                    Radius = 761400,
                    GM = 192400000000,

                    // orbital characteristics
                    ParentBody = Bodies[21],
                    SemiMajorAxis = 583500000,
                    Eccentricity = 0.0014,
                    Inclination = 0.068,
                    ArgPer = 104.400,
                    LongAsc = 279.771,

                    LaplacePlane = ((FixedOrbitingBody)Bodies[21]).OrbitalPlane
                };
                ((FixedOrbitingBody)Bodies[26]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[26]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[26]).LongAsc,
                    ((FixedOrbitingBody)Bodies[26]).Inclination,
                    "Oberon Orbit"
                    );

                Bodies[27] = new FixedOrbitingBody
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
                    LongAsc = 131.78422574
                };
                ((FixedOrbitingBody)Bodies[27]).OrbitalPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    ((FixedOrbitingBody)Bodies[27]).LongAsc,
                    ((FixedOrbitingBody)Bodies[27]).Inclination,
                    "Neptune Orbit"
                    );

                Bodies[28] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "TRITON",
                    Radius = 1353400,
                    GM = 1427600000000,

                    // orbital characteristics
                    ParentBody = Bodies[27],
                    SemiMajorAxis = 354759000,
                    Eccentricity = 0,
                    Inclination = 156.865,
                    ArgPer = 66.142,
                    LongAsc = 177.608,
                    //Inclination = 129.812 to ecliptic
                    // 156.885 to Neptune's Equator

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 299.456,
                            Decl = 43.414
                        },
                        "Triton Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[28]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[28]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[28]).LongAsc,
                    ((FixedOrbitingBody)Bodies[28]).Inclination,
                    "Triton Orbit"
                    );

                Bodies[29] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "NEREID",
                    Radius = 170000,
                    GM = 2060000000,

                    // orbital characteristics
                    ParentBody = Bodies[27],
                    SemiMajorAxis = 5513818000,
                    Eccentricity = 0.7507,
                    Inclination = 7.090,
                    ArgPer = 281.117,
                    LongAsc = 335.570,
                    //Inclination = 129.812 to ecliptic
                    // 156.885 to Neptune's Equator

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 269.302,
                            Decl = 69.117
                        },
                        "Nereid Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[29]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[29]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[29]).LongAsc,
                    ((FixedOrbitingBody)Bodies[29]).Inclination,
                    "Nereid Orbit"
                    );

                Bodies[30] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "PROTEUS",
                    Radius = 210000,
                    GM = 3360000000,

                    // orbital characteristics
                    ParentBody = Bodies[27],
                    SemiMajorAxis = 117646000,
                    Eccentricity = 0.0005,
                    Inclination = 0.075,
                    ArgPer = 67.968,
                    LongAsc = 315.131,

                    LaplacePlane = new Plane(
                        ((Star)Bodies[0]).ReferencePlane,
                        new VecSphere()
                        {
                            RA = 299.406,
                            Decl = 42.432
                        },
                        "Proteus Laplace"
                        )
                };
                ((FixedOrbitingBody)Bodies[30]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[30]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[30]).LongAsc,
                    ((FixedOrbitingBody)Bodies[30]).Inclination,
                    "Proteus Orbit"
                    );

                Bodies[31] = new FixedOrbitingBody
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
                    LongAsc = 110.30393684
                };
                ((FixedOrbitingBody)Bodies[31]).OrbitalPlane = new Plane(
                    ((Star)Bodies[0]).ReferencePlane,
                    ((FixedOrbitingBody)Bodies[31]).LongAsc,
                    ((FixedOrbitingBody)Bodies[31]).Inclination,
                    "Pluto Orbit"
                    );

                Bodies[32] = new OrbitingBody
                {
                    // physical characteristics
                    Name = "CHARON",
                    Radius = 603600,
                    GM = 102300000000,

                    // orbital characteristics
                    ParentBody = Bodies[0],
                    SemiMajorAxis = 19591000,
                    Eccentricity = 0.0002,
                    Inclination = 0.080,
                    ArgPer = 146.106,
                    LongAsc = 26.928,

                    LaplacePlane = ((FixedOrbitingBody)Bodies[30]).OrbitalPlane
                };
                ((FixedOrbitingBody)Bodies[32]).OrbitalPlane = new Plane(
                    ((OrbitingBody)Bodies[32]).LaplacePlane,
                    ((FixedOrbitingBody)Bodies[32]).LongAsc,
                    ((FixedOrbitingBody)Bodies[32]).Inclination,
                    "Charon Orbit"
                    );
            }
        }
    }
}
