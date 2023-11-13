namespace VideoplayerProject.API.Models;

public class IngredientInputDTO {
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Img { get; set; }
    
    public decimal? Price { get; set; }
    
    public IngredientInputDTO(string name, string brand, string img, decimal? price) {
        Name = name;
        Brand = brand;
        Img = img;
        Price = price;
    }
}