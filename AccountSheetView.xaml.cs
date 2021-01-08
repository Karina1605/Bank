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
using System.Data;
using Bank.models;
namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для AccountSheetView.xaml
    /// </summary>
    public partial class AccountSheetView : Window
    {
        Account account;
        DataTable data;
        public AccountSheetView(Account account)
        {
            InitializeComponent();
            this.account = account;
            Header.Content = account.CreateHeader();
            FillData();

        }
        void FillData()
        {
            data = new DataTable();
            DataColumn number = new DataColumn("#");
            DataColumn date = new DataColumn("Date");
            DataColumn descriprion = new DataColumn("Operation name");
            DataColumn sum = new DataColumn("Sum of operation");
            DataColumn res = new DataColumn("Balance");

            data.Columns.AddRange(new DataColumn[] { number, date, descriprion, sum, res });
            for (int i=0; i<data.Columns.Count; ++i)
                data.Columns[i].ReadOnly = true;
            Sheet.DataContext = data;
            decimal resbalance = 0;
            DateTime first = account.Operations.First().DateOfOperation;
            DateTime last = account.Operations.Last().DateOfOperation;
            for (int j=0; j<account.Operations.Count; ++j)
            {
                var r = data.NewRow();
               
                r["#"] = (j + 1).ToString();
                r["Date"] = account.Operations.ElementAt(j).DateOfOperation.ToString("d");
                r["Operation name"] = account.Operations.ElementAt(j).NameOfOperation;
                r["Sum of operation"] = account.Operations.ElementAt(j).SumOfOperation.ToString();
                resbalance += account.Operations.ElementAt(j).SumOfOperation;
                r["Balance"] = resbalance.ToString();

                data.Rows.Add(r);
            }
            this.FirstOperationDate.Text = first.ToString("d");
            this.LastOperationDate.Text = last.ToString("d");
            this.CurrentBalance.Text = account.CurrentBalance.ToString();
            this.OperationsCount.Text = account.Operations.Count.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".csv"; // Default file extension
            dlg.Filter = "CSV documents (.csv)|*.csv"; // Filter files by extension
            if (dlg.ShowDialog().HasValue)
            {
                using (System.IO.StreamWriter writer =new System.IO.StreamWriter(dlg.FileName))
                {
                    writer.WriteLine(account.CreateHeader());
                    writer.WriteLine();
                    foreach (DataRow r in data.Rows)
                    {
                        string st = $"{r[0]};{r[1]};{r[2]};{r[3]};{r[4]}";
                        writer.WriteLine(st);
                    }
                }
                
            }
            
        }
    }
}
