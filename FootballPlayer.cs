
using FieldNameAtrributes;

namespace FootballLibrary
{
    public enum Position
    {
        [FieldNameAtrribute("Вратарь")]
        GoalKeeper = 1,
        [FieldNameAtrribute("Защитник")]
        Defender,
        [FieldNameAtrribute("Полузащитник")]
        Midfielder,
        [FieldNameAtrribute("Нападающий")]
        Forward
    }

    public class FootballPlayer : Sportsman, IFootball
    {
        private FootballTeam _footballTeam;

        [FieldNameAtrribute("Амплуа")]
        public Position Position { get; set; }

        [FieldNameAtrribute("Команда")]
        public FootballTeam FootballTeam
        {
            get { return _footballTeam; }
            set
            {
                if (_footballTeam != null)
                {
                    _footballTeam.RemoveFootballPlayer(this);
                }

                if (value != null)
                {
                    _footballTeam = value;
                    _footballTeam.AddFootballPlayer(this);
                }
            }
        }

        public FootballPlayer() : base("Футбол")
        {
        }

        public new void Remove(ref IFootball footballPlayer)
        {
            if (_footballTeam != null)
            {
                _footballTeam.RemoveFootballPlayer((FootballPlayer)footballPlayer);
            }
            footballPlayer = null;
        }
    }
}