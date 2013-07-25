using System;

namespace DbAccessLibTest.Model
{
    public enum TableNames
    {
        Test
    }
    public class TestModel : ITestModel
    {
        public virtual int RowId { get; set; }
        public virtual string Guid { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime EditDate { get; set; }
    }
    public interface ITestModel
    {
        int RowId { get; set; }
        string Guid { get; set; }
        string Content { get; set; }
        DateTime CreateDate { get; set; }
        DateTime EditDate { get; set; }
    }
}
