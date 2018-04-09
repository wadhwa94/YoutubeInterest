using System;

namespace YouTubeInterest
{
    public class YouTubeVideo
    {
        public string id, title, description;
        public DateTime publishedDate;

        public YouTubeVideo(string id)
        {
            if (id != null)
            { 
            this.id = id;
            //YouTubeApi.GetVideoInfo(this);
            }
        }
    }
}