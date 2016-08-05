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
        public async System.Threading.Tasks.Task<HttpResponseMessage> SendGCMNotification([Metadata("Connection String")]string connectionString, [Metadata("Hub Name")]string hubName, [Metadata("Message")]string message, [Metadata("Toast Tags")]string tags = null)
        {
            try
            {
                NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);

                NotificationOutcome result;
                if (!string.IsNullOrEmpty(tags))
                {
                    result = await hub.SendGcmNativeNotificationAsync(message, tags);
                }
                else
                {
                    result = await hub.SendGcmNativeNotificationAsync(message);
                }

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
        public async System.Threading.Tasks.Task<HttpResponseMessage> SendMPNSNotification([Metadata("Connection String")]string connectionString, [Metadata("Hub Name")]string hubName, [Metadata("Toast XML")]string message, [Metadata("Toast Tags")]string tags = null)
        {
            try
            {
                NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);

                NotificationOutcome result;
                if (!string.IsNullOrEmpty(tags))
                {
                    result = await hub.SendMpnsNativeNotificationAsync(message, tags);
                }
                else
                {
                    result = await hub.SendMpnsNativeNotificationAsync(message);
                }

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
        public async System.Threading.Tasks.Task<HttpResponseMessage> SendWindowsNativeNotification([Metadata("Connection String")]string connectionString, [Metadata("Hub Name")]string hubName, [Metadata("Toast XML")]string message, [Metadata("Toast Tags")]string tags = null)
        {
            try
            {
                NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);

                NotificationOutcome result;
                if (!string.IsNullOrEmpty(tags))
                {
                    result = await hub.SendWindowsNativeNotificationAsync(message, tags);
                }
                else
                {
                    result = await hub.SendWindowsNativeNotificationAsync(message);
                }

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
        [Metadata("Send RAW Message (Windows Native)")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> SendWindowsNativeRawNotification([Metadata("Connection String")]string connectionString, [Metadata("Hub Name")]string hubName, [Metadata("Toast RAW")]string message, [Metadata("Toast Tags")]string tags = null)
        {
            try
            {
                NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);
                
                Notification notification = new WindowsNotification(message);
                notification.Headers.Add("X-WNS-Type", "wns/raw");

                NotificationOutcome result;
                if (!string.IsNullOrEmpty(tags))
                {
                    result = await hub.SendNotificationAsync(notification, tags);
                }
                else
                {
                    result = await hub.SendNotificationAsync(notification);
                }

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
        public async System.Threading.Tasks.Task<HttpResponseMessage> SendBaiduNativeNotification([Metadata("Connection String")]string connectionString, [Metadata("Hub Name")]string hubName, [Metadata("Message")]string message, [Metadata("Toast Tags")]string tags = null)
        {
            try
            {
                NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);

                NotificationOutcome result;
                if (!string.IsNullOrEmpty(tags))
                {
                    result = await hub.SendBaiduNativeNotificationAsync(message, tags);
                }
                else
                {
                    result = await hub.SendBaiduNativeNotificationAsync(message);
                }

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
        public async System.Threading.Tasks.Task<HttpResponseMessage> SendAppleNativeNotification([Metadata("Connection String")]string connectionString, [Metadata("Hub Name")]string hubName, [Metadata("JSON Payload")]string message, [Metadata("Toast Tags")]string tags = null)
        {
            try
            {
                NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);
                
                NotificationOutcome result;
                if (!string.IsNullOrEmpty(tags))
                {
                    result = await hub.SendAppleNativeNotificationAsync(message, tags);
                }
                else
                {
                    result = await hub.SendAppleNativeNotificationAsync(message);
                }

                return Request.CreateResponse<NotificationOutcome>(HttpStatusCode.OK, result);
            }
            catch (ConfigurationErrorsException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.BareMessage);
            }
        }
    }
}
