namespace ECommerceApp.Models
{
    public class Cereal
    {
        public string Name { get; set; }
        public string Mfr { get; set; }
        public CerealType Type { get; set; }
        public int Calories { get; set; }
        public string Protein { get; set; }
        public string Fat { get; set; }
        public string Sodium { get; set; }
        public string Fiber { get; set; }
        public string Carbo { get; set; }
        public string Sugars { get; set; }
        public string Potass { get; set; }
        public string Vitamins { get; set; }
        public string Shelf { get; set; }
        public decimal Weight { get; set; }
        public decimal Cups { get; set; }
        public string Rating { get; set; }
    }

    public enum CerealType
    {
        Cold,
        Hot,
    }
}