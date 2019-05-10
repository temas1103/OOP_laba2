using System.Collections.Generic;
using FieldNameAtrributes;

namespace FootballLibrary
{
    public enum Championat
    {
        [FieldNameAtrribute("АПЛ")]
        EnglishPremierLeague = 1,
        [FieldNameAtrribute("ЛИГА 1")]
        Ligue1,
        [FieldNameAtrribute("ЛА ЛИГА")]
        LaLiga,
        [FieldNameAtrribute("БУНДЕСЛИГА")]
        BundesLiga,
        [FieldNameAtrribute("CЕРИЯ А")]
        SerieA,
        [FieldNameAtrribute("РПЛ")]
        RussianPremierLeague,
        [FieldNameAtrribute("БПЛ")]
        BelarussianPremierLeague
    }

    public class FootballTeam : IFootball
    {
        [FieldNameAtrribute("Название")]
        public string Name { get; set; }

        [FieldNameAtrribute("Стадион")]
        public string Stadium { get; set; }

        [FieldNameAtrribute("Чемпионат")]
        public Championat Championat { get; set; }

        [FieldNameAtrribute("Спонсор")]
        public string Sponsor { get; set; }

        [FieldNameAtrribute("Игроки")]
        public List<FootballPlayer> FootballPlayers { get; set; }

        public FootballTeam()
        {
            FootballPlayers = new List<FootballPlayer>();
        }

        public void AddFootballPlayer(FootballPlayer footballPlayer)
        {
            FootballPlayers.Add(footballPlayer);
        }

        public void RemoveFootballPlayer(FootballPlayer footballPlayer)
        {
            FootballPlayers.Remove(footballPlayer);
        }

        public void Remove(ref IFootball footballTeam)
        {
            footballTeam = null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
