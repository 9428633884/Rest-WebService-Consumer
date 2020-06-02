using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Rest_WebService_Consumer
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RestConsumer
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RestConsumer()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public string executeRequest()
        {
            string strResponse = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpMethod.ToString();

            using ( HttpWebResponse response = (HttpWebResponse) request.GetResponse() )
            {
                if( response.StatusCode != HttpStatusCode.OK )
                {
                    throw new ApplicationException("Error Code : " + response.StatusCode.ToString() );
                }

                using ( Stream responseStream = response.GetResponseStream() )
                {
                    if( responseStream != null )
                    {
                        using ( StreamReader reader = new StreamReader(responseStream) )
                        {
                            strResponse = reader.ReadToEnd();
                        }
                    }
                }
            }

            return strResponse;
        }
    }
}
