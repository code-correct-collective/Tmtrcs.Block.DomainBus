namespace Tmtrcs.Block.DomainBus.Configuration
{
    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    using Tmtrcs.Block.DomainBus;
    using Tmtrcs.Block.DomainBus.Events;
    using Tmtrcs.Block.DomainBus.Queries;

    /// <summary>
    /// Class <c>ConfigurationExtensions</c>.
    /// </summary>
    public static class InProcBusConfigurationExtensions
    {
        /// <summary>
        /// Adds the in proc bus.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>InProcBusConfiguration.</returns>
        public static InProcBusConfiguration AddInProcBus(this IServiceCollection services)
        {
            var configuration = new InProcBusConfiguration { Services = services };
            configuration.Services.AddScoped<IMediator, Mediator>();
            configuration.Services.AddTransient<ServiceFactory>(sp => sp.GetService);
            return configuration;
        }

        /// <summary>
        /// Adds the command support.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>A/an <c>IServiceCollection</c>.</returns>
        public static IDomainCommandBuilder AddCommands(this InProcBusConfiguration configuration)
        {
            configuration.Services.AddScoped<IDomainCommandBus, DomainCommandBus>();

            return new DomainCommandBuilder(configuration);
        }

        /// <summary>
        /// Ands the specified command builder.
        /// </summary>
        /// <param name="commandBuilder">The command builder.</param>
        /// <returns>InProcBusConfiguration.</returns>
        public static InProcBusConfiguration And(this IDomainCommandBuilder commandBuilder) => commandBuilder.Configuration;

        /// <summary>
        /// Adds the events.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>A/an <c>IEventBuilder</c>.</returns>
        public static IDomainEventBuilder AddEvents(this InProcBusConfiguration configuration)
        {
            configuration.Services.AddScoped<IDomainEventBus, DomainEventBus>();

            return new DomainEventBuilder(configuration);
        }

        /// <summary>
        /// Ands the specified event builder.
        /// </summary>
        /// <param name="eventBuilder">The event builder.</param>
        /// <returns>InProcBusConfiguration.</returns>
        public static InProcBusConfiguration And(this IDomainEventBuilder eventBuilder) => eventBuilder.Configuration;

        /// <summary>
        /// Adds the query.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>A/an <c>IQueryBuilder</c>.</returns>
        public static IDomainQueryBuilder AddQueries(this InProcBusConfiguration configuration)
        {
            configuration.Services.AddScoped<IDomainQueryBus, DomainQueryBus>();

            return new DomainQueryBuilder(configuration);
        }

        /// <summary>
        /// Ands the specified query builder.
        /// </summary>
        /// <param name="queryBuilder">The query builder.</param>
        /// <returns>InProcBusConfiguration.</returns>
        public static InProcBusConfiguration And(this IDomainQueryBuilder queryBuilder) => queryBuilder.Configuration;
    }
}
