This example shows how to create layered app with pattern UnitOfWork

layred app consist of:
- Domain layer: the best place for dbcontext, domain model (POCO), migration
- Repository layer: best suited for UnitOfWork and Repository
- Model layer: could be the DTO or ViewModel depends on your needs
- Application layer: works with Repository layer and Model layer, implements business logic of your App
- API proj - implementation of REST interfaces without any business logic


SumUp:
+ every layer has strong limitation and only one purpose
+ easy to maintain and develop
+ easy to unit test
- it's hard to design