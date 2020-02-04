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
using System.Net.Http;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ChatClient
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string Token { get; set; }
        private string MyID { get; set; }
        private Object objM { get; set; }
        private int messagecount;
        private double pixelsfromtop = 0;

        LoginWindow LoginWindow;
        HttpClient client = new HttpClient();
        List<Message> messages = new List<Message>();
        List<Friends> friends = new List<Friends>();

        int testchat = 25;
        int ChatID = 1;
        private object sender;

        public MainWindow()
        {
            InitializeComponent();
            LoginPageShow();
        }
       
        private void LoginPageShow()
        {
            LoginWindow = new LoginWindow();
            this.Hide();
            LoginWindow.Show();
            LoginWindow.TokenEvent += Login_TokenEventAsync;
        }
        private void Login_TokenEventAsync(string obj)
        {
            Token = obj; 
            Load();
        }
        private void Load()
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(LoginWindow.username_txtbx.Text), Encoding.UTF8, "application/json");
            HttpResponseMessage id = client.PostAsync("http://localhost:49497/api/Users/FindByUsername", content).Result;
            MyID = id.Content.ReadAsStringAsync().Result;
            MyID = Regex.Match(MyID, @"\""ID\"":\d\d,""").Value;
            MyID = MyID.Substring(5, MyID.Length - 7);
            LoginWindow.Close();
            this.Show();
            nazevchat();
            sendmessage();
            LoadFriends();

            DrawFriends();
            //LoadMessages();
            //Drawmessages();
            //MessageMe("qwertzuiopkjbdviubqwfjbdvniwfaiwubsv");
        }
        private void LoadMessages()
        {
            var foo = client.GetAsync("http://localhost:49497/api/Message/" + testchat);
            var jsonObject = foo.Result.Content.ReadAsStringAsync().Result.ToString();
            this.messages = JsonConvert.DeserializeObject<List<Message>>(jsonObject);
        }
        private void MessageMe(string inputMSG/*, string sendtime*/)
        {
            //TextBlock textBlock = new TextBlock();
            //textBlock.Text = inputMSG.Trim();
            //textBlock.TextWrapping = TextWrapping.Wrap;
            //textBlock.MaxWidth = 150;
            //textBlock.Height = textBlock.Text.Length;
            //Canvas.SetRight(textBlock, 10);
            //Canvas.SetTop(textBlock, pixelsfromtop);
            //Canvasmessages.Children.Add(textBlock);
            //pixelsfromtop = pixelsfromtop + /*textBlock.ActualHeight*/ + 10;
        }
        private void MessageOther(string inputMSG/*, string sendtime*/)
        {

        }
        private void Drawmessages()
        {
            messagecount = 0;
            foreach (Message message in messages)
            {
                if (message.ID_User != Convert.ToInt32(this.MyID))
                {
                    MessageOther(message.TheMessage/*, Convert.ToString(message.Send_Time)*/);
                }
                else
                {
                    MessageMe(message.TheMessage/*, Convert.ToString(message.Send_Time)*/);
                }


                messagecount += 1;
            }
        }
        private void LoadFriends()
        {
            var response = client.GetAsync("http://localhost:49497/api/Friends/UserID/" + MyID);
            var json = response.Result.Content.ReadAsStringAsync().Result.ToString();
            MessageBox.Show(json);
            this.friends = JsonConvert.DeserializeObject<List<Friends>>(json);
        }
        private void DrawFriends()
        {
            foreach (Friends fr in friends)
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(fr.ID_Friend), Encoding.UTF8, "application/json");
                HttpResponseMessage kamarad = client.PostAsync("http://localhost:49497/api/Users/FindUserByIDs", content).Result;
            }
        }
        private void Friends()
        {
            Button button = new Button();
            button.Width = 248;
            button.Height = 75;
            button.Background = Brushes.Blue;
            //button.Content = 
            Canvas.SetLeft(button, 0);
            Canvas.SetTop(button, 0);
            FriendsCanvas.Children.Add(button);
        }
        private void nazevchat()
        {
            Line line = new Line();
            line.X1 = 1;
            line.X2 = 744;
            line.Y1 = 48;
            line.Y2 = 48;
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 1;
            nazevchatcanvas.Children.Add(line);
        }
        private void sendmessage()
        {
            Line line = new Line();
            line.X1 = 1;
            line.X2 = 744;
            line.Y1 = 0;
            line.Y2 = 0;
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 1;
            sendmessagecanvas.Children.Add(line);
        }
        private void Ellipse_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Token);
        }
    }
}


//TextBlock textBlock = new TextBlock();
//textBlock.TextWrapping = TextWrapping.Wrap;
//            textBlock.Text = inputMSG;
//            textBlock.MaxWidth = 200;
//            textBlock.MaxHeight = 800;
//            textBlock.MinWidth = 20;
//            textBlock.MinHeight = 20;
//            Canvas.SetTop(textBlock, pixelsfromtop);
//            Canvas.SetLeft(textBlock, 12);
//            //Rectangle obdelnicek = new Rectangle();
//            //obdelnicek.RadiusX = 5;
//            //obdelnicek.RadiusY = 5;
//            //obdelnicek.Height = textBlock.Height + 2;
//            //obdelnicek.Width = textBlock.Width + 2;
//            //obdelnicek.Fill = Brushes.Gray;
//            //Canvas.SetTop(obdelnicek, 200);
//            //Canvas.SetLeft(obdelnicek, 10);
//            TextBlock casikblock = new TextBlock();
//casikblock.Text = sendtime;
//            casikblock.FontSize = 10;
//            Canvas.SetTop(casikblock, pixelsfromtop + 22);
//            Canvas.SetLeft(casikblock, 10);
//            Canvasmessages.Children.Add(textBlock);
//            //Canvasmessages.Children.Add(obdelnicek);
//            Canvasmessages.Children.Add(casikblock);