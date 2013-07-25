using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using System.Xml.Serialization;
using XCode.Configuration;
using XCode.DataAccessLayer;
namespace DbAccessLibTest.Model
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("IX_Test", true, "Guid")]
    [BindIndex("PK_Test_1", true, "Guid")]
    [BindTable("Test", Description = "", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class XCodeTestModel : IXCodeTestModel
    {
        #region 属性
        private Int32 _RowId;
        /// <summary></summary>
        [DisplayName("")]
        [Description("")]
        [DataObjectField(false, true, false, 10)]
        [BindColumn(1, "RowId", "", null, "int", 10, 0, false)]
        public Int32 RowId
        {
            get { return _RowId; }
            set { if (OnPropertyChanging("RowId", value)) { _RowId = value; OnPropertyChanged("RowId"); } }
        }
        private String _Guid;
        /// <summary></summary>
        [DisplayName("")]
        [Description("")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(2, "Guid", "", null, "varchar(50)", 0, 0, false)]
        public String Guid
        {
            get { return _Guid; }
            set { if (OnPropertyChanging("Guid", value)) { _Guid = value; OnPropertyChanged("Guid"); } }
        }
        private String _Content;
        /// <summary></summary>
        [DisplayName("")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(3, "Content", "", null, "nvarchar(500)", 0, 0, true)]
        public String Content
        {
            get { return _Content; }
            set { if (OnPropertyChanging("Content", value)) { _Content = value; OnPropertyChanged("Content"); } }
        }
        private DateTime _CreateDate;
        /// <summary></summary>
        [DisplayName("")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(4, "CreateDate", "", "getdate()", "datetime", 3, 0, false)]
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { if (OnPropertyChanging("CreateDate", value)) { _CreateDate = value; OnPropertyChanged("CreateDate"); } }
        }
        private DateTime _EditDate;
        /// <summary></summary>
        [DisplayName("")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "EditDate", "", null, "datetime", 3, 0, false)]
        public DateTime EditDate
        {
            get { return _EditDate; }
            set { if (OnPropertyChanging("EditDate", value)) { _EditDate = value; OnPropertyChanged("EditDate"); } }
        }
		#endregion
        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case "RowId" : return _RowId;
                    case "Guid" : return _Guid;
                    case "Content" : return _Content;
                    case "CreateDate" : return _CreateDate;
                    case "EditDate" : return _EditDate;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "RowId" : _RowId = Convert.ToInt32(value); break;
                    case "Guid" : _Guid = Convert.ToString(value); break;
                    case "Content" : _Content = Convert.ToString(value); break;
                    case "CreateDate" : _CreateDate = Convert.ToDateTime(value); break;
                    case "EditDate" : _EditDate = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion
        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public class _
        {
            ///<summary></summary>
            public static readonly FieldItem RowId = Meta.Table.FindByName("RowId");
            ///<summary></summary>
            public static readonly FieldItem Guid = Meta.Table.FindByName("Guid");
            ///<summary></summary>
            public static readonly FieldItem Content = Meta.Table.FindByName("Content");
            ///<summary></summary>
            public static readonly FieldItem CreateDate = Meta.Table.FindByName("CreateDate");
            ///<summary></summary>
            public static readonly FieldItem EditDate = Meta.Table.FindByName("EditDate");
        }
        #endregion
    }
    /// <summary>接口</summary>
    public partial interface IXCodeTestModel
    {
        #region 属性
        /// <summary></summary>
        Int32 RowId { get; set; }
        /// <summary></summary>
        String Guid { get; set; }
        /// <summary></summary>
        String Content { get; set; }
        /// <summary></summary>
        DateTime CreateDate { get; set; }
        /// <summary></summary>
        DateTime EditDate { get; set; }
        #endregion
        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}