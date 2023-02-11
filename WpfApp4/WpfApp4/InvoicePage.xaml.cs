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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for InvoicePage.xaml
    /// </summary>
    public partial class InvoicePage : Window
    {
        public InvoicePage()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CLHeaderInvoice clh = new CLHeaderInvoice();
            clh.AddInvoice(Int32.Parse(TxtInvoiceNum.Text), DateInvoice.SelectedDate.ToString(),Int32.Parse( TxtPriceTotal.Text));
            
        }

        private void AddInvoice_Click(object sender, RoutedEventArgs e)
        {
            CLHeaderInvoice clh = new CLHeaderInvoice();
            TxtInvoiceNum.Text = clh.NewIvoiceID().ToString();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DateInvoice.SelectedDate = DateTime.Now;
            DateInvoice.IsEnabled = false;
        }
    }
}
