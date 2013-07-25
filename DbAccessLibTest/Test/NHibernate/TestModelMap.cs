using DbAccessLibTest.Model;
using FluentNHibernate.Mapping;

namespace DbAccessLibTest.Test.NHibernate
{
    /// <summary>
    /// This is an example automapping configuration. You should create your own that either
    /// implements IAutomappingConfiguration directly, or inherits from DefaultAutomappingConfiguration.
    /// Overriding methods in this class will alter how the automapper behaves.
    /// </summary>
    class TestModelMap : ClassMap<TestModel>
    {
        public TestModelMap()
        {
            Table("Test");
            Id(o => o.Guid).Column("Guid");
            Map(o => o.Content).Column("Content");
            Map(o => o.RowId).Column("RowId").ReadOnly();
            Map(o => o.EditDate).Column("EditDate").ReadOnly().Update();
            Map(o => o.CreateDate).Column("CreateDate").ReadOnly();
        }
    }
}