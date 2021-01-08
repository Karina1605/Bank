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
using Bank.models;
namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для OperationWithAccount.xaml
    /// </summary>
    public partial class OperationWithAccount : Window
    {
        Account current = null;
        List<Operation> operations;
        int commits = 0;
        public OperationWithAccount()
        {
            InitializeComponent();
            LockEnabled();
            operations = new List<Operation>();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            int num;
            if (!Int32.TryParse(this.NumberTextBox.Text, out num))
                MessageBox.Show("Incorrect account number");
            else
            {
                using (Model m = new Model())
                {
                    current = m.GetAccount(num);
                }
                if (current != null)
                {
                    
                    UnlockEnabled();
                }
                    
                else
                    MessageBox.Show("There is no account with this number");
            }
            
        }
        void LockEnabled()
        {
            this.GetSheet.IsEnabled = false;
            this.MonthlyTranzaction.IsEnabled = false;
            this.PutButton.IsEnabled = false;
            this.SumBox.IsEnabled = false;
            this.TakeButton.IsEnabled = false;
            this.Save.IsEnabled = false;
        }
        void UnlockEnabled()
        {
            this.GetSheet.IsEnabled = true;
            this.MonthlyTranzaction.IsEnabled = true;
            this.PutButton.IsEnabled = true;
            this.SumBox.IsEnabled = true;
            this.TakeButton.IsEnabled = true;
            this.Save.IsEnabled = true;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void MonthlyTranzaction_Click(object sender, RoutedEventArgs e)
        {
            current.MonthlyOperation();
            
            commits++;
        }

        private void PutButton_Click(object sender, RoutedEventArgs e)
        {
            decimal d1;
            if (Decimal.TryParse(this.SumBox.Text, out d1) && d1>0)
            {
                current.AddSum(d1);
                this.SumBox.Text = "";
                commits++;
            }
            else
                MessageBox.Show("Incorrect Number");
        }

        private void TakeButton_Click(object sender, RoutedEventArgs e)
        {
            decimal d1;
            if (Decimal.TryParse(this.SumBox.Text, out d1) && d1 > 0)
            {
                current.TakeSum(d1);
                this.SumBox.Text = "";
                commits++;
            }
                
            else
                MessageBox.Show("Incorrect Number");
        }

        
        private void GetSheet_Click(object sender, RoutedEventArgs e)
        {
            (new AccountSheetView(current)).Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using(Model m =new Model())
            {
                m.UpdateAccount(current, commits);
                m.Save();
            }
        }

        private void To_menu_Click(object sender, RoutedEventArgs e)
        {
            (new Bank_Application()).Show();
            this.Close();
        }
    }
}
