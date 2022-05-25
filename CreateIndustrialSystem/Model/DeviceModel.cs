using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateIndustrialSystem.Model
{
    public class DeviceModel : BindableObject
    {
        /// <summary>
        /// 设备Id
        /// </summary>
        public string DeviceID { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }

        private bool _isRunning;
        /// <summary>
        /// 是否在运行
        /// </summary>
        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }

        private bool _isWarning = false;
        /// <summary>
        /// 是否报错
        /// </summary>
        public bool IsWarning
        {
            get { return _isWarning; }
            set
            {
                _isWarning = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<MonitorValueModel> MonitorValueList { get; set; } = new ObservableCollection<MonitorValueModel>();

        public ObservableCollection<WarningMessageModel> WarningMessageList { get; set; } = new ObservableCollection<WarningMessageModel>();
    }
}
