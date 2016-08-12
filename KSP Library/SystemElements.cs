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
    public struct VecCart
    {
        public double X;
        public double Y;
        public double Z;

        private VecSphere ToVecSphere()
        {
            return new VecSphere()
            {
                RA = Math.Atan2(Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2)), Z),
                Decl = Math.Atan2(Y, X)
            };
        }

        public override int GetHashCode()
        {
            int newHash = X.GetHashCode();
            newHash ^= Y.GetHashCode();
            newHash ^= Z.GetHashCode();
            return newHash;
        }
        public override bool Equals(object obj)
        {
            if (((VecCart)obj).X == X && ((VecCart)obj).Y == Y && ((VecCart)obj).Z == Z)
            {
                return true;
            }
            else return false;
        }
    }
    public struct VecSphere
    {
        public double RA;
        public double Decl;

        private VecCart ToVecCart()
        {
            return new VecCart()
            {
                X = Math.Sin(RA) * Math.Cos(Decl),
                Y = Math.Sin(RA) * Math.Cos(Decl),
                Z = Math.Cos(RA)
            };
        }

        public override int GetHashCode()
        {
            int newHash = RA.GetHashCode();
            newHash ^= Decl.GetHashCode();
            return newHash;
        }
        public override bool Equals(object obj)
        {
            if (((VecSphere)obj).RA == RA && ((VecSphere)obj).Decl == Decl)
            {
                return true;
            }
            else return false;
        }
    }
    public class Plane
    {
        public string Name { get; set; }
        public VecSphere NP { get; set; }
        public VecSphere Origin { get; set; }

        public Plane RefPlane { get; set; }
        public double Incl { get; set; }
        public double LAN { get; set; }

        // constructors
        public Plane(string name = "Default Plane")
        {
            Name = name;
            NP = new VecSphere()
            {
                RA = 0,
                Decl = 90
            };
            Origin = new VecSphere()
            {
                RA = 0,
                Decl = 0
            };
        }
        public Plane(VecSphere np, string name = "")
        {
            Name = name;
            NP = np;
            
            LAN = np.RA + 90;
            Incl = 90 - np.Decl;
            RefPlane = new Plane();

            Origin = new VecSphere()
            {
                RA = LAN,
                Decl = 0
            };
        }
        public Plane(Plane refPlane, VecSphere np, string name = "")
        {
            Name = name;
            NP = np;
            RefPlane = refPlane;
            
            VecSphere relNP = translateFixToRel(np, refPlane);
            LAN = relNP.RA + 90;
            Incl = findCAngle(np, refPlane.NP);
            VecSphere relOrigin = new VecSphere()
            {
                RA = LAN,
                Decl = 0
            };
            Origin = translateRelToFix(relOrigin, refPlane);
        }
        public Plane(Plane refPlane, double lan, double incl, string name = "")
        {
            Name = name;
            LAN = lan;
            Incl = incl;
            RefPlane = refPlane;
            VecSphere relNP = new VecSphere()
            {
                RA = lan - 90,
                Decl = 90 - incl
            };
            NP = translateRelToFix(relNP, refPlane);
            VecSphere relOrigin = new VecSphere()
            {
                RA = lan,
                Decl = 0
            };
            Origin = translateRelToFix(relOrigin, refPlane);
        }
        private Plane resetPlane(Plane plane)
        {
            Plane newPlane = new Plane(plane.NP, plane.Name);
            return newPlane;
        }

        private VecSphere translateFixToRel(VecSphere fix, Plane relPlane)
        {
            double obl = 90 - relPlane.NP.Decl;
            return new VecSphere()
            {
                RA = translateRA(fix, obl),
                Decl = translateDecl(fix, obl)
            };
        }
        private VecSphere translateRelToFix(VecSphere rel, Plane relPlane)
        {
            double obl = 90 - relPlane.NP.Decl;
            return new VecSphere()
            {
                RA = translateRA(rel, obl),
                Decl = translateDecl(rel, obl)
            };
        }

        private double findCAngle(VecSphere np, VecSphere refNP)
        {
            double radNPDecl = convertDegToRad(90 - np.Decl);
            double radRefNPDecl = convertDegToRad(90 - refNP.Decl);
            double raDif = Math.Abs(convertDegToRad(refNP.RA) - convertDegToRad(np.RA));

            // spherical law of cosines
            double cAngle = Math.Acos(Math.Cos(radNPDecl) * Math.Cos(radRefNPDecl) + Math.Sin(radNPDecl) * Math.Sin(radRefNPDecl) * Math.Cos(raDif));
            return convertRadToDeg(cAngle);
        }
        private double findLAN(VecSphere refNP, VecSphere origin)
        {
            double radRefNPRA = convertDegToRad(refNP.RA);
            double radRefNPDecl = convertDegToRad(refNP.Decl);
            double radOriginRA = convertDegToRad(origin.RA);
            double radOriginDecl = convertDegToRad(origin.Decl);

            double value = Math.Cos(Math.Sqrt(Math.Pow(radOriginRA, 2) + Math.Pow(radRefNPRA, 2) - 2 * radOriginRA * radRefNPRA * Math.Cos(radRefNPDecl - radOriginDecl)));
            return convertRadToDeg(value);
        }

        private double translateRA(VecSphere vec, double obl)
        {
            double radRA = convertDegToRad(vec.RA);
            double radDecl = convertDegToRad(vec.Decl);
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
        private double translateDecl(VecSphere vec, double obl)
        {
            double radRA = convertDegToRad(vec.RA);
            double radDecl = convertDegToRad(vec.Decl);
            double radObl = convertDegToRad(obl);

            double value = Math.Asin(Math.Sin(radDecl) * Math.Cos(radObl) + Math.Cos(radDecl) * Math.Sin(radObl) * Math.Sin(radRA));
            return convertRadToDeg(value);
        }

        private double translateRAReverse(double ra, double decl, double obl)
        {
            double radRA = convertDegToRad(ra);
            double radDecl = convertDegToRad(decl);
            double radObl = convertDegToRad(obl);

            double num = Math.Sin(radRA) * Math.Cos(radObl) - Math.Tan(radDecl) * Math.Sin(radObl);
            double denom = Math.Cos(radRA);
            double value = Math.Atan(num / denom);

            double Rnum = Math.Sin(radRA) * Math.Cos(radObl) - Math.Tan(radDecl) * Math.Sin(radObl);
            double Rdenom = Math.Cos(radRA);
            if (denom < 0)
            {
                return convertRadToDeg(value + Math.PI);
            }
            else return convertRadToDeg(value);
        }
        private double translateDeclReverse(double ra, double decl, double obl)
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