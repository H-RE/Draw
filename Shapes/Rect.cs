namespace LineasWPF
{
    class Rect :SingleNode
    {
        public Rect(Nodo node, double thickness = 2) : base(node, thickness)
        {
            ELeft.ToTrapezoidal();
            ERight.ToTrapezoidal();
            //SetTriangles();
            Model.Geometry.UpdateVertices();
        }
        public void SetAngle(double angle)
        {
            //SE ACTUALIZAN LOS ÁNGULOS
            this.angle = angle;
            ERight.Angle = angle;
            ELeft.Angle = angle;
            int i = 0;
            foreach (var pos in ERight.GetPositions())
            {
                Positions[i] = new SharpDX.Vector3((float)pos.X, (float)pos.Y, 0);
                i++;
            }
            foreach (var pos in ELeft.GetPositions())
            {
                Positions[i] = new SharpDX.Vector3((float)pos.X, (float)pos.Y, 0);
                i++;
            }
        }
    }
}
