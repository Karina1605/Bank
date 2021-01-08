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
    /// Логика взаимодействия для CommonSheets.xaml
    /// </summary>
    public partial class CommonSheets : Window
    {
        public CommonSheets()
        {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            using (Model m=new Model())
            {
                switch (SelectType.SelectedIndex)
                {
                    case 0:
                        SheetView.ItemsSource = m.GetCommonTable();
                        break;
                    case 1:
                        SheetView.ItemsSource = m.GetDeposits();
                        break;
                    case 2:
                        SheetView.ItemsSource = m.GetCreditCards();
                        break;
                    case 3:
                        SheetView.ItemsSource = m.GetPresentCards();
                        break;
                }
                var a = (from c in SheetView.Columns where (string)c.Header == "Operations" select c).First();
                SheetView.Columns.Remove(a);
                var b = (from c in SheetView.Columns where (string)c.Header == "Id" select c).First();
                b.DisplayIndex = 0;
                foreach (DataGridColumn column in SheetView.Columns)
                    column.IsReadOnly = true;
                
                
            }
            
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".csv"; // Default file extension
            dlg.Filter = "CSV documents (.csv)|*.csv"; // Filter files by extension
            if (dlg.ShowDialog().HasValue)
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(dlg.FileName))
                {
                    foreach (var r in SheetView.ItemsSource)
                    {
                        writer.WriteLine(((Account)r).GetCsvRow());
                    }
                }

            }

        }

        private void ToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            (new Bank_Application()).Show();
            this.Close();
        }
    }
}
