namespace AdresBeheerProject.REST.Model.Input {
    public class GemeenteRESToutputDTO {
        public GemeenteRESToutputDTO(string id, int niscode, string name, int aantalStraten, List<string> straten) {
            Id = id;
            Niscode = niscode;
            Name = name;
            AantalStraten = aantalStraten;
            Straten = straten;
        }

        public string Id { get; set; }

        public int Niscode { get; set; }

        public string Name { get; set; }

        public int AantalStraten { get; set; }

        public List<string> Straten { get; set; }
       
    }
}
