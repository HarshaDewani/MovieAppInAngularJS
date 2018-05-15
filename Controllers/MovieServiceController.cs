using MovieAppInAngularJS.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace MovieAppInAngularJS.Controllers
{
    public class MovieServiceController : ApiController
    {
        /// <summary>
        /// Api call to retreive movieList
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetMovieList()
        {

            var json = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/MovieList.json"));
            return new HttpResponseMessage()
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }
        /// <summary>
        /// Api call to retrieve Movie details by movie title
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Movie object</returns>
        [HttpGet]
        public HttpResponseMessage GetMovieDetails(string title)
        {
            string json = System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/MovieList.json");
            Movie movie = null;
            using (StreamReader stmReaderJson = new StreamReader(json))
            {
                string strJsonTxt = stmReaderJson.ReadToEnd();
                JArray ArrayJsonData = JArray.Parse(@strJsonTxt);
                if (ArrayJsonData[0].Children().Count() > 0)
                {
                    var movieList = ArrayJsonData.Where(x => x["title"].ToString() == title);
                    movie = new Movie
                    {
                        title = movieList.Select(x => x["title"]).FirstOrDefault().ToString(),
                        director = movieList.Select(x => x["director"]).FirstOrDefault().ToString(),
                        release_date = Convert.ToDateTime(movieList.Select(x => x["release_date"]).FirstOrDefault()),
                        videoUrl = movieList.Select(x => x["videoUrl"]).FirstOrDefault().ToString(),
                        description = movieList.Select(x => x["description"]).FirstOrDefault().ToString(),
                        stars = movieList.Select(x => x["stars"]).ToArray(),
                        posterThumb = movieList.Select(x => x["posterthumb"]).FirstOrDefault().ToString(),
                        writers = movieList.Select(x => x["writers"]).ToArray()
                    };
                }
                return Request.CreateResponse(HttpStatusCode.OK, movie, "application/json");

            }


        }



    }
}
