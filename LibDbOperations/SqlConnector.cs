using System.Data;
using System.Data.SqlClient;

namespace LibDbOperations {

    internal class SqlConnector {

        private readonly string _cnnStr;
        private SqlConnection connection;
        private SqlCommand sqlCmd;
        private SqlDataAdapter sqlDa;

        public SqlConnector() {
            this._cnnStr = "Data Source=.;Initial Catalog=CryptologyMessageDb;Integrated Security=true;";
        }

        public SqlConnector(string connStr) {
            this._cnnStr = connStr;
        }

        public DataTable SelectTable(string cmdStr) {
            this.connection = new SqlConnection(this._cnnStr);
            this.sqlCmd = new SqlCommand(cmdStr, this.connection);
            this.sqlDa = new SqlDataAdapter(this.sqlCmd);
            var dt = new DataTable();
            try {
                this.sqlDa.Fill(dt);
            } catch {
            }
            return dt;
        }

        public int runCommand(string cmdStr) {
            int numberOfRows;
            this.connection = new SqlConnection(this._cnnStr);
            this.sqlCmd = new SqlCommand(cmdStr, this.connection);
            try {
                this.connection.Open();
                numberOfRows = this.sqlCmd.ExecuteNonQuery();
                this.connection.Close();
            } catch {
                numberOfRows = -1;
                this.connection.Close();
            }
            return numberOfRows;
        }

    }

}