using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using WcfService1.Contracts;


namespace WcfService1.Data
{
    public class Data1 : IData1
    {
        private const string ConnectionStringName = "WcfService1ConnectionString";

        public IList<Blog> GetBlogs()
        {
            Mapper.Reset();
            Mapper.CreateMap<IDataReader, Blog>();
            Mapper.CreateMap<IDataReader, Author>();

            IList<Blog> result = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionStringName].ToString()))
            {
                var command = connection.CreateCommand();
                command.CommandText = "dbo.GetAllBlogs";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                result = Mapper.Map<IDataReader, IList<Blog>>(command.ExecuteReader());
            }
            return result;
        }
    }
}
