Web APIs implemented using C#, .Net Core 6.0, EF Core, IOC Conainer and MS SQL.
----------
Following are application's modules/layers:
1. **Interfaces** - Top layer functionality, implemented by Servcies layer.
2. **Servcies** - Services class/layer used to separate the business logic of an application from the presentation or user interface layer.
3. **Unit Tests** - Unit testes with basic functions of testing the API controller, along with the implementation of Object Factories class.
4. **Data Access Layer** - Implementes EF Core & IOC Container.
5. **Db Health Checks** - This class implements the health check interface, As part of the this check it try to connect to the DB and, if connection is successfull it return a healthy status.
6. **System Configuration Health Checks** -  This class checks the API settings/configurations and make sure that all settings exists and that they are all valid, if any setting doesn't exists or isn't valid API may report unhealthy status.
7. **API Controllers** - API's implementation. Implements Routing {Get, Post including Filters, Put, Delete}, Authorization filters.
