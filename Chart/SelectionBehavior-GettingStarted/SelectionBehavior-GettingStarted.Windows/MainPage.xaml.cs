using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Telerik.Charting;
using Telerik.UI.Xaml.Controls.Chart;
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

namespace SelectionBehavior_GettingStarted
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void DataPointSelectionChanged(object sender, EventArgs e)
        {
            if ((sender as ChartSelectionBehavior).SelectedPoints.Count<DataPoint>() > 0)
            {
                CategoricalDataPoint selectedPoint = (sender as ChartSelectionBehavior).SelectedPoints.First() as CategoricalDataPoint;
                textblock1.Text = String.Format("The value of the Selected Point is : {0}", selectedPoint.Value);
                textblock2.Text = String.Format("The category of the Selected Point is : {0}", selectedPoint.Category);
                textblock3.Text = String.Format("Show information stored in a property from our model : {0}", (selectedPoint.DataItem as CustomPoint).CustomProperty);
            }
        }
    }
}
