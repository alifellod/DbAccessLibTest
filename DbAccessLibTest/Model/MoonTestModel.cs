using System;
using Moon.Orm;

namespace DbAccessLibTest.Model
{
    public class MoonTestModel : EntityBase, ITestModel
    {
        public MoonTestModel()
        {
            SetEntityName("[Test]");
            SetFieldsCount(3);
            SetPrimaryField(TestTable.Guid);
            SetIsSystemSetPrimaryKey(false);
        }
        private Int32 _rowId;
        [Field(false, "RowId")]
        public Int32 RowId
        {
            get { return _rowId; }
            set
            {
                _rowId = value;
                FieldsChangedDictionary["[RowId]"] = value;
            }
        }
        private String _guid;
        [Field(true, "Guid")]
        public String Guid
        {
            get { return _guid; }
            set
            {
                _guid = value;
                FieldsChangedDictionary["[Guid]"] = value;
            }
        }
        private String _content;
        [Field(false, "Content")]
        public String Content
        {
            get { return _content; }
            set
            {
                _content = value;
                FieldsChangedDictionary["[Content]"] = value;
            }
        }
        private DateTime _createDate;
        [Field(false, "CreateDate")]
        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                _createDate = value;
                FieldsChangedDictionary["[CreateDate]"] = value;
            }
        }
        private DateTime _editDate;
        [Field(false, "EditDate")]
        public DateTime EditDate
        {
            get { return _editDate; }
            set
            {
                _editDate = value;
                FieldsChangedDictionary["[EditDate]"] = value;
            }
        }
    }

    public class TestTable
    {
        public static readonly Field RowId = new Field("[RowId]", false, "[Test]");
        public static readonly Field Guid = new Field("[Guid]", true, "[Test]");
        public static readonly Field Content = new Field("[Content]", false, "[Test]");
        public static readonly Field CreateDate = new Field("[CreateDate]", false, "[Test]");
        public static readonly Field EditDate = new Field("[EditDate]", false, "[Test]");
    }

}