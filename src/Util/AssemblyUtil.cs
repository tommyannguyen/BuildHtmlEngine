using System;
using System.IO;
using System.Reflection;

namespace ReportEngine.Util
{
    internal static class AssemblyUtil
    {
        private static Assembly GetAssembly() => typeof(AssemblyUtil).Assembly;
        public static string GetTemplateByName(string name)
        {
            var assembly = GetAssembly();
            var assemblyName = assembly.GetName().Name;
            var path = $"{assemblyName}.Templates.{name}.cshtml";

            return LoadResource(path, assembly);
        }

        public static string GetCssByName(string name)
        {
            var assembly = GetAssembly();
            var assemblyName = assembly.GetName().Name;
            var path = $"{assemblyName}.Templates.Styles.{name}.css";

            return LoadResource(path, assembly);
        }
        public static MemoryStream GetExcelTemplate(string name)
        {
            var assembly = GetAssembly();
            var assemblyName = assembly.GetName().Name;
            var path = $"{assemblyName}.Templates.Excels.{name}.xlsx";

            using var stream = assembly.GetManifestResourceStream(path);
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream;
        }

        private static string LoadResource(string path, Assembly assembly)
        {
            string result;

            using (var stream = assembly.GetManifestResourceStream(path))
            using (var reader = new StreamReader(stream ?? throw new InvalidOperationException()))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
