namespace VideoplayerProject.API.Models.Output; 

public class UtensilsOutputDTO {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Img { get; set; }

    public UtensilsOutputDTO(int id, string name, string img) {
        Id = id;
        Name = name;
        Img = img;
    }
}