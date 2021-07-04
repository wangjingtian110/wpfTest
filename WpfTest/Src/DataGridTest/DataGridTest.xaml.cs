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
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WpfTest
{
    /// <summary>
    /// DataGridTest.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridTest : Window
    {
       
        
        public DataGridTest()
        {
            InitializeComponent();

            DataContext = new DataGridTestViewModel(this);
           
        }
       
    }

    public class DataGridTestViewModel : BaseViewModel
    {
        private DataGridTest _win;


        private ObservableCollection<Customer> _custData;
        public ObservableCollection<Customer> CustData
        {
            get { return _custData; }
            set
            {
                _custData = value;
                Notify("CustData");
            }
        }

        public ICommand OnClick{get;}
        private void OnClickEvent(object obj)
        {
            var email = new Uri("maito:333@abc.com");
            CustData.Add(new Customer
            {
                FirstName = new Random().Next(1,10).ToString(),
                LastName = "ming",
                Email = email,
                IsMember = true,
                Status = OrderStatus.New
            });
        }


        public DataGridTestViewModel(DataGridTest win)
        {
            _win = win;
            _custData = GetData();

            OnClick = new DelegateCommand(OnClickEvent);
        }



        public ObservableCollection<Customer> GetData()
        {
            var email = new Uri("maito:333@abc.com");
            return new ObservableCollection<Customer>
            {
                new Customer
                {
                    FirstName = "xiao",
                    LastName = "ming",
                    Email = email,
                    IsMember = true,
                    Status = OrderStatus.New
                },
                new Customer
                {
                    FirstName = "xiao",
                    LastName = "ming",
                    Email = email,
                    IsMember = true,
                    Status = OrderStatus.New
                },
                new Customer
                {
                    FirstName = "xiao",
                    LastName = "ming",
                    Email = email,
                    IsMember = true,
                    Status = OrderStatus.New
                }
            };
        }

    }




    //Defines the customer object
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri Email { get; set; }
        public bool IsMember { get; set; }
        public OrderStatus Status { get; set; }

        public Customer()
        {
            FirstName = new Random().Next(0, 10).ToString();
            LastName = DateTime.Now.ToString();
            Email = new Uri("maito:333@abc.com");
            IsMember = new Random().Next() > 0;
            Status = OrderStatus.New;
        }
    }

    public enum OrderStatus { None, New, Processing, Shipped, Received };

    //Converts the mailto uri to a string with just the customer alias
    public class EmailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string email = value.ToString();
                int index = email.IndexOf("@");
                string alias = email.Substring(7, index - 7);
                return alias;
            }
            else
            {
                string email = "";
                return email;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Uri email = new Uri((string)value);
            return email;
        }
    }
}
