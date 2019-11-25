using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace EFC.Framework.Common.Utility
{
    public static class EmbeddedResource
    {
        public static string GetApiRequestFile(string namespaceAndFileName)
        {
            try
            {
                using (var stream = typeof(EmbeddedResource).GetTypeInfo().Assembly.GetManifestResourceStream(namespaceAndFileName))
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                    return reader.ReadToEnd();
            }

            catch (Exception)
            {
                throw new Exception($"Failed to read Embedded Resource {namespaceAndFileName}");
            }
        }
    }
}
