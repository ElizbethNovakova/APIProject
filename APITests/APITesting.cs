using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using APIProject;
using System.Net;

namespace APITests
{
    public class APITesting
    {
        private string UrlEndpoint = "posts";
        private int PostId = 1;
        private PostDto Post;
        private APIHelper APIHelper;

        [SetUp]
        public void Setup()
        {
            Post = new PostDto("new title", "new body", 1);
            APIHelper = new APIHelper();
            APIHelper.SetUrl(UrlEndpoint);
        }

        [Test]
        public void GetMethodTest()
        {
            APIHelper.CreateGetRequest(PostId);
            Assert.That(APIHelper.GetContent().Id, Is.EqualTo(PostId), "Get and received id must be the same");
            Assert.That(APIHelper.GetStatusCode(), Is.EqualTo(HttpStatusCode.OK), "Status code must be 200 - OK with GET Method");
        }

        [Test]
        public void PostMethodTest()
        {
            APIHelper.CreatePostRequest(Post);
            Assert.That(APIHelper.GetContent(), Is.EqualTo(Post), "Posted and get post must be the same");
            Assert.That(APIHelper.GetStatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code must be 201 - Created with POST Method");
        }

        [Test]
        public void PutMethodTest()
        {
            APIHelper.CreatePutRequest(PostId, Post);
            Assert.That(APIHelper.GetStatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code must be 200 - OK with PUT Method");
        }

        [Test]
        public void DeleteMethodTest()
        {
            APIHelper.CreateDeleteRequest(PostId);
            Assert.That(APIHelper.GetStatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code must be 200 - OK with DELETE Method");
        }
    }
}
