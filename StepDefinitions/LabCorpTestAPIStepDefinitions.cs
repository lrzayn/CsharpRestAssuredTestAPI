
using Newtonsoft.Json;
using RA;

namespace LabCorpLRZtestAPI.StepDefinitions
{
    [Binding]
    public sealed class LabCorpTestAPIStepDefinitions
    {
        DataPOST dataPost = new DataPOST();
        string? host, uri;

        //Given API url is APIurl
        [Given("API url is (.*)")]
        public void GivenAPIUrlIs(string APIurl)
        {
            switch (APIurl)
            {
                //for positive test
                case "LabCorpPOST":
                    //urlPOST_API = APIurl;
                    host = "https://petstore.swagger.io";
                    uri = "/v2/user/createWithArray";
                    break;

                //if API url have no exist, negative test
                default:
                    host = null;
                    uri = null;
                    break;
            }
        }

        //When post sample json
        [When("post sample json")]
        public void WhenPostSampleJson()
        {
            
            dataPost.id = 43433;
            dataPost.username = "323243431lrz";
            dataPost.firstname = "RRRR";
            dataPost.lastname = "LLL";
            dataPost.email = "we@gmail.com";
            dataPost.password = "23dwewe";
            dataPost.phone = 2324433;
            dataPost.userStatus = 0;

            string requestData = JsonConvert.SerializeObject(dataPost);
            //Console.Write(requestData.ToString());

            //send post request by Rest-assured
            new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .Host(host)
                .Uri(uri)
                .Body("[" + requestData + "]") //have to add square brackets to the body (API unique spec???)
                .When()
                .Post()
                .Then()
                .Debug()
                .TestStatus("POST Status code response", x => x == 200) //read status code for assertion
                .AssertAll();
        }

        [Then("send get request to validate username")]
        public void ThenSendGetRequestToValidateUsername()
        {
            uri = "/v2/user/" + dataPost.username;

            var id = new RestAssured()
                .Given()
                .Host(host)
                .Uri(uri)
                .When()
                .Get()
                .Then()
                .Retrieve(x => x.id);

            Console.WriteLine(id.ToString());
        }
    }

    public class DataPOST
    {
        public int id { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int phone { get; set; }
        public int userStatus { get; set; }
    }
}