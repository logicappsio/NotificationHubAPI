using Microsoft.ServiceBus.Notifications;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TRex.Metadata;
using System.Configuration;

namespace NotificationHubAPIApp.Controllers
{
    public class NotificationController : ApiController
    {
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(NotificationOutcome))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ConfigurationErrorsException))]
        [Metadata("Send Message (GCM)")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> SendGCMNotification([Metadata("Connection String")]string connectionString, [Metadata("Hub Name")]string hubName, [Metadata("Message")]string message)
        {
            try
            {
                NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);
                var result = await hub.SendGcmNativeNotificationAsync(message);
                return Request.CreateResponse<NotificationOutcome>(HttpStatusCode.OK, result);
            }
            catch (ConfigurationErrorsException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.BareMessage);
            }
        }

        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(NotificationOutcome))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ConfigurationErrorsException))]
        [Metadata("Send Message (MPNS)")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> SendMPNSNotification([Metadata("Connection String")]string connectionString, [Metadata("Hub Name")]string hubName, [Metadata("Toast XML")]string message)
        {
            try
            {
                NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);
                var result = await hub.SendMpnsNativeNotificationAsync(message);
                return Request.CreateResponse<NotificationOutcome>(HttpStatusCode.OK, result);
            }
            catch (ConfigurationErrorsException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.BareMessage);
            }
        }

        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(NotificationOutcome))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ConfigurationErrorsException))]
        [Metadata("Send Message (Windows Native)")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> SendWindowsNativeNotification([Metadata("Connection String")]string connectionString, [Metadata("Hub Name")]string hubName, [Metadata("Toast XML")]string message)
        {
            try
            {
                NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);
                var result = await hub.SendWindowsNativeNotificationAsync(message);
                return Request.CreateResponse<NotificationOutcome>(HttpStatusCode.OK, result);
            }
            catch (ConfigurationErrorsException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.BareMessage);
            }
        }

        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(NotificationOutcome))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ConfigurationErrorsException))]
        [Metadata("Send Message (Baidu Native)")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> SendBaiduNativeNotification([Metadata("Connection String")]string connectionString, [Metadata("Hub Name")]string hubName, [Metadata("Message")]string message)
        {
            try
            {
                NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);
                var result = await hub.SendBaiduNativeNotificationAsync(message);
                return Request.CreateResponse<NotificationOutcome>(HttpStatusCode.OK, result);
            }
            catch (ConfigurationErrorsException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.BareMessage);
            }
        }
        
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(NotificationOutcome))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ConfigurationErrorsException))]
        [Metadata("Send Message (Apple Native)")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> SendAppleNativeNotification([Metadata("Connection String")]string connectionString, [Metadata("Hub Name")]string hubName, [Metadata("JSON Payload")]string message)
        {
            try
            {
                NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);
                var result = await hub.SendAppleNativeNotificationAsync(message);
                return Request.CreateResponse<NotificationOutcome>(HttpStatusCode.OK, result);
            }
            catch (ConfigurationErrorsException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.BareMessage);
            }
        }

      
    }
}
