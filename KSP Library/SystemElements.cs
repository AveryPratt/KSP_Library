using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KSP_Library
{
    // systems
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
        public double SidRotPeriod { get; set; }
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

    public class Star : Body
    {
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
