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

        internal static TreeNode<Menu>[] BuildMenuTreeNode(this Menu[] menus)
        {
            var result = new Dictionary<int, TreeNode<Menu>>();

            foreach (var menu in menus)
            {
                if (result.ContainsKey(menu.Id))
                {
                    result[menu.Id].Node = menu;
                }
                else
                {
                    result[menu.Id] = new TreeNode<Menu>(menu);
                }

                if (!menu.ParentId.HasValue) continue;
                
                if (!result.ContainsKey(menu.ParentId.Value))
                {
                    result[menu.ParentId.Value] = new TreeNode<Menu>();
                }
                    
                result[menu.ParentId.Value].AddChild(menu);
            }

            return result.Values.Where(e => !e.Node.ParentId.HasValue).ToArray();
        }
    }
}