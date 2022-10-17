using CartorioOnline.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CartorioOnline.BL
{

    public class BaseBL : IDisposable
    {
        protected readonly IAppSettings _appSettings;
        public BaseBL(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        } 

        #region IDisposible Helper
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);

            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        public string Connection(string query)
        {
            DataTable data = new DataTable();
            NpgsqlDataReader reader;

            using (var db = new NpgsqlConnection(_appSettings.ConnectionString))
            {
                db.Open();
                using (var command = new NpgsqlCommand(query, db))
                {
                    reader = command.ExecuteReader();
                    data.Load(reader);

                    reader.Close();
                    db.Close();
                }
            }
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            return json;
        }
    }
}
