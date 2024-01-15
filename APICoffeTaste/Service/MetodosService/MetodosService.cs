using APICoffeTaste.Models;

namespace APICoffeTaste.Service.MetodosService
{
    public class MetodosService
    {

        public MetodosService() { }

        public async Task<List<MetodosModel>> GetMetodos()
        {
            List<MetodosModel>  metodos = new List<MetodosModel>();
  
            try
            {
                 metodos.ToList();
            }
            catch (Exception ex)
            {
                
            }
            return metodos;
        }

    }
}
