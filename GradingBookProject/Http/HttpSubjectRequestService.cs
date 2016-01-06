using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Models;
using GradingBookProject.ViewModels;

namespace GradingBookProject.Http
{
    class HttpSubjectRequestService : HttpRequestService<SubjectsViewModel>
    {
        public HttpSubjectRequestService()
            : base()
        {

        }
        /// <summary>
        /// Find all Subjects for a given Year.
        /// </summary>
        /// <param name="year">Year we want subjects of.</param>
        /// <returns>List of subjects of a given Year, null if there is no such a Year.</returns>
        public async Task<ICollection<SubjectsViewModel>> GetSubjectsOfYear(YearsViewModel year)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "GetByYearId/" + year.id);

                if (response.IsSuccessStatusCode)
                {
                    ICollection<SubjectsViewModel> responseSubjects = await response.Content.ReadAsAsync<ICollection<SubjectsViewModel>>();
                    return responseSubjects;
                }
                return null;
            }
        }
    }
}
