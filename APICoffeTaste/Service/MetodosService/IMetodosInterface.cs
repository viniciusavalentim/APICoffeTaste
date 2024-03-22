using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.MetodosService
{
    public interface IMetodosInterface
    {
        Task<ServiceResponse<List<MetodosModel>>> GetMetodos();
        Task<ServiceResponse<List<MetodosModel>>> CreateMetodos(DtoCreateMetodo novoMetodo);
        Task<ServiceResponse<MetodosModel>> GetMetodoById(int id);
        Task<ServiceResponse<List<MetodosModel>>> UpdateMetodos(MetodosModel updateMetodo);
        Task<ServiceResponse<List<MetodosModel>>> DeleteMetodos(int id);


    }
}






