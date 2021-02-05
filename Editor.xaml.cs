using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Documento
{
    /// <summary>
    /// Lógica de interacción para Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        public Editor()
        {
            InitializeComponent();
            setControles();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;//centra al editor
        }

        public RichTextBox getRichTextBox()
        {
            return txtRichBox;
        }

        public Menu getMenu()
        {
            return mainMenu;
        }


        private void setControles()
        {
            ce = new Controlador(this);
            CancelEventHandler c = new CancelEventHandler(ce.cerrarVentanaEditor);
            Closing += c;
            abrir.Click += new RoutedEventHandler(ce.abrir);
            guardar.Click += new RoutedEventHandler(ce.guardar);
        }

        private Controlador ce;
    }


}
