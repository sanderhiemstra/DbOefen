using DbOefen.Model;
using SQLite;
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
    public partial class AddQuestionPage : ContentPage
    {
        public AddQuestionPage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            Question question = new Question() { QuestionBody = QuestionEntry.Text };

            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Question>();
            int insertedRows = sQLiteConnection.Insert(question);

            if(insertedRows > 0)
            {
                _ = DisplayAlert("Gelukt!", "Je vraag is goed toegevoegd aan de database!", "OK");
            }
            else
            {
                _ = DisplayAlert("Ah jammer! Er ging iets fout", "Je vraag is NIET toegevoegd aan de database!", "OK");
            }

            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Question>();
                var questions = sQLiteConnection.Table<Question>().ToList();
                QuestionListView.ItemsSource = questions;
            }
        }

        private void QuestionListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedQuestion = QuestionListView.SelectedItem as Question;
            if(selectedQuestion != null)
            {
                Navigation.PushAsync(new QuestionDetailPage(selectedQuestion));
            }
        }

        private async void APIStuffButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CocktailPage());
        }
    }
}