namespace LineasWPF
{
    class Rect :SingleNode
    {
        public Rect(Nodo node, double thickness = 2) : base(node, thickness)
        {
            ELeft.ToTrapezoidal();
            ERight.ToTrapezoidal();
            SetTriangles();
            Model.Geometry.UpdateVertices();
        }
    }
}
