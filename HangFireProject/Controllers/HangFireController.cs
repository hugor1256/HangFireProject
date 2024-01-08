using Hangfire;
using HangFireProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HangFireProject.Controllers;

public class HangFireController : ControllerBase
{

    private IEmailService _emailService;
    private IBackgroundJobClient _backgroundJobClient;
    private IRecurringJobManager _recurringJobManager;

    public HangFireController(IEmailService emailService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
    {
        _emailService = emailService;
        _backgroundJobClient = backgroundJobClient;
        _recurringJobManager = recurringJobManager;
    }

    [HttpGet]
    [Route("ExececutarHangFire")]
    public ActionResult CreateFireAndForgetJob()
    {
        _backgroundJobClient.Enqueue(() => _emailService.SendEmail(":)", DateTime.Now.ToLongTimeString()));
        
        _backgroundJobClient.Schedule(
            () => _emailService.SendEmail(":)", DateTime.Now.ToLongTimeString()),
            TimeSpan.FromMinutes(2));
        
        RecurringJob.AddOrUpdate(() => _emailService.SendEmail(":)", DateTime.Now.ToLongTimeString()),Cron.Daily);

        return Ok("Job Executado com sucessom");
    }
}   
    