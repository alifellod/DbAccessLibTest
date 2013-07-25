using System;

namespace DbAccessLibTest
{
    /// <summary>
    /// 测试工作线程信息
    /// </summary>
    public class Worker : IComparable
    {
        /// <summary>
        /// 线程序号
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 此线程总耗时
        /// </summary>
        public long TotalElapsed { get; set; }
        /// <summary>
        /// 按线程序号排序
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            return String.Compare(Name, ((Worker)obj).Name, StringComparison.Ordinal);
        }
    }
}