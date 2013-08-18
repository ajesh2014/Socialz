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
    private socialz_secure_db query_string;

    public Db_socialz_Connector()
    {
        //
        // TODO: Add constructor logic here
        //
       connection_string =  ConfigurationManager.ConnectionStrings["socialz"].ConnectionString;
       socialz_db_connection = new MySqlConnection(connection_string);
       query_string = new socialz_secure_db();
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

    public DataSet select_query(int table, int proc_call, string [] proc_params, string [] param_value){
	
    string proc = query_string.get_proc(table,proc_call);

     MySqlCommand cmd = new MySqlCommand(proc,socialz_db_connection);
    
    MySqlDataAdapter myAdapter = new MySqlDataAdapter();
    myAdapter.SelectCommand = cmd;
     DataSet myDataSet = new DataSet();

    if(proc_params.Length>0 ){

        if(proc_params.Length==param_value.Length){

            for (int i = 0; i<proc_params.Length; i++){
            
                cmd.Parameters.Add(proc_params[i],param_value[i]);

            }

        }else{
            

            return myDataSet = null;

        }
   
        
    }

        cmd.CommandType = CommandType.StoredProcedure;
        myAdapter.SelectCommand = cmd;
        myAdapter.Fill(myDataSet);
        return myDataSet;
    }
        



}
