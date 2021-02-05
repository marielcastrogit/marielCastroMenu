using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


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
        }

        public RichTextBox getRichTextBox()
        {
            return txtRichBox;
        }

        public void setTextoBox(string contenido)
        {

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
