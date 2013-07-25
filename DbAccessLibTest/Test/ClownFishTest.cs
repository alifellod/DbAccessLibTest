using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClownFish;
using DbAccessLibTest.Environment;

namespace DbAccessLibTest.Test
{
    public class ClownFishTest : DbContextHolderBase, ITest
    {
        static ClownFishTest()
        {
            DbContext.RegisterDbConnectionInfo("sqlserver", "System.Data.SqlClient", "@", Control.ConnectionStrings);
        }
        public void TruncateTable()
        {
            DbHelper.ExecuteNonQuery(SqlString.TruncateTable, null, DbContext, CommandKind.SqlTextNoParams);
        }
        public bool Insert()
        {
            var parameter = new { Guid = Guid.NewGuid(), Content = string.Empty };
            return (DbHelper.ExecuteNonQuery(SqlString.Insert, parameter, DbContext, CommandKind.SqlTextWithParams) > 0);
        }
        public bool Update(string guid, string content)
        {
            var parameter = new { Guid = guid, Content = content };
            return (DbHelper.ExecuteNonQuery(SqlString.Update, parameter, DbContext, CommandKind.SqlTextWithParams) > 0);
        }
        public DataTable Select(int count)
        {
            return DbHelper.FillDataTable(string.Format(SqlString.Select, count), null, DbContext, CommandKind.SqlTextNoParams);
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
            var parameter = new { Guid = guid };
            return (DbHelper.ExecuteNonQuery(SqlString.Delete, parameter, DbContext, CommandKind.SqlTextWithParams) > 0);
        }
    }
}
