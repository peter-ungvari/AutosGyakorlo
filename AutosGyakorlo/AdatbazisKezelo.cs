using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosGyakorlo
{
    public delegate T Olvas<T>(SqlDataReader reader);
    public delegate void Parameterez<T>(SqlParameterCollection parameterek, T adatok);

    public class AdatbazisKezelo<T>
    {

        string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        Olvas<T> olvas;

        public Olvas<T> Olvas
        {
            get { return olvas; }
            set { olvas = value; }
        }

        readonly Dictionary<string, Parameterez<T>> modositok = new Dictionary<string, Parameterez<T>>();

        public Dictionary<string, Parameterez<T>> Modositok
        {
            get { return modositok; }
        }


        readonly Dictionary<string, Parameterez<T>> beszurok = new Dictionary<string, Parameterez<T>>();

        public Dictionary<string, Parameterez<T>> Beszurok
        {
            get { return beszurok; }
        }

        readonly Dictionary<string, Parameterez<T>> torlok = new Dictionary<string, Parameterez<T>>();

        public Dictionary<string, Parameterez<T>> Torlok
        {
            get { return torlok; }
        }

        string listazSql;

        public string ListazSql
        {
            get { return listazSql; }
            set { listazSql = value; }
        }
        
        private SqlConnection KapcsolatLetrehoz()
        {
            return new SqlConnection(connectionString);
        }

        public List<T> Listaz() 
        {
            using (var conn = KapcsolatLetrehoz())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(listazSql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<T> eredmeny = new List<T>();
                        while(reader.Read())
                        {
                            eredmeny.Add(olvas.Invoke(reader));
                        }
                        return eredmeny;
                    }
                    
                }
            }
        }

        public List<T> Keres(string sql, Dictionary<string,object> parameterek)
        {
            using (var conn = KapcsolatLetrehoz())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    foreach (var param in parameterek)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<T> eredmeny = new List<T>();
                        while (reader.Read())
                        {
                            eredmeny.Add(olvas.Invoke(reader));
                        }
                        return eredmeny;
                    }

                }
            }
        }

        public void Beszur(T adatok) {
            Modosit(adatok, beszurok);
        }

        public void Modosit(T adatok) {
            Modosit(adatok, modositok);
        }

        public void Torol(T adatok)
        {
            Modosit(adatok, torlok);
        }

        private void Modosit(T adatok, Dictionary<string,Parameterez<T>> modositok)
        {
            using(var conn = KapcsolatLetrehoz())
            {
                conn.Open();
                using (SqlTransaction tr = conn.BeginTransaction())
                {
                    foreach(var modosito in modositok) {
                        using (SqlCommand cmd = new SqlCommand(modosito.Key, conn, tr))
                        {
                            modosito.Value.Invoke(cmd.Parameters, adatok);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tr.Commit();
                }
            }
        }
    }
}
