namespace FinalTask.ComputerScience.Logic.Models
{
    public class Music
    {
        public Music(string Id)
        {
            this.Id = Id;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
    }
}
