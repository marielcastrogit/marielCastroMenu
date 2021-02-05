using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Documento
{
    public class Controlador
    {
        private MainWindow mw;

        public Controlador(MainWindow mw)
        {
            this.mw = mw;
        }

        public void nuevo(Object sender, RoutedEventArgs e)
        {
            Editor ed;
            ed = new Editor();
            ed.Show();
            
        }
    }
}
