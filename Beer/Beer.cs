using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace Beer
{
    public class Beer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Abv { get; set; }

        public override string ToString() =>
            $"{Name} {Abv}";

        public void ValidateName()
        {
            if (Name is null)
            {
                throw new ArgumentNullException("Name må ikke være null.");

            }
            if (Name.Length < 3)
            {
                throw new ArgumentException("Name skal være mindst 3 tegn lang");

            }

        }

        public void ValidateAbv()
        {
            if (Abv < 0 || Abv > 67)
            {
                throw new ArgumentOutOfRangeException("Abv skal være imellem 0 og 67.");
            }
        }
    }
}
