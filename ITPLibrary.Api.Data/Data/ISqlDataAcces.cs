namespace ITPLibrary.Api.Data.Data
{
    public interface ISqlDataAcces<T> where T : class
    {
        IEnumerable<T> GetAll(string queryString);
        T Get(string queryString);
        public void Add(string sqlCommand, T entity);
        public void Update(string sqlCommand, T entity);
        public void Delete(string sqlCommand, int id);
    }
}