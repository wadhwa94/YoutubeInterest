using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Http;
using Google.Apis.Auth.OAuth2.Responses;

namespace YouTubeInterest
{
    public class YouTubeApi
    {

        private static YouTubeService ytService = Auth();

        public static string AccessToken { get; set; }

        private static YouTubeService Auth()
        {

            //var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            //{
            //    ClientSecrets = new ClientSecrets
            //    {
            //        ClientId = "1091996968324-gmpcveo6mc3ptgl4fmthr3n49tb73f81.apps.googleusercontent.com",
            //        ClientSecret = "vU6QcV020r9kUfgEYsXeZfJB"
            //    },
            //    Scopes = new[] { YouTubeService.Scope.YoutubeReadonly,YouTubeService.Scope.YoutubeUpload,YouTubeService.Scope.YoutubeForceSsl,YouTubeService.Scope.Youtubepartner,YouTubeService.Scope.YoutubepartnerChannelAudit }
            //});

            //var credential = new UserCredential(flow, Environment.UserName, new TokenResponse
            //{
            //    AccessToken = AccessToken
            //  //  RefreshToken = RefreshToken
            //});
            //var service = new YouTubeService(new BaseClientService.Initializer
            //{
            //    ApplicationName = "MyApp",
            //    HttpClientInitializer = credential,
            //    DefaultExponentialBackOffPolicy = ExponentialBackOffPolicy.Exception | ExponentialBackOffPolicy.UnsuccessfulResponse503
            //});



            UserCredential creds;
            using (var stream = new FileStream(HttpRuntime.AppDomainAppPath + "client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                creds = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { YouTubeService.Scope.YoutubeReadonly, YouTubeService.Scope.Youtube, YouTubeService.Scope.YoutubeForceSsl, YouTubeService.Scope.Youtubepartner, YouTubeService.Scope.YoutubeUpload },
                        DateTime.Now.Ticks.ToString(), //this string needs to be changed for all the users else it will take the previous one or don't know which one
                        CancellationToken.None,
                        new FileDataStore(HttpRuntime.AppDomainAppPath + "YouTubeHistory")
                    ).Result;
            }

            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = creds,
                ApplicationName = "YouTubeHistory"
            });

            return service;
        }

        public static Dictionary<string,int> GetChannel(int videoCount)
        {
            //string errMessage;    
            //var channelId = ytService.Channels;
            //var playlistRequest = ytService.Playlists.List("snippet");
            //playlistRequest.Mine = true;
            //var response = playlistRequest.Execute();
            //if (response.Items.Count > 0)
            //{
            //    string mychannelId = response.Items[0].Snippet.ChannelId;
            Dictionary<string, int> VidCategory_Array = new Dictionary<string, int>();
            string message = "";
            try
            {
                VidCategory_Array.Add("Jatin", 1);
                VidCategory_Array.Add("Jatin wadhwa", 2);
                if (ytService == null)
                VidCategory_Array.Add("Rohitt", 2);
                //VidCategory_Array.Add( (ytService==null).ToString(), 2);
                //VidCategory_Array.Add(ytService.Name, 1);
                //VidCategory_Array.Add(ytService.ApiKey,2);
                //VidCategory_Array.Add(ytService.VideoCategories.List("snippet").ToString(), 3);


                //message = message + "1 ";
                //var channelsRequest = ytService.Channels.List("contentDetails");
                //message = message + "2 ";
                //channelsRequest.Mine = true;
                //message = message + "3 ";
                //var likePlaylistIIdResponse = channelsRequest.Execute();
                //message = message + "4 ";
                //Google.Apis.YouTube.v3.Data.PlaylistItemListResponse videosResponse = null;
                //message = message + "5 ";
                //int currentVideoCount = 0;
                //message = message + "6 ";
                //if (likePlaylistIIdResponse.Items.Count > 0)
                //{
                //    string likePlayListId = likePlaylistIIdResponse.Items[0].ContentDetails.RelatedPlaylists.Likes;
                //    string nextPagetoken = null;
                //    do
                //    {
                //        var videosRequest = ytService.PlaylistItems.List("snippet");
                //        videosRequest.PlaylistId = likePlayListId;
                //        if (videoCount != -1)
                //            videosRequest.MaxResults = Math.Min(videoCount, 50);
                //        else
                //            videosRequest.MaxResults = 50;
                //        if (nextPagetoken != null)
                //        {
                //            if (videosResponse.NextPageToken != null)
                //            {
                //                videosRequest.PageToken = videosResponse.NextPageToken;
                //            }
                //        }
                //        videosResponse = videosRequest.Execute();
                //        currentVideoCount += videosResponse.Items.Count;
                //        for (int i = 0; i < videosResponse.Items.Count; i++)
                //        {

                //            var videoId = videosResponse.Items[i].Snippet.ResourceId.VideoId; //itearate for all the videos

                //            var videoDetails = ytService.Videos.List("snippet");
                //            videoDetails.Id = videoId;
                //            var videoDetailsResponse = videoDetails.Execute();
                //            if (videoDetailsResponse.Items.Count > 0)
                //            {
                //                var videoCategoryId = videoDetailsResponse.Items[0].Snippet.CategoryId;
                //                var videoCategoryNameRequest = ytService.VideoCategories.List("snippet");
                //                videoCategoryNameRequest.Id = videoCategoryId;
                //                var videoCategoryNameResponse = videoCategoryNameRequest.Execute();
                //                var videoCategoryName = videoCategoryNameResponse.Items[0].Snippet.Title;

                //                if (VidCategory_Array.ContainsKey(videoCategoryName))
                //                {
                //                    VidCategory_Array[videoCategoryName] += 1;
                //                }
                //                else
                //                {
                //                    VidCategory_Array.Add(videoCategoryName, 1);
                //                }
                //            }

                //        }

                //        if (videosResponse.NextPageToken != null)
                //            nextPagetoken = videosResponse.NextPageToken;
                //    }while (videosResponse.NextPageToken != null && videoCount == -1);
                //}

                return VidCategory_Array;
            }
            catch (Exception e)
            {
                VidCategory_Array.Add( e.Message.ToString() + " " + message + " ----  " + e.InnerException, -1);
                return VidCategory_Array;
            }
             
            //}
        }

        //public static void GetVideoInfo(YouTubeVideo video)
        //{
        //    if (video == null)
        //        return;
        //    var videoRequest = ytService.Videos.List("snippet");

        //    var channelId = ytService.Channels;

        //    videoRequest.Id = video.id;

        //    var response = videoRequest.Execute();
        //    if(response.Items.Count > 0)
        //    {
        //        video.title = response.Items[0].Snippet.Title;
        //        video.description = response.Items[0].Snippet.Description;
        //        video.publishedDate = response.Items[0].Snippet.PublishedAt.Value;
        //        return;
        //    }
        //    else
        //    {
        //        return;// If video id is not found
        //    }

        //}
    }
}