using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    internal class DatabaseGenerator
    {
        private static readonly Random random = new Random();

        private const string path = "C:\\Users\\fredd\\Downloads\\ImageLibrary";

        private static string[] firstNames = { "John", "Jane", "Michael", "Emily", "David", "Sarah" };
        private static string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis" };

        private string[] imagePaths = Directory.GetFiles(path, "*.jpg");

        internal string GetFirstname()
        {
            int index = random.Next(firstNames.Length);
            return firstNames[index];
        }

        internal string GetLastname()
        {
            int index = random.Next(lastNames.Length);
            return lastNames[index];
        }

        internal uint GetPIN()
        {
            return (uint)random.Next(1000, 10000);
        }

        internal uint GetAcctNo()
        {
            return (uint)random.Next(100000, 1000000);
        }

        internal int GetBalance()
        {
            return random.Next(-1000, 10000);
        }

        //internal byte[] GetProfileImage()
        //{
        //    string randomImagePath = imagePaths[random.Next(imagePaths.Length)];
        //    byte[] profileImage = GetImageBytes(randomImagePath);
        //    return profileImage;
        //}

        //private byte[] GetImageBytes(string path)
        //{
        //    using (Bitmap image = new Bitmap(path))
        //    {
        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //            return stream.ToArray();
        //        }
        //    }
        //}

        public void GetNextAccount(out uint pin, out uint acctNo, out string firstName, out string lastName, out int balance)
        {
            pin = GetPIN();
            acctNo = GetAcctNo();
            firstName = GetFirstname();
            lastName = GetLastname();
            balance = GetBalance();
        }
    }
}
