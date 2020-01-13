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
    /// Interakční logika pro Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        //{"ID":16,"UserName":"Dandalf","Email":"fackovecdaniel@sssvt.cz","Password":"123456","Picture":null,"Friends":null,"Users":null,"Messages":null}
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            //Users user = new Users();
            //user.UserName = "testik";
            //user.Email = "aaa@aaa";
            //user.Password = "asfaef";
            //username_txtbx.Text = client.GetStringAsync("http://localhost:49497/api/Users/" + username_txtbx.Text).Result;
            string userinfo = client.GetStringAsync("http://localhost:49497/api/Users/" + username_txtbx.Text).Result;
            Regex regex = new Regex(@"""Password"":""\w{3,25}""");
            Match match = regex.Match(userinfo);
            string password = match.Value.Substring(12, match.Value.Length - 13);
            //MessageBox.Show(password);
            if (passwrd_txtbx.Password == password)
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject( username_txtbx.Text), Encoding.UTF8, "application/json");
                HttpResponseMessage token = client.PostAsync("http://localhost:49497/api/Token", content).Result;
                MessageBox.Show(token.Content.ToString());
            }
            //HttpContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            //var c = client.PostAsync("http://localhost:49497/api/Users", content).Result;
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
        }

        private void signupBTN_send_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
