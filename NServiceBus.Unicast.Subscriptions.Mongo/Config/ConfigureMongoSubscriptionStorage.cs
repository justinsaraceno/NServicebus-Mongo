﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NServiceBus.Unicast.Subscriptions.Mongo.Config
{
    public static class ConfigureMongoSubscriptionStorage
    {
        public static Configure MongoSubscriptionStorage(this Configure config)
        {
            config.Configurer.ConfigureComponent<SubscriptionStorage>(DependencyLifecycle.InstancePerCall);

            return config;
        }
    }
}
