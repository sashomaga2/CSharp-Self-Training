using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections;

public partial class UserDefinedFunctions
{
    [SqlFunction(Name = "AddSasho", IsDeterministic = true, IsPrecise = true)]
    public static int SashoAdd(int a, int b)
    {
        return a + b;
    }

    [SqlFunction(TableDefinition ="word nvarchar(max), length int", FillRowMethodName = "WordInfoCracker")]
    public static IEnumerable WordSplit(string str, string splitOn)
    {
        foreach (var word in str.Split(splitOn.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
        {
            yield return new WordInfo(word, word.Length);
        }
    }

    public static void WordInfoCracker(object obj, out string word, out int length)
    {
        var wi = obj as WordInfo;
        word = wi.Word;
        length = wi.Length;
    }
}

public class WordInfo
{
    public string Word
    {
        get;
        private set;
    }

    public int Length
    {
        get;
        private set;
    }

    public WordInfo(string word, int length)
    {
        Word = word;
        Length = length;
    }
}
