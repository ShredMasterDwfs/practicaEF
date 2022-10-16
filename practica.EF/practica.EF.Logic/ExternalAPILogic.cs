using practica.EF.Data;
using practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica.EF.Logic
{
    public class ExternalAPILogic
    {
        ExternalApiContext context = new ExternalApiContext();

        public async Task<List<ExternalAPI>> GetAPI()
        {
            try
            {
                var api = await context.GetAPIAsync();

                var response = api.Select(u => new ExternalAPI
                {
                    postId = u.postId,
                    id = u.id,                    
                    name = u.name,
                    email = u.email,
                    body = u.body
                }).ToList();

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
