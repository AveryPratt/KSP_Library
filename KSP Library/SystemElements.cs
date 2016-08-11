using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KSP_Library
{
    public abstract class SolarSystem
    {
        public Body[] Bodies { get; set; }

        // constructors
        public SolarSystem() { }
        public SolarSystem(Body[] bodies)
        {
            Bodies = bodies;
        }

        // methods
        public virtual Body GetSystemBody(string bodyName)
        {
            return Bodies.Single(b => b.Name == bodyName.ToUpper());
        }
        public virtual Body GetSystemBody(int bodyIndex)
        {
            return Bodies[bodyIndex];
        }

        public override int GetHashCode()
        {
            return Bodies.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (((SolarSystem)obj).GetHashCode() == this.GetHashCode())
            {
                return true;
            }
            else return false;
        }
        public override string ToString()
        {
            StringBuilder bodyNames = new StringBuilder();
            foreach(Body body in Bodies)
            {
                bodyNames.Append(body.ToString() + "\n");
            }
            return bodyNames.ToString();
        }
    }
    public struct Coordinates
    {
        public double RA;
        public double Decl;

        public override int GetHashCode()
        {
            int newHash = RA.GetHashCode();
            newHash ^= Decl.GetHashCode();
            return newHash;
        }
        public override bool Equals(object obj)
        {
            if (((Coordinates)obj).RA == RA && ((Coordinates)obj).Decl == Decl)
            {
                return true;
            }
            else return false;
        }
    }
    public class Plane
    {
        public string Name { get; set; }
        public Coordinates NP { get; set; }
        public Coordinates Origin { get; set; }

        public Plane RefPlane { get; set; }
        public double Incl { get; set; }
        public double LAN { get; set; }

        // constructors
        public Plane(string name = "Default Plane")
        {
            Name = name;
            NP = new Coordinates()
            {
                RA = 0,
                Decl = 90
            };
            Origin = new Coordinates()
            {
                RA = 0,
                Decl = 0
            };
        }
        public Plane(Coordinates np, string name = "")
        {
            Name = name;
            NP = np;

            RefPlane = new Plane();
            LAN = np.RA + 90;
            Incl = 90 - np.Decl;

            Origin = new Coordinates()
            {
                RA = LAN,
                Decl = 0
            };
        }
        public Plane(Plane refPlane, Coordinates np, string name = "")
        {
            Name = name;
            NP = np;
            RefPlane = refPlane;
            
            Coordinates relNP = translateFixedToRel(np, refPlane);
            LAN = relNP.RA + 90;
            Incl = 90 - relNP.Decl;
            Coordinates relOrigin = new Coordinates()
            {
                RA = LAN,
                Decl = 0
            };
            Origin = translateRelToFixed(relOrigin, refPlane);
        }
        public Plane(Plane refPlane, double lan, double incl, string name = "")
        {
            Name = name;
            LAN = lan;
            Incl = incl;
            RefPlane = refPlane;
            Coordinates relNP = new Coordinates()
            {
                RA = lan - 90,
                Decl = 90 - incl
            };
            NP = translateRelToFixed(relNP, refPlane);
            Coordinates relOrigin = new Coordinates()
            {
                RA = lan,
                Decl = 0
            };
            Origin = translateRelToFixed(relOrigin, refPlane);
        }
        private Plane resetPlane(Plane plane)
        {
            Plane newPlane = new Plane(plane.NP, plane.Name);
            return newPlane;
        }

        private Coordinates translateFixedToRel(Coordinates fix, Plane transPlane)
        {
            double obl = 90 - transPlane.NP.Decl;
            return new Coordinates()
            {
                RA = translateRA(fix.RA + 180, fix.Decl, obl) - 180,
                Decl = translateDecl(fix.RA + 180, fix.Decl, obl) - 180
            };
        }
        private Coordinates translateRelToFixed(Coordinates rel, Plane transPlane)
        {
            double obl = 90 - transPlane.NP.Decl;
            return new Coordinates()
            {
                RA = translateRA(rel.RA, rel.Decl, obl),
                Decl = translateDecl(rel.RA, rel.Decl, obl)
            };
        }

        private double findIncl(Coordinates np, Coordinates refNP)
        {
            double radNPRA = convertDegToRad(np.RA);
            double radNPDecl = convertDegToRad(np.Decl);
            double radRefNPRA = convertDegToRad(refNP.RA);
            double radRefNPDecl = convertDegToRad(refNP.Decl);

            double value = Math.Sqrt(Math.Pow(radNPRA, 2) + Math.Pow(radRefNPRA, 2) - 2 * radNPRA * radRefNPRA * Math.Cos(radRefNPDecl - radNPDecl));
            return convertRadToDeg(value);
        }
        private double findLAN(double refNPRA, double refNPDecl, double originRA, double originDecl)
        {
            double radRefNPRA = convertDegToRad(refNPRA);
            double radRefNPDecl = convertDegToRad(refNPDecl);
            double radOriginRA = convertDegToRad(originRA);
            double radOriginDecl = convertDegToRad(originDecl);

            double value = Math.Cos(Math.Sqrt(Math.Pow(radOriginRA, 2) + Math.Pow(radRefNPRA, 2) - 2 * radOriginRA * radRefNPRA * Math.Cos(radRefNPDecl - radOriginDecl)));
            return convertRadToDeg(value);
        }

        private double translateRA(double ra, double decl, double obl)
        {
            double radRA = convertDegToRad(ra);
            double radDecl = convertDegToRad(decl);
            double radObl = convertDegToRad(obl);

            double num = Math.Sin(radRA) * Math.Cos(radObl) - Math.Tan(radDecl) * Math.Sin(radObl);
            double denom = Math.Cos(radRA);
            double value = Math.Atan(num / denom);
            if (denom < 0)
            {
                return convertRadToDeg(value + Math.PI);
            }
            else return convertRadToDeg(value);
        }
        private double translateDecl(double ra, double decl, double obl)
        {
            double radRA = convertDegToRad(ra);
            double radDecl = convertDegToRad(decl);
            double radObl = convertDegToRad(obl);

            double value = Math.Asin(Math.Sin(radDecl) * Math.Cos(radObl) + Math.Cos(radDecl) * Math.Sin(radObl) * Math.Sin(radRA));
            return convertRadToDeg(value);
        }

        private double convertDegToRad(double deg)
        {
            double rad = (deg / 180) * Math.PI;
            while (rad < 0)
            {
                rad += 2 * Math.PI;
            }
            while (rad >= 2 * Math.PI)
            {
                rad -= 2 * Math.PI;
            }
            return rad;
        }
        private double convertRadToDeg(double rad)
        {
            double deg = (rad / Math.PI) * 180;
            while (deg < 0)
            {
                deg += 360;
            }
            while (deg >= 360)
            {
                deg -= 360;
            }
            return Math.Round(deg, 4);
        }

        // overrides
        public override bool Equals(object obj)
        {
            if (obj is Plane && ((Plane)obj).GetHashCode() == GetHashCode())
            {
                return true;
            }
            else return false;
        }
        public override int GetHashCode()
        {
            int newHash = NP.GetHashCode();
            newHash ^= Origin.GetHashCode();
            return newHash;
        }
    }
    public interface IOrbital
    {
        Plane OrbitalPlane { get; set; }
        Body ParentBody { get; set; }
        long SemiMajorAxis { get; set; }
        double Eccentricity { get; set; }
        double Inclination { get; set; }
        double ArgPer { get; set; }
        double LongAsc { get; set; }
    }
    public interface ILaplace
    {
        Plane LaplacePlane { get; set; }
        int apPrecPer { get; set; }
        int nodPrecPer { get; set; }
    }
    public abstract class Body
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public long GM { get; set; }
        public int Radius { get; set; }
        public int AtmosphereHeight { get; set; }
        public Plane EqPlane { get; set; }
        public double SidRotPeriod { get; set; }

        // overrides
        public override bool Equals(object obj)
        {
            if (((Body)obj).GetHashCode() == this.GetHashCode())
            {
                return true;
            }
            else return false;
        }
        public override int GetHashCode()
        {
            int newHash = GM.GetHashCode();
            newHash ^= Radius.GetHashCode();
            newHash ^= AtmosphereHeight.GetHashCode();
            newHash ^= EqPlane.GetHashCode();
            newHash ^= SidRotPeriod.GetHashCode();
            return newHash;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class FixedOrbitingObject : IOrbital
    {
        public Plane OrbitalPlane { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public Body ParentBody { get; set; }
        public long SemiMajorAxis { get; set; }
        public double Eccentricity { get; set; }
        public double Inclination { get; set; }
        public double ArgPer { get; set; }
        public double LongAsc { get; set; }
    }
    public class OrbitingObject : FixedOrbitingObject, ILaplace
    {
        public Plane LaplacePlane { get; set; }
        public int apPrecPer { get; set; }
        public int nodPrecPer { get; set; }
    }
    public class FixedOrbitingBody : Body, IOrbital
    {
        public Plane OrbitalPlane { get; set; }
        public Body ParentBody { get; set; }
        public long SemiMajorAxis { get; set; }
        public double Eccentricity { get; set; }
        public double Inclination { get; set; }
        public double ArgPer { get; set; }
        public double LongAsc { get; set; }
        public long SOIRad { get; set; }

        public void CalculateSOIRad()
        {

        }
    }
    public class OrbitingBody : FixedOrbitingBody, ILaplace
    {
        public Plane LaplacePlane { get; set; }
        public int apPrecPer { get; set; }
        public int nodPrecPer { get; set; }
    }
    public class Star : Body
    {
        public Plane ReferencePlane { get; set; }
        new public BigInteger GM { get; set; }
    }
    public struct BigGM
    {
        public static BigInteger ENotation(double value, double displacement)
        {
            return (BigInteger)value * (BigInteger)Math.Pow(10, displacement);
        }
    }
}