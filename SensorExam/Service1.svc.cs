using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SensorExam
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly string connectionString =
            @"Server=tcp:madsdankdb.database.windows.net,1433;Initial Catalog=Sensor;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<SensorModel> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public bool AddStudent(SensorModel room)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                const string sql = "INSERT INTO SensorTable(Room, Temp, Smoke) VALUES(@room,@temp,@smoke)";
                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@room", room.Room);
                cmd.Parameters.AddWithValue("@temp", temp.Temp );
                cmd.Parameters.AddWithValue("@smoke", smoke.Smoke );
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public List<SensorModel> GetRoom(int room)
        {
            using (var connection = new SqlConnection(connectionString))

            {
                var toBereturnedList = new List<SensorModel>();

                connection.Open();
                const string sql = "SELECT * FROM SensorTable WHERE Room = @room";
                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@room", room);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var s = new SensorModel();
                    s.Room = Convert.ToInt32(reader["room"].ToString());
                    s.Temp = Convert.ToInt32(reader.GetString(2));
                    s.Smoke = Convert.ToInt32(reader.GetString(3));
                    toBereturnedList.Add(s);
                }
                return toBereturnedList;
            }
        }

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
        public List<SensorModel> GetRoom()
        {
            throw new NotImplementedException();
        }

        public List<SensorModel> GetTemp()
        {
            throw new NotImplementedException();
        }
    }
}
