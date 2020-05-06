using FluentValidator;
using System;

namespace SkateStore.Api.Model
{
    public abstract class Base : Notifiable
    {
        public Base()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
        public int Id { get; private set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; private set; }

        protected void SetUpdated()
        {
            this.Updated = DateTime.Now;
        }
        protected abstract void Validate();

    }
}
