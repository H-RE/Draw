using SharpDX;
using System;

namespace LineasWPF
{
    class SingleNode :Shape
    {
        public Nodo Node;
        public SingleNode(Nodo node,double thickness):base(thickness)
        {
            Node = node;
            Node.PositionChanged += MoveNode;
            ELeft.Angle = 0;
            ERight.Angle = 0;
            ELeft.Center = node.Position;
            ERight.Center = node.Position;
        }
        private void MoveNode(object sender, EventArgs e)
        {
            angle = 0;
            ERight.Angle = angle;
            ELeft.Angle = angle;
            ERight.Center = Node.Position;
            ELeft.Center = Node.Position;

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
    }
}
