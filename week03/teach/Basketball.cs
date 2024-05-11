/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using System.Numerics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("C:\\Users\\fun_l.DESKTOP-JD5OICG\\school\\cse212\\week03\\teach\\Basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                players[playerId] = points;
            }
        }
        // convert map to array
        var playersArray = players.ToArray();
        Array.Sort(playersArray, (a, b) => b.Value - a.Value);

        // Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        var topPlayers = new string[10];
        // Console.WriteLine(playersArray);
        for (var i = 0; i < 10; ++i)
        {
            topPlayers[i] = playersArray[i].Key;
            Console.WriteLine(topPlayers[i] + " " + playersArray[i].Value);
        }

    }
}