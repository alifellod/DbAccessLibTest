using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DbAccessLibTest.Model;
using PWMIS.DataMap.Entity;

namespace DbAccessLibTest.Test
{
    public class PdfOrmTest : ITest
    {
        public void Init()
        {

        }
        public bool Insert()
        {
            PdfTestModel model = new PdfTestModel
            {
                Guid = Guid.NewGuid().ToString(),
                EditDate = DateTime.Now
            };
            return EntityQuery<PdfTestModel>.Instance.Insert(model) > 0;
        }
        public bool Update(string guid, string content)
        {
            PdfTestModel model = new PdfTestModel
            {
                Guid = guid,
                Content = content,
                EditDate = DateTime.Now
            };
            return EntityQuery<PdfTestModel>.Instance.Update(model) > 0;
        }
        public DataTable Select(int count)
        {
            GetModelList(count);
            return null;
        }
        public List<PdfTestModel> GetModelList(int count)
        {
            PdfTestModel model = new PdfTestModel();
            OQL q = OQL.From(model).Limit(count).Select().OrderBy(model.Guid, "ASC").END;
            return EntityQuery<PdfTestModel>.QueryList(q);
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
            PdfTestModel model = new PdfTestModel { Guid = guid };
            return EntityQuery<PdfTestModel>.Instance.Delete(model) > 0;
        }
    }
}
