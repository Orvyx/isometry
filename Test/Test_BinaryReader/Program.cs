using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Test_BinaryReader
{
    class Program
    {
        const string fileName = "TestFile.wrd";
        static void Main(string[] args)
        {
            WriteDefaultValues();
            DisplayValues();
            return;
        }
        public static void WriteDefaultValues()
        {
            string tempFile = fileName + ".dat";
            using (BinaryWriter writer = new BinaryWriter(File.Open(tempFile, FileMode.Create)))
            {
                writer.Write(1.25F);
                writer.Write("f");
                writer.Write(10);
                writer.Write(true);
            }
            EncryptFile(tempFile, fileName);
            File.Delete(tempFile);
        }
        public static void DisplayValues()
        {
            float aspectRatio;
            string tempDirectory;
            int autoSaveTime;
            bool showStatusBar;
            if (File.Exists(fileName))
            {
                string tempFile = fileName + ".dat";
                DecryptFile(fileName, tempFile);
                using (BinaryReader reader = new BinaryReader(File.Open(tempFile, FileMode.Open)))
                {
                    aspectRatio = reader.ReadSingle();
                    tempDirectory = reader.ReadString();
                    autoSaveTime = reader.ReadInt32();
                    showStatusBar = reader.ReadBoolean();
                }
                Debug.WriteLine("Ratio: " + aspectRatio);
                Debug.WriteLine("Directory: " + tempDirectory);
                Debug.WriteLine("SaveTime: " + autoSaveTime);
                Debug.WriteLine("StatusBar: " + showStatusBar);
                File.Delete(tempFile);
            }
        }
        private static bool DecryptFile(string inputFile, string outputFile)
        {
            string s = "h3y_gUyZ";
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            byte[] bytes = unicodeEncoding.GetBytes(s);
            FileStream fileStream = new FileStream(inputFile, FileMode.Open);
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            FileStream fileStream2 = new FileStream(outputFile, FileMode.Create);
            try
            {
                int num;
                while ((num = cryptoStream.ReadByte()) != -1)
                {
                    fileStream2.WriteByte((byte)num);
                }
                fileStream2.Close();
                cryptoStream.Close();
                fileStream.Close();
            }
            catch
            {
                fileStream2.Close();
                fileStream.Close();
                File.Delete(outputFile);
                return true;
            }
            return false;
        }
        private static void EncryptFile(string inputFile, string outputFile)
        {
            string s = "h3y_gUyZ";
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            byte[] bytes = unicodeEncoding.GetBytes(s);
            FileStream fileStream = new FileStream(outputFile, FileMode.Create);
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            FileStream fileStream2 = new FileStream(inputFile, FileMode.Open);
            int num;
            while ((num = fileStream2.ReadByte()) != -1)
            {
                cryptoStream.WriteByte((byte)num);
            }
            fileStream2.Close();
            cryptoStream.Close();
            fileStream.Close();
        }
    }
}
