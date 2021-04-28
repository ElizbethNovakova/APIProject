using APIProject;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;


namespace APITests
{
    public class Tests
    {
        private RestClient client;
        private PostDto post;
        private const int STATUS_CODE_OK = 200;
        private const int STATUS_CODE_CREATED = 201;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://jsonplaceholder.typicode.com/");
            post = new PostDto("new title", "new body", 1);
        }

        [Test]
        public void GetMethodTest()
        {
            var request = new RestRequest("posts/{postId}", Method.GET);
            request.AddUrlSegment("postId", 1);

            var response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<PostDto>(response);

            var statusCode = (int) response.StatusCode;
            
            Assert.AreEqual(1, output.Id);
            Assert.AreEqual(STATUS_CODE_OK, statusCode, "Status code must be 200 - OK with GET Method");
        }

        [Test]
        public void PostMethodTest()
        {
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(post);

            var response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<PostDto>(response);

            var statusCode = (int) response.StatusCode;
            
            Assert.AreEqual(post.Title, output.Title, "Titles must be the same");
            Assert.AreEqual(STATUS_CODE_CREATED, statusCode, "Status code must be 201 - Created with POST Method");
        }

        [Test]
        public void PutMethodTest()
        {
            var request = new RestRequest("posts/{postId}", Method.PUT);
            request.AddUrlSegment("postId", 1);
            request.AddJsonBody(post);

            var response = client.Execute(request);
            var statusCode = (int)response.StatusCode;
            
            Assert.AreEqual(STATUS_CODE_OK, statusCode, "Status code must be 200 - OK with PUT Method");
        }

        [Test]
        public void DeleteMethodTest()
        {
            var request = new RestRequest("posts/{postId}", Method.DELETE);
            request.AddUrlSegment("postId", 1);

            var response = client.Execute(request);
            var statusCode = (int)response.StatusCode;

            Assert.AreEqual(STATUS_CODE_OK, statusCode, "Status code must be 200 - OK with DELETE Method");
        }
    }
}