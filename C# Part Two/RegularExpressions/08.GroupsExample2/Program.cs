using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.GroupsExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"<html> This is a hyperlink: 
            <a href=""javascript:'window.close()'"">
            close the window</a><br> ... and one more link: <a 
            target=""_blank"" href=/main.aspx class='link'> <b>
            main page</b> </a>< a href = 'http://www.nakov.com'
            > <img src='logo.gif'>Nakov's home site < /a >";

            string hrefPattern = @"<\s*a\s[^>]*\bhref\s*=\s*" +
               @"('(?<url>[^']*)'|""(?<url>[^""]*)""|" +
               @"(?<url>\S*))[^>]*>" +
               @"(?<linktext>(.|\s)*?)<\s*/a\s*>";
            

        }
    }
}
