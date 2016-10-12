using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdidasBackdoor
{
    public class WriteHtml
    {
        public void CreateHtml(string url, string id)
        {
            using (FileStream fs = new FileStream(string.Format("test{0}.html", id), FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine("<html>");
                    w.WriteLine("<head>");
                    w.WriteLine("<script language=\"Javascript\">");
                    w.WriteLine("function submitForm() {");
                    w.WriteLine("    var theForm = document.getElementById(\"theForm\");");
                    w.WriteLine("    theForm.submit();");
                    w.WriteLine("}");
                    w.WriteLine("</script>");
                    w.WriteLine("<body onload=\"submitForm()\">");
                    w.WriteLine(string.Format("<form id=\"theForm\" action=\"{0}\" method=\"POST\">",url));
                    w.WriteLine("    <input type=\"text\" name=\"Thuans a faggot\" value=\"myusername\"/>");
                    w.WriteLine("</form>");
                    w.WriteLine("</body>");
                    w.WriteLine("</html>");
                }
            }
        }
    }
}
