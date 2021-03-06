﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace YouTubeInterest.Controllers
{
    [Authorize]
    public class YApiController : ApiController
    {
        // Get api/yapi
        public Dictionary<string, int> GetChannel(int videoCount)
        {
            Dictionary<string,int> channelId = new Dictionary<string, int>();
            //channelId.Add("Test", 1);
            //YouTubeApi obj = new YouTubeApi();
            //string accessToken = Request.Headers.GetValues("Authorization").First().ToString().Split()[1];
            //User.Claims.FirstOrDefault(c => c.SomeProperty == "access_token")
            //YouTubeApi.AccessToken = accessToken;
            //YouTubeApi obj = new YouTubeApi();
           
            channelId = YouTubeApi.GetChannel(videoCount);

            return channelId;
        }
    }
}
