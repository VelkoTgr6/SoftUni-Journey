using Library.Core.Layout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerConsoleApp.CustomLayouts
{
    public class XmlLayout : ILayout
    {
        public string Format 
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                
                sb.AppendLine("<log>");
                sb.AppendLine("\t<date>{0}</date>");
                sb.AppendLine("\t<level>{1}</level>");
                sb.AppendLine("\t<message>{2}</message>");
                sb.AppendLine("</log>");

                return sb.ToString().TrimEnd();
            }
            set
            {

            }
        }
    }
}
