using FluentValidator;
using System;

namespace SkateStore.Products.Domain.Entities
{
    public class Product : Notifiable
    {
        protected Product() { }
        public Product(string name, string description, decimal price, string photo)
        {
            Name = name;
            Description = description;
            Price = price;
            Photo = photo;
            Created = DateTime.Now;
            Updated = DateTime.Now;

            this.Validate();
        }

        public void Update(string name, string description, decimal price, string photo)
        {
            Name = name;
            Description = description;
            Price = price;
            Photo = photo;
            Updated = DateTime.Now;

            this.Validate();
        }

        protected void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddNotification("Name", "Nome é obrigatório!");

            if (string.IsNullOrEmpty(Description))
                AddNotification("Description", "Descrição é obrigatório!");

            if (Price < 1)
                AddNotification("Price", "Preço invalido!");
        }
        public int Id { get; private set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string Photo { get; private set; }
    }
}
