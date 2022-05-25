using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateIndustrialSystem.BLL
{
    public class DataResult<T>
    {
        /// <summary>
        /// 返回的状态
        /// </summary>
        public bool State { get; set; } = false;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public T Data { get; set; }
    }

    public class DataResult : DataResult<string> { }
}
