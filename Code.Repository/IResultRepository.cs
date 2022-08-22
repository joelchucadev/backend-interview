using Code.Repository.Model;

namespace Code.Repository
{
    // Repository Pattern
    public interface IResultRepository 
    {
        public void SaveResult(ResultEntity entity);
    }
}