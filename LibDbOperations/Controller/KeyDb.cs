using System;
using System.Collections.Generic;
using System.Data;

using LibDbOperations.Model;

namespace LibDbOperations.Controller {

    public class KeyDb : IKeyDb {

        public List<Key> GetKeys() {
            var table = GetKeysTable();
            var rowsCount = table.Rows.Count;
            if (rowsCount == 0) {
                return new List<Key>();
            }
            List<Key> keys = new List<Key>(rowsCount);
            for (int i = 0; i < rowsCount; i++) {
                var currentRow = table.Rows[i];
                keys.Add(new Key {
                    KeyId = Convert.ToInt32(currentRow[0].ToString()),
                    KeyString = currentRow[1].ToString()
                });
            }
            return keys;
        }

        private DataTable GetKeysTable() {
            string command = "SELECT keyId, keyString FROM tblKey";
            SqlConnector con = new SqlConnector();
            var table = con.SelectTable(command);
            return table;
        }

    }

}