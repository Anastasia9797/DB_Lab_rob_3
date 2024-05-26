using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Diagnostics.Metrics;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Getting Conection...");
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                Console.WriteLine("Openning Connection...");
                conn.Open();
                Console.WriteLine("Connection successful!");
                do
                {
                    Console.WriteLine("--------------------------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Оберіть номер для виведення даних з конкретної таблиці:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1. Вивести всю інформацію про партії;");
                    Console.WriteLine("2. Вивести всю інформацію про продукти;");
                    Console.WriteLine("3. Вивести всю інформацію про цехи;");
                    Console.WriteLine("4. Вихід.");
                    Console.WriteLine("--------------------------");
                    string choice = Console.ReadLine();
                    Console.WriteLine("--------------------------");
                    if (choice == "1")
                    {
                        QueryBatch(conn);
                    }
                    else if (choice == "2")
                    {
                        QueryProduct(conn);
                    }
                    else if (choice == "3")
                    {
                        QueryWorkshop(conn);
                    }
                    else if (choice == "4")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вихід з циклу успішно завершено!");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Сталася помилка! Номер введено неправильно!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            Console.Read();
        }
        private static void QueryBatch(MySqlConnection conn)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string batch_id, name, workshop_id, quality_indicator, batch_volume, registration_date;
            string sql = "Select * from batch";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Console.WriteLine("Таблиця з інформацією про партії, що були виготовлені на підприємстві:");
                    while (reader.Read())
                    {
                        batch_id = reader["batch_id"].ToString();
                        name = reader["product_name"].ToString();
                        workshop_id = reader["workshop_id"].ToString();
                        quality_indicator = reader["quality_indicator"].ToString();
                        batch_volume = reader["batch_volume"].ToString();
                        registration_date = reader["registration_date"].ToString();
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("ID: " + batch_id + "; Назва: " + name + "; Номер цеха: " + workshop_id +
                             "; Показник якості: " + quality_indicator + "; Обсяг партії: " + batch_volume + 
                             "; Дата реєстації партії: " + registration_date);
                    }
                }
            }
        }
        private static void QueryProduct(MySqlConnection conn)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string product_id, name, premium, first_grade, second_grade, minimum_batch, shelf_life;
            string sql = "Select * from product";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Console.WriteLine("Таблиця з інформацією про продукцію, яка виготовляється на підприємстві:");
                    while (reader.Read())
                    {
                        product_id = reader["product_id"].ToString();
                        name = reader["product_name"].ToString();
                        premium = reader["premium"].ToString();
                        first_grade = reader["first_grade"].ToString();
                        second_grade = reader["second_grade"].ToString();
                        minimum_batch = reader["minimum_batch"].ToString();
                        shelf_life = reader["shelf_life"].ToString();
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("ID: " + product_id + "; Назва: " + name + "; Преміум якість: " + premium +
                             "; Якість першого ґатунку: " + first_grade + "; Якість другого ґатунку: " + second_grade +
                             "; Мінімальна партія: " + minimum_batch + "; Дата зберігання (в роках): " + shelf_life);
                    }
                }
            }
        }
        private static void QueryWorkshop(MySqlConnection conn)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string workshop_id, workshop_name, manager, managers_number;
            string sql = "Select * from workshop";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Console.WriteLine("Таблиця з інформацією цехи, які є на підприємстві:");
                    while (reader.Read())
                    {
                        workshop_id = reader["workshop_id"].ToString();
                        workshop_name = reader["workshop_name"].ToString();
                        manager = reader["managers_surname"].ToString();
                        managers_number = reader["managers_number"].ToString();
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("ID: " + workshop_id + "; Назва: " + workshop_name
                        + "; Прізвище менеджера: " + manager + "; Номер телефону менеджера: " + managers_number);
                    }
                }
            }
        }
    }
}
