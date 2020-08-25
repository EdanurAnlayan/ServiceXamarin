
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceXamarin
{
    public class SectionDetails
    {
        public string DistId { get; set; }
        public string DistName { get; set; }
        public string SectionId { get; set; }
        public string SectionName { get; set; }
    }

    public class Root
    {
        public List<SectionDetails> MyArray { get; set; }
    }
}
