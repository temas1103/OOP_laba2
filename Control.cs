using FootballLibrary;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public class Control
    {
        /* public IFootball CurrObject
         {
             get { return _currObject; }
             set { _currObject = value; }
         }*/
        public IFootball CurrObject { get; set; }

        public IFootballFactory[] FootballFactories { get; set; }

        public List<IFootball> ApplicationObjects { get; set; }

        public Reflection Reflection { get; set; }

        public object CompositionObject { get; set; }


        public Control()
        {
            FootballFactories = new IFootballFactory[] {
                new HumanFootballFactory(),
                new SportsmanFootballFactory(),
                new FootballPlayerFootballFactory(),
                new FootballTeamFootballFactory()
            };
            ApplicationObjects = new List<IFootball>();
            Reflection = new Reflection();
        }

        public void CreateObject(int footballFactoryIndex)
        {
            IFootballFactory footballFactory = FootballFactories[footballFactoryIndex];
            CurrObject = footballFactory.GetFootball();
        }

        public void AddObject(IFootball obj)
        {
            ApplicationObjects.Add(obj);
        }

        public void RemoveObject(IFootball obj)
        {
            ApplicationObjects.Remove(obj);
            obj.Remove(ref obj);
        }

        public void CreateStartObjects()
        {
            Human human = new Human();
            human.FirstName = "Артем";
            human.LastName = "Будник";
            human.Parametres.Age = 19;
            human.Parametres.Height = 176;
            human.Parametres.Weight = 60;
            AddObject(human);

            Sportsman sportsman = new Sportsman();
            sportsman.FirstName = "Дарья";
            sportsman.LastName = "Домрачева";
            sportsman.Country = "Беларусь";
            sportsman.Sport = "Биатлон";
            sportsman.SportsCategory = SportsCategory.MasterOfSports;
            sportsman.Parametres.Age = 27;
            sportsman.Parametres.Height = 180;
            sportsman.Parametres.Weight = 70;
            AddObject(sportsman);

            FootballTeam footballTeam1 = new FootballTeam();
            footballTeam1.Name = "Барселона";
            footballTeam1.Stadium = "Камп-Ноу";
            footballTeam1.Sponsor = "Viber";
            footballTeam1.Championat = Championat.LaLiga;
            AddObject(footballTeam1);

            FootballTeam footballTeam2 = new FootballTeam();
            footballTeam2.Name = "Арсенал";
            footballTeam2.Stadium = "Эмирэйтс";
            footballTeam2.Sponsor = "Emirates";
            footballTeam2.Championat = Championat.EnglishPremierLeague;
            AddObject(footballTeam2);

            FootballPlayer footballPlayer = new FootballPlayer();
            footballPlayer.FirstName = "Леонель";
            footballPlayer.LastName = "Месси";
            footballPlayer.SportsCategory = SportsCategory.MasterOfSports;
            footballPlayer.Position = Position.Forward;
            footballPlayer.FootballTeam = null;
            footballPlayer.Country = "Аргентина";
            footballPlayer.Parametres.Age = 31;
            footballPlayer.Parametres.Height = 176;
            footballPlayer.Parametres.Weight = 75;
            AddObject(footballPlayer);

            FootballPlayer footballPlayer2 = new FootballPlayer();
            footballPlayer2.FirstName = "Серхио";
            footballPlayer2.LastName = "Бускетс";
            footballPlayer2.SportsCategory = SportsCategory.MasterOfSports;
            footballPlayer2.Position = Position.Midfielder;
            footballPlayer2.FootballTeam = footballTeam1;
            footballPlayer2.Country = "Испания";
            footballPlayer2.Parametres.Age = 33;
            footballPlayer2.Parametres.Height = 181;
            footballPlayer2.Parametres.Weight = 85;
            AddObject(footballPlayer2);

            FootballPlayer footballPlayer3 = new FootballPlayer();
            footballPlayer3.FirstName = "Виктор";
            footballPlayer3.LastName = "Вальдес";
            footballPlayer3.SportsCategory = SportsCategory.MasterOfSports;
            footballPlayer3.Position = Position.GoalKeeper;
            footballPlayer3.FootballTeam = footballTeam1;
            footballPlayer3.Country = "Испания";
            footballPlayer3.Parametres.Age = 40;
            footballPlayer3.Parametres.Height = 189;
            footballPlayer3.Parametres.Weight = 77;
            AddObject(footballPlayer3);

            FootballPlayer footballPlayer4 = new FootballPlayer();
            footballPlayer4.FirstName = "Александр";
            footballPlayer4.LastName = "Глеб";
            footballPlayer4.SportsCategory = SportsCategory.MasterOfSports;
            footballPlayer4.Position = Position.Midfielder;
            footballPlayer4.FootballTeam = footballTeam2;
            footballPlayer4.Country = "Беларусь";
            footballPlayer4.Parametres.Age = 36;
            footballPlayer4.Parametres.Height = 178;
            footballPlayer4.Parametres.Weight = 72;
            AddObject(footballPlayer4);

            FootballPlayer footballPlayer5 = new FootballPlayer();
            footballPlayer5.FirstName = "Тьерри";
            footballPlayer5.LastName = "Анри";
            footballPlayer5.SportsCategory = SportsCategory.MasterOfSports;
            footballPlayer5.Position = Position.Forward;
            footballPlayer5.FootballTeam = footballTeam2;
            footballPlayer5.Country = "Франция";
            footballPlayer5.Parametres.Age = 35;
            footballPlayer5.Parametres.Height = 181;
            footballPlayer5.Parametres.Weight = 81;
            AddObject(footballPlayer5);
        }
    }
}