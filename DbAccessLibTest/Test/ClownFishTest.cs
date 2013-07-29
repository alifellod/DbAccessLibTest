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
        private static bool _isInit;
        public void Init()
        {
            if (!_isInit)
            {
                _isInit = true;
                DbContext.RegisterDbConnectionInfo("sqlserver", "System.Data.SqlClient", "@", Control.ConnectionStrings);
                //_instance = new ClownFishTest();
                Instance.Select(1);
            }
        }
        private static ClownFishTest _instance;
        public static ClownFishTest Instance
        {
            get { return _instance ?? (_instance = new ClownFishTest()); }
        }
        public void TruncateTable()
        {
            DbHelper.ExecuteNonQuery(SqlString.TruncateTable, null, DbContext, CommandKind.SqlTextNoParams);
        }
        public bool Insert()
        {
            //return (DbHelper.ExecuteNonQuery(SqlString.Insert, new { Guid = Guid.NewGuid(), Content = string.Empty }, DbContext, CommandKind.SqlTextWithParams) > 0);
            return (DbHelper.ExecuteNonQuery(string.Format(SqlString.InsertFormat, Guid.NewGuid(), string.Empty), null, DbContext, CommandKind.SqlTextNoParams) > 0);
        }
        public bool Update(string guid, string content)
        {
            //return (DbHelper.ExecuteNonQuery(SqlString.Update, new { Guid = guid, Content = content }, DbContext, CommandKind.SqlTextWithParams) > 0);
            return (DbHelper.ExecuteNonQuery(string.Format(SqlString.UpdateFormat, guid, content), null, DbContext, CommandKind.SqlTextNoParams) > 0);

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
            //return (DbHelper.ExecuteNonQuery(SqlString.Delete, new { Guid = guid }, DbContext, CommandKind.SqlTextWithParams) > 0);
            return (DbHelper.ExecuteNonQuery(string.Format(SqlString.DeleteFormat, guid), null, DbContext, CommandKind.SqlTextNoParams) > 0);

        }
    }
}
