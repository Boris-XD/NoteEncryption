using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Helpers
{
    public static class HandleSearch
    {
        public static bool HandleSearchBasic(object itemEvaluated, string searchTerm)
        {
            if (itemEvaluated == null)
            {
                return false;
            }
            var properties = itemEvaluated.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType.IsClass)
                {
                    var value = property.GetValue(itemEvaluated);
                    var valueIsValid = HandleSearchBasic(value, searchTerm);

                    if (valueIsValid)
                    {
                        return true;
                    }
                }
                if (!property.PropertyType.IsGenericType)
                {
                    if (property.GetCustomAttributes<DisplayAttribute>()?.FirstOrDefault()?.Encrypted == false)
                    {
                        if (property.GetValue(itemEvaluated).ToString().ToLower().Contains(searchTerm.ToLower()))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (EvaluateGenericProperty(property, itemEvaluated, searchTerm))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        private static bool EvaluateGenericProperty(PropertyInfo property, object itemEvaluated, string searchTerm)
        {
            var genericProperty = property.GetValue(itemEvaluated);

            foreach (var propertyInGeneric in genericProperty as IEnumerable<object>)
            {
                if (HandleSearchBasic(propertyInGeneric, searchTerm))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HandleSearchAdvanced(object itemEvaluated, string searchTerm, string fieldProperty)
        {
            if (itemEvaluated == null || string.IsNullOrEmpty(searchTerm) || string.IsNullOrEmpty(fieldProperty))
            {
                return false;
            }

            var properties = itemEvaluated.GetType().GetProperties();
            var field = properties.FirstOrDefault(x => x.Name.ToLower() == searchTerm.ToLower());

            if (field == null || field.PropertyType.GetCustomAttributes<DisplayAttribute>()?.FirstOrDefault()?.Sensitive == true)
            {
                return false;
            }
            else
            {
                var value = field.GetValue(itemEvaluated);

                if (value == null)
                {
                    return false;
                }
                else
                {
                    if (value.GetType().IsGenericType)
                    {
                        var genericValue = value as IEnumerable<object>;

                        foreach (var item in genericValue)
                        {
                            var itemBuilded = item.GetType().GetProperties();
                            if (itemBuilded.Any(x =>
                            {
                                var property = x.GetValue(item);
                                return property != null && property.ToString().ToLower().Contains(fieldProperty.ToLower());
                            }))
                            {
                                return true;
                            }
                        }
                    }

                    if (value.ToString().ToLower().Contains(fieldProperty.ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
