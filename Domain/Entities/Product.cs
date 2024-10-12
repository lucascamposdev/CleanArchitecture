using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock {  get; private set; }
        public string? Image {  get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description ,decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Name is too short.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description, description is required.");

            DomainExceptionValidation.When(description.Length < 3,
                "Description is too short.");

            DomainExceptionValidation.When(price < 0,
                "Invalid price, min 0.");

            DomainExceptionValidation.When(stock < 0,
                "Invalid stock, min 0.");

            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid image name, too long, max 250 characters.");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }
    }
}
