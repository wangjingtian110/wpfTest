using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfTest
{
    /// <summary>
    /// DataGridTemplateTest.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridTemplateTest : Window
    {
        public DataGridTemplateTest()
        {
            InitializeComponent();
            DataContext = new DataGridTemplateTestViewModel(this);

            DG1.Columns.Add(new DataGridTextColumn
            {
                Header = "123",
                Binding = new Binding("FirstName")
            });
        }
    }

    public class DataGridTemplateTestViewModel: BaseViewModel
    {
        private DataGridTemplateTest _win;

        public ICommand Refresh { get; }
        private void OnRefresh(object obj)
        {
            Customers.Add(new Customer());
        }

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers 
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
                Notify("Customers");
            }
        }


        public DataGridTemplateTestViewModel(DataGridTemplateTest win)
        {
            _win = win;
            Refresh = new DelegateCommand(OnRefresh);
            _customers = new ObservableCollection<Customer>();
        }
    }


}
