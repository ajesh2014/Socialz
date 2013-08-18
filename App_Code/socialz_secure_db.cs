using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// contains all the procs and tables defintion
/// </summary>
public class socialz_secure_db

{
    private string [,] table_procs = new string[3,3];

    public socialz_secure_db()
    {
        //
        // add all the procs and tables in here
        //
        table_procs[0, 0] = "area_table_all_areas";
        table_procs[0, 1] = "wanna_go_out_table_select_wanna_go_out_by_area";

    }
    
    public string get_proc(int table, int proc_def){
        
        return table_procs[table, proc_def];


    }



}
