using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using iBlogHub.Models;
using iBlogHub.Helpers;
using iBlogHub.Data;
using System.Xml;
using SimpleMvcSitemap;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Markdig;

namespace iBlogHub.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostsService _postService;
        private readonly ICurrentUser _user;
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;
        IFeedService _ss;
        public HomeController(ILogger<HomeController> logger, 
            IPostsService postsService,
            ICurrentUser user, ApplicationDbContext context,
            IStringLocalizer<HomeController> localizer,
            IFeedService ss) : base(context, postsService)
        {
            _logger = logger;
            _user = user;
            _context = context;
            _postService = postsService;            
            _localizer = localizer;
            _ss = ss;
        }

        public async Task<IActionResult> Index()
        {

            var model = new HomeViewModel();
            
            model.Articles = await _postService.Get();
            model.CategoriesModel = await _postService.AllCategories();
            model.User = _user.User;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/Search")]
        public async Task<IActionResult> Search(string q, int? page)
        {
            
            if (!string.IsNullOrEmpty(q) || !string.IsNullOrWhiteSpace(q))
            {
                ViewBag.SearchString = q;
                var model = await _postService.Search(q, 1);
                return View("_SearchResults", model);// Json(new { data = model },
            }
            else
            {
                return Json(new { data = false, msg = "Type your query to search." });
            }
        }

        [Route("/sitemap.xml")]
        public void Sitemap()
        {
            string host = Request.Scheme + "://" + Request.Host;

            Response.ContentType = "application/xml";

            using (var xml = XmlWriter.Create(Response.Body, new XmlWriterSettings { Indent = true }))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

                xml.WriteStartElement("url");
                xml.WriteElementString("loc", host);
                xml.WriteEndElement();

                xml.WriteEndElement();
            }
        }

        [HttpGet("/feed/{type}")]
        public async Task Rss(string type)
        {
            Response.ContentType = "application/xml";
            string host = Request.Scheme + "://" + Request.Host;

            using (XmlWriter xmlWriter = XmlWriter.Create(Response.Body, new XmlWriterSettings() { Async = true, Indent = true }))
            {
                var posts = await _ss.GetEntries(type, host);

                if (posts != null && posts.Count() > 0)
                {
                    var lastUpdated = posts.FirstOrDefault().Published;
                    var writer = await _ss.GetWriter(type, host, xmlWriter);

                    foreach (var post in posts)
                    {
                        post.Description = MdToHtml(post.Description);
                        await writer.Write(post);
                    }
                }
            }
        }

        private string MdToHtml(string str)
        {
            var mpl = new MarkdownPipelineBuilder()
                .UsePipeTables()
                .UseAdvancedExtensions()
                .Build();
            return Markdown.ToHtml(str, mpl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
