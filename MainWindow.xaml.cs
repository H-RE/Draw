using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelixToolkit.Wpf.SharpDX;

namespace LineasWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public Camera camera { get; }
        public EffectsManager effectsManager { get; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            effectsManager = new DefaultEffectsManager();
            camera = new PerspectiveCamera();

            var N1 = new Nodo(new Point(0, 0));
            var N2 = new Nodo(new Point(5, 0));
            var N3 = new Nodo(new Point(10, 0));
            var N4 = new Nodo(new Point(15, 10));
            var line1 = new Line(N1, N2);
            var line2 = new Line(N2, N3);
            var line3 = new Line(N2, N4);

            var circ = new Circle(N4,5);
            var rc = new Rect(N2, 5);
            circ.ChangeColor(1f, 0, 0);
            rc.ChangeColor(0, 1f, 0.8f);
            N2.Position = new Point(5,20);
            rc.SetAngle(Math.PI / 4);
            view1.Items.Add(line1.Model);
            view1.Items.Add(line2.Model);
            view1.Items.Add(line3.Model);
            view1.Items.Add(circ.Model);
            view1.Items.Add(rc.Model);
            
        }
    }
}
