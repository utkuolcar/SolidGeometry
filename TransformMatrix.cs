using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGeometry
{
    public class TransformMatrix
    {
        public RotationalMatrix RotationMatrix { get; set; }
        public Vector3 Origin { get; set; }
        public TransformMatrix(RotationalMatrix rotation,Vector3 o)
        {
            this.RotationMatrix = rotation;
            this.Origin = o;
        }
        public TransformMatrix(double a, double alpha, double d, double theta)
        {
            double ca = Math.Cos(alpha);
            double sa = Math.Sin(alpha);
            double ct = Math.Cos(theta);
            double st = Math.Sin(theta);

            //T =[ct - st 0 a ; st* ca ct* ca -sa - sa * d; st* sa ct* sa ca ca*d; 0 0 0 1];
            Vector3 c0 = new Vector3((float)ct, (float)(st *ca), (float)(st*sa));
            Vector3 c1 = new Vector3((float)-st, (float)(ct * ca), (float)(ct * sa));
            Vector3 c2 = new Vector3(0f, (float)-sa, (float)ca);

            
            this.RotationMatrix = new RotationalMatrix(c0,c1,c2);
            this.Origin = new Vector3((float)a, (float)(-sa * d), (float)(ca * d));
        }
        public TransformMatrix inverse() {
            RotationalMatrix inverseRotation = RotationMatrix.TransposeMatrix();
            return new TransformMatrix(inverseRotation, inverseRotation * Origin.GetMinus());
        }
        public static TransformMatrix identityMatrix() {
            return new TransformMatrix(new RotationalMatrix(new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1)), new Vector3(0, 0, 0));
        }
        public static TransformMatrix operator *(TransformMatrix t1, TransformMatrix t2)
        {    
            Vector3 o = new Vector3(
                t1.RotationMatrix.Column1.X * t2.Origin.X + t1.RotationMatrix.Column2.X * t2.Origin.Y + t1.RotationMatrix.Column3.X * t2.Origin.Z + t1.Origin.X,
                t1.RotationMatrix.Column1.Y * t2.Origin.X + t1.RotationMatrix.Column2.Y * t2.Origin.Y + t1.RotationMatrix.Column3.Y * t2.Origin.Z + t1.Origin.Y,
                t1.RotationMatrix.Column1.Z * t2.Origin.X + t1.RotationMatrix.Column2.Z * t2.Origin.Y + t1.RotationMatrix.Column3.Z * t2.Origin.Z + t1.Origin.Z);

            return new TransformMatrix(t1.RotationMatrix*t2.RotationMatrix,o);
        }
        public static Vector3 operator *(TransformMatrix t1, Vector3 v)
        {
           return new Vector3(
                t1.RotationMatrix.Column1.X * v.X + t1.RotationMatrix.Column2.X * v.Y + t1.RotationMatrix.Column3.X * v.Z + t1.Origin.X,
                t1.RotationMatrix.Column1.Y * v.X + t1.RotationMatrix.Column2.Y * v.Y + t1.RotationMatrix.Column3.Y * v.Z + t1.Origin.Y,
                t1.RotationMatrix.Column1.Z * v.X + t1.RotationMatrix.Column2.Z * v.Y + t1.RotationMatrix.Column3.Z * v.Z + t1.Origin.Z);

        }
    }
}
