using AlexJones_SchedulingApp.Models;
using System;

namespace AlexJones_SchedulingApp
{
    public class UserLoggedInEventArgs : EventArgs
    {
        private User user;

        public User User
        {
            get { return user; }
        }

        public UserLoggedInEventArgs(User user)
        {
            this.user = user;
        }
    }
}
