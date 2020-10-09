using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FoxmindTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var textFile = string.Empty;
                if (args.Any())
                {
                    textFile = args.First();
                }
                else
                {
                    Console.WriteLine(Constants.PleaseEnterFilePath);
                    textFile = Console.ReadLine();
                }


                GetDefectiveAndMaxStringNumbers numbers = new GetDefectiveAndMaxStringNumbers(textFile);
                var result = numbers.GetMaxStringNumber(out List<int> defectiveStrings);
                if (result.HasValue)
                {
                    Console.WriteLine(string.Format(Constants.ResultString, result));
                }
                else
                {
                    Console.WriteLine(Constants.NoResultString);
                }
                if (defectiveStrings.Any())
                {
                    Console.WriteLine(string.Format(Constants.DefectedLinesString, string.Join(',', defectiveStrings.Select(x => x.ToString()))));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
