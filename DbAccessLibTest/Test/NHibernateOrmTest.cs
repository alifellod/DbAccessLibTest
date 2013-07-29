using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DbAccessLibTest.Model;
using DbAccessLibTest.Test.NHibernate;
using FluentNHibernate.Cfg;
using NHibernate;

namespace DbAccessLibTest.Test
{
    public class NHibernateOrmTest : ITest
    {
        public void Init()
        {

        }
        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();
        static NHibernateOrmTest()
        {
        }
        private static ISessionFactory CreateSessionFactory()
        {
            ISessionFactory sessionFactory;
            try
            {
                sessionFactory = Fluently.Configure()
                                .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
                                .ConnectionString(s => s.Server(".").Database("Test")
                                    .TrustedConnection()))
                                .Mappings(m => m.FluentMappings.Add<TestModelMap>())
                                .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw;
            }
            return sessionFactory;
        }
        public bool Insert()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var model = new TestModel { Guid = Guid.NewGuid().ToString() };
                session.Save(model);
                session.Flush();
            }
            return true;
        }

        public bool Update(string guid, string content)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var model = new TestModel { Guid = guid, Content = content, EditDate = DateTime.Now };
                session.Update(model);
                session.Flush();
            }
            return true;
        }

        public DataTable Select(int count)
        {
            GetModelList(count);
            return null;
        }
        public IList<TestModel> GetModelList(int count)
        {
            IList<TestModel> result;
            using (var session = SessionFactory.OpenSession())
            {
                result = session.QueryOver<TestModel>().OrderBy(o => o.Guid).Asc.Take(count).List();
            }
            return result;
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
            using (var session = SessionFactory.OpenSession())
            {
                var model = new TestModel { Guid = guid };
                session.Delete(model);
                session.Flush();
            }
            return true;
        }
    }
}
