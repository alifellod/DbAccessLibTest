using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DbAccessLibTest.Model;
using Moon.Orm;

namespace DbAccessLibTest.Test
{
    public class MoonOrmTest : ITest
    {
        public static void Init() { }
        public bool Insert()
        {
            return DBFactory.Add(new MoonTestModel { Guid = Guid.NewGuid().ToString() }) != DBNull.Value;
        }
        public bool Update(string guid, string content)
        {
            var model = new MoonTestModel() { Content = content };
            model.SetOnlyMark(TestTable.Guid.Equal(guid));
            DBFactory.Update(model);
            return true;
        }
        public DataTable Select(int count)
        {
            GetModelList(count);
            return null;
        }
        public IList<MoonTestModel> GetModelList(int count)
        {
            //没有找到更好的查询方式
            return DBFactory.DefaultDB.GetPagedListDesc<MoonTestModel>(1, count, TestTable.Guid, TestTable.Guid.NotEqual("''"));
        }
        public List<string> GetGuidList(int count)
        {
            List<string> result = new List<string>();
            var list = GetModelList(count);
            if (list == null || list.Count == 0)
                return result;
            result.AddRange(list.Select(moonTestModel => moonTestModel.Guid));
            return result;
        }
        public bool Delete(string guid)
        {
            return DBFactory.DeleteWhen(TestTable.Guid.Equal(guid)) > 0;
        }
    }
}
