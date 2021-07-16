namespace Tmtrcs.Block.DomainBus.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Record InProcBusConfiguration.
    /// </summary>
    public sealed record InProcBusConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InProcBusConfiguration"/> class.
        /// </summary>
        public InProcBusConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InProcBusConfiguration"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public InProcBusConfiguration(IServiceCollection services) => this.Services = services;

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>The services.</value>
        // </summary>
        public IServiceCollection Services { get; init; }
    }
}
