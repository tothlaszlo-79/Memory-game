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
using System.Windows.Threading;

namespace Memory_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _BackgroundName = "background.JPG";
        string[] _ImageName = { "grabowski.jpg", "kukori.jpg",
            "kuldonc.jpg","vili.jpg"};
        BitmapImage _biBackground;
        BitmapImage[] biImages = new BitmapImage[8];
        Image[] _imImages;
        Random rnd = new Random();
        private DispatcherTimer _dt;

        public MainWindow()
        {
            InitializeComponent();
            _imImages = new Image[]
            {
                im10, im11, im12, im13,
                im20, im21, im22, im23
            };
            _dt = new DispatcherTimer
            {
                Interval = new TimeSpan(0,0,0,0,3000),
                IsEnabled = false
            };
            _dt.Tick += _dt_Tick;
            LoadImages();
            ShowImages();
            _dt.Start();
        }

        private void ShowImages()
        {
            for (int i = 0; i < 8; i++)
            {
                _imImages[i].Source = biImages[i];
            }
        }

        private void LoadImages()
        {
            try
            {
                _biBackground = new BitmapImage(
                    new Uri(@"Images/" + _BackgroundName,
                    UriKind.Relative));
                for (int i = 0; i < 4; i++)
                {
                    biImages[i] = new BitmapImage(
                        new Uri(@"Images/" + _ImageName[i],
                        UriKind.Relative));
                    biImages[i+4] = biImages[i];
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Images cannot be found!", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _dt_Tick(object? sender, EventArgs e)
        {
            ShowBackground();
            _dt.Stop();
        }

        private void ShowBackground()
        {
            for (int i = 0; i < 8; i++)
            {
                _imImages[i].Source = _biBackground;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ShowImages();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
