using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateIndustrialSystem.Model
{
    /// <summary>
    /// 数据库表的映射
    /// </summary>
    public class StorageModel
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 设备地址
        /// </summary>
        public int SlaveAddress { get; set; }

        /// <summary>
        /// 功能码
        /// </summary>
        public string FuncCode { get; set; }

        /// <summary>
        /// 开始地址
        /// </summary>
        public int StartAddress { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }
    }
}
