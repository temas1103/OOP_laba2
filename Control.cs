using System.Collections.Generic;
using SportLibrary;

namespace WindowsFormsApp1
{
    public class Control
    {
        public ISportFactory[] SportFactories { get; set; }

        public List<ISport> ApplicationObjects { get; set; }

        public Reflection Reflection { get; set; }

        public FormMain FormMain { get; set; }

        public Control(FormMain formMain)
        {
            SportFactories = new ISportFactory[] {
                new SportFactory(),
                new FunClubFactory(),
                new SportsmanFactory(),
                new FootballPlayerFactory(),
                new FootballTeamFactory()
            };
            ApplicationObjects = new List<ISport>();
            Reflection = new Reflection();
            FormMain = formMain;
        }

        public ISport CreateObject(int sportFactoryIndex)
        {
            ISportFactory sportFactory = SportFactories[sportFactoryIndex];
            return sportFactory.GetSport();
        }

        public void AddObject(ISport sportObject)
        {
            ApplicationObjects.Add(sportObject);
            FormMain.AddObjectToListBox(sportObject);
        }

        public void RemoveObject(ISport sportObject)
        {
            ApplicationObjects.Remove(sportObject);
            sportObject.Remove(ref sportObject);
        }

        public void CreateStartObjects()
        {
            Sport sportBiathlon = new Sport();
            sportBiathlon.Name = "Биатлон";
            sportBiathlon.IsTeamOrIndividual = TeamOrIndividual.Individual;
            sportBiathlon.IsSummerOrWinter = SummerOrWinter.Winter;
            sportBiathlon.IsOlimpicOrNonOlimpic = OlimpicOrNonOlimpic.Olimpic;
            ApplicationObjects.Add(sportBiathlon);

            FunClub funClubDasha = new FunClub();
            funClubDasha.Name = "Фаны Даши";
            funClubDasha.NumberOfMembers = 5000;
            funClubDasha.Slogan = "Вперед Беларусь!";
            ApplicationObjects.Add(funClubDasha);


            Sportsman sportsman = new Sportsman();
            sportsman.FirstName = "Дарья";
            sportsman.LastName = "Домрачева";
            sportsman.Country = "Беларусь";
            sportsman.Sport = sportBiathlon;
            sportsman.FunClub = funClubDasha;
            sportsman.SportsCategory = SportsCategory.MasterOfSports;
            sportsman.Parametres.Age = 27;
            sportsman.Parametres.Height = 180;
            sportsman.Parametres.Weight = 70;
            ApplicationObjects.Add(sportsman);

            Sport sportFootball = new Sport();
            sportFootball.Name = "Футбол";
            sportFootball.IsTeamOrIndividual = TeamOrIndividual.Team;
            sportFootball.IsSummerOrWinter = SummerOrWinter.Summer;
            sportFootball.IsOlimpicOrNonOlimpic = OlimpicOrNonOlimpic.Olimpic;
            ApplicationObjects.Add(sportFootball);

            FunClub funClubBarselona = new FunClub();
            funClubBarselona.Name = "Фаны Барселоны";
            funClubBarselona.NumberOfMembers = 10000;
            funClubBarselona.Slogan = "Viva Barsa";
            ApplicationObjects.Add(funClubBarselona);

            FootballTeam footballTeam1 = new FootballTeam();
            footballTeam1.Name = "Барселона";
            footballTeam1.Stadium = "Камп-Ноу";
            footballTeam1.Sponsor = "Viber";
            //footballTeam1.FunClub = funClubBarselona;
            footballTeam1.Championat = Championat.LaLiga;
            ApplicationObjects.Add(footballTeam1);

            FootballTeam footballTeam2 = new FootballTeam();
            footballTeam2.Name = "Арсенал";
            footballTeam2.Stadium = "Эмирэйтс";
            footballTeam2.Sponsor = "Emirates";
            footballTeam2.Championat = Championat.EnglishPremierLeague;
            ApplicationObjects.Add(footballTeam2);

            FootballPlayer footballPlayer = new FootballPlayer();
            footballPlayer.FirstName = "Леонель";
            footballPlayer.LastName = "Месси";
            footballPlayer.SportsCategory = SportsCategory.MasterOfSports;
            footballPlayer.Position = Position.Forward;
            footballPlayer.Sport = sportFootball;
            footballPlayer.FootballTeam = null;
            footballPlayer.Country = "Аргентина";
            footballPlayer.Parametres.Age = 31;
            footballPlayer.Parametres.Height = 176;
            footballPlayer.Parametres.Weight = 75;
            ApplicationObjects.Add(footballPlayer);

            FootballPlayer footballPlayer2 = new FootballPlayer();
            footballPlayer2.FirstName = "Серхио";
            footballPlayer2.LastName = "Бускетс";
            footballPlayer2.SportsCategory = SportsCategory.MasterOfSports;
            footballPlayer2.Position = Position.Midfielder;
            footballPlayer2.FootballTeam = footballTeam1;
            footballPlayer2.Sport = sportFootball;
            footballPlayer2.Country = "Испания";
            footballPlayer2.Parametres.Age = 33;
            footballPlayer2.Parametres.Height = 181;
            footballPlayer2.Parametres.Weight = 85;
            ApplicationObjects.Add(footballPlayer2);

            FootballPlayer footballPlayer3 = new FootballPlayer();
            footballPlayer3.FirstName = "Виктор";
            footballPlayer3.LastName = "Вальдес";
            footballPlayer3.SportsCategory = SportsCategory.MasterOfSports;
            footballPlayer3.Position = Position.GoalKeeper;
            footballPlayer3.FootballTeam = footballTeam1;
            footballPlayer3.Country = "Испания";
            footballPlayer3.Sport = sportFootball;
            footballPlayer3.Parametres.Age = 40;
            footballPlayer3.Parametres.Height = 189;
            footballPlayer3.Parametres.Weight = 77;
            ApplicationObjects.Add(footballPlayer3);

            FootballPlayer footballPlayer4 = new FootballPlayer();
            footballPlayer4.FirstName = "Александр";
            footballPlayer4.LastName = "Глеб";
            footballPlayer4.SportsCategory = SportsCategory.MasterOfSports;
            footballPlayer4.Position = Position.Midfielder;
            footballPlayer4.FootballTeam = footballTeam2;
            footballPlayer4.Country = "Беларусь";
            footballPlayer4.Sport = sportFootball;
            footballPlayer4.Parametres.Age = 36;
            footballPlayer4.Parametres.Height = 178;
            footballPlayer4.Parametres.Weight = 72;
            ApplicationObjects.Add(footballPlayer4);
        }
    }
}
