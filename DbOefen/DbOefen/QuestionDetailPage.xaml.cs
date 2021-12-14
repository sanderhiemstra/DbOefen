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
    public partial class QuestionDetailPage : ContentPage
    {
        Question question;
        public QuestionDetailPage(Question selectedQuestion)
        {
            InitializeComponent();
            question = selectedQuestion;

            IdLabel.Text = question.Id.ToString();
            QuestionBodyEntry.Text = question.QuestionBody;
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            int updatedRows;
            question.QuestionBody = QuestionBodyEntry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Question>();
                updatedRows = sQLiteConnection.Update(question);
            }

            if (updatedRows > 0)
            {
                _ = DisplayAlert("Gelukt", "Je vraag is goed aangepast.", "Ok");
            }
            else
            {
                _ = DisplayAlert("Ah, jammer! Er ging iets fout", "Je vraag is NIET aangepast.", "Ok");
            }

            await Navigation.PopAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            int deletedRows;

            using(SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Question>();
                deletedRows = sQLiteConnection.Delete(question);
            }

            if(deletedRows > 0)
            {
                _ = DisplayAlert("Gelukt", "Je vraag is verwijderd.", "Ok");
            }
            else
            {
                _ = DisplayAlert("Gelukt", "Je vraag is goed aangepast.", "Ok");
            }

            await Navigation.PopAsync();
        }
    }
}