# Azure Notification Hub API App
[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)

## Deploying ##
Click the "Deploy to Azure" button above.  You can create new resources or reference existing ones (resource group, gateway, service plan, etc.)  **Site Name and Gateway must be unique URL hostnames.**  The deployment script will deploy the following:
 * Resource Group (optional)
 * Service Plan (if you don't reference exisiting one)
 * Gateway (if you don't reference existing one)
 * API App (EventHubAPI)
 * API App Host (this is the site behind the api app that this github code deploys to)

## API Documentation ##
The app has actions to send notifications via the Azure Notification Hub SDK

* Send Message (GCM)
* Send Message (MPNS)
* Send Message (Windows Native)
* Send Message (Apple Native)
* Send Message (Baidu Native)

### Send Message Action ###
Each action has the following inputs

| Input | Description |
| ----- | ----- |
| Connection String | The connection string to access the notification hub. |
| Notification Hub Name | Name of the notification hub (e.g. `mynotification` ) |
| Message | The message to send.  Make sure you format this as needed for the type of notification (XML, JSON, etc.) |

The action will return a Notification Outcome object with details of the send.
