using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
//using GradingBookApi.Models;
using GradingBookProject.Models;

namespace GradingBookProject.Http
{
    /// <summary>
    /// Class containing methods for all Grading Book API interactions.
    /// </summary>
    /// <typeparam name="T">Class can handle multiple data types(Users, 
    /// Years, Subjects, Grades)</typeparam>
    public class  HttpRequestService <T>
    {
        protected const string baseUrl = "http://localhost:53716/";
        protected string url;

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
            else if (t == typeof(Groups))
            {
                url += "api/Groups/";
            }
            else if (t == typeof(GroupDetails))
            {
                url += "api/GroupDetails/";
            }
            else
            {
                url = "";
            }
        }

        /// <summary>
        /// Gets all objects of given type from API.
        /// </summary>
        /// <returns>IQueryable of objects</returns>
        public async Task<IQueryable<T>> GetAll( )
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
                    return responseObject.AsQueryable();
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Gets a specific object based of ID from API.
        /// </summary>
        /// <param name="id">Objects unique id.</param>
        /// <returns>A requested Object</returns>
        public async Task<T> GetOne(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET T/{id} to get specific
                HttpResponseMessage response = await client.GetAsync(url + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    T responseObject = await response.Content.ReadAsAsync<T>();
                    return responseObject;
                }
                else
                {
                    return default(T);
                }
            }
        }

        /// <summary>
        /// Sends an object to API to be saved.
        /// </summary>
        /// <param name="obj">Object to be send.</param>
        /// <returns></returns>
        public async Task<T> PostOne(T obj) {
           

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                //POST to create new
                HttpResponseMessage response = await client.PostAsJsonAsync(url, obj);
                if (response.IsSuccessStatusCode)
                {
                    T responseObject = await response.Content.ReadAsAsync<T>();
                    return responseObject;
                }
                else {
                    return default(T);
                }
            }
        }


        /// <summary>
        /// Sends an object to API to be updated.
        /// </summary>
        /// <param name="id">Objects unique id.</param>
        /// <param name="o">Object to be updated</param>
        /// <returns></returns>
        public async Task<T> UpdateOne(int id, T o)
        {
            using (var client = new HttpClient())
            {
                string updateUrl = url  + id.ToString();
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(updateUrl);
              
                if (response.IsSuccessStatusCode)
                {
                    T responseObject = await response.Content.ReadAsAsync<T>();
                    //PUT to update
                    response = await client.PutAsJsonAsync(updateUrl, o);
                    if(!response.IsSuccessStatusCode)
                        throw new Exception("Bad response!");
                    return responseObject;
                }
                else
                {
                    return default(T);
                }
            }
        }

        /// <summary>
        /// Requests the object to be deleted.
        /// </summary>
        /// <param name="id">Objects unique id.</param>
        /// <returns></returns>
        public async Task<T> DeleteOne(int id)
        {

            using (var client = new HttpClient())
            {
                string deleteUrl = url + "/" + id.ToString();
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(deleteUrl);

                if (response.IsSuccessStatusCode)
                {
                    T responseObject = await response.Content.ReadAsAsync<T>();
                    //DELETE to remove
                    response = await client.DeleteAsync(deleteUrl);
                    return responseObject;
                }
                else
                {
                    return default(T);
                }
            }
        }

    }
}