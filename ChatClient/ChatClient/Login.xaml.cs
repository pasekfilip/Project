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

        private void Login_Click(object sender, RoutedEventArgs e)
        {


            //HttpClient client = new HttpClient();
            //Users user = new Users();
            //user.UserName = "testik";
            //user.Email = "aaa@aaa";
            //user.Password = "asfaef";
            //mail.Text = client.GetStringAsync("http://localhost:49497/api/Users").Result;
            ////StringContent content = new StringContent(JsonConvert.SerializeObject(user));
            //HttpContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            //var c = client.PostAsync("http://localhost:49497/api/Users", content).Result;
        }

        private void mail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
