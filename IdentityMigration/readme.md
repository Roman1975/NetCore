## Purpose and goals
1. Need to migrate from asp.net mvc 4.5+ to asp.net core app 2.0
2. Migrate database with all ApplicationUsers, passswords, roles, external logins etc.
3. Migrate REST API part with existing AuthenticationServer (JWT) and ResourceServer
4. Explore new trends and solutions like OpenID


### Roadmap
- make database migration with existing users, see log.txt
- create AuthServer/ResourceServer with OpenID
- migrate users database to AuthServer?

### starting point, exploring https://IdentityServer.io
- general info https://andrewlock.net/an-introduction-to-openid-connect-in-asp-net-core/
- Asp.net Core identityt and IdentityServer - https://identityserver4.readthedocs.io/en/release/quickstarts/6_aspnet_identity.html
- using EF Core for configuration https://identityserver4.readthedocs.io/en/release/quickstarts/8_entity_framework.html
