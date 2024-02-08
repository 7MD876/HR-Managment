using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LearningManagementSystem.Enums
{
    public enum category    
    {
        [Display(Name = "ض.ص ")]
        PettyOfficer = 1,
        [Display(Name = "ض ")]
        Officer = 2,
        [Display(Name = "م")]
        CivilianStaff = 3,

    }
    //public static class EnumExtensions
    //{
    //    public static string GetDisplayName(this Enum enumValue)
    //    {
    //        return enumValue.GetType()
    //          .GetMember(enumValue.ToString())
    //          .First()
    //          .GetCustomAttribute<DisplayAttribute>()
    //          ?.GetName();
    //    }
    //}
}