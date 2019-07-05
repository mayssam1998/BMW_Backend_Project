using System;
using System.Collections.Generic;

namespace SuS.Common
{
    public interface IRabbitMqSender
    {
        Boolean PushMessage(string queue, string message, IDictionary<string, object> arguments);
    }
}