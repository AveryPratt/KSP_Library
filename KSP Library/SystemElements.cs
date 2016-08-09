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
        Plane(double npra, double npdecl, double fixedra, double fixeddecl)
        {
            NPRA = npra;
            NPDecl = npdecl;
            FixedRA = fixedra;
            FixedDecl = fixeddecl;
        }
        Plane(Plane refPlane, double npra, double npdecl)
        {
            NPRA = npra;
            NPDecl = npdecl;
            RefPlane = refPlane;
            setElements();
        }
        Plane(double incl, double longAsc, Plane refPlane)
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
            Inclination = Math.Sqrt(Math.Pow(radNPRA, 2) + Math.Pow(radRefNPRA, 2) - 2 * radNPRA * radRefNPRA * Math.Cos(radRefNPDecl - radNPDecl));
            //LongAsc = Math.Sqrt(Math.Pow(radFixRA, 2) + Math.Pow(radRefNPRA, 2) - 2 * radFixRA * radRefNPRA * Math.Cos(radRefNPDecl - radFixDecl));
            LongAsc = Math.Cos(Math.Sqrt(Math.Pow(radFixRA, 2) + Math.Pow(radRefNPRA, 2) - 2 * radFixRA * radRefNPRA * Math.Cos(radRefNPDecl - radFixDecl)));
        }
        private void setCoordinates()
        {
            NPRA = convertRadToDeg();
            NPDecl = convertRadToDeg();
            FixedRA = convertRadToDeg();
            FixedDecl = convertRadToDeg();
        }
        private double convertDegToRad(double deg)
        {
            return (deg / 360) * Math.PI;
        }
        private double convertRadToDeg(double rad)
        {
            return (rad / Math.PI) * 360;
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
        public Plane EclipticPlane { get; set; }
        public Plane InvarPlane { get; set; }
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