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
    }
}
