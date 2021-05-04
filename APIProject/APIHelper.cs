using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Net;

namespace APIProject
{
    public class APIHelper
    {
        private RestClient RestClient;
        private RestRequest RestRequest;
        private string BaseUrl = "https://jsonplaceholder.typicode.com/";

        public RestClient SetUrl(string Endpoint)
        {
            var Url = Path.Combine(BaseUrl, Endpoint);
            RestClient = new RestClient(Url);
            return RestClient;
        }

        public RestRequest CreatePostRequest(PostDto RequestBody)
        {
            RestRequest = new RestRequest(Method.POST);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddJsonBody(RequestBody);
           
            return RestRequest;
        }

        public RestRequest CreateGetRequest(int PostId)
        {
            RestRequest = new RestRequest("{postId}", Method.GET);
            RestRequest.AddUrlSegment("postId", PostId);
            return RestRequest;
        }

        public RestRequest CreatePutRequest(int PostId, PostDto RequestBody)
        {
            RestRequest = new RestRequest("{postId}", Method.PUT);
            RestRequest.AddUrlSegment("postId", PostId);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddJsonBody(RequestBody);

            return RestRequest;
        }

        public RestRequest CreateDeleteRequest(int PostId)
        {
            RestRequest = new RestRequest("{postId}", Method.DELETE);
            RestRequest.AddUrlSegment("postId", PostId);
            return RestRequest;
        }

        public IRestResponse GetResponse()
        {
            return RestClient.Execute(RestRequest);
        }

        public PostDto GetContent()
        {
            var deserialize = new JsonDeserializer();
            PostDto postDt0 = deserialize.Deserialize<PostDto>(GetResponse());
            return postDt0;
        }

        public HttpStatusCode GetStatusCode()
        {
            return GetResponse().StatusCode;
        }
    }
}
