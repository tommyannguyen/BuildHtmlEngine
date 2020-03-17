using System.Reflection;

namespace RenderingService
{
    public class TheTemplates
    {
        public static Assembly Assembly => typeof(TheTemplates).GetTypeInfo().Assembly;
    }
}
