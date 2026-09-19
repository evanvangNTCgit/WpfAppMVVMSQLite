using System;
using System.Collections.Generic;
using System.Text;
using WpfAppMVVM.Models;

namespace WpfAppMVVM.DataAccess
{
    public class DataService
    {
        private readonly DataContext _context;

        public DataService(DataContext dataContext)
        {
            this._context = dataContext;
        }

        /// <summary>
        /// Gets users from SQLite DB
        /// </summary>
        /// <returns>The list of users stored in db.</returns>
        public List<User> GetUsers()
        {
            return this._context.Users.ToList();
        }

        /// <summary>
        /// Adds user to the SQLite db
        /// </summary>
        /// <param name="user">User to add to DB</param>
        /// <returns>User that has been added to db.</returns>
        public User AddUser(User user)
        {
            this._context.Users.Add(user);
            this._context.SaveChanges();

            return user;
        }
    }
}
