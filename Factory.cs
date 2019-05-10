namespace FootballLibrary
{
    public interface IFootball
    {
        void Remove(ref IFootball obj);
    }

    public interface IFootballFactory
    {
        IFootball GetFootball();
    }

    public class HumanFootballFactory : IFootballFactory
    {
        public IFootball GetFootball()
        {
            return new Human();
        }

        public override string ToString()
        {
            return "Человек";
        }
    }

    public class SportsmanFootballFactory : IFootballFactory
    {
        public IFootball GetFootball()
        {
            return new Sportsman();
        }

        public override string ToString()
        {
            return "Спортсмен";
        }
    }

    public class FootballPlayerFootballFactory : IFootballFactory
    {
        public IFootball GetFootball()
        {
            return new FootballPlayer();
        }

        public override string ToString()
        {
            return "Футболист";
        }
    }

    public class FootballTeamFootballFactory : IFootballFactory
    {
        public IFootball GetFootball()
        {
            return new FootballTeam();
        }

        public override string ToString()
        {
            return "Футбольная команда";
        }
    }
}
