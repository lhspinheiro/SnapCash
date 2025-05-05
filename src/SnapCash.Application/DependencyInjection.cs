using Microsoft.Extensions.DependencyInjection;
using SnapCash.Application.AutoMapper;
using SnapCash.Application.UseCases.Register;
using SnapCash.Application.UseCases.Transfer;
using SnapCash.Communication.Services;
using SnapCash.Communication.Services.Notify;

namespace SnapCash.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddAutoMapper(services);
        
    }
    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
    private static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUser, RegisterUser>();
        services.AddScoped<ITransferUseCase, TransferUseCase>();
        services.AddHttpClient<IAuthorizationService, AuthorizationService>();
        services.AddHttpClient<ISendNotification, SendNotification>();
    }
}