using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Settings
{
    public class WindowsSettings : IDbSettings
    {
        public WindowsSettings()
        {

        }

        public string Server { get; set; }

        public string Database { get; set; }

        public bool IntegratedSecurity { get; set; }

        public string ConnectionString
        {
            get
            {
                return $"server = {Server}; database = {Database}; integrated security = {IntegratedSecurity}";
            }
        }
    }
}
