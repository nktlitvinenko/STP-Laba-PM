using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjectManager.Client.Windows.ApplicationUser.LoginFormDecorator.Abstract;

namespace ProjectManager.Client.Windows.ApplicationUser.LoginFormDecorator.Concrete
{
    public class RegisterDecorator : Decorator
    {
        public void Operation()
        {
            //Call old functionality
            base.Operation();

            //Add new behavior
            ShowRegisterForm();
        }

        private void ShowRegisterForm()
        {
            var mbResult = MessageBox.Show("User not found. Are you need to register in system?", "User not found. Register?",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);

            if (mbResult == MessageBoxResult.Yes)
            {
                Register regWindow = new Register();
                regWindow.ShowDialog();
            }
            else
                return;
        }
    }
}
