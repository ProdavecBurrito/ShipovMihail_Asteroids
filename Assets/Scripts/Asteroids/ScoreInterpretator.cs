using System;
using System.Collections.Generic;

namespace Shipov_Asteroids
{
    public class ScoreInterpretator
    {
        private string _value;
        private float _number;

        private List<string> _words = new List<string>() { " K", " M" };

        public string ConvertValue(string value)
        {
            for (int i = 0; i < _words.Count; i++)
            {
                if (value.Contains(_words[i]))
                {
                    var charIndex = _words[i].IndexOf(_words[i]);
                    value.Remove(charIndex);
                }
            }
            if (float.TryParse(value, out _number))
            {
               return value = Interpretate(_number);
            }
            return value;
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
