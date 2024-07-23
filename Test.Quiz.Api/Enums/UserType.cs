using System.ComponentModel;

namespace UTEHY.DatabaseCoursePortal.Api.Enums
{
    public enum UserType
    {
        [Description("Sinh viên")]
        User = 1,

        [Description("Quản trị")]
        Admin = 2,


    }
}
