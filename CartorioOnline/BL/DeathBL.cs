using CartorioOnline.Services;
using CartorioOnline.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace CartorioOnline.BL
{
    public class DeathBL : BaseBL
    {
        protected readonly IAppSettings _appSettings;

        #region Constructor
        public DeathBL(IAppSettings appSettings) : base(appSettings)
        {
            _appSettings = appSettings;
        }

        public static DeathBL Create(IAppSettings appSettings)
        {
            return new DeathBL(appSettings);
        }
        #endregion

        #region Methods

        public string GetPageDeath(int page, int pageRows)
        {
            var query = $@"
                select 
                    *
	            from death
	            order by deadname
	            limit {pageRows}
	            offset ({page} - 1) * 5;   
            ";

            return Connection(query);
        }

        public string PostDeath(DeathPostModel model)
        {
            var query = $@"
                INSERT INTO death(
	                registrationdate, deathdate, deadname, deadcpf, deadbirthdate, fathername, fatherbirthdate, mothername, motherbirthdate
                )
	            VALUES (
                    '{model.RegistrationDate}', 
                    '{model.DeathDate}',
                    '{model.DeadName}',
                    '{model.DeadCpf}',
                    '{model.BirthDate}',
                    '{model.FatherName}',
                    '{model.FatherBirthDate}',
                    '{model.MotherName}',
                    '{model.MotherBirthDate}'
                );
            ";
            Connection(query);
            return "Cadastrado com sucesso.";
        }

        #endregion
    }
}
