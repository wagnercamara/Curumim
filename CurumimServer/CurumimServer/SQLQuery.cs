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
        //
        private const int MESSAGE_TYPE_READ_NEW_MESSAGE = 13;
        private const int MESSAGE_TYPE_READ_ERRO = 14;
        private const int MESSAGE_TYPE_GET_PLAYER_MESSAGE = 19;
        //
        private const int MESSAGE_TYPE_GET_CONTACTS_SUCCESS = 21;
        private const int MESSAGE_TYPE_GET_CONTACTS_ERRO = 22;

        private ConnectionDB sQLConnection = new ConnectionDB();


        SqlCommand sqlCommand = new SqlCommand();


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
                this.sqlCommand.Parameters.AddWithValue("@esmeraldPlayer", 20);
                this.sqlCommand.Parameters.AddWithValue("@offOnPlayer", 0);

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
        public Boolean SqlUpdatePassword(string loginPlayer, string passwordPlayer, string secretPhresePlayer)
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
        public Boolean SqlInsertMenssage(int sender_id_tbPlayer, int receiver_id_tbPlayer, string messageMessage, DateTime dateTimeMessage)
        {
            Boolean successfullyConnected = false;
            Boolean newMessageSucess = false;
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
                this.sqlCommand.CommandText = "SetMessage";
                this.sqlCommand.CommandType = CommandType.StoredProcedure;
                this.sqlCommand.Parameters.Clear();

                this.sqlCommand.Parameters.AddWithValue("@sender_id_tbPlayer", sender_id_tbPlayer);
                this.sqlCommand.Parameters.AddWithValue("@receiver_id_tbPlayer", receiver_id_tbPlayer);
                this.sqlCommand.Parameters.AddWithValue("@messageMessage", messageMessage);
                this.sqlCommand.Parameters.AddWithValue("@dateTimeMessage", dateTimeMessage);

                try
                {
                    this.sqlCommand.ExecuteNonQuery();
                    newMessageSucess = true;
                }
                catch
                {
                    newMessageSucess = false;
                }
            }
            this.sQLConnection.ClouseConnection();
            return newMessageSucess;
        }
        public Boolean SqlSetOffOnLine(int idPlayer, int OffOn)
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
                this.sqlCommand.CommandText = "UpdateOffOnLinePlayer";
                this.sqlCommand.CommandType = CommandType.StoredProcedure;
                this.sqlCommand.Parameters.Clear();
                this.sqlCommand.Parameters.AddWithValue("@idPlayer", idPlayer);
                this.sqlCommand.Parameters.AddWithValue("@OffOn", OffOn);

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
        public dynamic LoginGetPlayer(string login, string password)
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
                this.sqlCommand.CommandText = @"SELECT * FROM[dbo].[GetPlayer](@login, @password)";
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
        public List<dynamic> SqlGetContacts(int idSender)
        {
            List<dynamic> dynamics = new List<dynamic>();
            List<string> login = new List<string>();
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
                this.sqlCommand.CommandText = @"SELECT * FROM[dbo].[GetMessagePlayerContacts](@idPlayer)";
                this.sqlCommand.Parameters.Clear();
                this.sqlCommand.Parameters.AddWithValue("@idPlayer", idSender);

                try
                {

                    SqlDataReader reader = this.sqlCommand.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Int32 sender = int.Parse(reader["sender"].ToString());
                        string loginSender = reader["loginSender"].ToString();
                        Int32 statusSender = Int32.Parse(reader["statusSender"].ToString());

                        Int32 receiver = int.Parse(reader["receiver"].ToString());
                        string loginReceiver = reader["loginReceiver"].ToString();
                        Int32 statusReceiver = Int32.Parse(reader["statusReceiver"].ToString());

                        bool xSender = login.Contains(loginSender);
                        bool yReceiver = login.Contains(loginReceiver);

                        if (xSender == false)
                        {
                            login.Add(loginSender);
                            dynamics.Add(new
                            {
                                Type = MESSAGE_TYPE_GET_CONTACTS_SUCCESS,
                                idPlayer = sender,
                                login = loginSender,
                                status = statusSender
                            });
                        }

                        if (yReceiver == false)
                        {
                            login.Add(loginReceiver);
                            dynamics.Add(new
                            {
                                Type = MESSAGE_TYPE_GET_CONTACTS_SUCCESS,
                                idPlayer = receiver,
                                login = loginReceiver,
                                status = statusReceiver
                            });
                        }

                    }
                }
                catch
                {
                    dynamics.Add(new { Type = MESSAGE_TYPE_GET_CONTACTS_ERRO });
                }
            }
            else
            {
                dynamics.Add(new { Type = MESSAGE_TYPE_GET_CONTACTS_ERRO });
            }
            this.sQLConnection.ClouseConnection();
            return dynamics;
        }
        public List<dynamic> SqlGetMessage(int sender_id_tbPlayer, int receiver_id_tbPlayer)
        {
            Boolean successfullyConnected = false;
            List<dynamic> message = new List<dynamic>();
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
                this.sqlCommand.CommandText = @"SELECT * FROM [dbo].[GetMessagePlayerChat] (@idSender,@idReceiver)";
                this.sqlCommand.Parameters.Clear();
                this.sqlCommand.Parameters.AddWithValue("@idSender", sender_id_tbPlayer);
                this.sqlCommand.Parameters.AddWithValue("@idReceiver", receiver_id_tbPlayer);

                try
                {
                    SqlDataReader reader = this.sqlCommand.ExecuteReader();
                    Boolean CommandSucess = reader.Read();

                    while (reader.Read() == true)
                    {
                        message.Add(new
                        {
                            Type = MESSAGE_TYPE_READ_NEW_MESSAGE,
                            sender = reader["sender"].ToString(),
                            message = reader["message"].ToString(),
                            date = reader["date"].ToString(),
                            receiver_id_tbPlayer
                        });
                    }
                }
                catch
                {
                    message.Add(new { Type = MESSAGE_TYPE_READ_ERRO });
                }

            }
            else
            {
                message.Add(new { Type = MESSAGE_TYPE_READ_ERRO });
            }


            this.sQLConnection.ClouseConnection();
            return message;
        }
    }
}
