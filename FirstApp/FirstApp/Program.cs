using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Linq;

namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. View Income");
                Console.WriteLine("4. View Balance");
                Console.WriteLine("Enter Your choice: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            SqlConnection con = new SqlConnection("Server=IN-4W3K9S3; database=ExpenseTracker; User Id=sa; password=Nani falls down@22!@nc");
                            con.Open();
                            SqlCommand cmd = new SqlCommand($"insert into Expense values(@title, @desc, @date, @amount)", con);
                            Console.Write("Enter Title ");
                            string title = Console.ReadLine();
                            Console.Write("Enter Description ");
                            string description = Console.ReadLine();
                            Console.Write("Enter Amount: ");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter Date(DD/MM/YYYY): ");
                            string date = Console.ReadLine();
                            cmd.Parameters.AddWithValue("@title", title);
                            cmd.Parameters.AddWithValue("@desc", description);
                            cmd.Parameters.AddWithValue("@date", date);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Transaction added successfully");
                            con.Close();
                            break;                            
                        }
                    case 2:
                        {
                            SqlConnection con1 = new SqlConnection("Server=IN-4W3K9S3; database=ExpenseTracker; User Id=sa; password=Nani falls down@22!@nc");
                            con1.Open();
                            SqlCommand cmd1 = new SqlCommand("select * from Expense where Amount < 0", con1);
                            SqlDataReader rd = cmd1.ExecuteReader();
                            while (rd.Read())
                            {
                                Console.WriteLine($" {rd[0]} | {rd[1]} | {rd[2]} | {rd[3]} " );
                            }
                            con1.Close();
                            break;
                        }
                    case 3:
                        {
                            SqlConnection con2 = new SqlConnection("Server=IN-4W3K9S3; database=ExpenseTracker; User Id=sa; password=Nani falls down@22!@nc");
                            con2.Open();
                            SqlCommand cmd2 = new SqlCommand("select * from Expense where Amount > 0", con2);
                            SqlDataReader rd = cmd2.ExecuteReader();
                            while (rd.Read())
                            {
                                Console.WriteLine($" {rd[0]} | {rd[1]} | {rd[2]} | {rd[3]} ");
                            }
                            con2.Close();
                            break;
                        }
                    case 4:
                        {
                            SqlConnection con3 = new SqlConnection("Server=IN-4W3K9S3; database=ExpenseTracker; User Id=sa; password=Nani falls down@22!@nc");
                            con3.Open();
                            SqlCommand cmd3 = new SqlCommand("select sum(Amount) from Expense ", con3);
                            SqlDataReader rd = cmd3.ExecuteReader();
                            while (rd.Read())
                            {
                                Console.WriteLine($"Your Balance Amount is: {rd[0]}");
                            }
                            con3.Close();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice Entered");
                            break;
                        }
                }
            }
            
        }
    }
}