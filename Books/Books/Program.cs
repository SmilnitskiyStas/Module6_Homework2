
using Books.Infrastructure;
using Books.Interfaces;
using Books.Services;

namespace Books
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddSingleton<IDataProvider, MemoryDataProvider>();

            // ������ CORS �� ������ ������.
            builder.Services.AddCors();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            /* ��� ����� ���� ���������� ��� �� ���� ������. Allow => ������� ��� (�� � ��������)
            * ����� ��������� ��������� ������ AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()~
            * WithMethods() => �� ��������� ��� ��������� �� ���� �� ������ ���������.
            * WithOrigins() => �� ���� ����� �� ������ ������ ���.
            */

            app.UseCors(builder => builder
            .WithOrigins("http://localhost:3000")
            .WithMethods("GET")
            .AllowAnyHeader());

            //app.UseCors(builder => builder
            //.AllowAnyOrigin()
            //.AllowAnyHeader());

            app.MapControllers();

            app.Run();
        }
    }
}