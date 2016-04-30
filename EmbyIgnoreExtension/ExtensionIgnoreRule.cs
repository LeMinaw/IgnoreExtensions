using MediaBrowser.Controller.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbyIgnoreExtension
{
    public class ExtensionIgnoreRule : IResolverIgnoreRule
    {
        public bool ShouldIgnore(CommonIO.FileSystemMetadata fileInfo, MediaBrowser.Controller.Entities.BaseItem parent)
        {
            if (fileInfo.IsDirectory)
                return false;

            if(EmbyIgnoreExtension.Plugin.Instance != null)
                return EmbyIgnoreExtension.Plugin.Instance.Configuration.IgnoredExtensionsList.Contains(
                        fileInfo.Extension
                            .ToLower()
                            .Replace(".", string.Empty) // extension contains a dot
                    );
            else
                return false;
        }
    }
}
