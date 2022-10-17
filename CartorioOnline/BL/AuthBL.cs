using CartorioOnline.Services;
using CartorioOnline.Models;
using System.Data;
using System.Threading.Tasks;

namespace CartorioOnline.BL
{
    public class AuthBL : BaseBL
    {
        #region Constructor
        protected readonly IAppSettings _appSettings;

        public AuthBL(IAppSettings appSettings) : base(appSettings)
        {
            _appSettings = appSettings;
        }

        public static AuthBL Create(IAppSettings appSettings)
        {
            return new AuthBL(appSettings);
        }
        #endregion

        #region Methods

        public Task<bool> IsLoggedIn()
        {
            //_db.ExecuteAsync("procedure", param: new
            //{
            //    Param1 = "parametro1",
            //    Param2 = "parametro2"
            //}, commandType: CommandType.StoredProcedure);

            //return Task.FromResult(true);
            return null;
        }

        #endregion

    }
}
