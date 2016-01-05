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
    class HttpSubjectDetailsRequestService : HttpRequestService<SubjectDetailsViewModel>
    {
        public HttpSubjectDetailsRequestService()
            : base()
        {

        }
        /// <summary>
        /// Find all Grades for a given Subject.
        /// </summary>
        /// <param name="subject">Subject we want details of.</param>
        /// <returns>List of Grades of a given Subject, null if there is no such a Subject.</returns>
        public async Task<ICollection<SubjectDetailsViewModel>> GetSubjectDetailsOfSubject(SubjectsViewModel subject)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url + "GetBySubjectId/" + subject.id);

                if (response.IsSuccessStatusCode)
                {
                    ICollection<SubjectDetailsViewModel> responseSubjectDetails = await response.Content.ReadAsAsync<ICollection<SubjectDetailsViewModel>>();
                    return responseSubjectDetails;
                }
                return null;
            }
        }
    }
}
