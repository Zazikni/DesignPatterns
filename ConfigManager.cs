using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //singleton
    internal class ConfigManager
    {
        /*
         * 
         * тут поля с какими то настройками для приложения
         * 
         */
        private static ConfigManager instance;
        public static ConfigManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigManager();
                    return instance;
                }
                else
                {
                    return instance;
                }
            }
            
        }
        private ConfigManager()
        {
            //инициализация класса какими-то данными
        }

    }
}
