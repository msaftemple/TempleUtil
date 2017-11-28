using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libUtilities
{
    public class StoredProcedure
    {
        public SqlCommand cmd { get; set; }
        //public DBConnect con = new DBConnect();
        private string SP;
        private string[] OutParam;

        // Create the StoredProcedure object with the name of the stored procedure then run the methods to add input/output params
        public StoredProcedure(string sp)
        {
            cmd = new SqlCommand(sp);
            SP = sp;
        }
        // For making SQLCommands of stored procedures with input parameters
        // Only Adds inputs
        public SqlCommand BuildSPInput(string[] param, string[] val)
        {
            for (int i = 0; i < param.GetLength(0); i++)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(param[i], val[i]);
            }
            return cmd;
        }
        // For making SQLCommands of stored procedures with output parameters
        // Only Adds outputs (run the input method if your command object needs inputs)
        public SqlCommand BuildSPOutput(string[] op)
        {
            OutParam = op;
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < OutParam.Count(); i++)
            {
                SqlParameter outPut = new SqlParameter();
                outPut.ParameterName = OutParam[i];
                cmd.Parameters.Add(outPut).Direction = ParameterDirection.Output;
            }
            return cmd;
        }
        //public string[] ReturnSPOutput()
        //{
        //    return con.CmdObjectReturnUpdate(cmd, OutParam);
        //}
    }
}
