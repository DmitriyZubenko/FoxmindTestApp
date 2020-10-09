using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace FoxmindTestApp
{
    public class GetDefectiveAndMaxStringNumbers
    {
        private readonly string _wayToFile;
        public GetDefectiveAndMaxStringNumbers(string wayToFile)
        {
            _wayToFile = wayToFile;
        }

        public int? GetMaxStringNumber(out List<int> defectiveStringsNumbers)
        {
            var dataFromFile = GetFileLines();

            defectiveStringsNumbers = new List<int>();
            double maxValue = double.MinValue;
            int? position = null;
            for (int i = 0; i < dataFromFile.Length; i++)
            {
                double lineSum = 0;
                bool isDefective = false;
                var splitArray = dataFromFile[i].Split(Constants.Separator);
                for (int j = 0; j < splitArray.Length; j++)
                {
                    if (double.TryParse(splitArray[j], System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                    {
                        lineSum += result;
                    }
                    else
                    {
                        defectiveStringsNumbers.Add(i + 1);
                        isDefective = true;
                        break;
                    }
                }
                if (!isDefective && lineSum > maxValue)
                {
                    maxValue = lineSum;
                    position = i + 1;
                }
            }
            return position;
        }

        private string[] GetFileLines()
        {
            if (!File.Exists(_wayToFile))
            {
                throw new Exception(Constants.FileNotExists);
            }

            return File.ReadAllLines(_wayToFile);
        }
    }
}
