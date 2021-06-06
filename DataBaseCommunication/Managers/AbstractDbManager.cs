using AutoMapper;

namespace DataBaseCommunication.Managers
{
    abstract internal class AbstractDbManager<DbModel, DTO>
    {
        protected StorageManagementDBContext dbContext;

        protected IMapper dtoMapper;

        public AbstractDbManager(StorageManagementDBContext dBContext, IMapper dtoMapper)
        {
            this.dbContext = dBContext;
            this.dtoMapper = dtoMapper;
        }

        protected DTO MapToDTO(DbModel model)
        {
            return dtoMapper.Map<DbModel, DTO>(model);
        }

        protected DbModel MapToModel(DTO model)
        {
            return dtoMapper.Map<DTO, DbModel>(model);
        }
    }
}
