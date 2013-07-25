using System.Collections.Generic;
using System.Data;

namespace DbAccessLibTest.Test
{
    public interface ITest
    {
         bool Insert();
         bool Update(string guid, string content);
         DataTable Select(int count);
         List<string> GetGuidList(int count);
         bool Delete(string guid);
    }
}
