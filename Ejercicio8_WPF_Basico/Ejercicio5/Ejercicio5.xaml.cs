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

namespace Ejercicio5
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_Event(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Evento Button.Click - Un evento de acción directa");
        }

        private void Mouse_Enter(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Evento MouseEnter - Detecta cuando el ratón entra en el botón");
        }

        private void Left_Click_Event(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Evento Button_MouseRightButtonDow - Un evento de clic específico con el botón derecho");
        }
    }
}
