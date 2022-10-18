using System;

namespace TwitterFaker.Services
{
    public static class NumberFormat
    {
        public static string KiloFormat(this int num)
        {
            if (num >= 100000000)
            { 
                return (num / 1000000f).ToString("#,0M");
            }

            if (num >= 10000000)
            { 
                return (num / 1000000f).ToString("0.#") + "M";
            }

            if (num >= 100000)
            { 
                return (num / 1000f).ToString("#,0K");
            }

            if (num >= 10000) 
            { 
                return (num / 1000f).ToString("0.#") + "K";
            }
            return num.ToString("#,0");
        }
    }
}
