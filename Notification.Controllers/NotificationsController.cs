using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Notification.Commands;

namespace Notification.Controllers
{
    [Route("api/emailNotification")]
    [ApiController]
    internal class NotificationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public NotificationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("SendNotification")]
        [HttpPost]
        public async Task<IActionResult> SendEmailAsync(string email,string subject,string message, int id)
        {
            try
            {
                await mediator.Publish(new SendEmailOrderNotification( email, subject,message, id));

                return StatusCode(201);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
