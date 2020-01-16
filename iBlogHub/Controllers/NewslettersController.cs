using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBlogHub.Data;
using iBlogHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace iBlogHub.Controllers
{
    public class NewslettersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<Newsletters> _logger;
        public NewslettersController(ApplicationDbContext db,
             IEmailSender emailSender, 
             ILogger<Newsletters> logger)
        {
            _db = db;
            _emailSender = emailSender;
            _logger = logger;
        }

        // GET: Newsletters
        public ActionResult Index()
        {
            return View();
        }

        // GET: Newsletters/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Newsletters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Newsletters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Newsletters newsletters)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkMail = await _db.Newsletters.Where(a => a.Email.ToLower().Equals(newsletters.Email.ToLower())).FirstOrDefaultAsync();

                    if (checkMail == null)
                    {
                        newsletters.id = Guid.NewGuid();
                        newsletters.SubscribedOn = DateTime.Now;
                        newsletters.isVerified = false;
                        _db.Newsletters.Add(newsletters);
                        await _db.SaveChangesAsync();
                        byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                        byte[] key = newsletters.id.ToByteArray();
                        string code = Convert.ToBase64String(time.Concat(key).ToArray());

                        var callbackUrl = Url.Action("ConfirmEmail", "Newsletters", new { newsletterId = newsletters.id, code = code }, protocol: Request.Scheme);

                        var msg = "<p>Greetings from iBlogHub, <br> Thank you for subscribing our newsletters, to continue your subscription, please" +
                            " verify you Email ID, click on the following link to verify now.<br> Verification Link: <a href=\""
                                                   + callbackUrl + "\">" + callbackUrl + "</a></p><br><p> <b>Regards, <br>Admin<br>@<a href='https://www.ibloghub.com'>iBlogHub.com</a></b></p>";
                        
                        await _emailSender.SendEmailAsync(newsletters.Email, "iBlogHub Newsletter Subscription", msg);
                        return Json(new
                        {
                            mail = newsletters.Email,
                            msg = "Thank you! you'll receive a confirmation mail soon, please verify it " +
                            "to continue subscription."
                        });
                    }
                    else
                    {
                        if (!checkMail.isVerified)
                        {

                            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                            byte[] key = newsletters.id.ToByteArray();
                            string code = Convert.ToBase64String(time.Concat(key).ToArray());

                            var callbackUrl = Url.Action("ConfirmEmail", "Newsletters", new { newsletterId = checkMail.id, code = code }, protocol: Request.Scheme);

                            var msg = "<p>Greetings from iBlogHub, <br> Thank you for subscribing our newsletters, to continue your subscription, please" +
                                " verify you Email ID, click on the following link to verify now.<br> Verification Link: <a href=\""
                                                       + callbackUrl + "\">" + callbackUrl + "</a></p><br><p> <b>Regards, <br>Admin<br>@<a href='https://www.ibloghub.com'>iBlogHub.com</a></b></p>";
                            await _emailSender.SendEmailAsync(newsletters.Email, "iBlogHub Newsletter Subscription", msg);
                            _logger.LogInformation($"New user with Email Id - {newsletters.Email} subscribed for Newsletter");
                            return Json(new
                            {
                                mail = newsletters.Email,
                                msg = "Thank you! you'll receive a confirmation mail soon, please verify it " +
                                "to continue subscription."
                            });
                        }
                        else
                        {
                            return Json(new
                            {
                                mail = newsletters.Email,
                                msg = "Thank you, but you're already subscribed!",
                                error = true
                            });
                        }

                    }

                }
                return Json(new { error = true, msg = "Some error occurred, please try again later." });

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error occurred in Newsletter for user - {newsletters.Email}. Error: ", ex);
                return Json(new { error = true, msg = "Some error occurred, please try again later." });
            }

        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string newsletterId, string code)
        {
            var newsId = Guid.Parse(newsletterId);
            var model = await _db.Newsletters.Where(a => a.id == newsId).SingleOrDefaultAsync();
            if (model == null)
            {
                ViewBag.Message = "0";
                return View("Verification");
            }
            byte[] data = Convert.FromBase64String(code);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            if (when < DateTime.UtcNow.AddHours(-24))
            {
                ViewBag.Message = "1";
                return View("Verification");
            }
            else
            {
                model.isVerified = true;
                await _db.SaveChangesAsync();
                ViewBag.Message = "Thank you for verifying your MailId, you're all set up to receive our newsletters.";
                return View("Verification", model);
            }
        }

        // GET: Newsletters/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Newsletters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Newsletters/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Newsletters/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}