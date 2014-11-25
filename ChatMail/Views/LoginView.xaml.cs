using ChatMail.Code.Controller;
using ChatMail.Code.ViewModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatMail.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        UserController usc = new UserController();
        public LoginView()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (usc.Login(tbUsername.Text, passwordbox.Password))
            {
                var context = (ContentControlService)FindResource("ContentControlService");
                context.ShowedWindow = 1;
            }
            else
            {
                MessageBox.Show("Username oder Passwort falsch.");
            }
        }
    }
}
