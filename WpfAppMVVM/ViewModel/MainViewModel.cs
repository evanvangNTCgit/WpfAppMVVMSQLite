using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfAppMVVM.Commands;
using WpfAppMVVM.DataAccess;
using WpfAppMVVM.Models;
using WpfAppMVVM.Views;

namespace WpfAppMVVM.ViewModel
{
    public class MainViewModel
    {
        private readonly DataService _dataService;

        public ObservableCollection<User> Users { get; set; }

        public ICommand ShowAddUserWindowCommand { get; set; }

        public ICommand RefreshUserWindowList { get; set; }

        public MainViewModel(DataService dataService)
        {
            _dataService = dataService;

            this.Users = new(this._dataService.GetUsers());

            ShowAddUserWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
            RefreshUserWindowList = new RelayCommand(RefreshList, CanRefreshList);
        }

        private bool CanRefreshList(object obj)
        {
            return true;
        }

        private void RefreshList(object obj)
        {
            List<User> list = this._dataService.GetUsers();

            foreach (User user in list)
            {
                if (!this.Users.Contains(user))
                    this.Users.Add(user);
            }
        }

        private bool CanShowWindow(object obj)
        {
            return AddUser.IsWindowsOpen;
        }

        private void ShowWindow(object obj)
        {
            AddUser addUserWindow = new(this._dataService);

            if (obj is Window window)
            {
                addUserWindow.Owner = window;
                addUserWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            addUserWindow.ShowDialog();
        }
    }
}
