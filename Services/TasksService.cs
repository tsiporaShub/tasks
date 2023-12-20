using tasks.Models;
namespace tasks.Services;

public static class TasksService
{
    private static List<Task1> tasksList;

    static TasksService()
    {
        tasksList = new List<Task1>
        {
            new Task1 { Id = 1, Description = "todoHomeWork", IsDone = false},
            new Task1 { Id = 2, Description = "toSleep", IsDone = false},
            new Task1 { Id = 3, Description = "toEat", IsDone = true}
        };
    }

    public static List<Task1> GetAll() => tasksList;

    public static Task1 GetById(int id) 
    {
        return tasksList.FirstOrDefault(t => t.Id == id);
    }

    public static int Add(Task1 newTask)
    {
        if (tasksList.Count == 0)

            {
                newTask.Id = 1;
            }
        else
            {
                 newTask.Id =  tasksList.Max(t => t.Id) + 1;

            }

        tasksList.Add(newTask);

        return newTask.Id;
    }
  
    public static bool Update(int id, Task1 newTask)
    {
        if (id != newTask.Id)
            return false;

        var existingTask = GetById(id);
        if (existingTask == null )
            return false;

        var index = tasksList.IndexOf(existingTask);
        if (index == -1 )
            return false;

        tasksList[index] = newTask;

        return true;
    }  

      
    public static bool Delete(int id)
    {
         var existingTask = GetById(id);
        if (existingTask == null )
            return false;

        var index = tasksList.IndexOf(existingTask);
        if (index == -1 )
            return false;

        tasksList.RemoveAt(index);
        return true;
    }  



}