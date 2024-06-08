using Delgado.Server.DBConnect;
using Delgado.Shared;
using static System.Net.Mime.MediaTypeNames;


namespace Delgado.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();
           
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                                       builder => builder.WithOrigins("https://localhost:7155")
                                       .AllowAnyHeader()
                                       .AllowAnyMethod());
            });


            var mongoConnectionString = builder.Configuration.GetSection("MongoDB:ConnectionString").Value;
            var mongoDatabaseName = builder.Configuration.GetSection("MongoDB:DatabaseName").Value;
            if (string.IsNullOrEmpty(mongoConnectionString))
            {
                throw new Exception("mongoConnectionString is not set in the configuration");
            }
            if (string.IsNullOrEmpty(mongoDatabaseName))
            {
                throw new Exception("mongoDatabaseName is not set in the configuration");
            }
            else
            {
                builder.Services.AddSingleton(new DBConnect<CV>(mongoConnectionString, mongoDatabaseName));
            }

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var CVcollectionName = "CV";

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }


            app.UseCors("AllowSpecificOrigin");

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();


            //get cv
           
            app.MapGet("api/cv", async (DBConnect<CV> db) =>
            {
                var cv = await db.GetAll(CVcollectionName);
                return Results.Ok(cv);
            }).Produces<CV>(StatusCodes.Status200OK);

            //add cv
            app.MapPost("api/cv", async (DBConnect<CV> db, CV cv) =>
            {                
                await db.Add(CVcollectionName, cv);
                return Results.Ok(cv);
            });

            //modify cv
            app.MapPut("api/cv/{id}", async (DBConnect<CV> db, string id, CV cv) =>
            {
                await db.Update(CVcollectionName, id, cv);
                return Results.Ok(cv);
            });


            app.Run();            
        }
    }
}
