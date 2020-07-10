using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAppTestCases
{
    public class GlossaryControllerTests : ControllerTestsBase
    {
        public GlossaryControllerTests(WebApiTesterFactory factory) : base(factory) { }

        [Fact]
        public async Task should_return_list_of_glossary_items_without_need_for_token()
        {
            var response = await client.GetAsync("/api/glossary");
            response.StatusCode.ToString();
           
          
        }
    }
}
