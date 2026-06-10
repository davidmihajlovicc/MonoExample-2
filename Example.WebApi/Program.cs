using Autofac.Extensions.DependencyInjection;
using Example.Repository;
using Example.Repository.Common;
using Example.Service;
using Example.Service.Common;
using Autofac;
using System.Reflection;
using Example.Model.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllers();
builder.Services.AddAutoMapper(
    cfg => { },
    typeof(BookProfile),
    typeof(AuthorProfile)
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddTransient<IAuthorService, AuthorService >();
builder.Services.AddTransient<IBookService, BookService >();
builder.Services.AddTransient<IAuthorRepository,AuthorRepository >();
builder.Services.AddTransient<IBookRepository,BookRepository >();*/



builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    
    container.RegisterType<AuthorService>().As<IAuthorService>().InstancePerDependency();
    container.RegisterType<BookService>().As<IBookService>().InstancePerDependency();
    container.RegisterType<AuthorRepository>().As<IAuthorRepository>().InstancePerDependency();
    container.RegisterType<BookRepository>().As<IBookRepository>().InstancePerDependency();

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
