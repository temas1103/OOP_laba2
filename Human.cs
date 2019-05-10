using FieldNameAtrributes;

namespace FootballLibrary
{
    public class Human : IFootball
    {

        [FieldNameAtrribute("Имя")]
        public string FirstName { get; set; }

        [FieldNameAtrribute("Фамилия")]
        public string LastName { get; set; }

        [FieldNameAtrribute("Параметры")]
        public Parametres Parametres { get; set; }

        public Human()
        {
            Parametres = new Parametres();
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public void Remove(ref IFootball obj)
        {
            obj = null;
        }
    }
}