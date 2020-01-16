using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using iBlogHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Atom;
using Microsoft.SyndicationFeed.Rss;

namespace iBlogHub.Helpers
{
    public interface IFeedService
    {
        Task<IEnumerable<AtomEntry>> GetEntries(string type, string host);
        Task<ISyndicationFeedWriter> GetWriter(string type, string host, XmlWriter xmlWriter);
    }

    public class FeedService : IFeedService
    {
        ApplicationDbContext _db;

        public FeedService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<AtomEntry>> GetEntries(string type, string host)
        {
            var items = new List<AtomEntry>();
            var posts = await _db.Posts.Include(a=>a.Author).Include(a=>a.Category).Where(p => p.isVerified && p.Status == Enums.PostStatus.Published).ToListAsync();

            foreach (var post in posts)
            {
                var item = new AtomEntry
                {
                    Title = post.PostTitle,
                    Description = post.PostContent,
                    Id = $"{host}/{post.Category.slug}/{post.slug}",
                    Published = post.PostDate,
                    LastUpdated = post.ModifiedOn,
                    ContentType = "html",
                };

                if (post.Category!=null)
                {
                    item.AddCategory(new SyndicationCategory(post.Category.Title));
                    
                }

                item.AddContributor(new SyndicationPerson(post.Author.FirstName + " "+ post.Author.LastName, post.Author.Email));
                item.AddLink(new SyndicationLink(new Uri(item.Id)));
                items.Add(item);
            }

            return await Task.FromResult(items);
        }

        public async Task<ISyndicationFeedWriter> GetWriter(string type, string host, XmlWriter xmlWriter)
        {
            var lastPost = _db.Posts.Include(a => a.Author).Include(a => a.Category).
                Where(p => p.isVerified && p.Status == Enums.PostStatus.Published).OrderByDescending(p => p.PostDate).FirstOrDefault();
          

            if (lastPost == null)
                return null;

            if (type.Equals("rss", StringComparison.OrdinalIgnoreCase))
            {
                var rss = new RssFeedWriter(xmlWriter);
                await rss.WriteTitle(lastPost.PostTitle);
                await rss.WriteDescription(lastPost.PostContent);
                await rss.WriteGenerator("iBlogHub");
                await rss.WriteValue("link", host);
                return rss;
            }

            var atom = new AtomFeedWriter(xmlWriter);
            await atom.WriteTitle(lastPost.PostTitle);
            await atom.WriteId(host);
            await atom.WriteSubtitle(lastPost.PostContent);
            await atom.WriteGenerator("iBlogHub", "http://www.ibloghub.com/", "1.0");
            await atom.WriteValue("updated", lastPost.PostDate.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            return atom;
        }
    }
}
