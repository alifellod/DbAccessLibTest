using System;
using MySoft.Data;
namespace DbAccessLibTest.Model
{
    public class MySoftTestModel : Entity
    {
        private String _content;
        private DateTime _createDate;
        private DateTime _editDate;
        private String _guid;
        private Int32 _rowId;

        public Int32 RowId
        {
            get { return _rowId; }
            set
            {
                _rowId = value;
                OnPropertyValueChange(_.RowId, _rowId, value);
            }
        }

        public String Guid
        {
            get { return _guid; }
            set
            {
                _guid = value;
                OnPropertyValueChange(_.Guid, _guid, value);
            }
        }

        public String Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyValueChange(_.Content, _content, value);
            }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                _createDate = value;
                OnPropertyValueChange(_.CreateDate, _createDate, value);
            }
        }

        public DateTime EditDate
        {
            get { return _editDate; }
            set
            {
                _editDate = value;
                OnPropertyValueChange(_.EditDate, _editDate, value);
            }
        }

        /// <summary>
        ///     获取实体对应的表名
        /// </summary>
        protected override Table GetTable()
        {
            return new Table<MySoftTestModel>("Test");
        }

        /// <summary>
        ///     获取实体中的标识列
        /// </summary>
        protected override Field GetIdentityField()
        {
            return _.RowId;
        }

        /// <summary>
        ///     获取实体中的主键列
        /// </summary>
        protected override Field[] GetPrimaryKeyFields()
        {
            return new[] {_.Guid};
        }

        /// <summary>
        ///     获取列信息
        /// </summary>
        protected override Field[] GetFields()
        {
            return new[]
            {
                _.RowId,
                _.Guid,
                _.Content,
                _.CreateDate,
                _.EditDate
            };
        }

        /// <summary>
        ///     获取列数据
        /// </summary>
        protected override object[] GetValues()
        {
            return new object[]
            {
                _rowId,
                _guid,
                _content,
                _createDate,
                _editDate
            };
        }

        /// <summary>
        ///     给当前实体赋值
        /// </summary>
        protected override void SetValues(IRowReader reader)
        {
            if ((false == reader.IsDBNull(_.RowId)))
            {
                _rowId = reader.GetInt32(_.RowId);
            }
            if ((false == reader.IsDBNull(_.Guid)))
            {
                _guid = reader.GetString(_.Guid);
            }
            if ((false == reader.IsDBNull(_.Content)))
            {
                _content = reader.GetString(_.Content);
            }
            if ((false == reader.IsDBNull(_.CreateDate)))
            {
                _createDate = reader.GetDateTime(_.CreateDate);
            }
            if ((false == reader.IsDBNull(_.EditDate)))
            {
                _editDate = reader.GetDateTime(_.EditDate);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null))
            {
                return false;
            }
            if ((false == typeof (MySoftTestModel).IsAssignableFrom(obj.GetType())))
            {
                return false;
            }
            if (this == obj)
            {
                return true;
            }
            return false;
        }

        /// <summary>取得字段信息的快捷方式</summary>
        public class _
        {
            public static Field RowId = new Field<MySoftTestModel>("RowId");
            public static Field Guid = new Field<MySoftTestModel>("Guid");
            public static Field Content = new Field<MySoftTestModel>("Content");
            public static Field CreateDate = new Field<MySoftTestModel>("CreateDate");
            public static Field EditDate = new Field<MySoftTestModel>("EditDate");
        }
    }
}