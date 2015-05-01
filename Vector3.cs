using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGeometry
{
    public class Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public Vector3(float x,float y , float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public float GetDistance()
        {
            return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
        }
        public Vector3 ScalarMultiplyWith(float scalarNumber)
        {
            return new Vector3(X * scalarNumber, Y * scalarNumber, Z * scalarNumber);
        }
        public Vector3 AddDistance(float dis)
        {
            Vector3 unitVector = new Vector3(X / GetDistance(), Y / GetDistance(), Z / GetDistance());
            return this.VectorAdd(unitVector.ScalarMultiplyWith(dis));
        }
        public Vector3 VectorAdd(Vector3 addingVector)
        {
            return new Vector3(X + addingVector.X, Y + addingVector.Y, Z + addingVector.Z);
        }
        public Vector3 GetMinus()
        {
            return new Vector3(-X, -Y , -Z );
        }
        static public Vector3 Zero()
        {
            return new Vector3(0f, 0f, 0f);
        }

    }
}
