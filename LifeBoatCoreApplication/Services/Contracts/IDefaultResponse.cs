using Microsoft.Extensions.Configuration;

namespace LifeBoatCoreApplication.Services.Contracts
{
    public interface IDefaultResponse
    {
        string GetDefaultResponse();
        string GetDefaultReponseHardCoded();
    }

    class DefaultResponse : IDefaultResponse
    {
        private IConfiguration _configuration;

        public DefaultResponse(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetDefaultResponse()
        {
            return _configuration["DefaultResponseMessage"];
        }

        public string GetDefaultReponseHardCoded()
        {
            return "My Default Response!";
        }

    }
}