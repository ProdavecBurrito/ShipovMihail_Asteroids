using System;
using System.Collections.Generic;

namespace Shipov_Asteroids
{
    public class ScoreInterpretator
    {
        private float _number;

        //private List<string> _words = new List<string>() { " K", " M" };

        public string ConvertValue(string value)
        {
            if (float.TryParse(value, out _number))
            {
               return value = Interpretate(_number);
            }
            throw new ArgumentException("Wrong value type");
        }

        private string Interpretate(float value)
        {
            if (value >= 1000000)
            {
                return value / 1000000 + " M";
            }
            if (value >= 1000)
            {
                return value / 1000 + " K";
            }
            return value.ToString();
        }
    }
}
