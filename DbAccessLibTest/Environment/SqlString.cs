namespace DbAccessLibTest.Environment
{
    public class SqlString
    {
        public const string Insert = "insert into Test (Guid,Content) values(@Guid,@Content)";
        public const string InsertFormat = "insert into Test (Guid,Content) values('{0}','{1}')";
        public const string Delete = "delete Test where Guid=@Guid";
        public const string DeleteFormat = "delete Test where Guid='{0}'";
        public const string Update = "update Test set Content=@Content where Guid=@Guid";
        public const string UpdateFormat = "update Test set Content='{1}' where Guid='{0}'";
        public const string Select = "select top {0} * from Test order by Guid";
        public const string TruncateTable = "truncate table Test";
    }
}
