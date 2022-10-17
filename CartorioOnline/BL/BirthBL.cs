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
    public class BirthBL : BaseBL
    {
        protected readonly IAppSettings _appSettings;

        #region Constructor
        public BirthBL(IAppSettings appSettings) : base(appSettings)
        {
            _appSettings = appSettings;
        }

        public static BirthBL Create(IAppSettings appSettings)
        {
            return new BirthBL(appSettings);
        }
        #endregion

        #region Methods

        public string GetPageBirth(int page, int pageRows)
        {
            var query = $@"
                select 
                    birthid BirthId,
		            registrationdate RegistrationDate,
		            birthdate BirthDate,
		            registratecpf RegistrateCpf,
		            registratename RegistrateName,
		            fathername FatherName,
		            fathercpf FatherCpf,
		            mothername MotherName,
                    mothercpf MotherCpf
	            from birth
	            order by RegistrateName
	            limit {pageRows}
	            offset ({page} - 1) * 5;   
            ";

            return Connection(query);
        }

        public string PostBirth(BirthPostModel model)
        {
            var query = $@"
                INSERT INTO birth(
	                registrationdate, birthdate, registratecpf, registratename, fathername, fathercpf, mothername, mothercpf
                )
	            VALUES (
                    '{model.RegistrationDate}', 
                    '{model.BirthDate}',
                    '{model.RegistrateCpf}',
                    '{model.RegistrateName}',
                    '{model.FatherName}',
                    '{model.FatherCpf}',
                    '{model.MotherName}',
                    '{model.MotherCpf}'
                );
            ";
            Connection(query);
            return "Cadastrado com sucesso.";
        }

        #endregion
    }
}
