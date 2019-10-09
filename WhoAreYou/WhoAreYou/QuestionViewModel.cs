using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WhoAreYou
{
    class QuestionViewModel : INotifyPropertyChanged
    {
        public double totalScore = 0.00;
        public double score1 = 0, score2 = 0, score3 = 0, score4 = 0, score5 = 0;
        public string name;
        private double age = 0;
        private string character = "";
        public event PropertyChangedEventHandler PropertyChanged;

        

        public QuestionViewModel()
        {
            GetCharacterCommand = new Command(async () => await GetScore());
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string question1 = "Are you: " +
            " 1) Adventurous" +
            " 2) Relaxed" +
            " 3) Creative" +
            " 4) Secretive";

        public string question2 = "Are you: " +
            " 1) A Leader" +
            " 2) A Follower" +
            " 3) An Inventor" +
            " 4) A Conqueror";

        public string question3 = "Are you: " +
            " 1) No One" +
            " 2) Hunted" +
            " 3) Well Known" +
            " 4) Hidden";

        public string question4 = "What is your first name?";

        public string question5 = "How old are you?";

        public string Question1
        {
            get { return question1; }
            set { question1 = value; }
        }

        public string Question2
        {
            get { return question2; }
            set { question2 = value; }
        }

        public string Question3
        {
            get { return question3; }
            set { question3 = value; }
        }

        public string Question4
        {
            get { return question4; }
            set { question4 = value; }
        }

        public string Question5
        {
            get { return question5; }
            set { question5 = value; }
        }
    
        public double TotalScore
        {
            get { return totalScore; }
            set { Score1 = value;  }
        }

        public double Score1
        {
            get { return score1; }
            set{
                if (value > 0 && value < 5)
                {
                    score1 = value;
                    OnPropertyChanged("Score1");
                    OnPropertyChanged("Result");
                }
            }
        }

        public double Score2
        {
            get { return score2; }
            set{
                if (value > 0 && value < 5)
                {
                    score2 = value;
                    OnPropertyChanged("Score2");
                    OnPropertyChanged("Result");
                }
            }
        }

        public double Score3
        {
            get { return score3; }
            set
            {
                if (value > 0 && value < 5)
                {
                    score3 = value;
                    OnPropertyChanged("Score3");
                    OnPropertyChanged("Result");
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                    name = value;
                    OnPropertyChanged("Score4");
                    OnPropertyChanged("Result");
               
            }
        }

        public double Score5
        {
            get { return score5; }
            set
            {
                if (value <= 20)
                {
                    age = 1;
                }
                else if (value > 21 && value < 40)
                {
                    age = 2;
                }
                else if (value <= 40)
                {
                    age = 3;
                }
                else if (value > 40)
                {
                    age = 4;
                }

                score5 = value;


                OnPropertyChanged("Score5");
                OnPropertyChanged("Result");

            }
        }


        public double Result
        {
            get { return Score1 + Score2 + Score3 + Age; }
        }

        public Command GetCharacterCommand { get; }
        public string Character { get => character; set => character = value; }
        public double Age { get => age; set => age = value; }

        async Task GetScore()
        {
            totalScore = Score1 + Score2 + Score3 + Age;

            if (totalScore < 5)
            {
                Character = "Ezio the main assassin and ancestor to desmond. You lead a large group of assassins in your conquest to bring justice to Italy and restore the Assassin's Order. You biggest nemisis is Vivere de Pazzi";
            }
            else if (totalScore >= 5 && totalScore <= 6)
            {
                Character = "Desmond you are hunted by the templar order and visit your ancestors memories in order to learn how to save the world from being destroyed.";
            }
            else if (totalScore > 7 && totalScore <= 11)
            {
                Character = "Leonardo Da Vinci, you are a gifted inventor and helped Ezio create many of the tools he used to restore order.";
            }
            else if (totalScore > 12 && totalScore <= 16)
            {
                Character = "Viere de Pazzi, you want to destroy the Assassin's Order and control the people of Italy.";
            }
            await Application.Current.MainPage.DisplayAlert(Name + " You Are", Character, "OK");
        }
    }
}
