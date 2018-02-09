using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EasyToMySql
{
    public class Connect
    {
        private string[] _Value;
        private string _Host;
        private string _Username;
        private string _Password;
        private string _Database;
        private string _Charset;
        private string _Table;
        private string _connestionString;
        private string _Select;
        private string _Update;
        private string _Delete;
        private string _Insert;
        private bool _Encrypt;
        private MySqlConnection Connector = new MySqlConnection();
        private MySqlCommand _Command = new MySqlCommand();


        public string[] Value
        {
            get
            {
                return _Value;
            }
        }
        public string Host { get => _Host; set => _Host = value; }
        public string Username { get => _Username; set => _Username = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Database { get => _Database; set => _Database = value; }
        public string Charset { get => _Charset; set => _Charset = value; }
        public string Table { get => _Table; set => _Table = value; }
        public string ConnestionString
        {
            get
            {
                return _connestionString;
            }
        }
        public string querySelect { get => _Select; set => _Select = value; }
        public string queryUpdate { get => _Update; set => _Update = value; }
        public string queryDelete { get => _Delete; set => _Delete = value; }
        public string queryInsert { get => _Insert; set => _Insert = value; }
        public bool Encrypt { get => _Encrypt; set => _Encrypt = value; }
        public MySqlCommand Command { get => _Command; set => _Command = value; }
        public string Open(string oHost, string oDatabase, string oCharset, string oUsername, string oPassword, bool oEncrypt = false)
        {
            Host = oHost;
            Database = oDatabase;
            Charset = oCharset;
            Username = oUsername;
            Password = oPassword;
            Encrypt = oEncrypt;
            _connestionString = $"Host={_Host};Username={_Username};Password:={_Password};Database={_Database};Encrypt={_Encrypt};CharSet={_Charset};";

            Connector.ConnectionString = _connestionString;
            Connector.Open();
            Connector.Close();
            return "Connection established successfully.";
        }

        /*public object CustomCommand(string oTable,int Record,int Index)
        {
            Connector.Open();
            object[,] Values = new object[Record, Index];
            Table = oTable;
            Command.CommandText = "SELECT * FROM "+ $"{Table}";
            Command.Connection = Connector;
            Command.CommandType = CommandType.Text;
            MySqlDataReader Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                for (int j = 0; j < Record; j++)
                {

                    for (int i = 0; i < Index; i++)
                    {
                        Values[j,i] = Reader[i];
                        Console.WriteLine(Values[j,i]);
                    }
                }
            }
            Reader.Close();
            return (Values);
        }*/

        /*public object Selector(string oTable, int Record, int Index)
        {
            Connector.Open();
            object[,] Values = new object[Record, Index];
            Table = oTable;
            Command.CommandText = Table;
            Command.Connection = Connector;
            Command.CommandType = CommandType.TableDirect;
            MySqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                for (int j = 0; j < Index; j++)
                {

                    for (int i = 0; i < Record; i++)
                    {
                        Values[i, j] = Reader[i];
                        Console.WriteLine(Values[i, j]);
                    }
                }
            }
            Reader.Close();
            return ("");
        }*/

        /*public object Finder(string oTable,string oFields, int oId)
        {
            Connector.Open();
            int ValueCount = 0;
            string[] Commas = oFields.Split(',');
            foreach (var item in Commas)
            {
                ValueCount++;
            }
            object[] Values = new object[ValueCount];
            Table = oTable;
            Command.CommandText = "SELECT "+$"{oFields}"+" FROM " + $"{Table}"+" WHERE "+$" user_Id={oId}";
            Command.Connection = Connector;
            Command.CommandType = CommandType.Text;
            MySqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                for (int i = 0; i < ValueCount; i++)
                {
                    Values[i] = Reader[i];
                    Console.WriteLine(Values[i]);
                    _Value[i] = Reader[i].ToString();
                }
            }
            Reader.Close();
            Connector.Close();
            return ($"To get values, Work on the Value property!");
        }*/
        public object Inserter(string oTable, string oFields, string oValues)
        {
            Connector.Open();
            Table = oTable;
            Command.CommandText = "INSERT INTO " + $"{Table}" + " (" + $"{oFields}" + ") VALUES (" + $"{oValues}" + ")";
            Command.Connection = Connector;
            Command.CommandType = CommandType.Text;
            MySqlDataReader Reader = Command.ExecuteReader();
            Reader.Close();
            return ("Values Inserted successfully");
        }

        public object Deleter(string oTable, string oField, int oId)
        {
            Connector.Open();
            Table = oTable;
            Command.CommandText = Command.CommandText = "DELETE FROM " + $"{Table}" + " WHERE " + $" user_Id={oId}";
            Command.Connection = Connector;
            Command.CommandType = CommandType.Text;
            MySqlDataReader Reader = Command.ExecuteReader();
            Reader.Close();
            Connector.Close();
            return ($"The Id {oId} has been deleted.");
        }
    }
    internal class EasyToMySqlException : Exception
    {
        internal string _connectionException;
        public string ConnectionException
        {
            get
            {
                return _connectionException;
            }
            set
            {
                _connectionException = value;
            }
        }
    }

}

