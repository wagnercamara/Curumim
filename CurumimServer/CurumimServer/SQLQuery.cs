using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CurumimServer
{

    public class SQLQuery
    {

        private const int LOGIN_TYPE_RETURN_SUCCESS = 2;
        private const int LOGIN_TYPE_RETURN_ERROR = 3;

        private ConnectionDB sQLConnection = new ConnectionDB();


        SqlCommand sqlCommand = new SqlCommand();
        

        public dynamic LoginPlayer(string login, string password)
        {
            dynamic dynamic = null;
            Boolean successfullyConnected = false;

            try
            {
                sqlCommand.Connection = sQLConnection.OpenConnection();
                successfullyConnected = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }


            if (successfullyConnected == true)
            {
                //select getplayer()
                this.sqlCommand.CommandText = "GetPlayer";

                //não precisa
                this.sqlCommand.CommandType = CommandType.StoredProcedure;
                this.sqlCommand.Parameters.Clear();
                this.sqlCommand.Parameters.AddWithValue("@login", login);
                this.sqlCommand.Parameters.AddWithValue("@password", password);
                try
                {

                    SqlDataReader reader = this.sqlCommand.ExecuteReader();
                    Boolean CommandSucess = reader.Read();

                    if (CommandSucess == true)
                    {
                        dynamic = (new
                        {

                            Type = LOGIN_TYPE_RETURN_SUCCESS,

                            idPlayer = int.Parse(reader["idPlayer"].ToString()),

                            fullNamePlayer = reader["fullNamePlayer"].ToString(),
                            loginPlayer = reader["loginPlayer"].ToString(),
                            levelPlayer = reader["levelPlayer"].ToString(),
                            avatarPlayer = reader["avatarPlayer"].ToString(),

                            punctuationPlayer = Int32.Parse(reader["punctuationPlayer"].ToString()),
                            rankingPlayer = Int32.Parse(reader["rankingPlayer"].ToString()),
                            victoryPlayer = Int32.Parse(reader["victoryPlayer"].ToString()),
                            totalBatllesPlayer = Int32.Parse(reader["totalBatllesPlayer"].ToString()),
                            esmeraldPlayer = Int32.Parse(reader["esmeraldPlayer"].ToString()),

                        });
                    }
                    else
                    {
                        dynamic = (new { Type = LOGIN_TYPE_RETURN_ERROR });
                    }
                }
                catch
                {
                    dynamic = (new { Type = LOGIN_TYPE_RETURN_ERROR });
                }
            }
            else
            {
                dynamic = (new { Type = LOGIN_TYPE_RETURN_ERROR });
            }
            this.sQLConnection.ClouseConnection();
            return dynamic;
        }
        public Boolean SqlSetNewPlayer(string fullNamePlayer, string loginPlayer, string passwordPlayer, string secretPhresePlayer, string avatarPlayer)
        {
            Boolean successfullyConnected = false;
            Boolean newPlayerSucess = false;
            try
            {
                this.sqlCommand.Connection = sQLConnection.OpenConnection();

                successfullyConnected = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (successfullyConnected == true)
            {
                this.sqlCommand.CommandText = "SetNewPlayer";
                this.sqlCommand.CommandType = CommandType.StoredProcedure;
                this.sqlCommand.Parameters.Clear();
                this.sqlCommand.Parameters.AddWithValue("@fullNamePlayer", fullNamePlayer);
                this.sqlCommand.Parameters.AddWithValue("@loginPlayer", loginPlayer);
                this.sqlCommand.Parameters.AddWithValue("@passwordPlayer", passwordPlayer);
                this.sqlCommand.Parameters.AddWithValue("@secretPhresePlayer", secretPhresePlayer);
                this.sqlCommand.Parameters.AddWithValue("@avatarPlayer", avatarPlayer);
                this.sqlCommand.Parameters.AddWithValue("@levelPlayer", "Curumim");
                this.sqlCommand.Parameters.AddWithValue("@punctuationPlayer", 0);
                this.sqlCommand.Parameters.AddWithValue("@rankingPlayer", 0);
                this.sqlCommand.Parameters.AddWithValue("@victoryPlayer", 0);
                this.sqlCommand.Parameters.AddWithValue("@totalBatllesPlayer", 0);
                this.sqlCommand.Parameters.AddWithValue("@esmeraldPlayer", 0);

                try
                {
                    this.sqlCommand.ExecuteNonQuery();
                    newPlayerSucess = true;
                }
                catch
                {
                    newPlayerSucess = false;
                }
            }
            this.sQLConnection.ClouseConnection();
            return newPlayerSucess;
        }
        public Boolean SqlUpdatePassword(string fullNamePlayer, string loginPlayer, string passwordPlayer, string secretPhresePlayer)
        {
            Boolean successfullyConnected = false;
            Boolean updatePlayerSucess = false;
            try
            {
                this.sqlCommand.Connection = sQLConnection.OpenConnection();
                successfullyConnected = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (successfullyConnected == true)
            {
                this.sqlCommand.CommandText = "UpdatePasswordPlayer";
                this.sqlCommand.CommandType = CommandType.StoredProcedure;
                this.sqlCommand.Parameters.Clear();
                this.sqlCommand.Parameters.AddWithValue("@fullNamePlayer", fullNamePlayer);
                this.sqlCommand.Parameters.AddWithValue("@loginPlayer", loginPlayer);
                this.sqlCommand.Parameters.AddWithValue("@passwordPlayer", passwordPlayer);
                this.sqlCommand.Parameters.AddWithValue("@secretPhresePlayer", secretPhresePlayer);
                try
                {
                    this.sqlCommand.ExecuteNonQuery();
                    updatePlayerSucess = true;
                }
                catch
                {
                    updatePlayerSucess = false;
                }
            }
            this.sQLConnection.ClouseConnection();
            return updatePlayerSucess;

        }
    }
}
