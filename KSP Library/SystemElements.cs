using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KSP_Library
{
    // systems
    internal interface ISystem
    {
        Body[] Bodies { get; set; }
        Body GetSystemBody(string bodyName);
        Body GetSystemBody(int bodyIndex);
    }

    public abstract class SolarSystem : ISystem
    {
        public Body[] Bodies { get; set; }

        public virtual Body GetSystemBody(string bodyName)
        {
            return Bodies.Single(b => b.Name == bodyName.ToUpper());
        }
        public virtual Body GetSystemBody(int bodyIndex)
        {
            return Bodies[bodyIndex];
        }

        public override string ToString()
        {
            StringBuilder bodyNames = new StringBuilder();
            foreach(Body body in Bodies)
            {
                bodyNames.Append(body.ToString());
            }
            return bodyNames.ToString();
        }
    }

    // celestial bodies
    public interface IParent
    {
        OrbitingBody[] ChildBodies { get; set; }
    }

    public interface IOrbital
    {
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
        public double NPRightAsc { get; set; }
        public double NPDeclination { get; set; }
        public int RotPeriod { get; set; }
    }

    public class OrbitingObject : IOrbital
    {
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

    public class ParentOrbitingBody : OrbitingBody, IParent
    {
        public OrbitingBody[] ChildBodies { get; set; }
    }

    public class Star : Body, IParent
    {
        public OrbitingBody[] ChildBodies { get; set; }
        new public BigInteger GM { get; set; }
    }

    public struct BigGM
    {
        public static BigInteger ENotation(double value, double displacement)
        {
            return (BigInteger)value * (BigInteger)Math.Pow(10, displacement);
        }
    }

    //public abstract class Body
    //{
    //    // independent properties
    //    public string Name { get; set; }
    //    public int Radius { get; set; }
    //    public long GM { get; set; }
    //    public int AtmosphereHeight { get; set; }

    //    // possibly dependent properties
    //    public bool HasAtmosphere { get; set; }
    //    public long SOI { get; set; }

    //    // new methods
    //    public int GetEscapeVelocity(int distance, bool IsDistanceFromCenter)
    //    {
    //        if (!IsDistanceFromCenter)
    //        {
    //            distance += Radius;
    //        }
    //        return (int)Math.Round(Math.Sqrt((2*GM)/distance));
    //    }
    //    public int GetOrbitalVelocity(int semiMajorAxis, int distance, bool IsDistanceFromCenter)
    //    {
    //        if (!IsDistanceFromCenter)
    //        {
    //            distance += Radius;
    //        }
    //        return (int)Math.Round(Math.Sqrt(GM * (2 / distance - 1 / semiMajorAxis)));
    //    }

    //    // override methods
    //    public override string ToString()
    //    {
    //        return Name;
    //    }
    //    public override bool Equals(object obj)
    //    {
    //        if (obj == null)
    //        {
    //            return false;
    //        }
    //        else if (!(obj is Body))
    //        {
    //            return false;
    //        }
    //        else if (Name != ((Body)obj).Name)
    //        {
    //            return false;
    //        }
    //        else return true;
    //    }
    //    public override int GetHashCode()
    //    {
    //        return Name.GetHashCode();
    //    }
    //}

    //public class Star : Body
    //{
    //    new public BigInteger GM { get; set; }
    //}

    //public class OrbitingBody : Body
    //{
    //    // independent properties
    //    public Body ParentBody { get; set; }
    //    public long SemiMajorAxis { get; set; }
    //    public double Eccentricity { get; set; }
    //    public double Inclination { get; set; }
    //    public double ArgPer { get; set; }
    //    public double LongAsc { get; set; }

    //    // dependent properties
    //    public long OrbitalPeriod { get; set; }
    //    public long Periapsis { get; set; }
    //    public long Apoapsis { get; set; }
    //}

    //public class RotatingBody : OrbitingBody
    //{
    //    // independent properties
    //    public double RightAsc { get; set; }
    //    public double Declination { get; set; }

    //    // dependent properties
    //    public double AxialTilt { get; set; }
    //}
}
