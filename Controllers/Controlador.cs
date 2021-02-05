using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Documento.Controllers
{
    public class Controlador
    {
        private MainWindow mw;
        private Documento d;
        public Controlador(MainWindow mw)
        {
            this.mw = mw;
        }

        public void nuevo(Object sender, RoutedEventArgs c)
        {
            d = new Documento();
            d.Show();

        }
    }
}
