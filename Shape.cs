using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf.SharpDX.Model.Scene2D;
using SharpDX;
using System;

namespace LineasWPF
{
    class Shape
    {
        public MeshGeometryModel3D Model { get; protected set; }
        private readonly MeshGeometry3D Mesh;
        protected Vector3Collection Positions;
        protected IntCollection Indices;
        protected Vector3Collection Normals;
        public Edge ELeft, ERight;
        protected double Thickness;//SE HACE EVENTO? DEPENDENCY PROPERTY? Cuando cambia
        public Shape(double thickness)
        {
            Thickness = thickness;
            ELeft = new Edge(false, Thickness);
            ERight = new Edge(true, Thickness);

            Positions = new Vector3Collection();
            Normals = new Vector3Collection();
            Indices = new IntCollection();
            Mesh = new MeshGeometry3D
            {
                Positions = Positions,
                Indices = Indices,
                Normals = Normals
            };
            var material = new PhongMaterial
            {
                DiffuseColor = new Color4(1f, 1f, 0, 0.5f)
            };
            Model = new MeshGeometryModel3D
            {
                Material = material,
                Geometry = Mesh,
            };
        }

    }
    class SingleNode:Shape
    {
        public Nodo Node;
        public SingleNode(Nodo node,double thickness):base(thickness)
        {
            Node = node;
            Node.PositionChanged += MoveNode;
        }
        private void MoveNode(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var pos in ERight.WithAngleAndPosition(0, Node.Position))
            {
                Positions[i] = new SharpDX.Vector3((float)pos.X, (float)pos.Y, 0);
                i++;
                //Console.WriteLine(pos.X.ToString()+','+ pos.Y.ToString());
            }
            foreach (var pos in ELeft.WithAngleAndPosition(0, Node.Position))
            {
                Positions[i] = new SharpDX.Vector3((float)pos.X, (float)pos.Y, 0);
                i++;
                //Console.WriteLine(pos.X.ToString() + ',' + pos.Y.ToString());
            }
        }
    }
    class Circle:SingleNode
    {
        public Circle(Nodo node, double thickness = 2):base(node,thickness)
        {
            ELeft = new Edge(false, Thickness);
            ERight = new Edge(true, Thickness);
        }
    }
}
