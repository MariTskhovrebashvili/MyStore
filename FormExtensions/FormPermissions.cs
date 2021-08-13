using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FormExtensions
{
    public static class FormPermissions
    {
        public static void RenderControlsByPermission(this Form form, IEnumerable<short> permissions, char seperator = '\t') 
        {
            foreach (Control control in form.Controls)
            {
                if (control.Tag != null)
                {
                    if (control is ToolStrip)
                        (control as ToolStrip).RenderToolStripByPermission(permissions, seperator);
                    else
                        control.RenderControlByPermission(permissions, seperator);
                }
            } 
        }

        public static void RenderToolStripByPermission(this ToolStrip toolStrip, IEnumerable<short> permissions, char seperator)
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item.Tag != null && permissions.Intersect(ConvertToPermissions(item.Tag.ToString(), seperator)).Count() == 0)
                    item.Visible = false;
                else if(item is ToolStripDropDownItem)
                    (item as ToolStripDropDownItem).RenderDropDownItems(permissions, seperator);
            }
        }

        public static void RenderDropDownItems(this ToolStripDropDownItem item, IEnumerable<short> permissions, char seperator)
        {
            if (item.Tag != null && permissions.Intersect(ConvertToPermissions(item.Tag.ToString(), seperator)).Count() == 0)
                item.Visible = false;
            else if(item.DropDownItems.Count != 0)
                foreach (var innerItem in item.DropDownItems)
                    if(innerItem is ToolStripDropDownItem)
                        (innerItem as ToolStripDropDownItem).RenderDropDownItems(permissions, seperator);
        }

        public static void RenderControlByPermission(this Control control, IEnumerable<short> permissions, char seperator)
        {
            if (control.Tag != null && permissions.Intersect(ConvertToPermissions(control.Tag.ToString(), seperator)).Count() == 0)
                control.Visible = false;
            else if (control.Controls.Count != 0)
                foreach (Control innerControl in control.Controls)
                    innerControl.RenderControlByPermission(permissions, seperator);
        }

        private static IEnumerable<short> ConvertToPermissions(string numbers, char seperator)
        {
            if(numbers.Contains(seperator))
                return CovertToShort(numbers.Split(seperator));
            return new List<short>() { Convert.ToInt16(numbers) };
        }

        private static IEnumerable<short> CovertToShort(IEnumerable<string> numbers)
        {
            foreach (string number in numbers)
                yield return Convert.ToInt16(number);
        }
    }
}
