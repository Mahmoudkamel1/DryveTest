using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DryveTask.Helpers;
using DryveTask.Models;
using DryveTask.services.Interfaces;
using Newtonsoft.Json.Linq;

namespace FlickrList.services.implementations
{
    public class FlickrServices : IFlickrServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<List<Photo>> GetPictures()
        {
            try
            {
                var client = new HttpClient();


                var response = await client.GetAsync(Constants.BASEURL + Constants.GetImageListURL);
                var jsonStringUnEncodeing = await response.Content.ReadAsStringAsync();

                byte[] bytes = Encoding.Default.GetBytes(jsonStringUnEncodeing);
                var jsonStringEncodeing = Encoding.UTF8.GetString(bytes);
                var jsonObject = JObject.Parse(jsonStringUnEncodeing);

                var jToken = jsonObject["items"];
                List<Photo> list = jToken.ToObject<List<Photo>>();
                return list;
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.StackTrace);
                return new List<Photo>();
            }
        }

    }

}