using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CYQ.Data;
using DbAccessLibTest.Model;

namespace DbAccessLibTest.Test
{
    public class CyqOrmTest : ITest
    {
        public bool Insert()
        {
            bool result;
            using (MAction actiont = new MAction(TableNames.Test))
            {
                actiont.Set("Guid", Guid.NewGuid());
                result = actiont.Insert(InsertOp.None);
            }
            return result;
        }
        public bool Update(string guid, string content)
        {
            bool result;
            using (MAction actiont = new MAction(TableNames.Test))
            {
                actiont.Set("Content", content);
                result = actiont.Update("Guid='" + guid + "'");
            }
            return result;
        }
        public DataTable Select(int count)
        {
            DataTable result;
            using (MAction actiont = new MAction(TableNames.Test))
            {
                result = actiont.Select(count, "order by RowId").ToDataTable();
                //actiont.Select(count, "order by RowId");
            }
            return result;
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
            bool result;
            using (MAction actiont = new MAction(TableNames.Test))
            {
                result = actiont.Delete("Guid='" + guid + "'");
            }
            return result;
        }
    }
}
