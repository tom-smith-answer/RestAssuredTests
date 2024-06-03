namespace TestProject1
{
    using static RestAssured.Dsl;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("https://localhost:7135/api/Players")]
        [TestCase("https://localhost:7135/api/Players/1")]
        public void StatusCodeIndicatingSuccessCanBeVerifedForGetRequests(string url)
        {
            Given()
                .When()
                .Get(url)
                .Then()
                .StatusCode(200);
        }

        [TestCase("https://localhost:7135/api/Players")]
        [TestCase("https://localhost:7135/api/Players/1")]
        public void ResponseContentTypeHeaderCanBeVerifiedForGetRequests(string url)
        {
            Given()
            .When()
            .Get(url)
            .Then()
            .StatusCode(200)
            .ContentType("application/json; charset=utf-8");
        }

        [Test]
        public void JsonStringResponseBodyCanBeVerifiedForGetRequests()
        {
            Given()
            .When()
            .Get("https://localhost:7135/api/PLayers/1")
            .Then()
            .StatusCode(200)
            .Body("{\"id\":1,\"firstName\":\"Damián\",\"middleName\":\"Emiliano\",\"lastName\":\"Martínez\",\"dateOfBirth\":\"1992-09-02T01:00:00+01:00\",\"squadNumber\":23,\"position\":\"Goalkeeper\",\"abbrPosition\":\"GK\",\"team\":\"Aston Villa FC\",\"league\":\"Premier League\",\"starting11\":false}");
        }

        [Test]
        public void responsebodylengthcanbeverified()
        {
            Given()
            .When()
            .Get("https://localhost:7135/api/players")
            .Then()
            .Log(RestAssured.Response.Logging.ResponseLogLevel.All)
            .ResponseBodyLength(NHamcrest.Is.EqualTo(11));
        }

        [Test]
        public void ResponseTimeCanBeVerified()
        {
            Given()
            .When()
            .Get("https://localhost:7135/api/Players")
            .Then()
            .ResponseTime(NHamcrest.Is.LessThan(TimeSpan.FromMilliseconds(200)));
        }
    }
}