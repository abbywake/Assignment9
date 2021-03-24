using Assignment9.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    public class SessionDisplay : Display
    {
       

        public static Display GetDisplay(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionDisplay cart = session?.GetJson<SessionDisplay>("Cart")
                ?? new SessionDisplay();
            cart.Session = session;
            return cart;

        }

        [JsonIgnore]
        public ISession Session { get; private set; }

        public override void AddItem(addMovie addM, int quantity)
        {
            base.AddItem(addM, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(addMovie addM)
        {
            base.RemoveLine(addM);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
