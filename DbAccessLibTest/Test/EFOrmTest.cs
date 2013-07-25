using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using DbAccessLibTest.Model;
using DbAccessLibTest.Test.EF;

namespace DbAccessLibTest.Test
{
    public class EFOrmTest : ITest
    {
        private readonly EFDbContext _dbContext;
        //private static readonly EFDbContext _dbContext = new EFDbContext("Conn");
        public EFOrmTest()
        {
            _dbContext = new EFDbContext("Conn");
        }
        public bool Insert()
        {
            DbSet<TestModel> model = _dbContext.Set<TestModel>();
            model.Add(new TestModel { Guid = Guid.NewGuid().ToString(), EditDate = DateTime.Now });
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(string guid, string content)
        {
            var model = _dbContext.Set<TestModel>().Find(guid);
            model.Content = content;
            _dbContext.Entry(model).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        public DataTable Select(int count)
        {
            GetModelList(count);
            return null;
        }

        public IList<TestModel> GetModelList(int count)
        {
            DbSet<TestModel> model = _dbContext.Set<TestModel>();
            return model.OrderBy(o => o.Guid).Take(count).ToList();
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
            var model = _dbContext.Set<TestModel>().Find(guid);
            _dbContext.Entry(model).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
