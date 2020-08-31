using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace DesktopAppTest
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

        private async void Button_Click(object sender, RoutedEventArgs e) // void by exception, because wpf works with void methods
        {
            await DownloadImageAsync(this.Image1, "https://lh3.googleusercontent.com/w5XeO9sXG_ZRrPR0FpODchO237ffOhSwY1aJ1equHLNGT47iyU34VLgHP_RLCqUoHreTenxZFhg=w640-h400-e365");
            await DownloadImageAsync(this.Image2, "https://icatcare.org/app/uploads/2018/07/Thinking-of-getting-a-cat.png");
            await DownloadImageAsync(this.Image3, "https://www.humanesociety.org/sites/default/files/styles/1240x698/public/2018/08/kitten-440379.jpg?h=c8d00152&itok=1fdekAh2");
            await DownloadImageAsync(this.Image4, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRNj_XlpJRkyYkdv_DQz4lxXRrSvY2-pjJQ3g&usqp=CAU");
            await DownloadImageAsync(this.Image5, "https://lh3.googleusercontent.com/proxy/IuhRoQY5fKLXIRpcAu-dSPEqtwLQuodBlHrAWao5YYd8y1b2OejDdzFxVIDF4LafBa1dSHpBK5CjCRTg_bri1_KpD5t8D3T9sdg3mP2qOh_WbtdErHxPxLnDgQ");
        }

        private async Task DownloadImageAsync(Image image, string url)
        {
            var client = new HttpClient();
            //Thread.Sleep(2000);
            var request = await client.GetAsync(url);
            var byteData = await request.Content.ReadAsByteArrayAsync();
            image.Source = this.LoadImage(byteData);
        }

        private BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
