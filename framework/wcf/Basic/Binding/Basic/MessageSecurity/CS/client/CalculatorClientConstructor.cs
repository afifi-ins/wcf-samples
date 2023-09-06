using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Microsoft.Samples.MessageSecurity
{
    // This partial class constructor is needed as the service is hosted in IIS and advertises both HTTP and HTTPS endpoints.
    // This causes the generated client to have 2 configurations so a default constructor can't be generated as it's unknown which to use.
    // By adding this constructor, we can choose which endpoint we wish to use as the default.
    public partial class CalculatorClient
    {
#if NET6_0_OR_GREATER
        //public CalculatorClient() : this(EndpointConfiguration.BasicHttpBinding_ICalculator1) { }
#endif
    }
}
