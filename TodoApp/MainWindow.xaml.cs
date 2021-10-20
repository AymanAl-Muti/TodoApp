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
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace TodoApp
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;           
        }

        //On register button click
        private void regBut_Click(object sender, RoutedEventArgs e) 
        {
            
            
            //If you dont put your email and password when signing up you get an error message telling you to create an email and password
            if (emailinput.Text == "" && paswordinput.Password == "")
            {
                ErrorText.Text = "Please enter an Email and Password";
                ErrorText.Foreground = new SolidColorBrush(Colors.Red);
                ErrorText.Margin = new Thickness(317, 55, 179, 21);
                Grid.SetRow(ErrorText, 2);
                Grid.SetColumn(ErrorText, 1);
                System.Diagnostics.Debug.WriteLine("please for fucks sake");
            }

            else 
            {
                //Resets the error line to the default so once someone actually puts proper stuff into the bar it goes bye bye
                ErrorText.Text = "";
                ErrorText.Foreground = new SolidColorBrush(Colors.White);
                ErrorText.Margin = new Thickness(0,0,0,0);
                Grid.SetRow(ErrorText, 0);
                Grid.SetColumn(ErrorText, 0);

                if (emailinput.Text != "" && paswordinput.Password != "") 
                {

                    conformationCodePage form = new conformationCodePage(emailinput.Text, paswordinput.Password);
                    this.Close();
                    form.Show();
                }
            }
            
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LoginWindow Login = new LoginWindow();
            this.Close();
            Login.Show();
        }
    }
}