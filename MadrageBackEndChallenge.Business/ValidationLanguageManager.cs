using System.Globalization;
using FluentValidation;
using FluentValidation.Resources;
using Microsoft.Extensions.Localization;

namespace MadrageBackEndChallenge.Business
{
    internal class ValidationLanguageManager : ILanguageManager
    {
        private readonly IStringLocalizer _stringLocalizer;

        public ValidationLanguageManager(IStringLocalizer stringLocalizer)
        {         
            _stringLocalizer = stringLocalizer;
            ValidatorOptions.DisplayNameResolver = (t, m, l) => stringLocalizer[m.Name].Value;
        }

        public bool Enabled { get; set; }
        public CultureInfo Culture { get; set; }

        public string GetString(string key, CultureInfo culture = null)
        {
            return _stringLocalizer[key].Value;
        }
    }
}