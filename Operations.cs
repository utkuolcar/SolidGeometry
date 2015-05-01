using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGeometry
{
    public static class Operations
    {
        public static double UzunlukBul(Vector3 joint1, Vector3 joint2)
        {
            double uzunluk = 
                Math.Sqrt(Math.Pow(((double)joint1.X - (double)joint2.X), 2) 
                + Math.Pow(((double)joint1.Y - joint2.Y), 2) 
                + Math.Pow(((double)joint1.Z - joint2.Z), 2));
            return uzunluk;
        }
        public static double AciBul(double a, double b, double c)
        {
            double aci = Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b));
            aci = aci * 57.2957795;
            return aci;
        }
        public static int Map(int Value, int FromLow, int FromHigh, int ToLow, int ToHigh)
        {
            double Result;
            Result = (((Value - FromLow) * (ToHigh - ToLow)) / (FromHigh - FromLow)) + ToLow;

            return Convert.ToInt32(Result);
        }
        public static double Map(double Value, double FromLow, double FromHigh, double ToLow, double ToHigh)
        {
            double Result;
            Result = (((Value - FromLow) * (ToHigh - ToLow)) / (FromHigh - FromLow)) + ToLow;

            return Result;
        }
        public static float Map(float Value, float FromLow, float FromHigh, float ToLow, float ToHigh)
        {
            double Result;
            Result = (((Value - FromLow) * (ToHigh - ToLow)) / (FromHigh - FromLow)) + ToLow;

            return (float)Result;
        }
    }
}
