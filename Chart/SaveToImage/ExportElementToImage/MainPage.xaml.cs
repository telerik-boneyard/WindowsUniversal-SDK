using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ExportElementToImage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.radChart.DataContext = new double[] { 20, 30, 50, 10, 60, 40, 20, 80 };
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedFileName = "SavedImage.jpg";
            savePicker.FileTypeChoices.Add("Image", new List<string>() { ".jpg" });

            //Get the file the user selected
            StorageFile saveFile = await savePicker.PickSaveFileAsync();

            await this.SaveVisualElementToFile(this.radChart, saveFile);

            var cd = new MessageDialog(string.Format("Image saved in Saved Pictures folder as {0}", saveFile.Name));

            await cd.ShowAsync();
        }

        private async Task SaveVisualElementToFile(FrameworkElement element, StorageFile file)
        {
            var renderTargetBitmap = new RenderTargetBitmap();
            await renderTargetBitmap.RenderAsync(element, (int)element.ActualWidth, (int)element.ActualHeight);
            var pixels = await renderTargetBitmap.GetPixelsAsync();

            using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                var encoder = await
                    BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
                byte[] bytes = pixels.ToArray();
                encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                     BitmapAlphaMode.Ignore,
                                     (uint)element.ActualWidth, (uint)element.ActualHeight,
                                     96, 96, bytes);

                await encoder.FlushAsync();
            }
        }
    }
}
