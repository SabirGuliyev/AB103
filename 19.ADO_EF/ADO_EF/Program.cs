using ADO_EF.Models;
using System.Data;
using System.Data.SqlClient;

namespace ADO_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region ADO.NET
            //Student student=new Student
            //{
            //    Name="Cavidan",
            //    Point=99
            //};

            //int result;
            //using (SqlConnection connection = new SqlConnection("Server=MSI;Database=AB103Joins;Trusted_connection=true;Integrated security=true;"))
            //{
            //    connection.Open();
            //    string cmd = $"INSERT INTO Students VALUES('{student.Name}',{student.Point},2)";
            //    //string cmd = "DELETE FROM Students WHERE Id=13";
            //    SqlCommand command = new SqlCommand(cmd, connection);
            //    result = command.ExecuteNonQuery();
            //}






            //    if (result>0)
            //{
            //    Console.WriteLine("Student successfully DELETED");
            //}
            //else
            //{
            //    Console.WriteLine("Error occured");
            //}


            //string query = "SELECT * FROM Students";
            //DataTable table=new DataTable();
            //using (SqlConnection connection = new SqlConnection("Server=MSI;Database=AB103Joins;Trusted_connection=true;Integrated security=true;"))
            //{
            //    //SqlCommand cmd = new SqlCommand(query,connection);
            //    //cmd.ExecuteScalar();

            //    connection.Open();

            //    SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
            //    adapter.Fill(table);
            //}  


            //List<Student> students = new List<Student>();


            //foreach (DataRow item in table.Rows)
            //{
            //    //Console.WriteLine(+" "++" " + item["point"]);

            //    Student student2 = new Student
            //    {
            //        Id=Convert.ToInt32(item["id"]),
            //        Name=item["name"].ToString(),
            //        Point=Convert.ToInt32(item["point"])
            //    };
            //    students.Add(student2);

            //}



            //foreach (var item in students)
            //{
            //    Console.WriteLine(item.Name+" "+item.Point);
            //} 
            #endregion







        }
    }
}