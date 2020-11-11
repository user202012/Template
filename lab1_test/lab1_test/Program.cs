using System;
using System.IO;

namespace lav
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile value = new ReadFile();
            ReadLine val = new ReadLine();
            val.MainFunction();
            value.MainFunction();
        }
    }
    abstract class Crypt
    {
        public void MainFunction()
        {
            string FileContent = GetContent();
            string Content = DoCrypt(FileContent);
            SaveContent(Content);
        }
        static string DoCrypt(string Filecontent)
        {
            static char Crypter(char character, ushort secretKey)
            {
                character = (char)(character ^ secretKey);
                return character;
            }
            string NewStr = "";
            foreach (var c in Filecontent)
                NewStr += Crypter(c, 0x0088);
            return NewStr;
        }
        public abstract string GetContent();
        public abstract void SaveContent(string Content);

    }

    class ReadFile : Crypt
    {
        public override string GetContent()
        {
            string FileContent;
            using (FileStream fstream = File.OpenRead(@"C:\Users\User\Desktop\RecoverMyPass\lab1_test\lab1_test\test.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                FileContent = System.Text.Encoding.Default.GetString(array);
            }
            return FileContent;
        }
        public override void SaveContent(string content)
        {
            Console.WriteLine(content);
        }
    }

    class ReadLine : Crypt
    {
        public override string GetContent()
        {
            string FileContent;
            FileContent = Console.ReadLine();
            return FileContent;
        }
        public override void SaveContent(string content)
        {
            Console.WriteLine(content);
        }
    }
}
