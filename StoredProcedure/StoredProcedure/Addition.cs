using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections;
using System.Collections.Generic;

public partial class StoredProcedures
{
    [SqlProcedure]
    public static void Addition (SqlInt32 num1, SqlInt32 num2, out SqlInt32 sum)
    {
        sum = num1 + num2;
    }

    [SqlProcedure]
    public static void IncrementMeBy (SqlInt32 increment, ref SqlInt32 me)
    {
        me += increment;
    }

    [SqlProcedure]
    public static void EchoMsg (SqlString msg)
    {
        var pipe = SqlContext.Pipe;
        pipe.Send(msg.Value);
    }

    [SqlProcedure]
    public static void MakeFib (SqlInt32 first, SqlInt32 second, SqlInt32 length)
    {
        var result = new int[length.Value];

        //TODO return result
        var resultMetadata = new SqlMetaData[2];
        resultMetadata[0] = new SqlMetaData("position", SqlDbType.Int);
        resultMetadata[1] = new SqlMetaData("value", SqlDbType.Int);

        //var resultSender = new SqlResultSender(SqlContext.Pipe);
        //var dataRecord = resultSender.CreateDataRecord(resultMetadata);

        var dataRecord = new SqlDataRecord(resultMetadata);
        var pipe = SqlContext.Pipe;
        pipe.SendResultsStart(dataRecord);

        dataRecord.SetSqlInt32(0, 0);
        dataRecord.SetSqlInt32(1, first);
        pipe.SendResultsRow(dataRecord);

        dataRecord.SetSqlInt32(0, 1);
        dataRecord.SetSqlInt32(1, second);
        pipe.SendResultsRow(dataRecord);

        var fibLength = length;
        var fibFirst = first;
        var fibSecond = second;
        // every record object from class FibResult value and index
        for (int position = 2; position < fibLength; position++)
        {
            var fibNext = fibFirst + fibSecond;
            fibFirst = fibSecond;
            fibSecond = fibNext;

            dataRecord.SetSqlInt32(0, position);
            dataRecord.SetSqlInt32(1, fibNext);
            pipe.SendResultsRow(dataRecord);
        }

        pipe.SendResultsEnd();   
    }

    private void SendResultRow(SqlInt32 position, SqlInt32 value)
    {

    }
}

public class SqlResultSender
{
    private readonly SqlPipe pipe;

    public SqlResultSender(SqlPipe pipe)
    {
        this.pipe = pipe;
    }

    public SqlDataRecord CreateDataRecord(SqlMetaData[] metaData)
    {
        return new SqlDataRecord(metaData);
    }

    public void SendRow()
    {

    }
}
