using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Xunit;

namespace api_main_gateway_test
{
    public class ApiGatewayShould
    {
        //Arrange
        public string BaseUrl = "https://localhost:5001/api/users";

        [Fact]
        public void getAllUsers()
        {
            //Arrange
            var request = (HttpWebRequest)WebRequest.Create(BaseUrl);

            //Act
            var result = request.GetResponse();
            Stream resultStream = result.GetResponseStream();
            StreamReader resultReader = new StreamReader(resultStream);
            string response = resultReader.ReadToEnd();
            List<ResponseObj> data = JsonConvert.DeserializeObject<List<ResponseObj>>(response);

            //Assert
            Assert.NotEmpty(data);

        }
    }

    public class ResponseObj
    {
        public int id;
        public string name;
        public string title;
    }
}
