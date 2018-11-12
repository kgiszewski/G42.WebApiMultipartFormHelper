using System.Collections.Generic;
using System.Net.Http;

namespace G42.WebApiMultipartFormHelper
{
    public class MultipartFormModel
    {
        public Dictionary<string, string> Arguments = new Dictionary<string, string>();
        public Dictionary<string, HttpContent> Files = new Dictionary<string, HttpContent>();
    }
}
