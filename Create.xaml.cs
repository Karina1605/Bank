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
    /// Логика взаимодействия для Create.xaml
    /// </summary>
    public partial class Create : Window
    {

        public Create()
        {
            InitializeComponent();
            HideAll();
        }

        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            switch(SelectType.SelectedIndex)
            {
                case 0:
                    ShowDep();
                    break;
                case 1:
                    ShowCredit();
                    break;
                case 2:
                    ShowPresent();
                    break;
            }

        }
        void HideAll()
        {
            this.CreateButton.Visibility = Visibility.Hidden;
            this.LimitLabel.Visibility = Visibility.Hidden;
            this.LimitTextBox.Visibility = Visibility.Hidden;
            this.PercentstOrSumTextBox.Visibility = Visibility.Hidden;
            this.PercentstOrSumLabel.Visibility = Visibility.Hidden;
            this.StartSumLabel.Visibility = Visibility.Hidden;
            this.StartSumTextBox.Visibility = Visibility.Hidden;
            this.NameLabel.Visibility = Visibility.Hidden;
            this.NametextBox.Visibility = Visibility.Hidden;

        }
        void ShowCredit()
        {
            HideAll();
            this.CreateButton.Visibility = Visibility.Visible;
            this.LimitLabel.Visibility = Visibility.Visible;
            this.LimitTextBox.Visibility = Visibility.Visible;
            this.PercentstOrSumLabel.Content = "Percent";
            this.PercentstOrSumTextBox.Visibility = Visibility.Visible;
            this.PercentstOrSumLabel.Visibility = Visibility.Visible;
            this.StartSumLabel.Visibility = Visibility.Visible;
            this.StartSumTextBox.Visibility = Visibility.Visible;
            this.NameLabel.Visibility = Visibility.Visible;
            this.NametextBox.Visibility = Visibility.Visible;

        }
        void ShowDep()
        {
            HideAll();
            this.CreateButton.Visibility = Visibility.Visible;
            this.PercentstOrSumLabel.Content= "Percent";
            this.PercentstOrSumTextBox.Visibility = Visibility.Visible;
            this.PercentstOrSumLabel.Visibility = Visibility.Visible;
            this.StartSumLabel.Visibility = Visibility.Visible;
            this.StartSumTextBox.Visibility = Visibility.Visible;
            this.NameLabel.Visibility = Visibility.Visible;
            this.NametextBox.Visibility = Visibility.Visible;

        }
        void ShowPresent()
        {
            HideAll();
            this.CreateButton.Visibility = Visibility.Visible;
            this.PercentstOrSumLabel.Content= "Monthly sum";
            this.PercentstOrSumTextBox.Visibility = Visibility.Visible;
            this.PercentstOrSumLabel.Visibility = Visibility.Visible;
            this.StartSumLabel.Visibility = Visibility.Visible;
            this.StartSumTextBox.Visibility = Visibility.Visible;
            this.NameLabel.Visibility = Visibility.Visible;
            this.NametextBox.Visibility = Visibility.Visible;

        }
        void ClearFields()
        {
            PercentstOrSumTextBox.Text = "";
            StartSumTextBox.Text = "";
            LimitTextBox.Text = "";
            NametextBox.Text = "";
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal d1, d2, d3;
                Account res = null;
                switch (SelectType.SelectedIndex)
                {
                    case 0:
                        d1 = Decimal.Parse(this.StartSumTextBox.Text);
                        d2 = Decimal.Parse(this.PercentstOrSumTextBox.Text);
                        res = new Deposit(d1, this.NametextBox.Text, d2);
                        break;
                    case 1:
                        d1 = Decimal.Parse(this.StartSumTextBox.Text);
                        d2 = Decimal.Parse(this.PercentstOrSumTextBox.Text);
                        d3 = Decimal.Parse(this.LimitTextBox.Text);
                        res = new CreditCard(d1, this.NametextBox.Text, d2, d3);
                        break;
                    case 2:
                        d1 = Decimal.Parse(this.StartSumTextBox.Text);
                        d2 = Decimal.Parse(this.PercentstOrSumTextBox.Text);
                        res = new PresentCard(d1, this.NametextBox.Text, d2);
                        break;
                }
                using (Model m = new Model())
                {
                    m.AddAccount(res);
                    m.Save();
                }
                ClearFields();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void To_menu_Click(object sender, RoutedEventArgs e)
        {
            (new Bank_Application()).Show();
            this.Close();
        }
    }
}
