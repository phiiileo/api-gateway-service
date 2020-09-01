using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Xunit;

namespace api_gateway_service_test
{
    public class ExpectedResult
    {
        public string BaseUrl = "https://localhost:5001/api/";
        [Fact]
        public void TestTodosEnpoint()
        {
            //Arrange
            var request = (HttpWebRequest)WebRequest.Create(BaseUrl + "todos");
            //act
            var result = request.GetResponse();
            Stream webStream = result.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            resolveResolve(responseReader);
        }

        [Fact]
        public void TestUserEndpoint()
        {
            //Arrange
            var request = (HttpWebRequest)WebRequest.Create(BaseUrl + "users");
            //act
            var result = request.GetResponse();
            Stream webStream = result.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            resolveResolve(responseReader);
        }


        public class responseObj
        {
            public int id;
        }

        // http response handler
        private void resolveResolve(StreamReader responseReader)
        {
            string response = responseReader.ReadToEnd();
            List<responseObj> objData = JsonConvert.DeserializeObject<List<responseObj>>(response);
            var data = objData[0];

            Assert.NotEmpty(objData);
            Assert.IsType<int>(data.id);
        }
    }
}
