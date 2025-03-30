using System;
namespace Planer;

public class Task
{
    public String? Name;
    public String Category;
    public int CategoryIndex;
    public Boolean IsFinished;
        
    public Task(String? taskName, String taskCategory, Boolean isFinished, int taskCategoryIndex)
    {
        Name = taskName;
        Category = taskCategory;
        IsFinished = isFinished;
        CategoryIndex = taskCategoryIndex;
    }
}