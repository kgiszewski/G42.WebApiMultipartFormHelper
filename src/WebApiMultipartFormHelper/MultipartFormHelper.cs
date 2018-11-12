using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace G42.WebApiMultipartFormHelper
{
    public static class MultipartFormHelper
    {
        public static async Task<MultipartFormModel> ParseRequest(HttpRequestMessage request)
        {
            var provider = new MultipartMemoryStreamProvider();

            await request.Content.ReadAsMultipartAsync(provider);

            var arguments = new Dictionary<string, string>();
            var files = new Dictionary<string, HttpContent>();

            foreach (var content in provider.Contents)
            {
                if (content.Headers.ContentDisposition.FileName != null)
                {
                    var filename = content.Headers.ContentDisposition.FileName.Trim('\"');

                    files.Add(filename, content);
                }
                else
                {
                    foreach (var parameter in content.Headers.ContentDisposition.Parameters)
                    {
                        var name = parameter.Value;

                        //trim off some quotes
                        if (name.StartsWith("\"") && name.EndsWith("\"")) name = name.Substring(1, name.Length - 2);

                        var value = await content.ReadAsStringAsync();

                        arguments.Add(name, value);
                    }
                }
            }

            return new MultipartFormModel
            {
                Files = files,
                Arguments = arguments
            };
        }
    }
}
