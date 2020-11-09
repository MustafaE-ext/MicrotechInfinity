using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Core.ORM
{
    class MD_EntityLoader
    {
        static public Int64 TotalCount(SqlConnection conn, string sQuery)
        {
            SqlCommand cmd = new SqlCommand(sQuery, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows || !reader.Read()) return 0;

            object obj = reader.GetValue(0);
            Int64 count = 0;
            Int64.TryParse(obj.ToString(), out count);

            reader.Close();
            return count;
        }

        static public List<T> LoadEntitiesWithPagination<T>(string sQuery, string sPaginationQuery, out Int64 totalRows, bool bFollowProps = true)
        {
            try
            {
                string myCompanyConnString = MyConfig._config.GetConnectionString("Company");

                using (SqlConnection conn = new SqlConnection(myCompanyConnString))
                {
                    conn.Open();
                    totalRows = TotalCount(conn, sPaginationQuery);
                    return LoadEntities<T>(conn, sQuery, bFollowProps);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        static public List<T> LoadEntities<T>(SqlConnection conn, string sQuery, bool bFollowProps = true)
        {
            List<T> listT = null;

            try
            {
                SqlCommand cmd = new SqlCommand(sQuery, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    listT = new List<T>();

                    string sFieldName;

                    //int rows = 0;
                    while (reader.Read())
                    {
                        T ent = Activator.CreateInstance<T>();

                        //++rows;
                        for (int i = 0; i < reader.FieldCount; ++i)
                        {
                            sFieldName = reader.GetName(i);

                            string[] arrProps = sFieldName.Split('.'); //Handle: Parent.Id

                            if (arrProps.Count() > 1 && bFollowProps)
                            {
                                PropertyInfo prop0 = ent.GetType().GetProperty(arrProps[0], BindingFlags.Public | BindingFlags.Instance);

                                if (null != prop0 && prop0.CanWrite)
                                {
                                    Object obj0 = Activator.CreateInstance(prop0.PropertyType);
                                    prop0.SetValue(ent, obj0, null);

                                    PropertyInfo prop1 = prop0.PropertyType.GetProperty(arrProps[1], BindingFlags.Public | BindingFlags.Instance);

                                    if (null != prop1 && prop1.CanWrite)
                                    {
                                        object obj1 = reader.GetValue(i);

                                        if (obj1 != null && !Convert.IsDBNull(obj1))
                                            prop1.SetValue(obj0, obj1, null);
                                    }
                                }
                            }
                            else
                            {
                                sFieldName = sFieldName.Replace('.', '_');

                                PropertyInfo prop = ent.GetType().GetProperty(sFieldName, BindingFlags.Public | BindingFlags.Instance);

                                if (null != prop && prop.CanWrite)
                                {
                                    object obj = reader.GetValue(i);

                                    if (obj != null && !Convert.IsDBNull(obj))
                                        prop.SetValue(ent, obj, null);
                                }
                            }

                        }

                        listT.Add(ent);
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }


            return listT;
        }

        static public List<T> LoadEntities<T>(string sQuery, bool bFollowProps = true)
        {
            List<T> listT = null;

            try
            {
                string myCompanyConnString = MyConfig._config.GetConnectionString("Company");

                using (SqlConnection conn = new SqlConnection(myCompanyConnString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sQuery, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        listT = new List<T>();

                        string sFieldName;

                        //int rows = 0;
                        while (reader.Read())
                        {
                            T ent = Activator.CreateInstance<T>();

                            //++rows;
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                sFieldName = reader.GetName(i);

                                string[] arrProps = sFieldName.Split('.'); //Handle: Parent.Id

                                if (arrProps.Count() > 1 && bFollowProps)
                                {
                                    PropertyInfo prop0 = ent.GetType().GetProperty(arrProps[0], BindingFlags.Public | BindingFlags.Instance);

                                    if (null != prop0 && prop0.CanWrite)
                                    {
                                        Object obj0 = Activator.CreateInstance(prop0.PropertyType);
                                        prop0.SetValue(ent, obj0, null);

                                        PropertyInfo prop1 = prop0.PropertyType.GetProperty(arrProps[1], BindingFlags.Public | BindingFlags.Instance);

                                        if (null != prop1 && prop1.CanWrite)
                                        {
                                            object obj1 = reader.GetValue(i);

                                            if (obj1 != null && !Convert.IsDBNull(obj1))
                                                prop1.SetValue(obj0, obj1, null);
                                        }
                                    }
                                }
                                else
                                {
                                    sFieldName = sFieldName.Replace('.', '_');

                                    PropertyInfo prop = ent.GetType().GetProperty(sFieldName, BindingFlags.Public | BindingFlags.Instance);

                                    if (null != prop && prop.CanWrite)
                                    {
                                        object obj = reader.GetValue(i);

                                        if (obj != null && !Convert.IsDBNull(obj))
                                            prop.SetValue(ent, obj, null);
                                    }
                                }

                            }

                            listT.Add(ent);
                        }
                    }

                    reader.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }


            return listT;
        }
           
    }
}
