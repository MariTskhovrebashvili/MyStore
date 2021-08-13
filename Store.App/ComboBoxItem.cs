using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.App
{
    public class ComboBoxItem : IEqualityComparer<ComboBoxItem>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Equals(ComboBoxItem x, ComboBoxItem y)
        {
            return GetHashCode(x) == GetHashCode(y);
        }

        public int GetHashCode([DisallowNull] ComboBoxItem obj)
        {
            return obj.Id.GetHashCode();
        }

        public override string ToString()
        {
            if(Name == "" || int.TryParse(Name, out _) || Name == null)
                return $"{Id}";
            return $"{Id}. {Name}";
        }
    }
}
