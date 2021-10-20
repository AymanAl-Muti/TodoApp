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
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using MySql.Data.MySqlClient;
using MySql;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for conformationCodePage.xaml
    /// </summary>
    public partial class conformationCodePage : Window
    {
        
        public conformationCodePage(string emailText, string passwordText)
        {

            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            
                
        //Generates random code to be sent to email to verify email address
            Random rand = new Random();
            App.Current.Properties["codeString"] = rand.Next(100000, 999999).ToString();
            string randomCode = App.Current.Properties["codeString"].ToString();

            

            var smptClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("todo.app.code@gmail.com", "ayman7865"),
                EnableSsl = true,
            };

            smptClient.Send("todo.app.code@gmail.com", emailText, "Testing TODO APP EMAIL CODE SEND", randomCode);


            //If email doesnt already exist within database, proceed to put the email and password into the database
            using var con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["todoDB"].ConnectionString);
            con.Open();

            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $"INSERT INTO creditentials (email, password) VALUES ('{emailText}', '{passwordText}')";
            cmd.ExecuteNonQuery();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string myProperty = App.Current.Properties["codeString"].ToString();
            if(conB.Text == myProperty)
            {
                MessageBox.Show("you have passed");
            }
           
        }
    }
}
