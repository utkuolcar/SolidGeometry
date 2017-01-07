using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolidGeometry;

namespace SolidGeometry
{
    public class RotationalMatrix
    {
        public Vector3 Column1 { get; set; }
        public Vector3 Column2 { get; set; }
        public Vector3 Column3 { get; set; }

        public RotationalMatrix(Vector3 column1, Vector3 column2, Vector3 column3)
        {
            Column1 = column1;
            Column2 = column2;
            Column3 = column3;
        }
        public RotationalMatrix(double roll, double pitch, double yaw)
        {
            Column1 = new Vector3(
                (float)(Math.Cos(roll) * Math.Cos(pitch) * Math.Cos(yaw) - Math.Sin(roll) * Math.Sin(yaw)),
                (float)(Math.Sin(roll) * Math.Cos(pitch) * Math.Cos(yaw) + Math.Cos(roll) * Math.Sin(yaw)),
                (float)(-Math.Sin(pitch)* Math.Cos(yaw)));
            Column2 = new Vector3(
                (float)(-Math.Cos(roll) * Math.Cos(pitch) * Math.Sin(yaw) - Math.Sin(roll) * Math.Cos(yaw)),
                (float)(-Math.Sin(roll) * Math.Cos(pitch) * Math.Sin(yaw) + Math.Cos(roll) * Math.Cos(yaw)),
                (float)(Math.Sin(pitch) * Math.Sin(yaw)));
            Column3 = new Vector3(
                (float)(Math.Cos(roll) * Math.Cos(pitch) ),
                (float)(Math.Sin(roll) * Math.Cos(pitch)),
                (float)(Math.Cos(pitch)));

        }
        public RotationalMatrix InverseMatrix()
        {
            RotationalMatrix matrix = GetCofactor();
            float determinant = GetDeterminant();
            return new RotationalMatrix(matrix.Column1.ScalarMultiplyWith(determinant), matrix.Column2.ScalarMultiplyWith(determinant), matrix.Column3.ScalarMultiplyWith(determinant));     
        }
        public RotationalMatrix TransposeMatrix()
        {
            return new RotationalMatrix(new Vector3(Column1.X, Column2.X, Column3.X), new Vector3(Column1.Y, Column2.Y, Column3.Y), new Vector3(Column1.Z, Column2.Z, Column3.Z));
        }
        public float GetDeterminant()
        {
            return Column1.X * Column2.Y * Column3.Z + Column1.Y * Column2.Z * Column3.X + Column1.Z * Column2.X * Column3.Y - (Column3.X*Column2.Y*Column3.Z+Column1.Y*Column2.Z*Column3.X+Column3.Z*Column2.X*Column1.Y);
        }
        public static Vector3 MultiplyWith3x1(RotationalMatrix matrix, Vector3 vector)
        {
            return new Vector3((matrix.Column1.X * vector.X) + (matrix.Column2.X * vector.Y) + (matrix.Column3.X * vector.Z), (matrix.Column1.Y * vector.X) + (matrix.Column2.Y * vector.Y) + (matrix.Column3.Y * vector.Z), (matrix.Column1.Z * vector.X) + (matrix.Column2.Z * vector.Y) + (matrix.Column3.Z * vector.Z));
        }
        public static RotationalMatrix identityMatrix()
        {
            return new RotationalMatrix(new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1));
        }
        public static Vector3 operator *(RotationalMatrix r, Vector3 v)
        {
            return MultiplyWith3x1(r, v);
        }
        public static RotationalMatrix operator *(RotationalMatrix r1, RotationalMatrix r2)
        {
            Vector3 c0 = new Vector3(
                r1.Column1.X * r2.Column1.X + r1.Column2.X * r2.Column1.Y + r1.Column3.X * r2.Column1.Z, 
                r1.Column1.Y * r2.Column1.X + r1.Column2.Y * r2.Column1.Y + r1.Column3.Y * r2.Column1.Z, 
                r1.Column1.Z * r2.Column1.X + r1.Column2.Z * r2.Column1.Y + r1.Column3.Z * r2.Column1.Z);
            Vector3 c1 = new Vector3(
                r1.Column1.X * r2.Column2.X + r1.Column2.X * r2.Column2.Y + r1.Column3.X * r2.Column2.Z, 
                r1.Column1.Y * r2.Column2.X + r1.Column2.Y * r2.Column2.Y + r1.Column3.Y * r2.Column2.Z, 
                r1.Column1.Z * r2.Column2.X + r1.Column2.Z * r2.Column2.Y + r1.Column3.Z * r2.Column2.Z);
            Vector3 c2 = new Vector3(
                r1.Column1.X * r2.Column3.X + r1.Column2.X * r2.Column3.Y + r1.Column3.X * r2.Column3.Z, 
                r1.Column1.Y * r2.Column3.X + r1.Column2.Y * r2.Column3.Y + r1.Column3.Y * r2.Column3.Z, 
                r1.Column1.Z * r2.Column3.X + r1.Column2.Z * r2.Column3.Y + r1.Column3.Z * r2.Column3.Z);

            return new RotationalMatrix(c0,c1,c2);
        }
        public RotationalMatrix GetCofactor()
        {
            RotationalMatrix matrix =
                new RotationalMatrix(new Vector3(
                Column2.Y * Column3.Z - Column2.Z * Column3.Y,
                (Column2.X * Column3.Z - Column2.Z * Column3.X) * (-1),
                Column2.X * Column3.Y - Column2.Y * Column3.X),
                new Vector3(
                (Column1.Y * Column3.Z - Column1.Z * Column3.Y) * (-1),
                 Column1.X * Column3.Z - Column1.Z * Column3.X,
                (Column1.X * Column3.Y - Column1.Y * Column3.X) * (-1)),
                new Vector3(
                Column1.Y * Column2.Z - Column1.Z * Column2.Y,
                (Column1.X * Column2.Z - Column1.Z * Column2.X) * (-1),
                Column1.X * Column2.Y - Column1.Y * Column2.X)
        );
            return matrix;
        }
    }
}
