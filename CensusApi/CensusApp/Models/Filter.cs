namespace CensusApp.Models
{
    public class Filter
    {
        public string Opertator { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name} {Opertator} {Value}";
        }

    }
}
