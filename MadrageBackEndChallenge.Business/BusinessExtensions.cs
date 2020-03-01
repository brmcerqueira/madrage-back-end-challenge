using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Resources;
using LightInject;
using MadrageBackEndChallenge.Domain;
using MadrageBackEndChallenge.Domain.Utils;

namespace MadrageBackEndChallenge.Business
{
    public static class BusinessExtensions
    {       
        public static void AdjustValidationLanguageManager(this IServiceFactory serviceFactory)
        {
            ValidatorOptions.LanguageManager = serviceFactory.GetInstance<ILanguageManager>();
        }

        internal static void Check<T>(this IValidator<T> validator, T instance)
        {
            var validationResult = validator.Validate(instance);

            if (!validationResult.IsValid)
            {
                throw new Domain.Exceptions.ValidationException(validationResult.Errors.Select(e => e.ErrorMessage));
            }
        }

        internal static MenuTreeNode[] BuildMenuTreeNode(this IEnumerable<Menu> menus)
        {
            var result = new Dictionary<int, MenuTreeNode>();

            foreach (var menu in menus)
            {
                if (result.ContainsKey(menu.Id))
                {
                    result[menu.Id].Parse(menu);
                }
                else
                {
                    result[menu.Id] = new MenuTreeNode(menu)
                    {
                        IsRoot = true
                    };
                }

                if (!menu.ParentId.HasValue) continue;
                
                if (result.ContainsKey(menu.ParentId.Value))
                {
                    result[menu.Id].IsRoot = false;
                }
                else
                {
                    result[menu.ParentId.Value] = new MenuTreeNode()
                    {
                        IsRoot = true
                    };
                }
                    
                result[menu.ParentId.Value].AddChild(result[menu.Id]);
            }

            return result.Values.Where(e => e.IsRoot && e.Id > 0).ToArray();
        }
    }
}