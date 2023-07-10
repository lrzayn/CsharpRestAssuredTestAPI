
using Newtonsoft.Json;
using RA;

namespace LabCorpLRZtestAPI.StepDefinitions
{
    [Binding]
    public sealed class LabCorpTestAPIStepDefinitions
    {
        DataPOST dataPost = new DataPOST();
        string? host, uri;
        string usernameTest = "323243431lrz";
        string usernameTestSpain = "América";
        string usernameTestChinese = "美国";
        string usernameTestNull = null;

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

                //for uri negative test
                case "LabCorpPOSTnegative":
                    //urlPOST_API = APIurl;
                    host = "https://petstore.swagger.io";
                    uri = "/v2/user";
                    break;

                //if API url have no exist, negative test
                default:
                    host = null;
                    uri = null;
                    break;
            }
        }

        //And JSON data for positive test
        [Given("JSON data for (.*) test")]
        public void GivenJSONdata(string testType)
        {
            switch (testType)
            {
                //for positive test
                case "positive":
                    dataPost.id = 43433;
                    dataPost.username = usernameTest;
                    dataPost.firstname = "RRRR";
                    dataPost.lastname = "LLL";
                    dataPost.email = "we@gmail.com";
                    dataPost.password = "23dwewe";
                    dataPost.phone = 2324433;
                    dataPost.userStatus = 0;

                    break;

                //positiveSpain
                case "positiveSpain":
                    dataPost.id = 43434;
                    dataPost.username = usernameTestSpain;
                    dataPost.firstname = "RRRR";
                    dataPost.lastname = "LLL";
                    dataPost.email = "we@gmail.com";
                    dataPost.password = "23dwewe";
                    dataPost.phone = 2324433;
                    dataPost.userStatus = 0;
                    break;

                //positiveChinese
                case "positiveChinese":
                    dataPost.id = 43435;
                    dataPost.username = usernameTestChinese;
                    dataPost.firstname = "RRRR";
                    dataPost.lastname = "LLL";
                    dataPost.email = "we@gmail.com";
                    dataPost.password = "23dwewe";
                    dataPost.phone = 2324433;
                    dataPost.userStatus = 0;
                    break;

                //negative
                //usernameTestNull
                case "negativee":
                    dataPost.id = 43435;
                    dataPost.username = usernameTestNull;
                    dataPost.firstname = "RRRR";
                    dataPost.lastname = "LLL";
                    dataPost.email = "we@gmail.com";
                    dataPost.password = "23dwewe";
                    dataPost.phone = 2324433;
                    dataPost.userStatus = 0;
                    break;

                default:
                    dataPost = null;
                    break;
            }                    
        }

        //When post sample json
        [When("post sample json (.*)")]
        public void WhenPostSampleJson(int statusCode)
        {
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
        //6 threads that runs for 30 seconds
        //.Load(6, 30)
                .Post()
                .Then()
                .Debug()
                .TestStatus("POST Status code response", x => x == statusCode) //read status code for assertion
                .AssertAll();
        }


        //Then assert status code 200
        [Then("assert status code (.*)")]
        public void ThenAssertStatusCode(int statusCode)
        {
            string requestData = JsonConvert.SerializeObject(dataPost);

            //send post request by Rest-assured
            new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .Host(host)
                .Uri(uri)
                .Body("[" + requestData + "]") //have to add square brackets to the body (API unique spec???)
                .When()
                //6 threads that runs for 30 seconds
                //.Load(6, 30)
                .Post()
                .Then()
                .Debug()
                .TestStatus("POST Status code response", x => x == statusCode) //read status code for assertion
                .AssertAll();
        }

        [Then("send get request to validate username")]
        public void ThenSendGetRequestToValidateUsername()
        {
            host = "https://petstore.swagger.io";
            uri = "/v2/user/" + usernameTest;

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