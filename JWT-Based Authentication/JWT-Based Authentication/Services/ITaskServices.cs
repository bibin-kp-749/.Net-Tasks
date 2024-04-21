using JWT_Based_Authentication.Model;

namespace JWT_Based_Authentication.Services
{
    public interface ITaskServices
    {
        public IEnumerable<Tasks> ViewTasks();
        public IEnumerable<Tasks> AddTasks(Tasks task);
        public IEnumerable<Tasks> UpdateTasks(Tasks task);
        public IEnumerable<Tasks> DeleteTasks(int id);
    }
}
