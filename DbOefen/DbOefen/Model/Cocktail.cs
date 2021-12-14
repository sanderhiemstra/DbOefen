using DbOefen.helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbOefen.Model
{
    public class Cocktail
    {
        public static string GenerateURLName(string name)
        {
            return string.Format(Constants.COCKTAIL_BY_NAME, name);
        }

        public static string GenerateURLLetter(string letter)
        {
            return string.Format(Constants.COCKTAIL_BY_LETTER, letter);
        }

        public static string GenerateURLRandom()
        {
            return string.Format(Constants.COCKTAIL_AT_RANDOM);
        }

        public static string GenerateURLById()
        {
            return string.Format(Constants.COCKTAIL_DETAILS_BY_ID);
        }
    }
}
