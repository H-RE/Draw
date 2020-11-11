namespace LineasWPF
{
    class Circle :SingleNode
    {
        public Circle(Nodo node, double thickness = 2):base(node,thickness)
        {
            ELeft.ToCircular();
            ERight.ToCircular();

            //SetTriangles(); //AQUÍ ESTÁ EL ERROOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOR====================
            Model.Geometry.UpdateVertices();
        }
    }
}
