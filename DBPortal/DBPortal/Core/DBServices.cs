using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DBPortal.Core
{
    public static class DBServices
    {
        private static String strConn = ConfigurationManager.AppSettings.Get("ConnectionString");

        /// <summary>
        /// Get Data from SQL Table to DataView
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public static DataView GetTblView(string sqlStr)
        {

            SqlConnection MyConnection = default(SqlConnection);
            DataSet DS = null;
            SqlDataAdapter MyCommand = default(SqlDataAdapter);
            DataView Source = new System.Data.DataView();

            MyConnection = new SqlConnection(strConn);

            try
            {

                MyCommand = new SqlDataAdapter(sqlStr, MyConnection);

                DS = new DataSet();
                MyCommand.Fill(DS);
                Source = DS.Tables[0].DefaultView;

            }
            catch (Exception e)
            {

            }
            finally
            {
                MyConnection.Close();
            }

            return Source;

        }

        /// <summary>
        /// Update SQL Query in DB
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public static object UpdateSQL(string strQuery, out string strMsg)
        {
            Int32 i = 0;
            SqlConnection oConn = new SqlConnection(strConn);
            strMsg = "";

            try
            {
                oConn.Open();
                SqlCommand cmd = new SqlCommand(strQuery, oConn);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                //Console.WriteLine(strQuery);
                i = -1;
                strMsg = er.ToString() + ";" + strQuery;
            }
            finally
            {
                oConn.Close();
            }

            return i.ToString();
        }

        /// <summary>
        /// Insert SQL Query in DB
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="strMsg"></param>
        /// <param name="lastInsertID"></param>
        /// <returns></returns>
        public static object InsertSQL(string strQuery, out string strMsg, out int lastInsertID)
        {

            lastInsertID = 0;
            Int32 i = 0;
            SqlConnection oConn = new SqlConnection(strConn);
            strMsg = "";

            try
            {
                oConn.Open();
                SqlCommand cmd = new SqlCommand(strQuery, oConn);
                lastInsertID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception er)
            {
                //Console.WriteLine(strQuery);
                i = -1;
                lastInsertID = -1;
                strMsg = er.ToString() + ";" + strQuery;
            }
            finally
            {
                oConn.Close();
            }


            return i.ToString();

        }


        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }


        public static List<T> ToList<T>(this DataView oView) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();

            //foreach (DataRow row in oView)
            // {

            for (int i = 0; i < oView.Count; i++)
            {
                var item = CreateItemFromRow<T>(oView[i].Row, properties);
                result.Add(item);
            }

            return result;
        }


        public static T ToObject<T>(this DataView oView) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();


            DataRow dr = oView[0].Row;
            var item = CreateItemFromRow<T>(dr, properties);
            return item;

        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                Console.WriteLine(property);
                try
                {
                    if (!property.Name.ToLower().Equals("statuslistitem"))
                    {
                        if (property.PropertyType == typeof(System.DayOfWeek))
                        {
                            DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                            property.SetValue(item, day, null);
                        }
                        else
                        {
                            property.SetValue(item, row[property.Name], null);

                        }
                    }
                }
                catch (Exception) { }
            }
            return item;
        }


    }
}