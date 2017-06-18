namespace Cilesta.Web.Katarina.Implimentation
{
    using System.Globalization;
    using System.Web.ModelBinding;
    using Castle.Windsor;
    using Cilesta.Web.Interfaces;

    public class CilestaValueProvider : ICilestaValueProvider
    {
        public IWindsorContainer Container { get; set; }

        public bool ContainsPrefix(string prefix)
        {
            return true;
        }

        public ValueProviderResult GetValue(string key)
        {
            if (this.ContainsPrefix(key))
            {
                return new ValueProviderResult(string.Empty, null, CultureInfo.InvariantCulture);
            }

            return null;
        }
    }
}
