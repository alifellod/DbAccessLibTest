using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DbAccessLibTest.Model;

namespace DbAccessLibTest.Test
{
    public class XCodeOrmTest : ITest
    {
        public void Init()
        {

        }
        static XCodeOrmTest()
        {
            XCode.DataAccessLayer.DAL.ShowSQL = false;
            //XCode.DataAccessLayer.DAL.SQLPath = AppDomain.CurrentDomain.BaseDirectory;
        }
        public bool Insert()
        {
            var model = new XCodeTestModel();
            model.Guid = Guid.NewGuid().ToString();
            return model.Insert() > 0;

        }
        public bool Update(string guid, string content)
        {
            var model = XCodeTestModel.FindByGuid(guid);
            model.Content = content;
            model.EditDate = DateTime.Now;
            return model.Update() > 0;
        }
        public DataTable Select(int count)
        {
            GetModelList(count);
            return null;
        }
        public List<XCodeTestModel> GetModelList(int count)
        {
            return XCodeTestModel.Search(string.Empty, "Guid ASC", 0, count);
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
            //return XCodeTestModel.Delete(new[] { "Guid" }, new object[] { guid }) > 0;
            return XCodeTestModel.FindByGuid(guid).Delete() > 0;
        }
    }
}
