using FieldNameAtrributes;

namespace FootballLibrary
{
    public enum SportsCategory
    {
        [FieldNameAtrribute("Третий")]
        Third = 1,
        [FieldNameAtrribute("Второй")]
        Second,
        [FieldNameAtrribute("Первый")]
        First,
        [FieldNameAtrribute("КМС")]
        CandidateMasterOfSports,
        [FieldNameAtrribute("МС")]
        MasterOfSports
    }

    public class Sportsman : Human, IFootball
    {
        [FieldNameAtrribute("Спорт")]
        public string Sport { get; set; }

        [FieldNameAtrribute("Страна")]
        public string Country { get; set; }

        [FieldNameAtrribute("Разряд")]
        public SportsCategory SportsCategory { get; set; }

        public Sportsman()
        {
        }

        public Sportsman(string sport)
        {
            Sport = sport;
        }
    }
}
