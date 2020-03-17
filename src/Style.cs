using ReportEngine.Util;
using System.IO;
using System.Reflection;

namespace ReportEngine
{
    public static class Style
    {
        public static string GetStylesheet(string name)
        {
            return string.Format("<style>{0}</style>", AssemblyUtil.GetCssByName(name));
        }
    }
}
