﻿using Newtonsoft.Json;
using NHibernate.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events.Entidades.Listeners
{
    public class UpdateListener : IPostUpdateEventListener
    {
        public void OnPostUpdate(PostUpdateEvent @event)
        {
            if (@event.Entity is Orders)
            {
                Orders order = (Orders)@event.Entity;
                Console.WriteLine($@"Update - {order.OrderID}");
            }
        }

        public Task OnPostUpdateAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
        {
            if (@event.Entity is Orders)
            {
                Orders order = (Orders)@event.Entity;
                return Task.Run(() => Console.WriteLine($@"Update - {order.OrderID}"));
            }
            else
            {
                return Task.Run(() => { });
            }
        }
    }
}
