using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DataServer
    {
        private static readonly Lazy<DataServer> instance = new Lazy<DataServer>(() => new DataServer());

        public static DataServer Instance => instance.Value;

        private DatabaseClass _database;

        private DataServer()
        {
            _database = new DatabaseClass();
        }

        public uint GetAcctNoByIndex(int index) => _database.GetAcctNoByIndex(index);

        public uint GetPINByIndex(int index) => _database.GetPINByIndex(index);

        public string GetFirstNameByIndex(int index) => _database.GetFirstNameByIndex(index);

        public string GetLastNameByIndex(int index) => _database.GetLastNameByIndex(index);

        public int GetBalanceByIndex(int index) => _database.GetBalanceByIndex(index);

        // public byte[] GetProfileImageByIndex(int index) => _database.GetProfileImageByIndex(index);

        public int GetNumEntries() => _database.GetNumEntries();

        public List<DataStruct> GetRecords() => _database.GetRecords();

        public DataStruct SearchRecords(string searchLastName) => _database.SearchRecords(searchLastName);
    }
}
