using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Models.Entities;

namespace ShopOnline.Api.Data;

public class ShopOnlineSeeder
{
    private readonly ShopOnlineDbContext _dbContext;

    private readonly IReadOnlyList<Product> _products;
    private readonly IReadOnlyList<User> _users;
    private readonly IReadOnlyList<Cart> _carts;
    private readonly IReadOnlyList<ProductCategory> _productCategories;

    public ShopOnlineSeeder(ShopOnlineDbContext dbContext)
    {
        _dbContext = dbContext;

        _productCategories = GetProductCategories();
        _products = GetProducts();
        _users = GetUsers();
        _carts = GetCarts();
    }

    public IReadOnlyList<Product> GetProducts() => new List<Product>()
    {
        //Beauty Category
        new Product
        {
            Name = "Glossier - Beauty Kit",
            Description = "A kit provided by Glossier, containing skin care, hair care and makeup products",
            ImageURL = "/Images/Beauty/Beauty1.png",
            Price = 100,
            Qty = 100,
            ProductCategory = _productCategories.Where(c => c.Name == "Beauty").FirstOrDefault()
        },
        new Product
        {
            Name = "Curology - Skin Care Kit",
            Description = "A kit provided by Curology, containing skin care products",
            ImageURL = "/Images/Beauty/Beauty2.png",
            Price = 50,
            Qty = 45,
            ProductCategory = _productCategories.Where(c => c.Name == "Beauty").FirstOrDefault()
        },
        new Product
        {
            Name = "Cocooil - Organic Coconut Oil",
            Description = "A kit provided by Curology, containing skin care products",
            ImageURL = "/Images/Beauty/Beauty3.png",
            Price = 20,
            Qty = 30,
            ProductCategory = _productCategories.Where(c => c.Name == "Beauty").FirstOrDefault()
        },
        new Product
        {
            Name = "Schwarzkopf - Hair Care and Skin Care Kit",
            Description = "A kit provided by Schwarzkopf, containing skin care and hair care products",
            ImageURL = "/Images/Beauty/Beauty4.png",
            Price = 50,
            Qty = 60,
            ProductCategory = _productCategories.Where(c => c.Name == "Beauty").FirstOrDefault()
        },
        new Product
        {
            Name = "Skin Care Kit",
            Description = "Skin Care Kit, containing skin care and hair care products",
            ImageURL = "/Images/Beauty/Beauty5.png",
            Price = 30,
            Qty = 85,
            ProductCategory = _productCategories.Where(c => c.Name == "Beauty").FirstOrDefault()
        },


        //Electronics Category
        new Product
        {
            Name = "Air Pods",
            Description = "Air Pods - in-ear wireless headphones",
            ImageURL = "/Images/Electronic/Electronics1.png",
            Price = 100,
            Qty = 120,
            ProductCategory = _productCategories.Where(c => c.Name == "Electronics").FirstOrDefault()
        },
        new Product
        {
            Name = "On-ear Golden Headphones",
            Description = "On-ear Golden Headphones - these headphones are not wireless",
            ImageURL = "/Images/Electronic/Electronics2.png",
            Price = 40,
            Qty = 200,
            ProductCategory = _productCategories.Where(c => c.Name == "Electronics").FirstOrDefault()
        },
        new Product
        {
            Name = "On-ear Black Headphones",
            Description = "On-ear Black Headphones - these headphones are not wireless",
            ImageURL = "/Images/Electronic/Electronics3.png",
            Price = 40,
            Qty = 300,
            ProductCategory = _productCategories.Where(c => c.Name == "Electronics").FirstOrDefault()
        },
        new Product
        {
            Name = "Sennheiser Digital Camera with Tripod",
            Description = "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod",
            ImageURL = "/Images/Electronic/Electronic4.png",
            Price = 600,
            Qty = 20,
            ProductCategory = _productCategories.Where(c => c.Name == "Electronics").FirstOrDefault()
        },
        new Product
        {
            Name = "Canon Digital Camera",
            Description = "Canon Digital Camera - High quality digital camera provided by Canon",
            ImageURL = "/Images/Electronic/Electronic5.png",
            Price = 500,
            Qty = 15,
            ProductCategory = _productCategories.Where(c => c.Name == "Electronics").FirstOrDefault()
        },
        new Product
        {
            Name = "Nintendo Gameboy",
            Description = "Gameboy - Provided by Nintendo",
            ImageURL = "/Images/Electronic/technology6.png",
            Price = 100,
            Qty = 60,
            ProductCategory = _productCategories.Where(c => c.Name == "Electronics").FirstOrDefault()
        },


        //Furniture Category
		new Product
        {
            Name = "Black Leather Office Chair",
            Description = "Very comfortable black leather office chair",
            ImageURL = "/Images/Furniture/Furniture1.png",
            Price = 50,
            Qty = 212,
            ProductCategory = _productCategories.Where(c => c.Name == "Furniture").FirstOrDefault()
        },
        new Product
        {
            Name = "Pink Leather Office Chair",
            Description = "Very comfortable pink leather office chair",
            ImageURL = "/Images/Furniture/Furniture2.png",
            Price = 50,
            Qty = 112,
            ProductCategory = _productCategories.Where(c => c.Name == "Furniture").FirstOrDefault()
        },
        new Product
        {
            Name = "Lounge Chair",
            Description = "Very comfortable lounge chair",
            ImageURL = "/Images/Furniture/Furniture3.png",
            Price = 70,
            Qty = 90,
            ProductCategory = _productCategories.Where(c => c.Name == "Furniture").FirstOrDefault()
        },
        new Product
        {
            Name = "Silver Lounge Chair",
            Description = "Very comfortable Silver lounge chair",
            ImageURL = "/Images/Furniture/Furniture4.png",
            Price = 120,
            Qty = 95,
            ProductCategory = _productCategories.Where(c => c.Name == "Furniture").FirstOrDefault()
        },
        new Product
        {
            Name = "Porcelain Table Lamp",
            Description = "White and blue Porcelain Table Lamp",
            ImageURL = "/Images/Furniture/Furniture6.png",
            Price = 15,
            Qty = 100,
            ProductCategory = _productCategories.Where(c => c.Name == "Furniture").FirstOrDefault()
        },
        new Product
        {
            Name = "Office Table Lamp",
            Description = "Office Table Lamp",
            ImageURL = "/Images/Furniture/Furniture7.png",
            Price = 20,
            Qty = 73,
            ProductCategory = _productCategories.Where(c => c.Name == "Furniture").FirstOrDefault()
        },


        //Shoes Category
		new Product
        {
            Name = "Puma Sneakers",
            Description = "Comfortable Puma Sneakers in most sizes",
            ImageURL = "/Images/Shoes/Shoes1.png",
            Price = 100,
            Qty = 50,
            ProductCategory = _productCategories.Where(c => c.Name == "Shoes").FirstOrDefault()
        },
        new Product
        {
            Name = "Colorful Trainers",
            Description = "Colorful trainsers - available in most sizes",
            ImageURL = "/Images/Shoes/Shoes2.png",
            Price = 150,
            Qty = 60,
            ProductCategory = _productCategories.Where(c => c.Name == "Shoes").FirstOrDefault()
        },
        new Product
        {
            Name = "Blue Nike Trainers",
            Description = "Blue Nike Trainers - available in most sizes",
            ImageURL = "/Images/Shoes/Shoes3.png",
            Price = 200,
            Qty = 70,
            ProductCategory = _productCategories.Where(c => c.Name == "Shoes").FirstOrDefault()
        },
        new Product
        {
            Name = "Colorful Hummel Trainers",
            Description = "Colorful Hummel Trainers - available in most sizes",
            ImageURL = "/Images/Shoes/Shoes4.png",
            Price = 120,
            Qty = 120,
            ProductCategory = _productCategories.Where(c => c.Name == "Shoes").FirstOrDefault()
        },
        new Product
        {
            Name = "Red Nike Trainers",
            Description = "Red Nike Trainers - available in most sizes",
            ImageURL = "/Images/Shoes/Shoes5.png",
            Price = 200,
            Qty = 100,
            ProductCategory = _productCategories.Where(c => c.Name == "Shoes").FirstOrDefault()
        },
        new Product
        {
            Name = "Birkenstock Sandles",
            Description = "Birkenstock Sandles - available in most sizes",
            ImageURL = "/Images/Shoes/Shoes6.png",
            Price = 50,
            Qty = 150,
            ProductCategory = _productCategories.Where(c => c.Name == "Shoes").FirstOrDefault()
        }
    };

    private IReadOnlyList<User> GetUsers() => new List<User>
    {
        new User { Name = "Bob" },
        new User { Name = "Sarah" }
    };

    public IReadOnlyList<Cart> GetCarts() => new List<Cart>
    {
        new Cart { User = _users.FirstOrDefault() },
        new Cart { User = _users.Skip(1).FirstOrDefault() }
    };

    public IReadOnlyList<ProductCategory> GetProductCategories() => new List<ProductCategory>
    {
        new ProductCategory { Name = "Beauty" },
        new ProductCategory { Name = "Furniture" },
        new ProductCategory { Name = "Electronics" },
        new ProductCategory { Name = "Shoes" }
    };

    public void SeedInitialData(bool seed)
    {

        if (seed)
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.Migrate();
            _dbContext.Database.EnsureCreated();

            _dbContext.AddRange(_products);
            _dbContext.AddRange(_productCategories);
            _dbContext.AddRange(_users);
            _dbContext.AddRange(_carts);

            _dbContext.SaveChanges();
        }
    }
}
