using System.Collections.Generic;
using System.Data;

namespace DbAccessLibTest.Test
{
public interface ITest
{
    /// <summary>
    /// 预先初始化,比如可以针对单件模式下,多线程并发导致的未初始化情况
    /// 如果单例模式下,需要做的事情有,初始化连接对象,初始化单例对象
    /// </summary>
    void Init();
    bool Insert();
    bool Update(string guid, string content);
    DataTable Select(int count);
    List<string> GetGuidList(int count);
    bool Delete(string guid);
}
}
