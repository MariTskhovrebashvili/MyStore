using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Settings
{
    public class LinuxSettings : IDbSettings
    {
        public LinuxSettings()
        {

        }

        public string Server { get; set; }

        public string Database { get; set; }

        public string UID { get; set; }

        public string PWD { get; set; }

        public string ConnectionString
        {
            get
            {
                return $"server = {Server}; database = {Database}; UID = {UID}; PWD = {PWD}";
            }
        }
    }
}
