using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nu.Plugin.Interfaces;

namespace Nu.Plugin.Gb
{
    class Program : INuPluginFilter
    {
        static async Task Main(string[] args) => await NuPlugin.Create()
            .Name("gb")
            .Usage("Return the length of a string")
            .IsFilter<Program>()
            .RunAsync();

        public object BeginFilter() => Array.Empty<string>();

        public JsonRpcParams Filter(JsonRpcParams requestParams)
        {
            var stringLength = requestParams.Value.Primitive["String"].ToString().Length;

            requestParams.Value.Primitive = new Dictionary<string, object>{
                {"Int", stringLength}
            };

            return requestParams;
        }

        public object EndFilter() => Array.Empty<string>();
    }
}
