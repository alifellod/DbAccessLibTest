using System.Configuration;

namespace DbAccessLibTest.Environment
{
    public class Control
    {
        public static readonly string ConnectionStrings = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
    }
}
