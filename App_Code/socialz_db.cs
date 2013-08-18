using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections;
using MySql.Data;
using System.Data;

/// <summary>
/// database connection class which can be used from several pages encapulates for security
/// </summary>
public class Db_socialz_Connector
{
    private string connection_string;
    private MySqlConnection socialz_db_connection;

    public Db_socialz_Connector()
    {
        //
        // TODO: Add constructor logic here
        //
       connection_string =  ConfigurationManager.ConnectionStrings["socialz"].ConnectionString;
       socialz_db_connection = new MySqlConnection(connection_string);
    }

    // open the conneciton
    public Boolean Db_socialz_open(){
        socialz_db_connection.Open();
        if(socialz_db_connection.State==System.Data.ConnectionState.Open)
        { 
            return true;
        }
        else{
            return false;
        }
    }

    // close the connection
    public Boolean Db_socialz_close(){
        
        socialz_db_connection.Close();

        if(socialz_db_connection.State==System.Data.ConnectionState.Closed)
        {  
            return true;
        }
        else{
            return false;
        }
    }

    // distory the connection
    public void Db_socialz_flush(){
        socialz_db_connection.Dispose();
    }

    public DataSet get_all_towns(){
	
    MySqlCommand cmd = new MySqlCommand("Select * from area_table",socialz_db_connection);
    

    MySqlDataAdapter myAdapter = new MySqlDataAdapter();
    myAdapter.SelectCommand = cmd;

    DataSet myDataSet = new DataSet();
    myAdapter.Fill(myDataSet);

   
     return myDataSet;
    }
        



}
