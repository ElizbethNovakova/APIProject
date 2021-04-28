using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace APIProject
{
    public class PostDto
    {
        [JsonProperty("userId")]
        private int userId;
        [JsonProperty("id")]
        private int id;
        [JsonProperty("title")]
        private string title;
        [JsonProperty("body")]
        private string body;

        public PostDto()
        {
        }

        public PostDto(string title, string body, int userId)
        {
            this.title = title;
            this.body = body;
            this.userId = userId;
        }

        public int UserId { get => userId; set => userId = value; }
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Body { get => body; set => body = value; }
    }
}
