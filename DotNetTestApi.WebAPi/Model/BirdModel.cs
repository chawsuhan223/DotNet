namespace DotNetTestApi.WebAPi.Model
{


        public class BirdDataModel//Data Model
        {
            public int Id { get; set; }
            public string BirdMyanmarName { get; set; }
            public string Description { get; set; }
            public string ImagePath { get; set; }

    }
    public class BirdViewModel//View Model
    {
        public int BirdId { get; set; }
        public string BirdName { get; set; }
        public string Des { get; set; }
        public string PhotoURL { get; set; }
    }
}
