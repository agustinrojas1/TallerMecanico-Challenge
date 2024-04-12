using Microsoft.EntityFrameworkCore;
using TallerMecanico.BusinessLogic.Services;
using TallerMecanico.BusinessLogic.Services.Reportes;
using TallerMecanico.Models.Dtos;
using TallerMecanico.Models.Models;
using TallerMecanico.Persistence;
using TallerMecanico.Persistence.Context;
using TallerMecanico.Persistence.Repository;
using TallerMecanico.Persistence.Repository.Reportes;
using TallerMecanico.Presentation.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("TallerMecanicoDbConnection");

builder.Services.AddDbContext<TallerMecanicoContext>(options =>
    options.UseSqlServer(connectionString,
    b => b.MigrationsAssembly("TallerMecanico.Presentation")));

builder.Services.AddScoped<IConnectionFactory>(provider =>
{
    return new ConnectionFactory(connectionString);
});

builder.Services.AddScoped<IRepositoryDto<Automovil, AutomovilQueryDto>, AutomovilRepository>();
builder.Services.AddScoped<IServiceDto<Automovil, AutomovilQueryDto>, AutomovilService>();
builder.Services.AddScoped<IRepositoryDto<Moto, MotoQueryDto>, MotoRepository>();
builder.Services.AddScoped<IServiceDto<Moto, MotoQueryDto>, MotoService>();
builder.Services.AddScoped<IRepositoryDto<Presupuesto, PresupuestoQueryDto>, PresupuestoRepository>();
builder.Services.AddScoped<IPresupuestoService, PresupuestoService>();
builder.Services.AddScoped<IRepository<Desperfecto>, DesperfectoRepository>();
builder.Services.AddScoped<IService<Desperfecto>, DesperfectoService>();
builder.Services.AddScoped<IRepository<Repuesto>, RepuestoRepository>();
builder.Services.AddScoped<IService<Repuesto>, RepuestoService>();
builder.Services.AddScoped<IRepository<DesperfectoRepuesto>, DesperfectoRepuestoRepository>();
builder.Services.AddScoped<IService<DesperfectoRepuesto>, DesperfectoRepuestoService>();

builder.Services.AddScoped<IReportesRepository, ReportesRepository>();
builder.Services.AddScoped<IReportesService, ReportesService>();


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
