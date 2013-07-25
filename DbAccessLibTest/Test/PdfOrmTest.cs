using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DbAccessLibTest.Environment;
using DbAccessLibTest.Model;
using PWMIS.DataMap.Entity;
using PWMIS.DataProvider.Adapter;
using PWMIS.DataProvider.Data;

namespace DbAccessLibTest.Test
{
    public class PdfOrmTest : ITest
    {
        private readonly AdoHelper _dbHelper = MyDB.GetDBHelperByConnectionName("pdf");
        public bool Insert()
        {
            IDataParameter[] parameters =
            {
                new SqlParameter("@Guid",SqlDbType.VarChar,50){Value=Guid.NewGuid().ToString()},
                new SqlParameter("@Content",SqlDbType.NVarChar,500){Value=string.Empty}
            };
            return (_dbHelper.ExecuteNonQuery(SqlString.Insert, CommandType.Text, parameters) > 0);

        }
        public bool Update(string guid, string content)
        {
            PdfTestModel model = new PdfTestModel
            {
                Guid = guid,
                Content = content,
                EditDate = DateTime.Now
            };
            OQL q = OQL.From(model).Update(model.Content, model.EditDate).Where(model.Guid).END;

            return EntityQuery<PdfTestModel>.ExecuteOql(q, _dbHelper) > 0;
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
            OQL q = OQL.From(model).Delete().Where(model.Guid).END;
            return EntityQuery<PdfTestModel>.ExecuteOql(q, _dbHelper) > 0;
        }
    }
}
