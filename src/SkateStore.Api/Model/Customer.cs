namespace SkateStore.Api.Model
{
    public class Customer : Base
    {
        protected Customer() { }
        public Customer(string name)
        {
            Name = name;

            this.Validate();
        }

        public void Update(string name)
        {
            Name = name;

            this.SetUpdated();
            this.Validate();
        }

        public string Name { get; private set; }        
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddNotification("Name", "Nome é obrigatório!");
        }
    }
}
