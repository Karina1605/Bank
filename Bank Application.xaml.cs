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

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Bank_Application.xaml
    /// </summary>
    public partial class Bank_Application : Window
    {
        public Bank_Application()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int action = this.Action.SelectedIndex;
            switch(this.Action.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("Incorrect action");
                    break;
                case 1:
                    (new Create()).Show();
                    this.Close();
                    break;
                case 2:
                    (new OperationWithAccount()).Show();
                    this.Close();
                    break;
                case 3:
                    (new CommonSheets()).Show();
                    this.Close();
                    break;

            }
        }

    }
}
