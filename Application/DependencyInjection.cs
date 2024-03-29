using BasicGraphQL.Application.UseCases.Books;

namespace BasicGraphQL.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBookUseCase, CreateBookUseCase>();

        return services;
    }
}