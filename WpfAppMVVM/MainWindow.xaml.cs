using System.Windows;
using System.Windows.Controls;
using WpfAppMVVM.Models;
using WpfAppMVVM.ViewModel;

namespace WpfAppMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WpfAppMVVM.DataAccess.DataContext dataContext = new();

            //dataContext.Database.EnsureDeleted();
            dataContext.Database.EnsureCreated();

            WpfAppMVVM.DataAccess.DataService dataService = new(dataContext);

            var test = dataService.GetUsers();

            MainViewModel mainViewModel = new(dataService);
            this.DataContext = mainViewModel;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.UserList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            if (obj.GetType() == typeof(User))
            {
                var user = (User)obj;

                return user.Name?.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) ?? false;
            }

            return false;
        }
    }
}