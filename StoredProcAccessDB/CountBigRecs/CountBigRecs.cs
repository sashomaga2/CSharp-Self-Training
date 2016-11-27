using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [SqlProcedure]
    public static void CountBigRecs(SqlInt32 limit, out SqlInt32 count)
    {
        count = 0;
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        using (SqlCommand cmd = new SqlCommand(@"select count(*) from Rectangles where (height * width) > @limit", conn))
        {
            cmd.Parameters.AddWithValue("@limit", limit);
            conn.Open();
            count = (int)cmd.ExecuteScalar();
        }
            
    }

    [SqlProcedure]
    public static void GetBigRecs(SqlInt32 limit)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        using (SqlCommand cmd = new SqlCommand(@"select (height * width) as area from Rectangles where (height * width) > @limit", conn))
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@limit", limit);
            SqlContext.Pipe.ExecuteAndSend(cmd);
        }

    }

    [SqlProcedure]
    public static void GetBigRecsReader(SqlInt32 limit)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        using (SqlCommand cmd = new SqlCommand(@"select (height * width) as area from Rectangles where (height * width) > @limit", conn))
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@limit", limit);
            var results = cmd.ExecuteReader();
            // Do something with results before send over
            SqlContext.Pipe.Send(results);
        }

    }

    [SqlProcedure]
    public static void TrimAllWidths(SqlInt32 trimBy, out SqlInt32 affected)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        using (SqlCommand cmd = new SqlCommand(@"update Rectangles set width = width - @trimBy where width - @trimBy > 3", conn))
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@trimBy", trimBy);
            affected = cmd.ExecuteNonQuery();
        }

    }
}
