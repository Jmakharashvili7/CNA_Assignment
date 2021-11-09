using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CNA_Assignment
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SendButton.Click += SendMessageDispacher;
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        { 
            if (messageInputBox.Text == "")
            {
                MessageBox.Show("No message in text box!", "Warning");
            }
            else
            { 
                string message = messageInputBox.Text;
                messageInputBox.Text = "";
                if (usernameBlock.Text == "Template")
                { 
                    MessageBox.Show("Please input your username!", "Warning");
                    messageInputBox.Text = message;
                }
                else
                { 
                    string name = usernameBlock.Text;    
                    MessageDisplay.Text += name + ": " + message + "\n";
                }
            }

        }

        private void SendMessageDispacher(object sender, RoutedEventArgs e)
        {
            string message = messageInputBox.Text;
            
            // The work to perform on another thread
            ThreadStart ButtonThread = delegate()
            { 
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action<string>(SendMessage), message);
            };

            // Creathe the thread and kick it started!
            new Thread(ButtonThread).Start();
        }

        private void SendMessage(string status)
        {
            MessageDisplay.Text += usernameBlock.Text + ": " + status + "\n";
        }
    }
}
