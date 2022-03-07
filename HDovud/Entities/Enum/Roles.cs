using System.ComponentModel;
using HDovud.Entities.Models;

namespace HDovud.Entities.Enum
{
    public enum Roles
    {
        [Description("Администратор")]
        Admin = 1,
        [Description("Пользователь")]
        User
    }
}