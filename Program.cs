using KSP_Library;
using KSP_Library.Systems;
using KSP_Library.Rocketry;
using System;
using System.Collections.Generic;

namespace RocketConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            VecSphere np1 = new VecSphere() { RA = 90, Decl = 90 };
            VecSphere np2 = new VecSphere() { RA = 180, Decl = 90 };
            VecSphere np3 = new VecSphere() { RA = 45, Decl = 60 };
            VecSphere np4 = new VecSphere() { RA = 135, Decl = 60 };

            Plane plane1 = new Plane("Plane 1");
            Plane plane2 = new Plane(np1, "Plane 2");
            Plane plane3 = new Plane(np2, "Plane 3");
            Plane plane4 = new Plane(np3, "Plane 4");
            Plane plane5 = new Plane(np4, "Plane 5");

            string test1 = "Const 1:\nNPRA: " + plane1.NP.RA + " - 270???" +
                "\nNPDecl: " + plane1.NP.Decl + " - 90" +
                "\nOrRA: " + plane1.Origin.RA + " - 0???" +
                "\nOrDecl: " + plane1.Origin.Decl + " - 0\n\n";
            Console.WriteLine(test1);

            string test2 = "Const 2:\nNPRA: " + plane2.NP.RA + " - 90???" +
                "\nNPDecl: " + plane2.NP.Decl + " - 90" +
                "\nOrRA: " + plane2.Origin.RA + " - 0???" +
                "\nOrDecl: " + plane2.Origin.Decl + " - 0" +
                "\nRefNPRA: " + plane2.RefPlane.NP.RA + " - 270???" +
                "\nRefNPDecl: " + plane2.RefPlane.NP.Decl + " - 90" +
                "\nRefOrRA: " + plane2.RefPlane.Origin.RA + " - 0???" +
                "\nRefOrDecl: " + plane2.RefPlane.Origin.Decl + " - 0\n\n";
            Console.WriteLine(test2);
            
            string test3 = "Const 2:\nNPRA: " + plane3.NP.RA + " - 180???" +
                "\nNPDecl: " + plane3.NP.Decl + " - 90" +
                "\nOrRA: " + plane3.Origin.RA + " - 270???" +
                "\nOrDecl: " + plane3.Origin.Decl + " - 0" +
                "\nRefNPRA: " + plane3.RefPlane.NP.RA + " - 270???" +
                "\nRefNPDecl: " + plane3.RefPlane.NP.Decl + " - 90" +
                "\nRefOrRA: " + plane3.RefPlane.Origin.RA + " - 0???" +
                "\nRefOrDecl: " + plane3.RefPlane.Origin.Decl + " - 0\n\n";
            Console.WriteLine(test3);
            
            string test4 = "Const 2:\nNPRA: " + plane4.NP.RA + " - 90" +
                "\nNPDecl: " + plane4.NP.Decl + " - 60" +
                "\nOrRA: " + plane4.Origin.RA + " - 315" +
                "\nOrDecl: " + plane4.Origin.Decl + " - 0" +
                "\nRefNPRA: " + plane4.RefPlane.NP.RA + " - 270???" +
                "\nRefNPDecl: " + plane4.RefPlane.NP.Decl + " - 90" +
                "\nRefOrRA: " + plane4.RefPlane.Origin.RA + " - 0???" +
                "\nRefOrDecl: " + plane4.RefPlane.Origin.Decl + " - 0\n\n";
            Console.WriteLine(test4);

            string test5 = "Const 2:\nNPRA: " + plane5.NP.RA + " - 90" +
                "\nNPDecl: " + plane5.NP.Decl + " - 60" +
                "\nOrRA: " + plane5.Origin.RA + " - 315" +
                "\nOrDecl: " + plane5.Origin.Decl + " - 0" +
                "\nRefNPRA: " + plane5.RefPlane.NP.RA + " - 270???" +
                "\nRefNPDecl: " + plane5.RefPlane.NP.Decl + " - 90" +
                "\nRefOrRA: " + plane5.RefPlane.Origin.RA + " - 0???" +
                "\nRefOrDecl: " + plane5.RefPlane.Origin.Decl + " - 0\n\n";
            Console.WriteLine(test5);

            //Console.WriteLine("constructor 3 test 1");
            //Plane plane5 = new Plane(plane1, np1, "Plane 5");
            //Console.WriteLine(plane5.ToString());

            //Console.WriteLine("constructor 3 test 2");
            //Plane plane6 = new Plane(plane4, np1, "Plane 6");
            //Console.WriteLine(plane6.ToString());

            //Console.WriteLine("constructor 3 test 3");
            //Plane plane7 = new Plane(plane4, np3);
            //Console.WriteLine(plane7.ToString());





            //List<Plane> planes = new List<Plane>();
            //Plane plane1 = new Plane("Plane1");
            //Plane plane2 = new Plane(new VecSphere() { RA = 315, Decl = 80 }, "Plane2");
            //Plane plane3 = new Plane(plane1, new VecSphere() { RA = 225, Decl = 80 }, "Plane3");
            //Plane plane4 = new Plane(plane2, new VecSphere() { RA = 225, Decl = 80 }, "Plane4");
            //Plane plane5 = new Plane(new VecSphere() { RA = 315, Decl = 0 }, "Plane 5");
            //Plane plane6 = new Plane(plane5, new VecSphere() { RA = 225, Decl = 80 }, "Plane6");

            ////planes.Add(plane1);
            ////planes.Add(plane2);
            //planes.Add(plane3);
            //planes.Add(plane4);
            //planes.Add(plane6);

            //foreach (Plane plane in planes)
            //{
            //    if (plane.RefPlane == null)
            //    {
            //        plane.RefPlane = new Plane("Plane not found");
            //    }
            //    Console.WriteLine(
            //        plane.Name + "\nNorth Pole RA: " +
            //        plane.NP.RA + "\nNorth Pole Decl: " +
            //        plane.NP.Decl + "\nOrigin Point RA: " +
            //        plane.Origin.RA + "\nOrigin Point Decl: " +
            //        plane.Origin.Decl + "\n\nCheck Angle(90): " + 
            //        Plane.FindCAngle(plane.NP, plane.Origin) + "\n\nReference Plane: " +
            //        plane.RefPlane.Name + "\nLongitude of Ascending Node: " +
            //        plane.LAN + "\nInclination: " +
            //        plane.Incl +
            //        "\n\n------------\n"
            //        );
            //    Console.WriteLine(
            //        plane.RefPlane.Name + "\nNorth Pole RA: " +
            //        plane.RefPlane.NP.RA + "\nNorth Pole Decl: " +
            //        plane.RefPlane.NP.Decl + "\nOrigin Point RA: " +
            //        plane.RefPlane.Origin.RA + "\nOrigin Point Decl: " +
            //        plane.RefPlane.Origin.Decl + "\n\nCheck Angle(90): " +
            //        Plane.FindCAngle(plane.RefPlane.NP, plane.RefPlane.Origin) + 
            //        "\n\n------------\n"
            //        );
            //}








            //SolarSystem mySystem = new RealSolarSystem();
            //Plane plane1 = ((OrbitingBody)mySystem.Bodies[6]).OrbitalPlane;
            //Console.WriteLine(
            //    plane1.Name +
            //    "\nNP RA: " +
            //    plane1.NP.RA + "\nNP Decl: " +
            //    plane1.NP.Decl + "\nReference RA: " +
            //    plane1.Origin.RA + "\nReference Decl: " +
            //    plane1.Origin.Decl + "\nLAN: " +
            //    plane1.LongAsc + "\nIncl: " +
            //    plane1.Inclination + "\n");
            //Plane plane2 = ((FixedOrbitingBody)mySystem.Bodies[1]).OrbitalPlane;
            //Console.WriteLine(
            //    plane2.Name +
            //    "\nNP RA: " +
            //    plane2.NP.RA + "\nNP Decl: " +
            //    plane2.NP.Decl + "\nReference RA: " +
            //    plane2.Origin.RA + "\nReference Decl: " +
            //    plane2.Origin.Decl + "\nLAN: " +
            //    plane2.LongAsc + "\nIncl: " +
            //    plane2.Inclination + "\n");









            //SolarSystem mySystem = new RealSolarSystem();
            //List<Plane> planes = new List<Plane>();
            //foreach (Body body in mySystem.Bodies)
            //{
            //    if (body.EqPlane != null)
            //    {
            //        Plane eqPlane = body.EqPlane;
            //        planes.Add(eqPlane);
            //    }
            //    if (body is Star && ((Star)body).ReferencePlane != null)
            //    {
            //        Plane orbPlane = ((Star)body).ReferencePlane;
            //        planes.Add(orbPlane);
            //    }
            //    if (body is OrbitingBody && ((OrbitingBody)body).LaplacePlane != null)
            //    {
            //        Plane orbPlane = ((OrbitingBody)body).LaplacePlane;
            //        planes.Add(orbPlane);
            //    }
            //    if (body is FixedOrbitingBody && ((FixedOrbitingBody)body).OrbitalPlane != null)
            //    {
            //        Plane orbPlane = ((FixedOrbitingBody)body).OrbitalPlane;
            //        planes.Add(orbPlane);
            //    }
            //}
            //Console.WriteLine("\n");
            //foreach (Plane plane in planes)
            //{
            //    if (plane.RefPlane == null)
            //    {
            //        plane.RefPlane = new Plane("Plane not found");
            //    }
            //    Console.WriteLine(
            //        plane.Name + "\nNorth Pole RA: " +
            //        plane.NP.RA + "\nNorth Pole Decl: " +
            //        plane.NP.Decl + "\nOrigin Point RA: " +
            //        plane.Origin.RA + "\nOrigin Point Decl: " +
            //        plane.Origin.Decl + "\n\nReference Plane: " +
            //        plane.RefPlane.Name + "\nLongitude of Ascending Node: " +
            //        plane.LAN + "\nInclination: " +
            //        plane.Incl + "\n\n------------\n");
            //}
        }
    }
}
