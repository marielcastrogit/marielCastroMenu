using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.IO;

namespace Documento
{
    public class Controlador
    {
        private MainWindow mw;
        private Editor ed;
        private int esLlamado;
        private MenuItem itemBuscar;
        private TextBox cajaTexto;

        public Controlador(MainWindow mw)
        {
            this.mw = mw;
            ed = new Editor();
            esLlamado = 0;
        }

        public Controlador(Editor ed)
        {
            this.ed = ed;
            itemBuscar = new MenuItem();
            cajaTexto = new TextBox();
        }


        public void cargandoVentana(object sender, RoutedEventArgs e)
        {
            //Que inicie con la ventana maximizada
            mw.WindowState = WindowState.Maximized;
        }

        public void nuevo(Object sender, RoutedEventArgs e)//Doy click en nuevo
        {
            mostrarEditor();//lama al metodo mostrarEditor
        }

        private void mostrarEditor()
        {
            if (esLlamado == 0)//esLlamado vale 0 
            {
                ed.getRichTextBox().Document.Blocks.Clear();//La proxima vez que se abra el editor aparecera sin caracteres.
                ed.Show();//entonces como ha sido llamado 0 veces se abre el Editor
            }
        }

        public void cerrarVentanaEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;//cancela el evento de cerrar la ventana
            ed.Visibility = System.Windows.Visibility.Hidden;//Simplemente guarda la ventana, de alguna forma la oculta
            esLlamado = 0;//es llamado = 0;
        }

        public void cerrarVentanaWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void guardar(Object sender, RoutedEventArgs e)
        {
            //Abro un cuadro de guardado 
            SaveFileDialog sfd = new SaveFileDialog();
            //En el cuadro se inicia con un nombre de archivo como Texto.txt
            //Y en este cuadro solo se muestran los archivos con extension .txt
            sfd.FileName = "Texto";
            sfd.DefaultExt = ".txt";
            sfd.Filter = "Archivos de texto(.txt)|*.txt";

            //El metodo showDialog devuelve true si se da clic en el boton guardar del saveDialog 
            bool? seleccionoGuardar = sfd.ShowDialog();

            //Si el boton es seleccionado entonces que escriba todo el texto que hay en el RichTextBox 
            // en el archivo 
            if (seleccionoGuardar == true)
            {
                System.IO.File.WriteAllText(sfd.FileName, getContenidoBox(ed.getRichTextBox()));
            }
        }

        public string getContenidoBox(RichTextBox richbox)
        {
            //El rango de texto va desde la primera letra del RichTextBox hasta la ultima.
            //De esta forma todo el contenido sera enviado al metodo guardar.
            TextRange textRange = new TextRange(richbox.Document.ContentStart, richbox.Document.ContentEnd);
            return textRange.Text;
        }

        public void abrir(Object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de texto (*.txt)|*.txt|All Files (*.*)|*.*";
            ofd.InitialDirectory = "c:\\"; //Aca le estamos diciendo que tome como directorio de trabajo a la ruta c:
            ofd.RestoreDirectory = true;// pero aca le decimos que una vez que el archivo sea abierto, es decir
            //cuando se cierre el OpenFileDialog se restaure la ruta de trabajo a la misma de siempre

            bool? seleccionoAbrir = ofd.ShowDialog();

            if ((bool)seleccionoAbrir)
            {
                getContenidoArchivo(ofd.FileName, ed.getRichTextBox());
            }

        }
        public void getContenidoArchivo(string nombreArchivo, RichTextBox rtb)
        {
            TextRange range;
            FileStream fStream;
            //Si el archivo existe entonces: 

            if (System.IO.File.Exists(nombreArchivo))
            {
                //de principio a fin el contenido del archivo estara escrito en el richBox.
                range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

                //abro el flujo para que abra archivo con el nombre que se espeficio.
                fStream = new System.IO.FileStream(nombreArchivo, mode: System.IO.FileMode.Open);

                //Cargo el contenido desde el inicio al final transformandolo en texto.
                range.Load(fStream, System.Windows.DataFormats.Text);

                //cierro el flujo.
                fStream.Close();
            }




        }
    }
}
