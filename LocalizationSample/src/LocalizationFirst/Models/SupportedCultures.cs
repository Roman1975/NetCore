using System.Globalization;

namespace LocalizationSample.Models
{
    public sealed class SupportedCultures
    {
        static CultureInfo[] _items = new[]
                {
                    new CultureInfo("uk-UA"),
                    new CultureInfo("en-US"),
                };

        public static CultureInfo[] Items
        {
            get
            {
                return _items;
            }
        }
    }
}
