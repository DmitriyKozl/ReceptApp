using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdresBeheerProject.BL.Interfaces;
using AdresBeheerProject.BL.Models;
using AdresBeheerProject.DL.Exceptions;

namespace AdresBeheerProject.DL.Repositories {
    public class GemeenteRepository : IGemeenteRepo {

        private string _connectionstring;

        public GemeenteRepository(string connectionString) {
            _connectionstring = connectionString;
        }

        public Gemeente GeefGemeente(int niscode) {
            string sql = "select * from gemeente where niscode = @niscode";
            using(SqlConnection conn = new(_connectionstring)) {
                using(SqlCommand cmd = conn.CreateCommand()){
                    try {
                        conn.Open();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@niscode", niscode);
                        IDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        Gemeente g = new((int)dr["niscode"], (string)dr["gemeentenaam"]);
                        dr.Close();
                        return g;

                    } catch (Exception ex) {

                        throw new GemeenteRepoException("GeefGemeente");
                    }
                }
            }
        }
    }
}
