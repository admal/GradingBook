using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GradingBookApi.Models;

namespace GradingBookProject.Http
{
    public class  HttpRequestService <T>
    {
        private const string baseUrl = "http://localhost:53716/";
        private string url;

        public HttpRequestService()
        {
            url = baseUrl;
            var t = typeof (T);
            if (t == typeof (Users))
            {
                url += "api/Users/";

            }
            else if (t == typeof (Years))
            {
                url += "api/Years/";
            }
            else if (t == typeof (Subjects))
            {
                url += "api/Subjects/";
            }
            else if (t == typeof (SubjectDetails))
            {
                url += "api/SubjectDetails/";
            }
            else
            {
                url = "";
            }
        }


        public async Task<List<T>> GetAll( )
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    List<T> responseObject = await response.Content.ReadAsAsync<List<T>>();
                    return responseObject;
                }
                else
                {
                    return null;
                }
            }
        }


    }
}