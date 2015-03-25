using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Telerik.Core;
using Windows.ApplicationModel.DataTransfer;
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

namespace Grid.PasteCSV
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

            this.DataContext = new MainViewModel();
        }

    }

    public class DataItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class MainViewModel : ViewModelBase
    {
        public ICommand PasteCommand { get; set; }

        public ObservableCollection<DataItem> Items { get; set; }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                this.OnPropertyChanged("ErrorMessage");
            }
        }


        public MainViewModel()
        {
            this.PasteCommand = new DelegateCommand((e) => this.OnPaste());
            this.Items = new ObservableCollection<DataItem>(from c in Enumerable.Range(0, 10) select new DataItem { ID = c, Name = "Initial Data " + c });
        }

        private async void OnPaste()
        {
            string text = string.Empty;

            var dataPackageView = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
            if (dataPackageView.Contains("Csv"))
            {
                try
                {
                    text = await dataPackageView.GetTextAsync("Csv");


                }
                catch (Exception ex)
                {
                    this.ErrorMessage = "Error retrieving Text format from Clipboard: " + ex.Message;
                }

                var itemsString = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                //Skip header
                for (int i = 1; i < itemsString.Length; i++)
                {
                    var properties = itemsString[i].Split(',');

                    var item = new DataItem
                    {
                        ID = int.Parse(properties[0]),
                        Name = properties[1]
                    };

                    this.Items.Add(item);
                }
            }
        }

    }

    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<object> execute,
                       Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }

}
