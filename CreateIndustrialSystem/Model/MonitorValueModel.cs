using CreateIndustrialSystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateIndustrialSystem.Model
{
    /// <summary>
    /// 监控数据对象
    /// </summary>
    public class MonitorValueModel : BindableObject
    {
        public Action<MonitorValueState, string, string> ValueStateChanged;

        /// <summary>
        /// 当前值对应的设备Id
        /// </summary>
        public string ValueId { get; set; }

        /// <summary>
        /// 当前值对应的设备名称
        /// </summary>
        public string ValueName { get; set; }

        /// <summary>
        /// 当前存储区的Id
        /// </summary>
        public string StorageAreaId { get; set; }

        /// <summary>
        /// 开始的地址
        /// </summary>
        public int StartAddress { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 是否告警
        /// </summary>
        public bool IsAlarm { get; set; }

        /// <summary>
        /// 极低值
        /// </summary>
        public double LoLoAlarm { get; set; }

        /// <summary>
        /// 过低值
        /// </summary>
        public double LowAlarm { get; set; }

        /// <summary>
        /// 极高值
        /// </summary>
        public double HiHiAlarm { get; set; }

        /// <summary>
        /// 极低值
        /// </summary>
        public double HighAlarm { get; set; }

        /// <summary>
        /// 过高值
        /// </summary>
        public string Unit { get; set; }

        private double _currentValue;

        public double CurrentValue
        {
            get { return _currentValue; }
            set
            {
                _currentValue = value;

                if (IsAlarm)
                {
                    string msg = ValueDesc;
                    MonitorValueState state = MonitorValueState.OK;

                    if (value < LoLoAlarm)
                    { msg += "极低"; state = MonitorValueState.LoLo; }
                    else if (value < LowAlarm)
                    { msg += "过低"; state = MonitorValueState.Low; }
                    else if (value > HiHiAlarm)
                    { msg += "极高"; state = MonitorValueState.HiHi; }
                    else if (value > HighAlarm)
                    { msg += "过高"; state = MonitorValueState.High; }

                    ValueStateChanged(state, msg + "。当前值：" + value.ToString(), ValueId);

                }
                //Values.Add(new ObservableValue(value));
                //if (Values.Count > 60) Values.RemoveAt(0);

                OnPropertyChanged();
            }
        }
        public string ValueDesc { get; set; }

        //public ChartValues<ObservableValue> Values { get; set; } = new ChartValues<ObservableValue>();
    }
}
