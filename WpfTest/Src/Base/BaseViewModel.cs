using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Public Properties  
        /// <summary>  
        /// 显示名称  
        /// </summary>  
        public virtual string DisplayName { get; protected set; }
        #endregion

        #region Constructor  
        /// <summary>  
        /// 实例化一个ViewModelBase对象  
        /// </summary>  
        protected BaseViewModel()
        {
        }
        #endregion

        #region INotifyPropertyChanged Members  
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region IDisposable Members  
        public void Dispose()
        {
            this.OnDispose();
        }
        /// <summary>  
        /// 若支持IDisposable，请重写此方法，当被调用Dispose时会执行此方法。  
        /// </summary>  
        protected virtual void OnDispose()
        {
        }
        #endregion
    }
}
