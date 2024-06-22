using Microsoft.Data.SqlClient;

namespace DataIntegration.Interface
{
    public interface IManageData
    {
        public void SqlRequest(string sqlR);
        public void SqlRequest(string sqlR, Dictionary<string, object> options);
        public SqlDataReader SqlRequestReader(string sqlR);
        public SqlDataReader SqlRequestReader(string sqlR, Dictionary<string, object> options);
        public void Update();
    }
}
