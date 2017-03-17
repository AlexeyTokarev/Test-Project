using System;
using System.Data.SqlClient;
using System.Data;

namespace MyTestProject002
{
    /// <summary>
    /// Объявление Базы данных
    /// </summary>
    public class DataBaseDeclaring // Объявление Базы данных
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TaskDataBase.mdf;Integrated Security=True;Connect Timeout=30";
        
        /// <summary>
        /// Объявляет нашу Базу данных
        /// </summary>
        public void DeclareDataBase(string _sql)
        {
            string sql = _sql;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                foreach (DataTable dt in ds.Tables) // перебор всех таблиц
                {

                    foreach (DataColumn column in dt.Columns)   // перебор всех столбцов
                        Console.Write("{0,-20}", column.ColumnName);
                    Console.WriteLine();


                    foreach (DataRow row in dt.Rows) // перебор всех строк таблицы
                    {
                        var cells = row.ItemArray;   // получаем все ячейки строки

                        foreach (object cell in cells)
                            Console.Write("{0,-20}", cell);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
