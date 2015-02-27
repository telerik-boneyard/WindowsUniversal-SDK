using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LegendControl_DynamicSeries
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.provider.Source = GenerateCollection();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        public List<Data> GenerateData(int i)
        {
            List<Data> data = new List<Data>();
            data.Add(new Data { Category = "Apple", Value = 4 + i });
            data.Add(new Data { Category = "Orange", Value = 15 - i });
            data.Add(new Data { Category = "Lemon", Value = 20 + i * i });
            return data;
        }

        public List<ViewModel> GenerateCollection()
        {
            List<ViewModel> collection = new List<ViewModel>();
            for (int i = 0; i < 5; i++)
            {
                ViewModel vm = new ViewModel();
                vm.Data = GenerateData(i);
                vm.LegendName = "Series " + i;
                collection.Add(vm);
            }
            return collection;
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
    }
}
