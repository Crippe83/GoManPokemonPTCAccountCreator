using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoManPTCAccountCreator.Controller
{
    class PortTesterController
    {
        public static async Task<Boolean> IsPortOpen(String ip, String port)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        {"remoteAddress", ip},
                        {"portNumber", port}
                    };

                    var request = new HttpRequestMessage();
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("X-Prototype-Version", "1.6.0");

                    request.Headers.Add("User-Agent", "GoMan Browser");
                    request.Headers.Add("Accept", "*/*");
                    request.Headers.Add("Referer", "http://www.yougetsignal.com/tools/open-ports/");

                    request.RequestUri = new Uri("http://ports.yougetsignal.com/check-port.php");
                    request.Method = HttpMethod.Post;
                    request.Content = new FormUrlEncodedContent(values);

                    var response = await client.SendAsync(request);

                    var responseString = await response.Content.ReadAsStringAsync();

                    return responseString.Contains("open");
                }
            }
            catch
            {
                
                return false;;
            }
        }
    }
}
