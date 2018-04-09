using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouTubeInterest;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            string id = "Z1VB6B-cGYo";
            string timeStamp = DateTime.Now.Ticks.ToString();

            YouTubeApi obj = new YouTubeApi();

               // YouTubeApi.GetVideoInfo(id);

            }
        }
    }

