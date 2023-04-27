using FileDirectoryJson.Models;
using Newtonsoft.Json;

namespace FileDirectoryJson
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            #region File,Directory
            //Directory.CreateDirectory(@"C:\Users\sabir\Desktop\AB103test");



            //File.Create(@"C:\Users\sabir\Desktop\AB103test\text.txt");

            //File.Delete(@"C:\Users\sabir\Desktop\AB103test\text.txt");


            //Directory.Delete(@"C:\Users\sabir\Desktop\AB103test",true);



            //FileInfo fileInfo = new FileInfo(@"C:\Users\sabir\Desktop\AB103test\text2.txt");

            ////fileInfo.Create();
            //fileInfo.Delete(); 
            #endregion


            #region Stream
            //Directory.CreateDirectory(@"C:\Users\sabir\Desktop\AB103test");
            //File.Create(@"C:\Users\sabir\Desktop\AB103test\text.txt");



            //StreamWriter sw = new StreamWriter(@"C:\Users\sabir\Desktop\AB103test\text.txt", true);
            //sw.Write("Arif");
            //sw.WriteLine("Sakina");
            //sw.WriteLine("Nahid");
            //sw.Close();

            //StreamReader sr = new StreamReader(@"C:\Users\sabir\Desktop\AB103test\text.txt");

            //string result=sr.ReadToEnd();

            //sr.Close();

            //Console.WriteLine(result);



            //StreamWriter sw = new StreamWriter(@"C:\Users\sabir\Desktop\AB103test\text.txt", true);
            //sw.Write("Arif");
            //sw.WriteLine("Sakina");
            //sw.WriteLine("Nahid");
            //sw.Close();

            //string result;

            //using (StreamWriter sw = new StreamWriter(@"C:\Users\sabir\Desktop\AB103test\text2.txt", true))
            //{
            //    sw.WriteLine("Salam men usingle yazilmisham");
            //}

            //using (StreamReader sr=new StreamReader(@"C:\Users\sabir\Desktop\AB103test\text.txt", true))
            //{
            //    result = sr.ReadToEnd();
            //}


            //Console.WriteLine(result); 
            #endregion


            //Group group = new Group("AB103");

            //List<Student> students = new List<Student>();
            //students.Add(new Student("Arif", "Abdulla", group));
            //students.Add(new Student("Saleh", "Nebiyev", group));
            //students.Add(new Student("Nermin", "Memmedova", group));



            //string json = JsonConvert.SerializeObject(students);


            //Console.WriteLine(json);


            //using (StreamWriter sw = new StreamWriter(@"C:\Users\sabir\OneDrive\Рабочий стол\FileDirectoryJson\FileDirectoryJson\Files\Students.json"))
            //{
            //    sw.WriteLine(json);
            //    }







                string result;

            using(StreamReader sr=new StreamReader(@"C:\Users\sabir\OneDrive\Рабочий стол\FileDirectoryJson\FileDirectoryJson\Files\Students.json"))
            {
                result = sr.ReadToEnd();
            }


           List<Student> students= JsonConvert.DeserializeObject<List<Student>>(result);


            foreach (var item in students)
            {
                Console.WriteLine(item.Name+" "+item.Surname);
            }


        }

    }
}