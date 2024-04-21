using JWT_Based_Authentication.Model;

namespace JWT_Based_Authentication.Services
{
    public class TaskServices:ITaskServices
    {
        public IEnumerable<Tasks> ViewTasks()
        {
            return tasks;
        }
        public static List<Tasks> tasks = new List<Tasks>
       {
           new Tasks{TaskId=1,TaskName="learn Javascript",TaskDescription="Complete in 3 days",TaskStatus="pending"},
           new Tasks{TaskId=2,TaskName="Start React js",TaskDescription="Build a project using React",TaskStatus="Not started"}
       };
        public IEnumerable<Tasks> AddTasks(Tasks task)
        {
            tasks.Add(new Tasks { TaskId = tasks.Count+1, TaskName = task.TaskName, TaskDescription = task.TaskDescription, TaskStatus = task.TaskStatus });
            return tasks;
        }
        public IEnumerable<Tasks> UpdateTasks(Tasks task)
        {   
            var value=tasks.FirstOrDefault(response=> task.TaskId == response.TaskId);
            value.TaskId= task.TaskId;
            value.TaskName = task.TaskName;
            value.TaskDescription= task.TaskDescription;
            value.TaskStatus= task.TaskStatus;
            return tasks;
        }
        public IEnumerable<Tasks> DeleteTasks(int id)
        {
            tasks.RemoveAll(t => t.TaskId == id);
            return tasks;
        }
    }
}
