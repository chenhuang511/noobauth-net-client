# NoobAuth Net Client

The simple Netcore web app, implement OAuth2 authorization, integerate with [NoobAuth](https://github.com/chenhuang511/noob-oauth) server.

# Getting started

If you are running the NoobAuth server in localhost, you need change the ```appsettings.json``` with your NoobAuth information, or add a record into your machine ```hosts``` file as follows:

* 127.0.0.1 noobauth.vn
* 127.0.0.1 netclient.vn

## Logout callback

Because the NoobAuth (OAuth2 server) will call back to our NetClient, we need give the right callback url before calling the Logout Endpoint.

Change callback url in class ```Controllers/AccountController.cs``` with the domain you are running this project (https://netclient.vn for example).

With local running, you may need modify for machine ```hosts``` file, separate the domains of NoobAuth and NetClient to avoid the confusion about cookies of 2 applications.

## Refer

This project used a part of code from [the example](https://github.com/oktadev/okta-aspnet-oauth2-starter-example)

# License

MIT