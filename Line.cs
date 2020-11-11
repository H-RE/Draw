using SharpDX;
using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace LineasWPF
{
    class Line:Shape
    {
        public Nodo NRight, NLeft;
        
        public Line(Nodo left, Nodo right,double thickness=2):base(thickness)
       {
            NRight = right;
            NLeft = left;
            angle = Kinematics.Angle(NLeft.Position, NRight.Position);
            //Se establece el angulo inicial
            ERight.Angle = angle;
            ELeft.Angle = angle;

            NRight.PositionChanged += MoveNode;
            NLeft.PositionChanged += MoveNode;
            //Se establecen las posiciones iniciales
            ERight.Center = NRight.Position;
            ELeft.Center = NLeft.Position;

            //Se actualizan los triangulos
            SetTriangles();
            Model.Geometry.UpdateVertices();

        }

        private void MoveNode(object sender, EventArgs e)
        {
            //actualiza el angulo
            angle = Kinematics.Angle(NLeft.Position, NRight.Position);
            ERight.Angle = angle;
            ELeft.Angle = angle;
            ERight.Center = NRight.Position;
            ELeft.Center = NLeft.Position;
            //Actualiza las posiciones
            int i = 0;
            foreach (var pos in ERight.GetPositions())
            {
                Positions[i] = new Vector3((float)pos.X, (float)pos.Y, 0);
                i++;
            }
            foreach (var pos in ELeft.GetPositions())
            {
                Positions[i] = new Vector3((float)pos.X, (float)pos.Y, 0);
                i++;
            }
            Model.Geometry.UpdateVertices();
        }
        public void Translate(double distance)
        {

        }
        public void MoveLine()
        {

        }
    }
}
