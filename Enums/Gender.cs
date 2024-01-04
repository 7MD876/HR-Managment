using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LearningManagementSystem.Enums
{
    public enum Gender
    {
        [Display(Name ="ذكر")]
        male = 1,
        [Display(Name = "أنثى")]
        female = 2, 

    }
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              .GetCustomAttribute<DisplayAttribute>()
              ?.GetName();
        }
    }
}
