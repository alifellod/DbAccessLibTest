using System;
using PWMIS.DataMap.Entity;

namespace DbAccessLibTest.Model
{
    public class PdfTestModel : EntityBase
    {
        public PdfTestModel()
        {
            TableName = "Test";
            PrimaryKeys.Add("RowId");//主键
        }
        protected override void SetFieldNames()
        {
            PropertyNames = new[] { "RowId", "Guid", "Content", "CreateDate", "EditDate" };
        }

        public string RowId
        {
            get { return getProperty<string>("RowId"); }
            set { setProperty("RowId", value); }
        }
        public string Guid
        {
            get { return getProperty<string>("Guid"); }
            set { setProperty("Guid", value); }
        }
        public string Content
        {
            get { return getProperty<string>("Content"); }
            set { setProperty("Content", value); }
        }
        public DateTime CreateDate
        {
            get { return getProperty<DateTime>("CreateDate"); }
            set { setProperty("CreateDate", value); }
        }

        public DateTime EditDate
        {
            get { return getProperty<DateTime>("EditDate"); }
            set { setProperty("EditDate", value); }
        }
    }
}
