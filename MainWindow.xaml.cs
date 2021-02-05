using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Documento
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            setControles();
        }

        private void setControles()
        {
            c = new Controlador(this);

            nuevo.Click += new RoutedEventHandler(c.nuevo);
            Loaded += new RoutedEventHandler(c.cargandoVentana);
            CancelEventHandler ce = new CancelEventHandler(c.cerrarVentanaWindow);
            Closing += ce;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private Controlador c;
    }
}
