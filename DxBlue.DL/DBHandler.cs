
using DxBlue.Common.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public static class DBHandler
{
    public static AppSettingsReader ConfigSetting = new System.Configuration.AppSettingsReader();
    //public static string ConnStr = ((string)(ConfigSetting.GetValue("dbConnString", typeof(string))));
    public static int IntReturnVal { get; set; }
    private static string ConnStr = string.Empty;
    public static SqlConnection Connect(string connStr)
    {
        return (new SqlConnection(ConfigurationManager.ConnectionStrings[connStr].ConnectionString));

    }

    public static DataTable ExecuteDataTable(string connStr, CommandType strCommandType, string selectString, string source)
    {
        var cmdDataTable = new SqlCommand();
        var conn = Connect(connStr);
        cmdDataTable.Connection = conn;
        cmdDataTable.CommandType = CommandType.Text;
        cmdDataTable.CommandText = selectString;
        cmdDataTable.CommandTimeout = 0;

        try
        {
            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var daSelect = new SqlDataAdapter(cmdDataTable);
            var rDatatable = new DataTable();
            rDatatable.Clear();
            daSelect.Fill(rDatatable);
            return rDatatable;
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return null;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }

    internal static object ExecuteWithOutput(string v1, string v2, ref Hashtable ht, string v3, string v4)
    {
        throw new NotImplementedException();
    }

    public static DataSet ExecuteDataset(string connStr, CommandType strCommandType, string selectString, string source)
    {
        var cmdDataset = new SqlCommand();
        var conn = Connect(connStr);
        cmdDataset.Connection = conn;
        cmdDataset.CommandType = CommandType.Text;
        cmdDataset.CommandText = selectString;
        cmdDataset.CommandTimeout = 0;
        try
        {
            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var daSelect = new SqlDataAdapter(cmdDataset);
            var rDataset = new DataSet();
            rDataset.Clear();
            daSelect.Fill(rDataset);
            return rDataset;

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return null;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }

    }
    public static DataRow GetDataRow(string connStr, string commandText, ref Hashtable ht, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand();
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }

            cmdPSelect.Connection = conn;
            cmdPSelect.CommandType = CommandType.StoredProcedure;
            cmdPSelect.CommandText = commandText;
            cmdPSelect.CommandTimeout = 0;
            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }

            var daSelect = new SqlDataAdapter(cmdPSelect);
            var dsSelect = new DataSet();
            daSelect.Fill(dsSelect);
            switch (dsSelect.Tables[0].Rows.Count)
            {
                case 0:
                    return null;
                default:
                    return dsSelect.Tables[0].Rows[0];
            }

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return null;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }

    }

    public static DataRow GetDataRow(string connStr, string commandText, ref Hashtable ht, int qtype, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand();
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }

            cmdPSelect.Connection = conn;
            switch (qtype)
            {
                case 0:
                    cmdPSelect.CommandType = CommandType.Text;
                    break;
                default:
                    cmdPSelect.CommandType = CommandType.StoredProcedure;
                    break;
            }
            cmdPSelect.CommandText = commandText;
            cmdPSelect.CommandTimeout = 0;
            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }

            var daSelect = new SqlDataAdapter(cmdPSelect);
            var dsSelect = new DataSet();
            daSelect.Fill(dsSelect);
            switch (dsSelect.Tables[0].Rows.Count)
            {
                case 0:
                    return null;
                default:
                    return dsSelect.Tables[0].Rows[0];
            }

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return null;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }

    }
    public static DataRow GetDataRow(string connStr, string commandString, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = commandString
            };

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var daSelect = new SqlDataAdapter(cmdPSelect);
            var dsSelect = new DataSet();
            daSelect.Fill(dsSelect);
            switch (dsSelect.Tables[0].Rows.Count)
            {
                case 0:
                    return null;
                default:
                    return dsSelect.Tables[0].Rows[0];
            }

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return null;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }

    }

    public static object GetDataTable(object connStr, string v1, ref Hashtable ht, string v2)
    {
        throw new NotImplementedException();
    }

    public static int ModifyCommand(string connStr, string commandText, ref Hashtable ht, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdModify = new SqlCommand();
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdModify.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }

            cmdModify.Connection = conn;
            cmdModify.CommandType = CommandType.StoredProcedure;
            cmdModify.CommandText = commandText;
            cmdModify.CommandTimeout = 0;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var rflag = cmdModify.ExecuteNonQuery();
            cmdModify.Parameters.Clear();
            return rflag;
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return -1;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static DataTable GetDataTable(string connStr, string commandText, ref Hashtable ht, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand();
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }

            cmdPSelect.Connection = conn;
            cmdPSelect.CommandType = CommandType.StoredProcedure;
            cmdPSelect.CommandText = commandText;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var daSelect = new SqlDataAdapter(cmdPSelect);
            var dtSelect = new DataTable();
            daSelect.SelectCommand.CommandTimeout = 0;
            daSelect.Fill(dtSelect);
            cmdPSelect.Parameters.Clear();
            return dtSelect;
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return null;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static DataTable GetDataTable(string connStr, string commandText, ref Hashtable ht, int qtype, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand();
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }

            cmdPSelect.Connection = conn;
            switch (qtype)
            {
                case 0:
                    cmdPSelect.CommandType = CommandType.Text;
                    break;
                default:
                    cmdPSelect.CommandType = CommandType.StoredProcedure;
                    break;
            }
            cmdPSelect.CommandText = commandText;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var daSelect = new SqlDataAdapter(cmdPSelect);
            var dtSelect = new DataTable();
            daSelect.SelectCommand.CommandTimeout = 0;
            daSelect.Fill(dtSelect);
            cmdPSelect.Parameters.Clear();
            return dtSelect;
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return null;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static DataTable GetDataTableWithOutputParameter(string connStr, string commandText, ref Hashtable ht, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand();
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }
            var IntPara1 = cmdPSelect.Parameters.Add("@ReturnVal", SqlDbType.Int);
            IntPara1.Direction = ParameterDirection.Output;

            cmdPSelect.Connection = conn;
            cmdPSelect.CommandType = CommandType.StoredProcedure;
            cmdPSelect.CommandText = commandText;

            if (conn.State == ConnectionState.Closed) { conn.Open(); }
            var DASelect = new SqlDataAdapter(cmdPSelect);
            var dtSelect = new DataTable();
            DASelect.SelectCommand.CommandTimeout = 0;
            DASelect.Fill(dtSelect);

            //ht.Add("TotalRecords", Convert.ToInt32(IntPara1.Value));
            IntReturnVal = Convert.ToInt32(IntPara1.Value);
            cmdPSelect.Parameters.Clear();
            return dtSelect;

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return null;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static DataTable GetDataTable(string connStr, string commandString, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = commandString
            };

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var daSelect = new SqlDataAdapter(cmdPSelect);
            var dtSelect = new DataTable();
            daSelect.SelectCommand.CommandTimeout = 0;

            daSelect.Fill(dtSelect);
            cmdPSelect.Parameters.Clear();
            return dtSelect;

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return null;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static DataSet GetDataSet(string connStr, string commandText, ref Hashtable ht, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand();
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }
            cmdPSelect.Connection = conn;
            cmdPSelect.CommandType = CommandType.StoredProcedure;
            cmdPSelect.CommandText = commandText;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var daSelect = new SqlDataAdapter(cmdPSelect);
            var dsSelect = new DataSet();
            daSelect.SelectCommand.CommandTimeout = 0;

            daSelect.Fill(dsSelect);
            cmdPSelect.Parameters.Clear();
            return dsSelect;

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return null;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static void DeleteRecord(string connStr, int recordId, string nameOfsp, string source)
    {
        var conn = Connect(connStr);
        var cmdDObject = new SqlCommand
        {
            CommandTimeout = 0,
            Connection = conn,
            CommandType = CommandType.StoredProcedure,
            CommandText = nameOfsp
        };

        try
        {
            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }

            var sqlRecordId = cmdDObject.Parameters.Add("@RecordID", SqlDbType.Int);
            sqlRecordId.Direction = ParameterDirection.Input;
            sqlRecordId.Value = recordId;

            cmdDObject.ExecuteNonQuery();
            cmdDObject.Parameters.Clear();

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            // string Str = ex.Message;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static int GetInteger(string connStr, string commandText, ref Hashtable ht, string source)
    {
        var conn = Connect(connStr);
        var cmdInt = new SqlCommand { CommandTimeout = 0 };

        try
        {
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdInt.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
                //IntPara.Value = values[i];
            }

            cmdInt.Connection = conn;
            cmdInt.CommandType = CommandType.StoredProcedure;
            cmdInt.CommandText = commandText;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }

            var retint = Convert.ToInt32(cmdInt.ExecuteScalar());
            //Handling Null in C#
            return !retint.Equals(DBNull.Value) ? retint : -1;
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            //string Str = ex.Message;
            return -1;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static int GetInteger(string connStr, string commandText, ref Hashtable ht, int qtype, string source)
    {
        var conn = Connect(connStr);
        var cmdInt = new SqlCommand { CommandTimeout = 0 };

        try
        {
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdInt.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
                //IntPara.Value = values[i];
            }

            cmdInt.Connection = conn;
            switch (qtype)
            {
                case 0:
                    cmdInt.CommandType = CommandType.Text;
                    break;
                default:
                    cmdInt.CommandType = CommandType.StoredProcedure;
                    break;
            }

            cmdInt.CommandText = commandText;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }

            var retint = Convert.ToInt32(cmdInt.ExecuteScalar());
            //Handling Null in C#
            return !retint.Equals(DBNull.Value) ? retint : -1;
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            //string Str = ex.Message;
            return -1;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static int GetInteger(string connStr, string selectString, string source)
    {
        var conn = Connect(connStr);
        var cmdIntFromString = new SqlCommand
        {
            CommandTimeout = 0,
            Connection = conn,
            CommandType = CommandType.Text,
            CommandText = selectString
        };
        try
        {
            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }

            var retint = Convert.ToInt32(cmdIntFromString.ExecuteScalar());
            //Handling Null in C#
            return !retint.Equals(DBNull.Value) ? retint : -1;
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return -1;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static string GetString(string connStr, string commandText, ref Hashtable ht, string source)
    {
        var conn = Connect(connStr);
        var cmdInt = new SqlCommand { CommandTimeout = 0 };
        try
        {
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdInt.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }
            cmdInt.Connection = conn;
            cmdInt.CommandType = CommandType.StoredProcedure;
            cmdInt.CommandText = commandText;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var retint = Convert.ToString(cmdInt.ExecuteScalar());
            //Handling Null in C#
            return !retint.Equals(DBNull.Value) ? retint : "-1";
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return "-1";
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static decimal GetDecimalFromString(string connStr, string selectString, string source)
    {
        var conn = Connect(connStr);
        var cmddecFromString = new SqlCommand
        {
            CommandTimeout = 0,
            Connection = conn,
            CommandType = CommandType.Text,
            CommandText = selectString
        };
        try
        {
            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var retdec = Convert.ToDecimal(cmddecFromString.ExecuteScalar());
            //Handling Null in C#
            return !retdec.Equals(DBNull.Value) ? retdec : -1.0m;
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return -1.0m;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }

    }
    public static string GetStringFromString(string connStr, string selectString, string source)
    {
        var conn = Connect(connStr);
        var cmdStrFromString = new SqlCommand
        {
            CommandTimeout = 0,
            Connection = conn,
            CommandType = CommandType.Text,
            CommandText = selectString
        };
        try
        {
            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }

            var retstring = Convert.ToString(cmdStrFromString.ExecuteScalar());
            //Handling Null in C#
            return !retstring.Equals(DBNull.Value) ? retstring : "-1";

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return "-1";
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
    public static bool GetBooleanFromString(string connStr, string selectString, string source)
    {
        var conn = Connect(connStr);
        var cmdBoolFromString = new SqlCommand
        {
            CommandTimeout = 0,
            Connection = conn,
            CommandType = CommandType.Text,
            CommandText = selectString
        };

        try
        {
            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }

            var ret = Convert.ToBoolean(cmdBoolFromString.ExecuteScalar());
            //Handling Null in C#
            return !ret.Equals(DBNull.Value);

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return false;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }

    }
    public static bool CheckIfExists(string connStr, string commandText, ref Hashtable ht, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand { CommandTimeout = 0 };
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }

            cmdPSelect.Connection = conn;
            cmdPSelect.CommandType = CommandType.StoredProcedure;
            cmdPSelect.CommandText = commandText;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var daSelect = new SqlDataAdapter(cmdPSelect);
            var dtSelect = new DataTable();
            daSelect.Fill(dtSelect);
            cmdPSelect.Parameters.Clear();
            return Convert.ToInt32(dtSelect.Rows[0].ItemArray[0]) > 0;
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return false;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }

    }
    public static int GetReturnVal(string connStr, string commandText, ref Hashtable ht, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand { CommandTimeout = 0 };
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }
            var intPara1 = cmdPSelect.Parameters.Add("@ReturnVal", SqlDbType.Int);
            intPara1.Direction = ParameterDirection.Output;

            cmdPSelect.Connection = conn;
            cmdPSelect.CommandType = CommandType.StoredProcedure;
            cmdPSelect.CommandText = commandText;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            cmdPSelect.ExecuteNonQuery();

            var retval = Convert.ToInt32(intPara1.Value);
            cmdPSelect.Parameters.Clear();
            switch (retval.Equals(DBNull.Value))
            {
                case false:
                    return retval;
                default:
                    return -1;
            }

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return -1;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }

    public static dynamic ExecuteWithOutput(string connStr, string commandText, ref Hashtable ht, String outputParamName, String returnType, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand { CommandTimeout = 0 };
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }
            SqlParameter intPara1;
            switch (returnType)
            {
                case "string":
                    intPara1 = cmdPSelect.Parameters.Add(outputParamName, SqlDbType.VarChar);
                    intPara1.Direction = ParameterDirection.Output;
                    break;
                case "int":
                case "number":
                    intPara1 = cmdPSelect.Parameters.Add(outputParamName, SqlDbType.Int);
                    intPara1.Direction = ParameterDirection.Output;
                    break;
                case "bigint":
                    intPara1 = cmdPSelect.Parameters.Add(outputParamName, SqlDbType.BigInt);
                    intPara1.Direction = ParameterDirection.Output;
                    break;
                case "datetime":
                    intPara1 = cmdPSelect.Parameters.Add(outputParamName, SqlDbType.DateTime);
                    intPara1.Direction = ParameterDirection.Output;
                    break;
                case "date":
                    intPara1 = cmdPSelect.Parameters.Add(outputParamName, SqlDbType.Date);
                    intPara1.Direction = ParameterDirection.Output;
                    break;
                default:
                    intPara1 = cmdPSelect.Parameters.Add(outputParamName, SqlDbType.VarChar);
                    intPara1.Direction = ParameterDirection.Output;
                    break;
            }


            cmdPSelect.Connection = conn;
            cmdPSelect.CommandType = CommandType.StoredProcedure;
            cmdPSelect.CommandText = commandText;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            cmdPSelect.ExecuteNonQuery();

            var retval = intPara1.Value;
            cmdPSelect.Parameters.Clear();
            switch (retval.Equals(DBNull.Value))
            {
                case false:
                    return retval;
                default:
                    return -1;
            }

        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return -1;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }


    }
    public static string GetReturnValString(string connStr, string commandText, ref Hashtable ht, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand { CommandTimeout = 0 };

            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }

            var intPara1 = cmdPSelect.Parameters.Add("@ReturnStr", SqlDbType.Char, 16);
            intPara1.Direction = ParameterDirection.Output;
            cmdPSelect.Connection = conn;
            cmdPSelect.CommandType = CommandType.StoredProcedure;
            cmdPSelect.CommandText = commandText;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            cmdPSelect.ExecuteNonQuery();

            var retval = Convert.ToString(intPara1.Value);
            cmdPSelect.Parameters.Clear();
            return retval.Equals(DBNull.Value) == false ? retval : "-1";
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return "-1";
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }

    }
    public static DataTable GroupBy(DataTable table, String[] aggregateColumns, String[] aggregateFunctions, Type[] columnTypes, String[] groupByColumns, string source)
    {
        var view = new DataView(table);
        var grouped = view.ToTable(true, groupByColumns);

        for (var i = 0; i < aggregateColumns.Length; i++)
            grouped.Columns.Add(aggregateColumns[i], columnTypes[i]);

        foreach (DataRow row in grouped.Rows)
        {
            var filterParts = new List<String>();
            foreach (var t in groupByColumns)
                filterParts.Add(String.Format("[{0}] = '{1}'", t, row[t].ToString().Replace("'", "''")));

            var filter = String.Join(" AND ", filterParts.ToArray());

            for (var i = 0; i < aggregateColumns.Length; i++)
                row[aggregateColumns[i]] = table.Compute(aggregateFunctions[i], filter);
        }
        return grouped;
    }
    public static DataTable GroupBy(DataTable table, String[] aggregateColumns, String[] aggregateFunctions, String[] groupByColumns, string source)
    {
        var view = new DataView(table);
        var grouped = view.ToTable(true, groupByColumns);

        foreach (var t in aggregateColumns)
            grouped.Columns.Add(t);

        foreach (DataRow row in grouped.Rows)
        {
            var filterParts = new List<String>();
            foreach (var t in groupByColumns)
                filterParts.Add(String.Format("[{0}] = '{1}'", t, row[t].ToString().Replace("'", "''")));

            var filter = String.Join(" AND ", filterParts.ToArray());

            for (var i = 0; i < aggregateColumns.Length; i++)
                row[aggregateColumns[i]] = table.Compute(aggregateFunctions[i], filter);
        }
        return grouped;
    }
    public static DataTable GetDataTableExcel(string strPath, string strSheetName, string source)
    {

        try
        {
            var sourceConstr = "";
            if (System.IO.Path.GetExtension(strPath) == ".xlsx" || System.IO.Path.GetExtension(strPath) == ".xls")
            {

                sourceConstr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", strPath);
            }
            else
            {
                sourceConstr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", strPath);
            }

            //var sourceConstr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";", strPath);
            //  var sourceConstr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=Excel 4.0", strPath);

            var con = new OleDbConnection(sourceConstr);
            var query = "Select * From " + strSheetName;
            var dtSelect = new DataTable();
            var data = new OleDbDataAdapter(query, con);
            data.Fill(dtSelect);
            return dtSelect;
        }
        catch (Exception)
        {
            return null;

        }

    }

    public static DataTable GetDataTable(string connStr, string commandText, ref Hashtable ht, ref Hashtable htTableTypeParam, string source)
    {
        var conn = Connect(connStr);
        try
        {
            var cmdPSelect = new SqlCommand();
            foreach (DictionaryEntry dict in ht)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.Direction = ParameterDirection.Input;
            }

            foreach (DictionaryEntry dict in htTableTypeParam)
            {
                var intPara = cmdPSelect.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                intPara.SqlDbType = SqlDbType.Structured;
            }

            cmdPSelect.Connection = conn;
            cmdPSelect.CommandType = CommandType.StoredProcedure;
            cmdPSelect.CommandText = commandText;

            switch (conn.State)
            {
                case ConnectionState.Closed:
                    conn.Open();
                    break;
            }
            var daSelect = new SqlDataAdapter(cmdPSelect);
            var dtSelect = new DataTable();
            daSelect.SelectCommand.CommandTimeout = 0;
            daSelect.Fill(dtSelect);
            cmdPSelect.Parameters.Clear();
            return dtSelect;
        }
        catch (Exception ex)
        {
            LogError.WriteErrorToFile(ex, source);
            return null;
        }
        finally
        {
            switch (conn.State)
            {
                case ConnectionState.Open:
                    conn.Close();
                    break;
            }
        }
    }
}
