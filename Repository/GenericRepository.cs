using Microsoft.EntityFrameworkCore;
using FirstApi.Interfaces;
using FirstApi.Model;


namespace FirstApi.Repository
{
    public class GenericRepository<M> : IGenericRepository<M> where M : class
    {
        protected readonly ProductContext productContext;

        public GenericRepository(ProductContext appDbContext)
        {
            productContext = appDbContext;
        }

        public Task Add(M entity)
        {
            productContext.Set<M>().Add(entity);
            return Task.CompletedTask;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(M entity)
        {
            productContext.Set<M>().Remove(entity);
        }

        public IQueryable<M> GetAll()
        {
            return productContext.Set<M>().AsNoTracking();
        }

        public Task<M> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(M entity)
        {
            throw new NotImplementedException();
        }
    }
}
