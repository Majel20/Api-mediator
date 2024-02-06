namespace FirstApi.Interfaces
{
    public interface IGenericRepository<M> where M : class
    {
        Task<M> GetById(int id);
        IQueryable<M> GetAll();
        Task Add(M entity);
        void Delete(M entity);
        void Update(M entity);

        void DeleteById(int id);
    }
}
