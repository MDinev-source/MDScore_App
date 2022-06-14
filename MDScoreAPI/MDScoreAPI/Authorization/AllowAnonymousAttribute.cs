namespace MDScoreAPI.Authorization
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    { }
}
