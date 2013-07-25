using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DbAccessLibTest.Environment;
using Moon.Orm;

namespace DbAccessLibTest.Test
{
    public class MoonTest : ITest
    {
        private readonly DB _dbHelper = DBFactory.DefaultDB;
        public bool Insert()
        {
            return (_dbHelper.ExecuteOneSql(string.Format(SqlString.InsertFormat, Guid.NewGuid(), string.Empty)) > 0);
        }
        public bool Update(string guid, string content)
        {
            return (_dbHelper.ExecuteOneSql(string.Format(SqlString.UpdateFormat, guid, content)) > 0);
        }
        public DataTable Select(int count)
        {
            return _dbHelper.GetDataTable(string.Format(SqlString.Select, count));
        }
        public List<string> GetGuidList(int count)
        {
            List<string> result = new List<string>();
            DataTable dtb = Select(count);
            if (dtb == null || dtb.Rows.Count == 0)
                return result;
            result.AddRange(from DataRow row in dtb.Rows select row["Guid"].ToString());
            return result;
        }
        public bool Delete(string guid)
        {
            return (_dbHelper.ExecuteOneSql(string.Format( SqlString.DeleteFormat,guid)) > 0);
        }
    }
}
