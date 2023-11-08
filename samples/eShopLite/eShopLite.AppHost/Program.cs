﻿var builder = DistributedApplication.CreateBuilder(args);

var catalogDb = builder.AddPostgresContainer("catalog").AddDatabase("catalogdb");
var basketCache = builder.AddRedisContainer("basketcache");

var catalogService = builder.AddProject<Projects.eShopLite_CatalogService>("catalogservice")
    .WithReference(catalogDb);

var basketService = builder.AddProject<Projects.eShopLite_BasketService>("basketservice")
    .WithReference(basketCache);

builder.AddProject<Projects.eShopLite_Frontend>("frontend")
    .WithReference(basketService)
    .WithReference(catalogService);

builder.AddProject<Projects.eShopLite_CatalogDb>("catalogdbapp")
    .WithReference(catalogDb);

builder.Build().Run();
