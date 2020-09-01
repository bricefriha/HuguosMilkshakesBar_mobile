using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HuguosMilkshakesBar.Models
{
    class Post
    {
        [JsonProperty("headline")]
        public string Headline { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        public string Time { get {

                string span = string.Empty;

                TimeSpan timeSpan = DateTime.Now - this.CreatedDate;

                // If it's more than a year
                if (timeSpan.Days > 365)
                {
                    // get the number of years
                    int nbYears = timeSpan.Days / 365;

                    span = nbYears.ToString() + " years ago";
                }
                // It's more than a month
                else if (timeSpan.Days > 30)
                {
                    // Number of months
                    int nbMonth = timeSpan.Days / 30;

                    if (nbMonth == 1)
                        span = "1 month ago";
                    else
                        span = nbMonth.ToString() + " months ago";
                }
                // It's more than a week
                else if (timeSpan.Days > 7)
                {
                    // Number of weeks
                    int nbWeeks = timeSpan.Days / 7;

                    if (nbWeeks == 1)
                        span = "1 week ago";
                    else
                        span = nbWeeks.ToString() + " weeks ago";
                        
                }
                // It's more than a day
                else if (timeSpan.Days > 0)
                {
                    int days = timeSpan.Days;

                    if (days == 1)
                        span = "1 day ago";
                    else
                        span = days.ToString() + " days ago";
                }
                // it's more than an hour
                else if (timeSpan.Hours > 0)
                {
                    int hours = timeSpan.Hours;

                    if (hours == 1)
                        span = "1 hour ago";
                    else
                        span = hours.ToString() + " hours ago";
                }
                else if (timeSpan.Minutes > 0)
                {
                    int minutes = timeSpan.Minutes;

                    if (minutes == 1)
                        span = "1 minute ago";
                    else
                        span = minutes.ToString() + " minutes ago";
                }
                else if (timeSpan.Seconds > 0)
                {
                    int seconds = timeSpan.Seconds;
                    if (seconds == 1)
                        span = "1 second ago";
                    else
                        span = seconds.ToString() + " Seconds ago";
                }
                else
                {
                    span =  "just now";
                }
                return span; 
            }  }
    }
}
