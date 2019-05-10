using FieldNameAtrributes;

namespace FootballLibrary
{
    public class Parametres
    {
        [FieldNameAtrribute("Возраст")]
        public int Age { get; set; }

        [FieldNameAtrribute("Рост")]
        public int Height { get; set; }

        [FieldNameAtrribute("Вес")]
        public int Weight { get; set; }
    }
}