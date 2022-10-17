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
    public class MarriageBL : BaseBL
    {
        protected readonly IAppSettings _appSettings;

        #region Constructor
        public MarriageBL(IAppSettings appSettings) : base(appSettings)
        {
            _appSettings = appSettings;
        }

        public static MarriageBL Create(IAppSettings appSettings)
        {
            return new MarriageBL(appSettings);
        }
        #endregion

        #region Methods

        public string GetPageMarriage(int page, int pageRows)
        {
            var query = $@"
                select 
                    *
	            from marriage
	            order by marriagedate
	            limit {pageRows}
	            offset ({page} - 1) * 5;   
            ";

            return Connection(query);
        }

        public string PostMarriage(MarriageModel model)
        {
            var query = $@"
                INSERT INTO spouse (
	                birthdate, name, cpf, fathername, fatherbirthdate, fathercpf, mothername, motherbirthdate, mothercpf
                )
	            VALUES (
                    '{model.Spouse1.BirthDate}', 
                    '{model.Spouse1.Name}',
                    '{model.Spouse1.Cpf}',
                    '{model.Spouse1.FatherName}',
                    '{model.Spouse1.FatherBirthDate}',
                    '{model.Spouse1.FatherCpf}',
                    '{model.Spouse1.MotherName}',
                    '{model.Spouse1.MotherBirthDate}',
                    '{model.Spouse1.MotherCpf}'
                )
                returning spouseid;
            ";
            var spouseid1 = Connection(query);

            query = $@"
                INSERT INTO spouse (
	                birthdate, name, cpf, fathername, fatherbirthdate, fathercpf, mothername, motherbirthdate, mothercpf
                )
	            VALUES (
                    '{model.Spouse2.BirthDate}', 
                    '{model.Spouse2.Name}',
                    '{model.Spouse2.Cpf}',
                    '{model.Spouse2.FatherName}',
                    '{model.Spouse2.FatherBirthDate}',
                    '{model.Spouse2.FatherCpf}',
                    '{model.Spouse2.MotherName}',
                    '{model.Spouse2.MotherBirthDate}',
                    '{model.Spouse2.MotherCpf}'
                )
                returning spouseid;
            ";
            var spouseid2 = Connection(query);

            query = $@"
                INSERT INTO marriage (
	                registrationdate, marriagedate, spouseid1, spouseid2
                )
	            VALUES (
                    '{model.RegistrationDate}', 
                    '{model.MarriedDate}',
                    {spouseid1},
                    {spouseid2}
                );
            ";
            Connection(query);

            return "Cadastrado com sucesso.";
        }

        #endregion
    }
}
