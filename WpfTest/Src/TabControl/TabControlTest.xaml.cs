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
    /// TabControlTest.xaml 的交互逻辑
    /// </summary>
    public partial class TabControlTest : Window
    {
        public TabControlTest()
        {
            InitializeComponent();

            this.DataContext = new TabControlTestViewModel(this);
        }
    }

    public class TabControlTestViewModel : BaseViewModel
    {
        private TabControlTest _win;

        public TabControlTestViewModel(TabControlTest win)
        {
            _win = win;
            _win.infos.Text = "初始化：";

            Names = new ObservableCollection<string>
            {
                "123",
                "345"
            };

            Contents = new ObservableCollection<string>
            {
                "aaaaa",
                "bbbbb"
            };

            IndexChanged = new DelegateCommand(OnIndexChanged);
            _currentContent = "初始内容";
        }

        public ObservableCollection<string> Names { get; set; }

        public ObservableCollection<string> Contents { get; set; }

        private int _currentIndex;
        public int CurrentIndex
        {
            get
            {
                return _currentIndex;
            }
            set
            {
                _currentIndex = value;
                Notify("CurrentIndex");
            }
        }

        private string _currentContent;
        public string CurrentContent
        {
            get
            {
                return _currentContent;
            }
            set
            {
                _currentContent = value;
                Notify("CurrentContent");
            }
        }

        public ICommand IndexChanged { get; }

        public void OnIndexChanged(object obj)
        {
            var info = new Random().Next(1, 6) + "index :" + _currentIndex;
            _win.infos.AppendText(info);
            CurrentContent = info;
        }
    }
}
