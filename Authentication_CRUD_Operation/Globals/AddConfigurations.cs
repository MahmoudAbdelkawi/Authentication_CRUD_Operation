using Authentication_CRUD_Operation.Data;
using Authentication_CRUD_Operation.Dtos.Validation;
using Authentication_CRUD_Operation.Helpers;
using Authentication_CRUD_Operation.Repository.Employees;
using Authentication_CRUD_Operation.Repository.Users;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Authentication_CRUD_Operation.Globals
{
    public static class AddConfigurations
    {
        public static IServiceCollection AddConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole> (options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<JWT>(configuration.GetSection("JWT"));

            services.AddHttpContextAccessor();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());

            // add configuration for FluentValidation TODO in clean architecture
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
