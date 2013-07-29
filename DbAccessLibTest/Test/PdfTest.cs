using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DbAccessLibTest.Environment;
using PWMIS.DataProvider.Adapter;
using PWMIS.DataProvider.Data;

namespace DbAccessLibTest.Test
{
    public class PdfTest : ITest
    {
        public void Init()
        {

        }
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
            IDataParameter[] parameters =
            {
                new SqlParameter("@Guid",SqlDbType.VarChar,50){Value=guid},
                new SqlParameter("@Content",SqlDbType.NVarChar,500){Value=content}
            };
            return (_dbHelper.ExecuteNonQuery(SqlString.Update, CommandType.Text, parameters) > 0);
        }
        public DataTable Select(int count)
        {
            return _dbHelper.ExecuteDataSet(string.Format(SqlString.Select, count)).Tables[0];
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
            IDataParameter[] parameters =
            {
                new SqlParameter("@Guid",SqlDbType.VarChar,50){Value=guid}
            };
            return (_dbHelper.ExecuteNonQuery(SqlString.Delete, CommandType.Text, parameters) > 0);
        }
    }
}
