namespace VideoplayerProject.API.Models.Output; 

public class IngredientOutputDTO {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Img { get; set; }
    public string Brand { get; set; }

    public decimal? Price { get; set; }
    
    public IngredientOutputDTO(int id, string name, string img, string brand, decimal? price) {
        Id = id;
        Name = name;
        Img = img;
        Brand = brand;
        Price = price;
    }
}