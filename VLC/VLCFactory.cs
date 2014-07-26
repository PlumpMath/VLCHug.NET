using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLCInterface
{
    public class VLCFactory
    {
        private String[] Options;

        public VLCFactory()
        {
            Options = new String[0];
        }

        public VLCFactory(String[] Options)
        {
            this.Options = Options;
        }

        public VLCInterface CreateInstance()
        {
            return new VLCInterface(Options.Length, Options);
        }
    }
}
