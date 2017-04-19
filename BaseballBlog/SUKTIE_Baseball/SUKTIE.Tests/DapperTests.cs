using NUnit.Framework;
using SUKTIE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUKTIE.Tests
{
    [TestFixture]
    public class DapperTests
    {
        [Test]
        public void CanLoadPosts()
        {
            var repo = new PostsRepository();

            var posts = repo.PostsSelectAll().ToList();

            Assert.AreEqual(2, posts.Count());

            Assert.AreEqual("Pirate Bullpen Update", posts[0].PostName);
        }

        [Test]
        public void CanLoadHashtags()
        {
            var repo = new HashtagsRepository();

            var hashtags = repo.HashtagsSelectAll().ToList();

            Assert.AreEqual(2, hashtags.Count());

            Assert.AreEqual("#Ballin", hashtags[0].HashtagName);
        }

        [Test]
        public void CanLoadStaticPage()
        {
            var repo = new StaticPageRepository();

            var staticPage = repo.StaticPageSelectAll().ToList();

            Assert.AreEqual(0, staticPage.Count());

            
        }

        [Test]
        public void CanLoadPostsByHashtagId()
        {
            var repo = new PostsRepository();

            var posts = repo.PostsSelectByHashtagId(1).ToList();

            Assert.AreEqual(2, posts.Count());


        }
        [Test]
        public void CanLoadMostRecentPost()
        {
            var repo = new PostsRepository();
            var post = repo.PostsSelectMostRecent().ToList();

            Assert.AreEqual(1, post.Count);
            Assert.AreEqual("Pirate Bullpen Update", post[0].PostName);  
        }

        [Test]
        public void CanLoad15RecentPosts()
        {
            var repo = new PostsRepository();
            var post = repo.PostsSelect15().ToList();

            Assert.AreEqual(2, post.Count);
            Assert.AreEqual("Pirate Bullpen Update", post[0].PostName);
        }
    }
}
