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
using System.Web;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ChatClient
{
    /// <summary>
    /// Interakční logika pro LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private bool passwrdok { get; set; }
        public string Token { get; set; }
        public event Action<string> TokenEvent;
        private MainWindow main;
        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            passwrdok = false;
            main = mainWindow;
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            Login login = new Login();
            login.UserName = username_txtbx.Text;
            login.Password = passwrd_txtbx.Password;
            HttpContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            HttpResponseMessage token = client.PostAsync("http://localhost:49497/api/Token", content).Result;
            Token = token.Content.ReadAsStringAsync().Result;
            TokenToMain();
            main.Show();
        }

        private void mail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void signupBTN_Click(object sender, RoutedEventArgs e)
        {
            label_login.Content = "Sign up";
            label_signup.Visibility = Visibility.Hidden;
            signupBTN.Visibility = Visibility.Hidden;
            LoginBTN.Visibility = Visibility.Hidden;
            mail.Visibility = Visibility.Visible;
            passwrd_check.Visibility = Visibility.Visible;
            password_check_label.Visibility = Visibility.Visible;
            mail_label.Visibility = Visibility.Visible;
            signupBTN_send.Visibility = Visibility.Visible;
            PasswordChanged.Visibility = Visibility.Visible;
            SignupBTN_backtologin.Visibility = Visibility.Visible;
            backtologin_label.Visibility = Visibility.Visible;
        }

        private void signupBTN_send_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
            HttpClient client = new HttpClient();
            if (client.GetStringAsync("http://localhost:49497/api/Users/" + username_txtbx.Text).Result == "null")
            {
                if (passwrdok == true)
                {
                    user.UserName = username_txtbx.Text;
                    user.Email = mail.Text;
                    user.Password = passwrd_txtbx.Password;
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    client.PostAsync("http://localhost:49497/api/Users", content);
                    SignupBTN_backtologin_Click(sender, e);

                }
            }
        }

        private void passwrd_check_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(passwrd_txtbx.Password != passwrd_check.Password)
            {
                PasswordChanged.Content = "Zadaná hesla se neshpodují";
            }
            if(passwrd_txtbx.Password == passwrd_check.Password)
            {
                PasswordChanged.Content = "OK";
                passwrdok = true;
            }
        }

        private void SignupBTN_backtologin_Click(object sender, RoutedEventArgs e)
        {
            label_login.Content = "login";
            label_signup.Visibility = Visibility.Visible;
            signupBTN.Visibility = Visibility.Visible;
            LoginBTN.Visibility = Visibility.Visible;
            mail.Visibility = Visibility.Hidden;
            passwrd_check.Visibility = Visibility.Hidden;
            password_check_label.Visibility = Visibility.Hidden;
            mail_label.Visibility = Visibility.Hidden;
            signupBTN_send.Visibility = Visibility.Hidden;
            PasswordChanged.Visibility = Visibility.Hidden;
            SignupBTN_backtologin.Visibility = Visibility.Hidden;
            backtologin_label.Visibility = Visibility.Hidden;
        }

        public void TokenToMain()
        {
            if (Token != null)
                TokenEvent(Token);
        }
    }
}


//--------------------------------------------------------------

//{"ID":16,"UserName":"Dandalf","Email":"fackovecdaniel@sssvt.cz","Password":"123456","Picture":null,"Friends":null,"Users":null,"Messages":null}
//username_txtbx.Text = client.GetStringAsync("http://localhost:49497/api/Users/" + username_txtbx.Text).Result;