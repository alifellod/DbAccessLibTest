using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DbAccessLibTest.Model;
using MySoft.Data;

namespace DbAccessLibTest.Test
{
    public class MySoftOrmTest : ITest
    {
        private static readonly DbSession DBSession = new DbSession(new MySoft.Data.SqlServer9.SqlServer9Provider(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString));

        public bool Insert()
        {
            return DBSession.Insert<MySoftTestModel>(new[] { MySoftTestModel._.Guid }, new object[] { Guid.NewGuid().ToString() }) > 0;
        }

        public bool Update(string guid, string content)
        {
            return DBSession.Update<MySoftTestModel>(new[] { MySoftTestModel._.Content, MySoftTestModel._.EditDate }, new object[] { content, DateTime.Now }, MySoftTestModel._.Guid == guid) > 0;
        }

        public DataTable Select(int count)
        {
            GetModelList(count);
            return null;
        }
        public IList<MySoftTestModel> GetModelList(int count)
        {
            return DBSession.From<MySoftTestModel>().OrderBy(MySoftTestModel._.Guid.Asc).GetTop(count).ToList();
        }

        public List<string> GetGuidList(int count)
        {
            List<string> result = new List<string>();
            var list = GetModelList(count);
            if (list == null || list.Count == 0)
                return result;
            result.AddRange(list.Select(o => o.Guid));
            return result;
        }

        public bool Delete(string guid)
        {
            return DBSession.Delete<MySoftTestModel>(MySoftTestModel._.Guid == guid) > 0;
        }
    }
}
