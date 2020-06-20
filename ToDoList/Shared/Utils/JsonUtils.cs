using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ToDoList.Shared.Utils
{
    public class JsonUtils
    {
        public static async Task<T> GetObjectFromHttpResponse<T>(HttpResponseMessage result)
        {
            var responseText = await result.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<T>(responseText);

            return responseObj;
        }
    }
}
