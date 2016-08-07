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
        public double RA { get; set; }
        public double Decl { get; set; }

        public Plane RefPlane { get; set; }
        public double Inclination { get; set; }
        public double LongAsc { get; set; }

        // constructors
        Plane(double ra, double decl)
        {
            RA = ra;
            Decl = decl;
        }
        Plane(double ra, double decl, Plane refPlane)
        {
            RA = ra;
            Decl = decl;
            RefPlane = refPlane;
        }
        private void getElements(double ra, double decl, Plane refPlane)
        {
            //Inclination = Math.Sqrt(ra * ra + refPlane.RA * refPlane.RA - 2 * ra * refPlane.RA * Math.Cos(refPlane.Decl - decl));
        }
        private void getCoordinates(double inclination, double longAsc, Plane refPlane)
        {
            //RA = (inclination * inclination);
            //Decl = 
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