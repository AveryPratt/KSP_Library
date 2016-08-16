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
        
        public void Rotate(VecCart axis, double angle)
        {
            double[,] R = new double[3, 3];
            R[0, 0] = Math.Cos(angle) + Math.Pow(axis.X, 2) * (1 - Math.Cos(angle));
            R[0, 1] = axis.Y * axis.X * (1 - Math.Cos(angle)) + axis.Z * Math.Sin(angle);
            R[0, 2] = axis.Z * axis.X * (1 - Math.Cos(angle)) - axis.Y * Math.Sin(angle);

            R[1, 0] = axis.X * axis.Y * (1 - Math.Cos(angle)) - axis.Z * Math.Sin(angle);
            R[1, 1] = Math.Cos(angle) + Math.Pow(axis.Y, 2) * 1 - Math.Cos(angle);
            R[1, 2] = axis.Z * axis.Y * (1 - Math.Cos(angle)) + axis.X * Math.Sin(angle);

            R[2, 0] = axis.X * axis.Z * (1 - Math.Cos(angle)) + axis.Y * Math.Sin(angle);
            R[2, 1] = axis.Y * axis.Z * (1 - Math.Cos(angle)) - axis.X * Math.Sin(angle);
            R[2, 2] = Math.Cos(angle) + Math.Pow(axis.Y, 2) * 1 - Math.Cos(angle);

            double x = X * R[0, 0] + Y * R[1, 0] + Z * R[2, 0];
            double y = X * R[0, 1] + Y * R[1, 1] + Z * R[2, 1];
            double z = X * R[0, 2] + Y * R[1, 2] + Z * R[2, 2];

            X = x;
            Y = y;
            Z = z;
        }
        public VecSphere ToVecSphere()
        {
            VecSphere radVecSphere = new VecSphere()
            {
                RA = Math.PI / 2 - Math.Atan2(Y, X),
                Decl = Math.Atan2(Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2)), Z)
            };
            radVecSphere.ConvertToDeg();
            return radVecSphere;
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

        public void ConvertToRad()
        {
            RA = convertDegToRad(RA);
            Decl = convertDegToRad(Decl);
        }
        public void ConvertToDeg()
        {
            RA = convertRadToDeg(RA);
            Decl = convertRadToDeg(Decl);
        }

        private double convertDegToRad(double deg)
        {
            return (deg / 180) * Math.PI;
            //while (rad < 0)
            //{
            //    rad += 2 * Math.PI;
            //}
            //while (rad >= 2 * Math.PI)
            //{
            //    rad -= 2 * Math.PI;
            //}
            //return rad;
        }
        private double convertRadToDeg(double rad)
        {
            return (rad / Math.PI) * 180;
            //while (deg < 0)
            //{
            //    deg += 360;
            //}
            //while (deg >= 360)
            //{
            //    deg -= 360;
            //}
            //return Math.Round(deg, 4);
        }

        public VecCart ToVecCart()
        {
            double radRA = convertDegToRad(RA);
            double radDecl = convertDegToRad(Decl);
            return new VecCart()
            {
                X = Math.Sin(Math.PI / 2 - radDecl) * Math.Cos(radRA),
                Y = Math.Sin(Math.PI / 2 - radDecl) * Math.Sin(radRA),
                Z = Math.Cos(Math.PI / 2 - radDecl)
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
                RA = 270,
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
            ResetRefPlane();
        }
        public Plane(Plane refPlane, VecSphere np, string name = "")
        {
            Name = name;
            NP = np;
            RefPlane = refPlane;
            // spherical triangle between refPlane NP and Origin, and np
            double a = (Math.PI / 180) * FindCAngle(np, refPlane.Origin);
            double b = (Math.PI / 180) * FindCAngle(np, refPlane.NP);
            double c = Math.PI / 2;
            if(np.RA > 180)
            {
                LAN = 270 - (180 / Math.PI) * Math.Acos((Math.Cos(a) - Math.Cos(b) * Math.Cos(c)) / (Math.Sin(b) * Math.Sin(c)));
            }
            else
            {
                LAN = 90 + (180 / Math.PI) * Math.Acos((Math.Cos(a) - Math.Cos(b) * Math.Cos(c)) / (Math.Sin(b) * Math.Sin(c)));
            }
            //LAN = relNP.RA + 90;
            Incl = FindCAngle(np, refPlane.NP);
            VecSphere relOrigin = new VecSphere()
            {
                RA = LAN,
                Decl = 0
            };
            Origin = RefPlane.TranslateCoords(relOrigin, false);
            //Origin = new VecSphere()
            //{
            //    RA = refPlane.Origin.RA + 
            //    Decl = Math.Cos((Math.PI / 180) * (refPlane.NP.Decl)) * LAN
            //};
            //Origin = RefPlane.TranslateCoords(relOrigin, false);
            //Origin.RA -= RefPlane.Origin.RA;
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
            NP = RefPlane.TranslateCoords(relNP, false);
            VecSphere relOrigin = new VecSphere()
            {
                RA = lan,
                Decl = 0
            };
            Origin = RefPlane.TranslateCoords(relOrigin, false);
        }
        private void setLAN()
        {
            VecSphere radRefNP = NP;
            radRefNP.ConvertToRad();
            VecSphere radOrigin = Origin;
            radOrigin.ConvertToRad();

            double radLAN = Math.Cos(Math.Sqrt(Math.Pow(radOrigin.RA, 2) + Math.Pow(radRefNP.RA, 2) - 2 * radOrigin.RA * radRefNP.RA * Math.Cos(radRefNP.Decl - radOrigin.Decl)));
            LAN = radLAN * (180 / Math.PI);
        }
        private void setIncl()
        {
            Incl = FindCAngle(NP, RefPlane.NP);
        }

        public void ResetRefPlane()
        {
            RefPlane = new Plane();
            LAN = NP.RA + 90;
            Incl = 90 - NP.Decl;
            Origin = new VecSphere()
            {
                RA = LAN,
                Decl = 0
            };
        }
        public VecSphere TranslateCoords(VecSphere vec, bool fixToRel = true)
        {
            vec.RA -= LAN;
            VecCart vecCart = vec.ToVecCart();
            Plane rotPlane = new Plane(NP); // uses this Plane with reset RefPlane
            VecSphere axis;
            if (!fixToRel)
            {
                axis = new VecSphere()
                {
                    RA = rotPlane.Origin.RA + 180,
                    Decl = rotPlane.Origin.Decl
                };
            }
            else
            {
                axis = rotPlane.Origin;
            }
            double angle = Plane.FindCAngle(rotPlane.NP, rotPlane.RefPlane.NP);
            VecCart axisCart = axis.ToVecCart();
            vecCart.Rotate(axisCart, angle);
            VecSphere vecSphere = vecCart.ToVecSphere();
            vecSphere.RA += LAN;
            return vecSphere;
        }
        public static double FindCAngle(VecSphere vec1, VecSphere vec2)
        {
            vec1.ConvertToRad();
            vec2.ConvertToRad();

            double vec1NPDif = Math.PI / 2 - vec1.Decl;
            double vec2NPDif = Math.PI / 2 - vec2.Decl;
            double raDif = Math.Abs(vec2.RA - vec1.RA);

            // spherical law of cosines
            double cAngle = Math.Acos(Math.Cos(vec1NPDif) * Math.Cos(vec2NPDif) + Math.Sin(vec1NPDif) * Math.Sin(vec2NPDif) * Math.Cos(raDif));
            return cAngle * (180 / Math.PI);
        }

        //private double translateRA(VecSphere vec, double obl)
        //{
        //    double radRA = convertDegToRad(vec.RA);
        //    double radDecl = convertDegToRad(vec.Decl);
        //    double radObl = convertDegToRad(obl);

        //    double num = Math.Sin(radRA) * Math.Cos(radObl) - Math.Tan(radDecl) * Math.Sin(radObl);
        //    double denom = Math.Cos(radRA);
        //    double value = Math.Atan(num / denom);
        //    if (denom < 0)
        //    {
        //        return convertRadToDeg(value + Math.PI);
        //    }
        //    else return convertRadToDeg(value);
        //}
        //private double translateDecl(VecSphere vec, double obl)
        //{
        //    double radRA = convertDegToRad(vec.RA);
        //    double radDecl = convertDegToRad(vec.Decl);
        //    double radObl = convertDegToRad(obl);

        //    double value = Math.Asin(Math.Sin(radDecl) * Math.Cos(radObl) + Math.Cos(radDecl) * Math.Sin(radObl) * Math.Sin(radRA));
        //    return convertRadToDeg(value);
        //}




        //private double translateRAReverse(double ra, double decl, double obl)
        //{
        //    double radRA = convertDegToRad(ra);
        //    double radDecl = convertDegToRad(decl);
        //    double radObl = convertDegToRad(obl);

        //    double num = Math.Sin(radRA) * Math.Cos(radObl) - Math.Tan(radDecl) * Math.Sin(radObl);
        //    double denom = Math.Cos(radRA);
        //    double value = Math.Atan(num / denom);

        //    double Rnum = Math.Sin(radRA) * Math.Cos(radObl) - Math.Tan(radDecl) * Math.Sin(radObl);
        //    double Rdenom = Math.Cos(radRA);
        //    if (denom < 0)
        //    {
        //        return convertRadToDeg(value + Math.PI);
        //    }
        //    else return convertRadToDeg(value);
        //}
        //private double translateDeclReverse(double ra, double decl, double obl)
        //{
        //    double radRA = convertDegToRad(ra);
        //    double radDecl = convertDegToRad(decl);
        //    double radObl = convertDegToRad(obl);

        //    double value = Math.Asin(Math.Sin(radDecl) * Math.Cos(radObl) + Math.Cos(radDecl) * Math.Sin(radObl) * Math.Sin(radRA));
        //    return convertRadToDeg(value);
        //}

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