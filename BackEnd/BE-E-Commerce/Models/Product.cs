namespace BE_E_Commerce.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    #region Book attribute
    public Category Category { get; set; }
    public Partner Partner { get; set; }
    public int Page { get; set; }
    public float Size { get; set; }
    public string Author { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }
    #endregion
    
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
} 