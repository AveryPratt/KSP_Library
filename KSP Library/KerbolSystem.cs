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
                    ID = 1,
                    Name = "KERBOL",
                    Radius = 261600000,
                    GM = BigGM.ENotation(1.1723328, 18),
                    //GM = 1172332800000000000
                    AtmosphereHeight = 600000,
                    NPRightAsc = 0,
                    NPDeclination = 0,
                    SidRotPeriod = 432000
                };

                Bodies[1] = new OrbitingBody
                {
                    ID = 2,
                    Name = "MOHO",
                    Radius = 250000,
                    GM = 168609380000,
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    NPRightAsc = 0,
                    NPDeclination = 0,
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
                    Name = "EELOO",
                    Radius = 210000,
                    GM = 74410815000,
                    NPRightAsc = 0,
                    NPDeclination = 0,
                    SidRotPeriod = 19460,

                    ParentBody = Bodies[0],
                    SemiMajorAxis = 90118820000,
                    Eccentricity = .26,
                    Inclination = 6.15,
                    ArgPer = 260,
                    LongAsc = 50,
                    SOIRad = 119082940
                };
            }
        }
    }
}