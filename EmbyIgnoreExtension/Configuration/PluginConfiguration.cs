using MediaBrowser.Model.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbyIgnoreExtension.Configuration
{
    public class PluginConfiguration : BasePluginConfiguration
    {
        internal string[] IgnoredExtensionsList { get; set; }

        //wrapper for IgnoredExtensionsList to set/get it in a single comma seperated string
        public string IgnoredExtensions 
        {
            get
            {
                string extensionString = string.Empty;
                foreach (string ext in IgnoredExtensionsList)
                {
                    if (extensionString != string.Empty)
                        extensionString += ", ";
                    extensionString += ext;
                }
                return extensionString;
            }
            set
            {
                List<string> lst = new List<string>();
                foreach (string ext in value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    lst.Add(ext.Replace(".", "").Trim());
                }

                IgnoredExtensionsList = lst.ToArray();
            }
        }
        public PluginConfiguration()
        {
            IgnoredExtensions = "dng, cr2, raw";
        }
    }

}
