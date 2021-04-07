using System;

namespace Library
{
    [Flags]
    public enum Permission
    {
        Admin = 1,
        User = 2,
        All = Admin | User
    }
}