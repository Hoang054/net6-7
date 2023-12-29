namespace CharityClinic.Services
{
    public interface IBaseService<T> where T : class
    {
        public Task<T?> Get(string entity);
        //public IEnumerable<T> Gets(T entity);
        //public IEnumerable<T> Gets(BaseSort? sort, BaseSearch? search);
        public Task<IEnumerable<T>> GetAll();
        public Task<IEnumerable<T>> Gets(int id);
        //public IEnumerable<T> GetPage(int pageNumber, int pageSize, BaseSort? sort, BaseSearch? search, out int totalRow);
        public Task<int> Create(T entity);
        public Task<int> Update(T entity);
        public Task<bool> Patch(T entity);
        public Task<int> Delete(int id);
    }
}
