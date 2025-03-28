
using Microsoft.EntityFrameworkCore;
using TodoListApi.Context;
using TodoListApi.Interfeces;
using TodoListApi.Services;

namespace TodoListApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddControllers();
            //Establecer la conexi�n a la base de datos
            builder.Services.AddDbContext<TodoListContext> (options => options.UseMySQL(builder.Configuration.GetConnectionString("appDBConnection"))
            );

            //Inyectar las dependencias
            builder.Services.AddScoped<ITask, TodoTaskService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            //Configuraci�n de CORS para permitir peticiones desde cualquier origen
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            //Test de conecci�n a la base de datos
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TodoListContext>();
                    bool canConnect = context.Database.CanConnect();
                    Console.WriteLine($"Conexi�n a la base de datos: {(canConnect ? "Exitosa": "Fallida")}");
                }
                catch (Exception e)
                {

                    Console.WriteLine($"Error al conectar a la base de datos: {e.Message}");
                }
                

            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAll");
            app.MapControllers();

            app.Run();
        }
    }
}
