using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace PublicTransportTracker.DataAccess
{
    public class BaseDB
    {
        private static string connString = "Host=aazn6r3k4ls0g8.c06buin8tady.sa-east-1.rds.amazonaws.com;Username=marzanog;Password=marzanog;Database=postgres";

        public static void executeQuery(string query)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void executeInsert(string tableName, List<List<object>> values)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    foreach(List<object> value in values)
                    {
                        StringBuilder query = new StringBuilder();
                        query.Append(String.Format("INSERT INTO {0} VALUES (", tableName));
                        foreach (object o in value)
                        {
                            if (o is int || o is decimal || o is double || o is long || isFunc(o) )
                            {
                                query.Append(String.Format("{0},", o.ToString()));

                            }
                            else
                            {
                                query.Append(String.Format("'{0}',", o.ToString()));
                            }

                        }
                        query.Remove(query.Length - 1, 1);
                        query.Append(")");
                        cmd.CommandText = query.ToString();
                        //Debug.WriteLine(cmd.CommandText);
                        cmd.ExecuteNonQuery();
                    }

                }
            }
        }


        public static List<object[]> executeSelect(string query)
        {
            List<object[]> returnList = new List<object[]>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        object[] line = new object[reader.FieldCount];
                        reader.GetValues(line);
                        returnList.Add(line);
                    }

            }
            return returnList;
        }


        private static bool isFunc(object s)
        {
            if(s is string)
            {
                Regex rgx = new Regex("^ST_GeomFromText");
                Regex rgx2 = new Regex("^nextval");
                if (rgx.IsMatch((string)s) || rgx2.IsMatch((string)s))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }


        public static void deleteAllData()
        {
            //executeQuery("delete from stop");
            //executeQuery("delete from route");
            //executeQuery("delete from calendar");
            //executeQuery("delete from city");           
            executeQuery("delete from stoptime");
            //executeQuery("delete from trip");
        }



    }
}