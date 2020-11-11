using SharpDX;
using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace LineasWPF
{
    class Line:Shape
    {
        public Nodo NRight, NLeft;
        public double angle { get; private set; }
        public Line(Nodo left, Nodo right,double thickness=2):base(thickness)
       {
            NRight = right;
            NLeft = left;
            angle = Kinematics.Angle(NLeft.Position, NRight.Position);

            NRight.PositionChanged += MoveNode;
            NLeft.PositionChanged += MoveNode;
            
            ELeft.ShapeChanged += UpdateShape;
            ERight.ShapeChanged += UpdateShape;

            SetPositions();
            SetIndices();
            SetNormals();
            Model.Geometry.UpdateVertices();
        }

        private void UpdateShape(object sender, EventArgs e)
        {
            //Borra posiciones e indices
            Positions.Clear();
            Indices.Clear();
            //Reasigna las posiciones
            SetPositions();
            //Reasigna los indices
            SetIndices();
            SetNormals();
        }

        private void SetPositions()
        {
            foreach (var pos in ERight.WithAngleAndPosition(angle, NRight.Position))//Eright.getpositions() (E)
            {
                Positions.Add(new Vector3((float)pos.X,(float)pos.Y,0));
            }
            foreach (var pos in ELeft.WithAngleAndPosition(angle, NLeft.Position))
            {
                Positions.Add(new Vector3((float)pos.X, (float)pos.Y, 0));
            }
        }
        private void MoveNode(object sender, EventArgs e)
        {
            //actualiza el angulo
            angle = Kinematics.Angle(NLeft.Position, NRight.Position);
            //Actualiza las posiciones
            int i = 0;
            foreach (var pos in ERight.WithAngleAndPosition(angle, NRight.Position))
            {
                Positions[i] = new Vector3((float)pos.X, (float)pos.Y, 0);
                i++;
            }
            foreach (var pos in ELeft.WithAngleAndPosition(angle, NLeft.Position))
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
