using System.Threading.Tasks;

namespace LLY.LifeTask.Repository.Infra
{
    public interface IUnitOfWork
    {
        void Commit();
        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
    }
}