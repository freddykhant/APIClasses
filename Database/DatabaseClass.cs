using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseClass
    {
        private List<DataStruct> dataStruct;

        public DatabaseClass()
        {
            dataStruct = new List<DataStruct>();
            InitializeDatabase(1000); // You can change the number of entries as needed
        }

        private void InitializeDatabase(int numEntries)
        {
            DatabaseGenerator generator = new DatabaseGenerator();

            for (int i = 0; i < numEntries; i++)
            {
                DataStruct record = new DataStruct
                {
                    acctNo = generator.GetAcctNo(),
                    pin = generator.GetPIN(),
                    balance = generator.GetBalance(),
                    firstName = generator.GetFirstname(),
                    lastName = generator.GetLastname(),
                    //profileImage = generator.GetProfileImage()
                };

                dataStruct.Add(record);
            }
        }

        public uint GetAcctNoByIndex(int index)
        {
            if (index < 0 || index >= dataStruct.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            return dataStruct[index].acctNo;
        }

        public uint GetPINByIndex(int index)
        {
            if (index < 0 || index >= dataStruct.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            return dataStruct[index].pin;
        }

        public string GetFirstNameByIndex(int index)
        {
            if (index < 0 || index >= dataStruct.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            return dataStruct[index].firstName;
        }

        public string GetLastNameByIndex(int index)
        {
            if (index < 0 || index >= dataStruct.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            return dataStruct[index].lastName;
        }

        public int GetBalanceByIndex(int index)
        {
            if (index < 0 || index >= dataStruct.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            return dataStruct[index].balance;
        }

        //public byte[] GetProfileImageByIndex(int index)
        //{
        //    if (index < 0 || index >= dataStruct.Count)
        //    {
        //        throw new IndexOutOfRangeException("Index is out of range");
        //    }

        //    return dataStruct[index].profileImage;
        //}

        public int GetNumEntries()
        {
            return dataStruct.Count;
        }

        public List<DataStruct> GetRecords()
        {
            return dataStruct;
        }

        public DataStruct SearchRecords(string searchLastName)
        {
            // Guard against null or empty searchLastName
            if (string.IsNullOrEmpty(searchLastName))
            {
                return null;
            }

            var records = GetRecords();

            foreach (var record in records)
            {
                // Check if record.lastName is not null or empty and then see if it contains the search string.
                if (!string.IsNullOrEmpty(record.lastName) && record.lastName.ToLower().Contains(searchLastName.ToLower()))
                {
                    return record;
                }
            }

            return null;
        }
    }
}
