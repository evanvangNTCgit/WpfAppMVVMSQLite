using System.Windows;
using System.Windows.Input;
using WpfAppMVVM.Commands;
using WpfAppMVVM.DataAccess;
using WpfAppMVVM.Models;

namespace WpfAppMVVM.ViewModel
{
    public class AddUserViewModel
    {
        private readonly DataService _service;

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }

        public ICommand AddUserCommand { get; set; }

        public AddUserViewModel(DataService dataService)
        {
            AddUserCommand = new RelayCommand(AddUser, CanAddUser);

            this._service = dataService;
        }

        private bool CanAddUser(object obj)
        {
            return true;
        }

        private void AddUser(object obj)
        {
            try
            {
                User added = this._service.AddUser(new Models.User() { Name = Name, Email = Email, Role = Role, CreatedDate = DateTime.Now, Id = RandomIdGenerator.RandomId() });
                if (added != null)
                {
                    MessageBox.Show($"Success!\nAdded {added.Name} to the database. Refresh to see {added.Name} in the listbox!");
                }
            }
            catch
            {
                MessageBox.Show("Could not add user. Try again. Likely forgot to fill in a field.");
            }
        }
    }
}
