namespace Ingenum.Case.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using Ingenum.Case.Core.Repository;
    using Ingenum.Case.Core.Services;

    public abstract class BaseService<DtoType, AddDtoType, ModelType, TRepository> : IBaseService<DtoType, AddDtoType, ModelType, TRepository>
        where DtoType : class
        where AddDtoType : class
        where ModelType : class
        where TRepository : IBaseRepository<ModelType>
    {

        protected readonly IMapper _mapper;
        protected TRepository repository;

        public BaseService(TRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Count()
        {
            return await repository.Count();
        }

        public virtual async Task<DtoType> CreateAsync(AddDtoType obj)
        {
            var addObject = _mapper.Map<ModelType>(obj);

            if (addObject != null)
            {
                var incomeCreated = await repository.CreateAsync(addObject);

                return _mapper.Map<DtoType>(incomeCreated);
            }

            return null;
        }

        public virtual async Task<bool> DeleteAsync(string id)
        {
            return await repository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<DtoType>> GetAllAsync()
        {
            var objects = await repository.GetAllAsync();

            return _mapper.Map<IEnumerable<DtoType>>(objects);
        }

        public virtual async Task<DtoType> GetByIdAsync(string id)
        {
            var obj = await repository.GetByIdAsync(id);

            return _mapper.Map<DtoType>(obj);
        }

        public virtual async Task<DtoType> UpdateAsync(string id, DtoType obj)
        {
            var objectFromDatabase = await this.repository.GetByIdAsync(id);

            if (objectFromDatabase != null)
            {
                _mapper.Map(obj, objectFromDatabase);

                var updateObj = await this.repository.UpdateAsync(objectFromDatabase);

                return _mapper.Map<DtoType>(updateObj);
            }

            return null;
        }
    }
}
