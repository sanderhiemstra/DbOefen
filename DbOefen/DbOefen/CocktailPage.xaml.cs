using DbOefen.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DbOefen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CocktailPage : ContentPage
    {
        public CocktailPage()
        {
            InitializeComponent();
        }

        private void ZoekCocktailNameButton_Clicked(object sender, EventArgs e)
        {
            var cocktails = CocktailLogic.GetCocktailsByName(CocktailNameEntry.Text);
        }
    }
}