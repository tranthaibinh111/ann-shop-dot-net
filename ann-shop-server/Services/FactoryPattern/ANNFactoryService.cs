using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop_server.Services
{
    public class ANNFactoryService
    {
        private static Dictionary<string, IANNService> _instance = new Dictionary<string, IANNService>();

        public static T getInstance<T>() where T: new()
        {
            IANNService instance;
            bool exist = _instance.TryGetValue(typeof(T).FullName, out instance);

            if (!exist)
            {
                instance = (IANNService)new T();
                _instance.Add(typeof(T).FullName, instance);
            }

            return (T)instance;
        }
    }
}