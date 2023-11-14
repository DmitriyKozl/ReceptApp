namespace VideoplayerProject.API.Models;

public class IngredientInputDTO {
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Img { get; set; }
    
    public decimal? Price { get; set; }
    
    public int IngredientId { get; set; }
    
    public IngredientInputDTO(int ingredientId,string name, string brand, string img, decimal? price) {
        IngredientId = ingredientId;
        Name = name;
        Brand = brand;
        Img = img;
        Price = price;
    }
}