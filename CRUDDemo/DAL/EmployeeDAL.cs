using CRUDDemo.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
namespace CRUDDemo.DAL
{
    public class EmployeeDAL
    {
        public int Insert(Employee employee) 
        {
            int res = 0;

            string con = "Server=localhost;userid=root;password=root;database=sakila";

            using (MySqlConnection conCon = new MySqlConnection(con))
            {
                try
                {
                    conCon.Open();
                    string Query = "Insert into Emp values(@id,@name,@sal,@gender,@add)";
                    MySqlCommand cmd =  new MySqlCommand(Query,conCon);

                    cmd.Parameters.AddWithValue("@id",employee.Id);
                    cmd.Parameters.AddWithValue("@name", employee.Name);
                    cmd.Parameters.AddWithValue("@sal", employee.Salary);
                    //cmd.Parameters.AddWithValue("@gender", employee.Gender);
                    //cmd.Parameters.AddWithValue("@add", employee.Address);

                  
                    cmd.Parameters.AddWithValue("@gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@add", employee.Address);

                    res = cmd.ExecuteNonQuery();




                }
                catch (Exception e)
                {
                }

              

            }


                return res;
        }
        public List<Employee> GetEmpList()
        {
            List<Employee> list = new List<Employee>();
            string con = "Server=localhost;userid=root;password=root;database=sakila";
            using (MySqlConnection conConn = new MySqlConnection(con))
            {
                try
                {
                    conConn.Open();
                    string Query = "Select * from Emp";
                    MySqlCommand cmd = new MySqlCommand(Query, conConn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee emp = new Employee()
                        {
                            Id = Convert.ToInt32(reader[0]),
                            Name = Convert.ToString(reader[1]),
                            Salary = (float)Convert.ToDecimal(reader[2]),
                          
                            Gender = Convert.ToString(reader[3]),
                            Address = Convert.ToString(reader[4])
                        };
                        list.Add(emp);

                    }
                }
                catch (Exception ex)
                {

                }

            }
            return list;
        }
        public int DeleteEmp(int id)
        {
            int res = 0;

            string con = "Server=localhost;userid=root;password=root;database=sakila";
            using(MySqlConnection conCon = new MySqlConnection(con))
            {
                try
                {
                    conCon.Open();
                    string Query = "delete from Emp where Id=@id";

                    MySqlCommand cmd = new MySqlCommand(Query, conCon);
                    cmd.Parameters.AddWithValue("@id", id);
                    res = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
               
            }
            return res;

        }
        public int UpdateEmp(Employee employee)
        {
            int res = 0;
            string con = "Server=localhost;userid=root;password=root;database=sakila";
            using (MySqlConnection conCon = new MySqlConnection(con))
            {
                try
                {
                    conCon.Open();
                    //  String Query = "Update Emp set name=@name," + "salary=@salary," + "gender=@gender" + "address=@address where id=@id";
                    String Query = "UPDATE Emp SET name=@name, salary=@salary, gender=@gender, address=@address WHERE id=@id";
                    ;
                    MySqlCommand cmd = new MySqlCommand( Query, conCon);
                    cmd.Parameters.AddWithValue("@id", employee.Id);
                    cmd.Parameters.AddWithValue("@name", employee.Name);
                    cmd.Parameters.AddWithValue("@salary", employee.Salary);
                    //cmd.Parameters.AddWithValue("@gender", employee.Gender);
                    //cmd.Parameters.AddWithValue("@add", employee.Address);


                    cmd.Parameters.AddWithValue("@gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@address", employee.Address);

                    res = cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                }

            }
            return res;
        }
        public Employee GetEmp(int id)
        {
            Employee emp= null;
            string con = "Server=localhost;userid=root;password=root;database=sakila";

            using(MySqlConnection  conCon = new MySqlConnection(con))
            {
                try
                {


                    conCon.Open();
                    string Query = "select* from emp where id=@Id";

                    MySqlCommand cmd = new MySqlCommand(Query, conCon);

                    cmd.Parameters.AddWithValue("@Id", id);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        emp = new Employee()
                        {
                            Id = Convert.ToInt32(reader[0]),
                            Name = Convert.ToString(reader[1]),
                            Salary = (float)Convert.ToDecimal(reader[2]),

                            Gender = Convert.ToString(reader[3]),
                            Address = Convert.ToString(reader[4])
                        };


                    }
                }
                catch(Exception ex)
                {

                }



            }


            return emp;
        }

    }
}
