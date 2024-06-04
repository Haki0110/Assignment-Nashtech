using HoangTQ_LibraryManagement.Application.Interfaces;
using HoangTQ_LibraryManagement.Application.Services;
using HoangTQ_LibraryManagement.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HoangTQ_LibraryManagement.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBorrowingRequestService, BorrowingRequestService>();

            services.AddScoped<UserRepository>();
            services.AddScoped<BookRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<BorrowingRequestRepository>();
        }
    }
}
