namespace DbAccessLibTest.Environment
{
    public class SqlString
    {
        /// <summary>
        /// insert into Test (Guid,Content) values(@Guid,@Content)
        /// </summary>
        public const string Insert = "insert into Test (Guid,Content) values(@Guid,@Content)";
        /// <summary>
        /// insert into Test (Guid,Content) values('{0}','{1}')
        /// </summary>
        public const string InsertFormat = "insert into Test (Guid,Content) values('{0}','{1}')";
        /// <summary>
        /// delete Test where Guid=@Guid
        /// </summary>
        public const string Delete = "delete Test where Guid=@Guid";
        /// <summary>
        /// update Test set Content=@Content where Guid=@Guid
        /// </summary>
        public const string DeleteFormat = "delete Test where Guid='{0}'";
        /// <summary>
        /// update Test set Content=@Content where Guid=@Guid
        /// </summary>
        public const string Update = "update Test set Content=@Content where Guid=@Guid";
        /// <summary>
        /// update Test set Content='{1}' where Guid='{0}'
        /// </summary>
        public const string UpdateFormat = "update Test set Content='{1}' where Guid='{0}'";
        /// <summary>
        /// select top {0} * from Test order by Guid
        /// </summary>
        public const string Select = "select top {0} * from Test order by Guid";
        public const string TruncateTable = "truncate table Test";
    }
}
