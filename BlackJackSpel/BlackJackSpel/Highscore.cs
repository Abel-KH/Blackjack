using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BlackJackSpel
{
    public class Result
    {
        public string Name { get; set; }
        public int FinalBalance { get; set; }
        public int RoundsPlayed { get; set; }
        public Result()
        {
            Name = "";
        }
        public Result(string name, int finalBalance, int roundsPlayed)
        {
            Name = name;
            FinalBalance = finalBalance;
            RoundsPlayed = roundsPlayed;
        }
    }
    public class Highscore
    {
        private List<Result> results;
        private string fileName;

        public Highscore()
        {
            results = new List<Result>();
            fileName = "highscore.json";
        }

        public void Load()
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    results = new List<Result>();
                    return;
                }

                string json = File.ReadAllText(fileName);
                List<Result> loadedList = JsonSerializer.Deserialize<List<Result>>(json);

                if (loadedList == null)
                {
                    results = new List<Result>();
                }
                else
                {
                    results = loadedList;
                }
            }
            catch
            {
                results = new List<Result>();
            }
        }

        public void Add(string name, int finalBalance, int roundsPlayed)
        {
            Result newResult = new Result(name, finalBalance, roundsPlayed);
            results.Add(newResult);
            Save();
        }

        public void Save()
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;

                string json = JsonSerializer.Serialize(results, options);
                File.WriteAllText(fileName, json);
            }
            catch (Exception error)
            {
                Console.WriteLine("Could not save the highscore list: " + error.Message);
            }
        }

        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine("Highscore");

            if (results.Count == 0)
            {
                Console.WriteLine("No results yet.");
                Console.WriteLine();
                return;
            }

            results.Sort(CompareBalance);

            int amountToShow = 5;
            if (results.Count < 5)
            {
                amountToShow = results.Count;
            }

            for (int i = 0; i < amountToShow; i++)
            {
                Result r = results[i];
                Console.WriteLine((i + 1) + ". " + r.Name + "      " + r.FinalBalance + " kr   (" + r.RoundsPlayed + " rounds)");
            }

            Console.WriteLine();
        }

        private int CompareBalance(Result a, Result b)
        {
            return b.FinalBalance.CompareTo(a.FinalBalance);
        }
    }
}