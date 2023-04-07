using BaseStringStringBuilder.Models;
using System.Text;

namespace BaseStringStringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region String Methods
            //Student student = new Student();
            //student.GetInfo();



            //string name = null;
            //String.IsNullOrEmpty(name);
            //if (String.IsNullOrWhiteSpace(name))
            //{
            //    Console.WriteLine("Yanlish deyer");
            //}
            //else
            //{
            //    Console.WriteLine(name.Length);
            //}


            //string[] words = { "Salam", "Necesiz", "Gencler" };
            //name = name.Trim();
            //name.ToLower();
            //name.ToUpper();
            //name.Replace("050", "+994-50");
            //name.Substring(name.Length - 4)
            //name.IndexOf('G');
            //name.LastIndexOf('G');
            //name.Contains("bir");
            //name.StartsWith("s")
            //name.EndsWith("yev")
            //char[] letters=name.ToCharArray();    { 'S','a','b'}

            //String.Concat(name, " Guliyev");
            //string[] words = name.Split(' ');
            //String.Join(' ', words); 
            #endregion


            //mutable & immutable
            //string word = "Salam";
            //word += " necesen";
            //word += " gencler";


            //string letter = "a";
            ////Console.WriteLine(word);

            //for (int i = 0; i < 100; i++)
            //{
            //    letter += "a";
            //    Console.WriteLine(letter);
            //}

            //string name = Console.ReadLine();

            //name=Capitalize(name.Trim());
            //Console.WriteLine(name);




            string password = "sabiR";
            bool result = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsDigit(password[i]))
                {
                    result = true;
                    break;
                }
            }
            Console.WriteLine(result);

        }
        public static string Capitalize(string name)
        {

           
            StringBuilder capital= new StringBuilder();
            capital.Append(Char.ToUpper(name[0]));


            for (int i = 1; i < name.Length; i++)
            {
                capital.Append(Char.ToLower(name[i]));
               
            }
            return capital.ToString();


        }
        public static string CapitalizeString(string name)
        {

            string capital = "";
            capital += Char.ToUpper(name[0]);

            for (int i = 1; i < name.Length; i++)
            {
                capital += Char.ToLower(name[i]);
                Console.WriteLine(capital);
            }
            return capital;


        }
    }
}