using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tw_app
{
    public class DB
    {
        OracleConnection connection;
        string username;
        public DB(string user, OracleConnection cnx)
        {
            username = user;
            connection = cnx;
        }
        public bool Check_user_DBA_privilege()
        {
            var reader = execute(@"SELECT Count(*) FROM USER_ROLE_PRIVS where granted_role = 'DBA'");
            reader.Read();
            int count = reader.GetInt32(0);
            return count > 0;
        }
        OracleDataReader execute(string sql)
        {
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteReader();
        }
        public List<string> Get_all_db_roles()
        {
            List<string> validRoles = new List<string>();
            var rd = execute(@"SELECT role FROM DBA_ROLES order by 1");
            while (rd.Read())
            {
                validRoles.Add(rd.GetString(0));
                //Debug.WriteLine(rd.GetString(0));
            }
            return validRoles;
        }        

        public List<Tuple<string, string>> GetUsersList()
        {
            List<Tuple<string, string>> users = new List<Tuple<string, string>>();
            var rd = execute("select upper(utilis), nom_utilis from utilisateur_app");
            while (rd.Read())
            {
                users.Add(new Tuple<string, string>(rd.GetString(0), rd.GetString(1)));
                //Debug.WriteLine(rd.GetString(0));
            }
            return users;
        }

        public List<string> GetUserRoles(string user)
        {
            List<string> perms = new List<string>();
            var rd = execute($@"SELECT distinct upper(ROLE_UTILIS) FROM ROLE_UTILISATEUR
                                 WHERE(NOM_UTILIS='{user}')");
            while (rd.Read())
            {
                perms.Add(rd.GetString(0));
                //Debug.WriteLine(rd.GetString(0));
            }
            return perms;
        }

        internal void addRoleToUser(string user, string role)
        {
            execute($@"INSERT INTO ROLE_UTILISATEUR VALUES('{user}', '{role}')");
            execute($@"GRANT {role} TO {user}");
            Debug.WriteLine($"Added {role} to {user}");
        }

        internal void removeRoleFromUser(string user, string role)
        {
            execute($@"DELETE FROM ROLE_UTILISATEUR WHERE NOM_UTILIS = '{user}' and ROLE_UTILIS = '{role}'");
            execute($@"revoke {role} from {user}");
            Debug.WriteLine($"Removed {role} from {user}");
        }
    }
}
