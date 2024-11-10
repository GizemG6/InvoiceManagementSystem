using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace InvoiceManagementSystem.Enums.EnumHelper
{
    public class EnumHelper
    {
        public static List<SelectListItem> GetEnumSelectList<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(e => new SelectListItem
            {
                Text = e.GetType().GetMember(e.ToString())
                             .FirstOrDefault()?
                             .GetCustomAttribute<DisplayAttribute>()?.Name ?? e.ToString(),
                Value = ((int)(object)e).ToString()
            }).ToList();
        }
    }
}
