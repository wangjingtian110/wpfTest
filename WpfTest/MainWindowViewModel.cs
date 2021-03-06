using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTest
{
    public class MainWindowViewModel :BaseViewModel
    {
        private ICommand _tabControlOpen;
        public ICommand TabControlOpen
        {
            get
            {
                return _tabControlOpen;
            }            
        }

        private ICommand _dataGridOpen;
        public ICommand DataGridOpen
        {
            get
            {
                return _dataGridOpen;
            }
        }
        private void OnDataGridOpen(object obj)
        {
            DataGridTest win = new DataGridTest();
            win.ShowDialog();
        }

        public ICommand DataGridTemplateOpen { get; }
        public void OnDataGridTemplateOpen(object obj)
        {
            DataGridTemplateTest win = new DataGridTemplateTest();
            win.ShowDialog();
        }

        public ICommand TabMultyOpen { get
            {
                return new DelegateCommand(obj =>
                {
                    var win = new TabControlDataGrid();
                    win.ShowDialog();
                });
            } }


        private MainWindow _win;

        public MainWindowViewModel(MainWindow win)
        {
            _win = win;
            _tabControlOpen = new DelegateCommand(OnTabControlOpen);
            _dataGridOpen = new DelegateCommand(OnDataGridOpen);
            DataGridTemplateOpen = new DelegateCommand(OnDataGridTemplateOpen);
        }

        public void OnTabControlOpen(object obj)
        {
            TabControlTest win = new TabControlTest();
            win.ShowDialog();
        }
    }
}
