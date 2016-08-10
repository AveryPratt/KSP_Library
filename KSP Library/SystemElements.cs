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
    public class Plane
    {
        public double NPRA { get; set; }
        public double NPDecl { get; set; }
        public double FixedRA { get; set; }
        public double FixedDecl { get; set; }

        public Plane RefPlane { get; set; }
        public double Inclination { get; set; }
        public double LongAsc { get; set; }

        // constructors
        public Plane()
        {
            NPRA = 0;
            NPDecl = 90;
            FixedRA = 0;
            FixedDecl = 0;
        }
        public Plane(double npRA, double npDecl, double fixedRA, double fixedDecl)
        {
            NPRA = npRA;
            NPDecl = npDecl;
            FixedRA = fixedRA;
            FixedDecl = fixedDecl;
        }
        public Plane(Plane refPlane, double npRA, double npDecl)
        {
            NPRA = npRA;
            NPDecl = npDecl;
            RefPlane = refPlane;
            setElements();
        }
        public Plane(double longAsc, double incl, Plane refPlane)
        {
            Inclination = incl;
            LongAsc = longAsc;
            RefPlane = refPlane;
            setCoordinates();
        }

        private void setElements()
        {
            double radNPRA = convertDegToRad(NPRA);
            double radNPDecl = convertDegToRad(NPDecl);
            double radRefNPRA = convertDegToRad(RefPlane.NPRA);
            double radRefNPDecl = convertDegToRad(RefPlane.NPDecl);
            double radFixRA = convertDegToRad(FixedRA);
            double radFixDecl = convertDegToRad(FixedDecl);
            Inclination = convertRadToDeg(Math.Sqrt(Math.Pow(radNPRA, 2) + Math.Pow(radRefNPRA, 2) - 2 * radNPRA * radRefNPRA * Math.Cos(radRefNPDecl - radNPDecl)));
            //LongAsc = Math.Sqrt(Math.Pow(radFixRA, 2) + Math.Pow(radRefNPRA, 2) - 2 * radFixRA * radRefNPRA * Math.Cos(radRefNPDecl - radFixDecl));
            LongAsc = convertRadToDeg(Math.Cos(Math.Sqrt(Math.Pow(radFixRA, 2) + Math.Pow(radRefNPRA, 2) - 2 * radFixRA * radRefNPRA * Math.Cos(radRefNPDecl - radFixDecl))));
        }
        private double convertDegToRad(double deg)
        {
            return (deg / 360) * Math.PI;
        }
        private double convertRadToDeg(double rad)
        {
            return (rad / Math.PI) * 360;
        }

        private void setCoordinates()
        {
            double relativeNPRA = 90 - LongAsc;
            double relativeNPDecl = 90 - Inclination;
            double relativeFixedRA = LongAsc;
            double relativeFixedDecl = 0;
            double obl = Inclination;
            NPRA = convertRadToDeg(translateRA(relativeNPRA, relativeNPDecl, obl));
            NPDecl = convertRadToDeg(translateDecl(relativeNPRA, relativeNPDecl, obl));
            FixedRA = convertRadToDeg(translateRA(relativeFixedRA, relativeFixedDecl, obl));
            FixedDecl = convertRadToDeg(translateDecl(relativeFixedRA, relativeFixedDecl, obl));
        }
        private double translateRA(double ra, double decl, double obl)
        {
            return Math.Atan(Math.Sin(ra) * Math.Cos(obl) - Math.Tan(decl) * Math.Sin(obl) / Math.Cos(ra));
        }
        private double translateDecl(double ra, double decl, double obl)
        {
            return Math.Asin(Math.Sin(decl) * Math.Cos(obl) + Math.Cos(decl) * Math.Sin(obl) * Math.Sin(ra));
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
    public class OrbitingObject : IOrbital
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
    public class OrbitingBody : Body, IOrbital
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