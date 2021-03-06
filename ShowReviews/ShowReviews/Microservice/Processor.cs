﻿using Newtonsoft.Json;
using ShowReviews.ApiHelper;
using ShowReviews.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShowReviews.Microservice
{
    public class Processor
    {
        private static List<Review> reviewList = new List<Review>();
        private static int average;
        public async Task getReviews()
        {
            using (HttpResponseMessage responseMessage
                = await Apihelper.ApiClient.GetAsync("https://sirestreviewfinal.azurewebsites.net/api/review/getall"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJSON = await responseMessage.Content.ReadAsStringAsync();
                    reviewList = JsonConvert.DeserializeObject<List<Review>>(responseJSON);
                }
            }
        }

        public async Task getAvg()
        {
            using (HttpResponseMessage responseMessage
                = await Apihelper.ApiClient.GetAsync("https://sirestreviewfinal.azurewebsites.net/api/review/getaverage"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseJSON = await responseMessage.Content.ReadAsStringAsync();
                    average = JsonConvert.DeserializeObject<int>(responseJSON);
                }
            }
        }
        public List<Review> ReviewList
        {
            get { return reviewList; }
        }

        public int Average
        {
            get { return average; }
        }


    }
}
