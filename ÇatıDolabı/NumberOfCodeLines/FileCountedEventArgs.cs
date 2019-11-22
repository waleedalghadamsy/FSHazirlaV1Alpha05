using System;
using System.Collections.Generic;
using System.Text;

namespace NumberOfCodeLines
{
    public class FileCountedEventArgs : EventArgs
    {
        public string CsFileName { get; set; }
        public int NoOfCsLines { get; set; }
        public string HtmlFileName { get; set; }
        public int NoOfHtmlLines { get; set; }
    }
}
