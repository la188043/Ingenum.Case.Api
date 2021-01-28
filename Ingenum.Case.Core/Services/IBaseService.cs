namespace Ingenum.Case.Core.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Ingenum.Case.Core.Repository;

    public interface IBaseService<DtoType, AddDtoType, ModelType, TRepository>
        where DtoType : class
        where AddDtoType : class
        where ModelType : class
        where TRepository : IBaseRepository<ModelType>
    {
        Task<IEnumerable<DtoType>> GetAllAsync();

        Task<DtoType> GetByIdAsync(string id);

        Task<DtoType> CreateAsync(AddDtoType obj);

        Task<DtoType> UpdateAsync(string id, DtoType obj);

        Task<bool> DeleteAsync(string id);

        Task<int> Count();
    }
}
