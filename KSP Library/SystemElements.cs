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
        internal interface ISystem
        {
            Body GetSystemBody(string bodyName);
            Body GetSystemBody(int bodyID);
            Body[] GetSystemBodies();
        }

        public abstract class SolarSystem : ISystem
        {
            public Body[] bodies { get; set; }
            public virtual Body GetSystemBody(string bodyName)
            {
                return bodies.Single(b => b.Name == bodyName.ToUpper());
            }
            public virtual Body GetSystemBody(int bodyIndex)
            {
                return bodies[bodyIndex];
            }
            public virtual Body[] GetSystemBodies()
            {
                return bodies;
            }

            public override string ToString()
            {
                StringBuilder bodyNames = new StringBuilder();
                foreach(Body body in bodies)
                {
                    bodyNames.Append(body.ToString());
                }
                return bodyNames.ToString();
            }
        }

        public class Body
        {
            public string Name { get; set; }
            public int Radius { get; set; }
            public long GM { get; set; }

            public override string ToString()
            {
                return Name;
            }
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                else if (!(obj is Body))
                {
                    return false;
                }
                else if (Name != ((Body)obj).Name)
                {
                    return false;
                }
                else return true;
            }
            public override int GetHashCode()
            {
                return Name.GetHashCode();
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
}
