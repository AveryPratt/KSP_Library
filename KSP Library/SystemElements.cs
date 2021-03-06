﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KSP_Library
{
    public struct VecCart
    {
        public double X;
        public double Y;
        public double Z;
        
        public void Rotate(VecCart axis, double angle)
        {
            //double a;
            //double b;
            //double c;
            //// z-axis rotation
            //X = a * Math.Cos(angle) - Y * Math.Sin(angle);
            //Y = b * Math.Sin(angle) + Y * Math.Cos(angle);
            //Z = c;

            /*x' = x*cos q - y*sin q
            y' = x*sin q + y*cos q 
            z' = z*/

            angle = (angle / 180) * Math.PI;

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

        public void RefineCoords()
        {
            while (RA < 0)
            {
                RA += 360;
            }
            while (RA >= 360)
            {
                RA -= 360;
            }
            while (Decl < 0)
            {
                Decl += 360;
            }
            while (Decl >= 360)
            {
                Decl -= 360;
            }
        }
        public VecCart ToVecCart()
        {
            VecSphere temp = this;
            temp.ConvertToRad();
            return new VecCart()
            {
                X = Math.Sin(Math.PI / 2 - temp.Decl) * Math.Cos(temp.RA),
                Y = Math.Sin(Math.PI / 2 - temp.Decl) * Math.Sin(temp.RA),
                Z = Math.Cos(Math.PI / 2 - temp.Decl)
            };
        }
        public VecSphere TranslateCoords(Plane refPlane)
        {
            VecSphere axis = new VecSphere()
            {
                RA = (refPlane.NP.RA + 270) % 360,
                Decl = 0
            };
            VecCart cart = this.ToVecCart();
            cart.Rotate(axis.ToVecCart(), 90 - refPlane.NP.Decl);
            VecSphere newCoords = cart.ToVecSphere();
            double relAxisRA;
            if (refPlane.NP.Decl < 0 ^ refPlane.Origin.RA - axis.RA > 180)
            {
                relAxisRA = 360 - Plane.FindCAngle(axis, refPlane.Origin);
            }
            else
            {
                relAxisRA = Plane.FindCAngle(axis, refPlane.Origin);
            }
            newCoords.RA += relAxisRA - axis.RA;
            newCoords.RefineCoords();
            return newCoords;
        }

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

        public override int GetHashCode()
        {
            int newHash = RA.GetHashCode();
            newHash ^= Decl.GetHashCode();
            return newHash;
        }
        public override bool Equals(object obj)
        {
            if(obj.GetType() != typeof(VecSphere))
            {
                return false;
            }
            else if (((VecSphere)obj).GetHashCode() != this.GetHashCode())
            {
                return false;
            }
            else return true;
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
            RefPlane = refPlane;
            Incl = FindCAngle(np, refPlane.NP);
            NP = np;

            // find: LAN, Origin (relOrigin, relNP)

            VecSphere rotAxis = new VecSphere()
            {
                RA = (refPlane.NP.RA + 90) % 360,
                Decl = 0
            };
            VecCart rotAxisCart = rotAxis.ToVecCart();
            VecCart NPCart = NP.ToVecCart();
            NPCart.Rotate(rotAxisCart, Incl);
            VecSphere relNP = NPCart.ToVecSphere();
            VecSphere refRotAxis = new VecSphere()
            {
                Decl = 0
            };
            if (NP.Decl >= 0 ^ refPlane.Origin.RA - rotAxis.RA > 180)
            {
                refRotAxis.RA = FindCAngle(refPlane.Origin, rotAxis);
            }
            else
            {
                refRotAxis.RA = 360 - FindCAngle(refPlane.Origin, rotAxis);
            }
            relNP.RA += (refRotAxis.RA - rotAxis.RA);
            LAN = (relNP.RA + 90) % 360;
            //VecSphere relOrigin = new VecSphere()
            //{
            //    RA = (relNP.RA + 90) % 360,
            //    Decl = 0
            //};
            //VecCart relOriginCart = relOrigin.ToVecCart();
            //VecSphere rotAxisInv = new VecSphere()
            //{
            //    RA = (rotAxis.RA + 180) % 360,
            //    Decl = 0
            //};
            //relOriginCart.Rotate(rotAxisInv.ToVecCart(), refPlane.Incl);
            //Origin = relOriginCart.ToVecSphere();
            //if (NP.Decl >= 0 ^ refPlane.Origin.RA - rotAxis.RA > 180)
            //{
            //    refRotAxis.RA = FindCAngle(refPlane.Origin, rotAxis);
            //}
            //else
            //{
            //    refRotAxis.RA = 360 - FindCAngle(refPlane.Origin, rotAxis);
            //}
        }
        public Plane(Plane refPlane, double lan, double incl, string name = "")
        {
            Name = name;
            RefPlane = refPlane;
            Incl = incl;
            LAN = lan;

            // find: NP, Origin
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
            VecCart vecCart = vec.ToVecCart();
            Plane rotPlane = new Plane(NP); // uses this Plane with reset RefPlane
            double rot1;
            if (RefPlane.Origin.Decl < 0)
            {
                rot1 = 360 - FindCAngle(rotPlane.Origin, RefPlane.Origin);
            }
            else
            {
                rot1 = FindCAngle(rotPlane.Origin, RefPlane.Origin);
            }
            double rot2;
            rot2 = rotPlane.Origin.RA;
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

        public static double FindCAngle(VecSphere vs1, VecSphere vs2)
        {
            vs1.ConvertToRad();
            vs2.ConvertToRad();

            double vec1NPDif = Math.PI / 2 - vs1.Decl;
            double vec2NPDif = Math.PI / 2 - vs2.Decl;
            double raDif = Math.Abs(vs2.RA - vs1.RA);

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
            foreach (Body body in Bodies)
            {
                bodyNames.Append(body.ToString() + "\n");
            }
            return bodyNames.ToString();
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