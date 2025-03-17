
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
            //Establecer la conexión a la base de datos
            builder.Services.AddDbContext<TodoListContext> (options => options.UseMySQL(builder.Configuration.GetConnectionString("appDBConnection"))
            );

            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<ITask, TodoTaskService>();

            var app = builder.Build();

            //Test-Connection
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TodoListContext>();
                    bool canConnect = context.Database.CanConnect();
                    Console.WriteLine($"Conexión a la base de datos: {(canConnect ? "Exitosa": "Fallida")}");
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


            app.MapControllers();

            app.Run();
        }
    }
}
