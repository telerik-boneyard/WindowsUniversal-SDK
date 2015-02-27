﻿using FinancialIndicators_GettingStarted;
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

namespace FinancialIndicators
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            List<FinancialData> SampleData = new List<FinancialData>();

            SampleData.Add(new FinancialData() { High = 31.1, Open = 30.33, Low = 30.19, Close = 30.66, Date = new DateTime(2010, 1, 4) });
            SampleData.Add(new FinancialData() { High = 31.24, Open = 30.62, Low = 29.91, Close = 30.86, Date = new DateTime(2010, 1, 11) });
            SampleData.Add(new FinancialData() { High = 31.24, Open = 30.75, Low = 28.84, Close = 28.96, Date = new DateTime(2010, 1, 19) });
            SampleData.Add(new FinancialData() { High = 29.92, Open = 29.24, Low = 27.66, Close = 28.18, Date = new DateTime(2010, 1, 25) });
            SampleData.Add(new FinancialData() { High = 28.79, Open = 28.39, Low = 27.57, Close = 28.02, Date = new DateTime(2010, 2, 1) });

            SampleData.Add(new FinancialData() { High = 28.4, Open = 28.01, Low = 27.57, Close = 27.93, Date = new DateTime(2010, 2, 8) });
            SampleData.Add(new FinancialData() { High = 29.03, Open = 28.13, Low = 28.02, Close = 28.77, Date = new DateTime(2010, 2, 16) });
            SampleData.Add(new FinancialData() { High = 28.94, Open = 28.84, Low = 28.02, Close = 28.67, Date = new DateTime(2010, 2, 22) });
            SampleData.Add(new FinancialData() { High = 29.3, Open = 28.77, Low = 28.24, Close = 28.59, Date = new DateTime(2010, 3, 1) });
            SampleData.Add(new FinancialData() { High = 29.38, Open = 28.52, Low = 28.5, Close = 29.27, Date = new DateTime(2010, 3, 8) });
            this.OhlcChart.DataContext = SampleData;
            this.secondChart.DataContext = SampleData;

            this.NavigationCacheMode = NavigationCacheMode.Required;
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
