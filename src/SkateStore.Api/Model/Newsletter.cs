using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateStore.Api.Model
{
    public class Newsletter : Base
    {
        public string EmailAddress { get; private set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
