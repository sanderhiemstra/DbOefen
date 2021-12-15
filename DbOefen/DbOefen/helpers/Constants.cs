﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DbOefen.helpers
{
    public class Constants
    {
        public const string COCKTAIL_BY_NAME = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s={0}";
        public const string COCKTAIL_BY_LETTER = "https://www.thecocktaildb.com/api/json/v1/1/search.php?f={0}";
        public const string INGREDIENT_BY_NAME = "https://www.thecocktaildb.com/api/json/v1/1/search.php?i={0}";
        public const string INGREDIENT_BY_ID = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?iid={0}";
        public const string COCKTAIL_AT_RANDOM = "https://www.thecocktaildb.com/api/json/v1/1/random";
        public const string COCKTAIL_DETAILS_BY_ID = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={0}";
    }
}
