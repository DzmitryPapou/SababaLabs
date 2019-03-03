using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FinalTask.ComputerScience.Logic.Facebook;
using FinalTask.ComputerScience.Logic.Interfaces;
using FinalTask.ComputerScience.Logic.Models;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Sababa.Logic.Tests.FinalTask.ComputerScience.Logic.Facebook
{
    [TestFixture]
    public class FacebookSocialNetworkTests
    {
        private AutoMocker Mocker;
        [SetUp]
        public void SetUp()
        {
            Mocker = new AutoMocker();
            Mocker.Use<FacebookSession>(new FacebookSession { Token = "AccessToken" });
        }

        [Test]
        public async Task FacebookFriends_Calling_RestClient()
        {
            Mocker.GetMock<IRestClient>()
                  .Setup(x => x.GetAsync(It.IsAny<string>(), CancellationToken.None))
                  .Returns(() => Task.FromResult("{\n  \"data\": [\n    {\n      \"id\": \"1958836617507628\",\n      \"name\": \"Николай Харевич\",\n      \"picture\": {\n        \"data\": {\n          \"height\": 50,\n          \"is_silhouette\": false,\n          \"url\": \"https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=1958836617507628&height=50&width=50&ext=1542795759&hash=AeRmTpikh2e4WWtj\",\n          \"width\": 50\n        }\n      },\n      \"likes\": {\n        \"data\": [\n          {\n            \"name\": \"Deep Purple\",\n            \"id\": \"143219729160521\",\n            \"created_time\": \"2018-10-10T08:23:06+0000\"\n          },\n          {\n            \"name\": \"Nirvana\",\n            \"id\": \"49436315526\",\n            \"created_time\": \"2018-10-10T08:22:53+0000\"\n          },\n          {\n            \"name\": \"Led Zeppelin\",\n            \"id\": \"131572223581891\",\n            \"created_time\": \"2018-10-10T08:22:46+0000\"\n          },\n          {\n            \"name\": \"The Prodigy\",\n            \"id\": \"18452288248\",\n            \"created_time\": \"2018-10-10T08:22:40+0000\"\n          },\n          {\n            \"name\": \"Fatboy Slim\",\n            \"id\": \"127027408216\",\n            \"created_time\": \"2018-10-10T08:17:57+0000\"\n          },\n          {\n            \"name\": \"Moby\",\n            \"id\": \"6028461107\",\n            \"created_time\": \"2018-10-10T08:16:51+0000\"\n          },\n          {\n            \"name\": \"Depeche Mode\",\n            \"id\": \"26101560328\",\n            \"created_time\": \"2018-10-10T08:16:44+0000\"\n          },\n          {\n            \"name\": \"rammstein\",\n            \"id\": \"108659419215323\",\n            \"created_time\": \"2018-10-10T08:15:39+0000\"\n          },\n          {\n            \"name\": \"Queen\",\n            \"id\": \"17337462361\",\n            \"created_time\": \"2018-10-10T08:14:35+0000\"\n          },\n          {\n            \"name\": \"AC/DC\",\n            \"id\": \"6750402929\",\n            \"created_time\": \"2018-10-10T08:14:25+0000\"\n          },\n          {\n            \"name\": \"Black Sabbath\",\n            \"id\": \"56848544614\",\n            \"created_time\": \"2018-10-10T08:12:18+0000\"\n          },\n          {\n            \"name\": \"Dungeon Hunter\",\n            \"id\": \"109439259242551\",\n            \"created_time\": \"2014-02-11T20:11:47+0000\"\n          }\n        ],\n        \"paging\": {\n          \"cursors\": {\n            \"before\": \"MTQzMjE5NzI5MTYwNTIx\",\n            \"after\": \"MTA5NDM5MjU5MjQyNTUx\"\n          }\n        }\n      }\n    }\n  ]\n}"));
            var fr = Mocker.CreateInstance<FacebookFriends>();
            await fr.GetFriendsAsync(null);
            Mocker.GetMock<IRestClient>().Verify(x => x.GetAsync(It.IsAny<string>(), CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task FacebookFriends_GettingFriends()
        {

            Mocker.GetMock<IRestClient>()
                 .Setup(x => x.GetAsync(It.IsAny<string>(), CancellationToken.None))
                 .Returns(() => Task.FromResult("{\n  \"data\": [\n    {\n      \"id\": \"1958836617507628\",\n      \"name\": \"Николай Харевич\",\n      \"picture\": {\n        \"data\": {\n          \"height\": 50,\n          \"is_silhouette\": false,\n          \"url\": \"https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=1958836617507628&height=50&width=50&ext=1542795759&hash=AeRmTpikh2e4WWtj\",\n          \"width\": 50\n        }\n      },\n      \"likes\": {\n        \"data\": [\n          {\n            \"name\": \"Deep Purple\",\n            \"id\": \"143219729160521\",\n            \"created_time\": \"2018-10-10T08:23:06+0000\"\n          },\n          {\n            \"name\": \"Nirvana\",\n            \"id\": \"49436315526\",\n            \"created_time\": \"2018-10-10T08:22:53+0000\"\n          },\n          {\n            \"name\": \"Led Zeppelin\",\n            \"id\": \"131572223581891\",\n            \"created_time\": \"2018-10-10T08:22:46+0000\"\n          },\n          {\n            \"name\": \"The Prodigy\",\n            \"id\": \"18452288248\",\n            \"created_time\": \"2018-10-10T08:22:40+0000\"\n          },\n          {\n            \"name\": \"Fatboy Slim\",\n            \"id\": \"127027408216\",\n            \"created_time\": \"2018-10-10T08:17:57+0000\"\n          },\n          {\n            \"name\": \"Moby\",\n            \"id\": \"6028461107\",\n            \"created_time\": \"2018-10-10T08:16:51+0000\"\n          },\n          {\n            \"name\": \"Depeche Mode\",\n            \"id\": \"26101560328\",\n            \"created_time\": \"2018-10-10T08:16:44+0000\"\n          },\n          {\n            \"name\": \"rammstein\",\n            \"id\": \"108659419215323\",\n            \"created_time\": \"2018-10-10T08:15:39+0000\"\n          },\n          {\n            \"name\": \"Queen\",\n            \"id\": \"17337462361\",\n            \"created_time\": \"2018-10-10T08:14:35+0000\"\n          },\n          {\n            \"name\": \"AC/DC\",\n            \"id\": \"6750402929\",\n            \"created_time\": \"2018-10-10T08:14:25+0000\"\n          },\n          {\n            \"name\": \"Black Sabbath\",\n            \"id\": \"56848544614\",\n            \"created_time\": \"2018-10-10T08:12:18+0000\"\n          },\n          {\n            \"name\": \"Dungeon Hunter\",\n            \"id\": \"109439259242551\",\n            \"created_time\": \"2014-02-11T20:11:47+0000\"\n          }\n        ],\n        \"paging\": {\n          \"cursors\": {\n            \"before\": \"MTQzMjE5NzI5MTYwNTIx\",\n            \"after\": \"MTA5NDM5MjU5MjQyNTUx\"\n          }\n        }\n      }\n    }\n  ]\n}"));
            var fr = Mocker.CreateInstance<FacebookFriends>();

            var result = await fr.GetFriendsAsync(null);
            Assert.That(result.Select(rs => rs.Id), Is.EquivalentTo(TestFriends().Select(tf => tf.Id)));
            Assert.That(result.Select(rs => rs.Name), Is.EquivalentTo(TestFriends().Select(tf => tf.Name)));

        }

        [Test]
        public async Task FacebookMusic_GettingMusic()
        {
            Mocker.GetMock<IRestClient>()
                  .Setup(x => x.GetAsync(It.IsAny<string>(), CancellationToken.None))
                  .Returns(() => Task.FromResult("{\n  \"data\": [\n    {\n      \"id\": \"1958836617507628\",\n      \"name\": \"Николай Харевич\",\n      \"picture\": {\n        \"data\": {\n          \"height\": 50,\n          \"is_silhouette\": false,\n          \"url\": \"https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=1958836617507628&height=50&width=50&ext=1542795759&hash=AeRmTpikh2e4WWtj\",\n          \"width\": 50\n        }\n      },\n      \"likes\": {\n        \"data\": [\n          {\n            \"name\": \"Deep Purple\",\n            \"id\": \"143219729160521\",\n            \"created_time\": \"2018-10-10T08:23:06+0000\"\n          },\n          {\n            \"name\": \"Nirvana\",\n            \"id\": \"49436315526\",\n            \"created_time\": \"2018-10-10T08:22:53+0000\"\n          },\n          {\n            \"name\": \"Led Zeppelin\",\n            \"id\": \"131572223581891\",\n            \"created_time\": \"2018-10-10T08:22:46+0000\"\n          },\n          {\n            \"name\": \"The Prodigy\",\n            \"id\": \"18452288248\",\n            \"created_time\": \"2018-10-10T08:22:40+0000\"\n          },\n          {\n            \"name\": \"Fatboy Slim\",\n            \"id\": \"127027408216\",\n            \"created_time\": \"2018-10-10T08:17:57+0000\"\n          },\n          {\n            \"name\": \"Moby\",\n            \"id\": \"6028461107\",\n            \"created_time\": \"2018-10-10T08:16:51+0000\"\n          },\n          {\n            \"name\": \"Depeche Mode\",\n            \"id\": \"26101560328\",\n            \"created_time\": \"2018-10-10T08:16:44+0000\"\n          },\n          {\n            \"name\": \"rammstein\",\n            \"id\": \"108659419215323\",\n            \"created_time\": \"2018-10-10T08:15:39+0000\"\n          },\n          {\n            \"name\": \"Queen\",\n            \"id\": \"17337462361\",\n            \"created_time\": \"2018-10-10T08:14:35+0000\"\n          },\n          {\n            \"name\": \"AC/DC\",\n            \"id\": \"6750402929\",\n            \"created_time\": \"2018-10-10T08:14:25+0000\"\n          },\n          {\n            \"name\": \"Black Sabbath\",\n            \"id\": \"56848544614\",\n            \"created_time\": \"2018-10-10T08:12:18+0000\"\n          },\n          {\n            \"name\": \"Dungeon Hunter\",\n            \"id\": \"109439259242551\",\n            \"created_time\": \"2014-02-11T20:11:47+0000\"\n          }\n        ],\n        \"paging\": {\n          \"cursors\": {\n            \"before\": \"MTQzMjE5NzI5MTYwNTIx\",\n            \"after\": \"MTA5NDM5MjU5MjQyNTUx\"\n          }\n        }\n      }\n    }\n  ]\n}"));

            var mus = Mocker.CreateInstance<FacebookMusic>();

            var result = await mus.GetMusicAsync(null);
            Assert.That(result.Select(rs => rs.Value.Id), Is.EquivalentTo(TestMusic().Select(tm => tm.Id)));
        }

        private static IEnumerable<Friends> TestFriends()
        {
            return new[]
            {
                new Friends { Id = "1958836617507628", Name = "Николай Харевич", Picture = "https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=1958836617507628&height=50&width=50&ext=1542795759&hash=AeRmTpikh2e4WWtj\\" },
            };
        }

        private static IEnumerable<Music> TestMusic()
        {
            return new[]
            {
                new Music("143219729160521"),
                new Music("49436315526"),
                new Music("131572223581891"),
                new Music("18452288248"),
                new Music("127027408216"),
                new Music("6028461107"),
                new Music("26101560328"),
                new Music("108659419215323"),
                new Music("17337462361"),
                new Music("6750402929"),
                new Music("56848544614"),
                new Music("109439259242551")
            };
        }
    }
}
