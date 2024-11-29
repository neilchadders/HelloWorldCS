namespace HelloWorld.Models{
    public class Computer
    {
        // private string _motherboard;
        public string Motherboard { get; set; } = ""; // declares a default property value
        public int CPUCores { get; set; }
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string VideoCard { get; set; } = ""; // declares a default property value

        public Computer() // this constructor makes sure that the properties are not null
        {
            if (VideoCard == null)
            {
                VideoCard = "";
            }
            if (Motherboard == null)
            {
                Motherboard = "";
            }
        }
    }
}