namespace SkateStore.Api.Model
{
    public class Product : Base
    {
        protected Product() { }
        public Product(string name, string description, decimal price, string photo)
        {         
            Name = name;
            Description = description;
            Price = price;
            Photo = photo;

            this.Validate();
        }

        public void Update(string name, string description, decimal price, string photo)
        {
            Name = name;
            Description = description;
            Price = price;
            Photo = photo;

            this.SetUpdated();
            this.Validate();
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddNotification("Name", "Nome é obrigatório!");

            if(string.IsNullOrEmpty(Description))
                AddNotification("Description", "Descrição é obrigatório!");

            if (Price < 1)
                AddNotification("Price", "Preço invalido!");
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string Photo { get; private set; }
    }
}
