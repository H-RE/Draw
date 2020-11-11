using HelixToolkit.Wpf.SharpDX;
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
        public readonly Edge ELeft, ERight;
        protected double Thickness;//SE HACE EVENTO? DEPENDENCY PROPERTY? Cuando cambia
        public double angle { get; protected set; }//darle un valor a esto
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
            Model.Geometry.IsDynamic = true;//FUNCIONA AÚN CON FALSE
            //Se actualiza todo cuando se cambia la forma de Edge
            ELeft.ShapeChanged += UpdateShape;
            ERight.ShapeChanged += UpdateShape;
        }
        public void ChangeColor(float red, float green, float blue)
        {
            Model.Material = new PhongMaterial
            {
                DiffuseColor = new Color4(red,green,blue, 0.5f)
            };
        }
        protected void UpdateShape(object sender, EventArgs e)
        {
            //Borra posiciones e indices
            Positions.Clear();
            Indices.Clear();
            Normals.Clear();
            //Reasigna los triangulos

            //SE ESTABLECEN LAS POSICIONES
            foreach (var pos in ERight.GetPositions())//Eright.getpositions() (E)
            {
                Positions.Add(new Vector3((float)pos.X, (float)pos.Y, 0));
            }
            foreach (var pos in ELeft.GetPositions())
            {
                Positions.Add(new Vector3((float)pos.X, (float)pos.Y, 0));
            }

            //SE ESTABLECEN LOS INDICES
            var temp = Positions.Count - 1;
            int i = 0;
            while (i < temp - 1)
            {
                Indices.Add(i);
                Indices.Add(temp);
                i++;
                Indices.Add(i);
            }
            //SE ESTABLECEN LOS VECTORES NORMALES
            for (int p = 0; p < Positions.Count; p++)
                Normals.Add(new Vector3(0, 0, 1));
        }
    }
}
