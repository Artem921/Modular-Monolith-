using Identity.Infrastructure;
using Microsoft.AspNetCore.HttpOverrides;
using Notification.Application;
using Notification.Contract;
using Notification.Infrastructure;
using Orders.Application;
using Orders.Contract;
using Orders.Infrastructure;
using Product.Application;
using Product.Contract;
using Product.Infrastructure;

using Utils.Module;
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
              .ConfigureApplicationPartManager(manager => manager.FeatureProviders.Add(new InternalControllerFeatureProvider()));

builder.Services.RegisterModule<ProductContractModule>(builder.Configuration);
builder.Services.RegisterModule<ProductApplicationModule>(builder.Configuration);
builder.Services.RegisterModule<ProductInfastructureModule>(builder.Configuration);

builder.Services.RegisterModule<OrdersInfrastructureModule>(builder.Configuration);
builder.Services.RegisterModule<OrdersApplicationModule>(builder.Configuration);
builder.Services.RegisterModule<OrdersContractModule>(builder.Configuration);

builder.Services.RegisterModule<NotificationInfrastractionModule>(builder.Configuration);
builder.Services.RegisterModule<NotificationApplicationModule>(builder.Configuration);
builder.Services.RegisterModule<NotificationContractModule>(builder.Configuration);


builder.Services.RegisterModule<IdentityInfrastructureModule>(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseForwardedHeaders();
app.InitializerDataBase();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
