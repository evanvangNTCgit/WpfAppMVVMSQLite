using System.Windows;
using WpfAppMVVM.DataAccess;
using WpfAppMVVM.ViewModel;

namespace WpfAppMVVM.Views
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private static int WindowsOpen = 0;

        public static bool IsWindowsOpen => AddUser.WindowsOpen < 1;

        public AddUser(DataService dataService)
        {
            InitializeComponent();

            this.ContentRendered += (sender, e) =>
            {
                AddUser.WindowsOpen++;
            };

            this.Closed += (sender, e) =>
            {
                AddUser.WindowsOpen--;
            };

            AddUserViewModel addUserViewModel = new(dataService);
            this.DataContext = addUserViewModel;
        }
    }
}
