using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yiyou.Util
{
    public class WebCtrlUtil
    {
        public static void SetDropDownText(System.Web.UI.WebControls.DropDownList ddl, string ItemText)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (string.Compare(ddl.Items[i].Text.Trim(), ItemText.Trim(), true) == 0 || string.Compare(ddl.Items[i].Value.Trim(), ItemText.Trim(), true) == 0)
                {
                    ddl.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
