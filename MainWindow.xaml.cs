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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sliRGB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte red = Convert.ToByte(sliRed.Value);
            byte green = Convert.ToByte(sliGreen.Value);
            byte blue = Convert.ToByte(sliBlue.Value);

            labRed.Content = red;
            labGreen.Content = green;
            labBlue.Content = blue;

            rctSzin.Fill = new SolidColorBrush(Color.FromRgb(red, green, blue));
        }

        private void Rogzit(object sender, RoutedEventArgs e)
        {
            string ertek = $"{sliRed.Value};{Convert.ToByte(sliGreen.Value)};{Convert.ToByte(sliBlue.Value)}";

            if (lbLista.Items.Contains(ertek) == false)
                lbLista.Items.Add($"{Convert.ToByte(sliRed.Value)};{Convert.ToByte(sliGreen.Value)};{Convert.ToByte(sliBlue.Value)}");
            else
                MessageBox.Show("Már felvetted ezt az értéket!");            
        }

        private void Torol(object sender, RoutedEventArgs e)
        {
            if (lbLista.Items.Count < 1)
                MessageBox.Show("A lista már üres!");
            else if (lbLista.SelectedIndex == -1)
                MessageBox.Show("Nincs kiválasztva szín!");
            else
                lbLista.Items.RemoveAt(lbLista.SelectedIndex);
        }

        private void Urit(object sender, RoutedEventArgs e)
        {
            lbLista.Items.Clear();
        }

        private void SzinAllitas(object sender, MouseButtonEventArgs e)
        {
            string[] szinek = lbLista.SelectedItem.ToString().Split(';');

            sliRed.Value = Convert.ToByte(szinek[0]);
            sliGreen.Value = Convert.ToByte(szinek[1]);
            sliBlue.Value = Convert.ToByte(szinek[2]);

            rctSzin.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(szinek[0]), Convert.ToByte(szinek[1]), Convert.ToByte(szinek[2])));
        }
    }
}
