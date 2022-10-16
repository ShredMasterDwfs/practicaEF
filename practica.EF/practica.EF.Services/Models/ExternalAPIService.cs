using practica.EF.Entities;
using practica.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica.EF.Services.Models
{
    public class ExternalAPIService
    {
        public async Task<List<ExternalAPI>> ListAPI()
        {
            ExternalAPILogic usuarioLogic = new ExternalAPILogic();

            try
            {
                return await usuarioLogic.GetAPI();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
