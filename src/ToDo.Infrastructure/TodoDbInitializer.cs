using ToDo.Domain.Entities;

namespace ToDo.Infrastructure
{
    public class TodoDbInitializer
    {
        public static void Initializer(ToDoDbContext toDoDbContext)
        {
            toDoDbContext.Database.EnsureCreated();

            if(!toDoDbContext.Todos.Any() && !toDoDbContext.Categories.Any())
            {
                Categorey category1 = new Categorey()
                {
                    Name = "Category1",
                    CreateAt = DateTime.UtcNow,
                };
                Categorey category2 = new Categorey()
                {
                    Name = "Category2",
                    CreateAt = DateTime.UtcNow,
                };

                toDoDbContext.Add(category1);
                toDoDbContext.Add(category2);

                List<Todo> todoList = new List<Todo>();

                for (int i = 0; i < 100; i++)
                {
                    bool isEven = (i % 2 == 0);

                    Todo todo = new Todo()
                    {
                        Title = $"To Do {i + 1}",
                        Description = $"Description {i + 1}",
                        CategoryId = isEven ? category1.Id : category2.Id,
                        CreateAt = DateTime.UtcNow,
                    };

                    todoList.Add(todo);
                }

                toDoDbContext.AddRange(todoList);
                toDoDbContext.SaveChanges();
            }
        }
    }
}
