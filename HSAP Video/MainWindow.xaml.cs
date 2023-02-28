using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace HSAP_Video
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool fullscreen = false;
        string pass = "830201";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fullscreen = true;
            Button btn = (Button)sender;
            mediaElement.Source = new Uri(@$"Videos\{btn.Content}.mp4", UriKind.Relative);
            mediaElement.Height = SystemParameters.PrimaryScreenHeight;
            mediaElement.Width = SystemParameters.PrimaryScreenWidth; ;
            BgRect.Visibility = Visibility.Visible;
            mediaElement.Play();
        }


        private void mediaElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (fullscreen == true)
            {
                fullscreen = false;              
                BgRect.Visibility = Visibility.Hidden;
                mediaElement.Close();
                mediaElement.Height = 0;
                mediaElement.Width = 0;
            }
        }

        private void salir(object sender, RoutedEventArgs e)
        {
            Window1 keypad = new Window1();
            keypad.ShowDialog();
            string inputRead = keypad.answer;
            keypad.Close();
            if (inputRead == pass) {
                Application.Current.Shutdown();
            }
        }
    }
}
