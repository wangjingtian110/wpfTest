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
    /// 以模板为原型创建的TabControl
    /// TabControl内为DataGrid，同时DataGrid内的内容在ViewModel中指定，并且根据SelectIndex进行切换，各Tab的DataGrid互不干扰
    /// 存在一个SubMit按钮 每次点击添加一条当前DataGrid的内容
    /// 存在一个Output按钮 每次点击输出当前DataGrid内容到指定位置
    /// </summary>
    public partial class TabControlDataGrid : Window
    {
        public TabControlDataGrid()
        {
            InitializeComponent();
            DataContext = new TabControlDataGridViewModel(this);
        }
    }

    public class TabControlDataGridViewModel : BaseViewModel
    {
        private TabControlDataGrid _win;

        public ObservableCollection<string> Names { get; set; }

        public ObservableCollection<ObservableCollection<Customer>> DataGrids { get; set; }

        public ObservableCollection<Customer> CurrentGrid { get
            {
                return DataGrids[CurrentIndex];
            }
            set
            {
                DataGrids[CurrentIndex] = value;
                Notify("CurrentGrid");
            }
        }
        public int CurrentIndex { get; set; }       

        public ICommand Submit { get; set; }
        private void OnSubmit(object obj)
        {
            CurrentGrid.Add(new Customer());
        }

        public ICommand Refresh { get; set; }
        private void OnRefresh(object obj)
        {
            var datas = DataGrids[CurrentIndex];
            string json = string.Join("_", datas.Select(o => o.FirstName).ToList());
            _win.infos.AppendText(json);
        }

        public ICommand IndexChanged { get; set; }
        private void OnSelectChanged(object obj)
        {            
            Notify("CurrentGrid");
        }


        public TabControlDataGridViewModel(TabControlDataGrid win)
        {
            _win = win;

            InitGrid();
            CurrentIndex = 0;

            Submit = new DelegateCommand(OnSubmit);
            Refresh = new DelegateCommand(OnRefresh);
            IndexChanged = new DelegateCommand(OnSelectChanged);
        }

        private void InitGrid()
        {
            DataGrids = new ObservableCollection<ObservableCollection<Customer>>
            {
                new ObservableCollection<Customer>
                {
                    new Customer(),
                    new Customer()
                },
                new ObservableCollection<Customer>
                {
                    new Customer(),
                    new Customer(),
                    new Customer()
                }
            };

            Names = new ObservableCollection<string>(DataGrids.Select(grid => "grid" + grid.Count));
        }
    }
}
