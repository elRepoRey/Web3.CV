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
          
                            
            var DBConnectionString = builder.Configuration["Zoormongodb"];
            if (string.IsNullOrEmpty(DBConnectionString))
            {
                throw new Exception("Zoormongodb is not set in the configuration");
            }
            else
            {
                builder.Services.AddSingleton(new DBConnect<CV>(DBConnectionString, "CV"));
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
