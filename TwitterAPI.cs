using Tweetinvi;
using Tweetinvi.Models;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using LinqToTwitter;
using System.Linq;
using Tweetinvi.Client;
using Tweetinvi.Core.Models;
using Tweetinvi.Core.Models.TwitterEntities;
using System.Drawing;

namespace TwitterAPI
{
    public class TwitterAPI
    {
        //methods for twitter api
        public static TwitterClient GetUser(string credLoc)
        {
            using (var reader = new StreamReader(credLoc))
            {
                using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<TwitApiKeys>().ToList();
                    var Ukey = records.Select(x => x.UKey).ToArray();
                    var UPass = records.Select(x => x.UPass).ToArray();
                    var AKey = records.Select(x=>x.AKey).ToArray();
                    var APass = records.Select(x=>x.APass).ToArray();
                    Console.WriteLine(Ukey);
                    var userclient = new TwitterClient(Ukey[0], UPass[0], AKey[0], APass[0]);
                    return userclient;

                }
                
            }
            
        }
        public static async Task MakeTweettxt(string tweetTxt, bool hasImg)
        {
            //making a tweet, and giving it the option of coming with or without an image.
            TwitterClient userClient = TwitterAPI.GetUser("imgloc");
            if (hasImg != false)
            {
                var tweet = await userClient.Tweets.PublishTweetAsync(tweetTxt);
            }
            else if(hasImg == true)
            {
                var tweet = await userClient.Tweets.PublishTweetAsync(tweetTxt);
                {

                }
            }
            
        }
        public class TwitApiKeys
        {
            [Name("UserKey")]
            public string UKey { get; set; }
            [Name("UserPass")]
            public string UPass { get; set; }
            [Name("AppKey")]
            public string AKey { get; set; }
            [Name("AppPass")]

            public string APass { get; set; }



        }

    }
}