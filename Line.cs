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
            foreach (var pos in ERight.WithAngleAndPosition(angle, NRight.Position))
            {
                Positions.Add(new SharpDX.Vector3((float)pos.X,(float)pos.Y,0));
            }
            foreach (var pos in ELeft.WithAngleAndPosition(angle, NLeft.Position))
            {
                Positions.Add(new SharpDX.Vector3((float)pos.X, (float)pos.Y, 0));
            }
        }
        private void SetIndices()
        {
            var temp = Positions.Count - 1;
            int i = 0;
            while (i < temp - 1)
            {
                Indices.Add(i);
                Indices.Add(temp);
                i++;
                Indices.Add(i);
            }
        }
        private void SetNormals()
        {
            for(int i=0; i<Positions.Count; i++)
            Normals.Add(new Vector3(0, 0, 1));
        }
        private void MoveNode(object sender, EventArgs e)
        {
            //actualiza el angulo
            angle = Kinematics.Angle(NLeft.Position, NRight.Position);
            int i = 0;
            foreach (var pos in ERight.WithAngleAndPosition(angle, NRight.Position))
            {
                Positions[i] = new SharpDX.Vector3((float)pos.X, (float)pos.Y, 0);
                i++;
                //Console.WriteLine(pos.X.ToString()+','+ pos.Y.ToString());
            }
            foreach (var pos in ELeft.WithAngleAndPosition(angle, NLeft.Position))
            {
                Positions[i] = new SharpDX.Vector3((float)pos.X, (float)pos.Y, 0);
                i++;
                //Console.WriteLine(pos.X.ToString() + ',' + pos.Y.ToString());
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
