using Microsoft.EntityFrameworkCore;
using sprintCanvas.Data;
using sprintCanvas.Models;

namespace sprintCanvas.Services
{
    public class TaskService
    {
        private readonly KanbanDbContext _db;

        public TaskService(KanbanDbContext db)
        {
            _db = db;
        }

        public async Task<Board?> GetBoardAsync(int boardId = 1)
        {
            return await _db.Boards
                .Include(b => b.Columns)
                .Include(b => b.Tasks)
                .FirstOrDefaultAsync(b => b.Id == boardId);
        }

        public async Task<IEnumerable<Board>> GetBoardsForUserAsync(string? ownerId)
        {
            return await _db.Boards
                .Where(b => ownerId == null || b.OwnerId == ownerId)
                .ToListAsync();
        }

        public async Task<SprintTask> CreateTaskAsync(SprintTask task)
        {
            _db.SprintTasks.Add(task);
            await _db.SaveChangesAsync();
            return task;
        }

        public async Task UpdateTaskAsync(SprintTask task)
        {
            _db.SprintTasks.Update(task);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            var t = await _db.SprintTasks.FindAsync(taskId);
            if (t != null)
            {
                _db.SprintTasks.Remove(t);
                await _db.SaveChangesAsync();
            }
        }

        public async Task MoveTaskAsync(int taskId, int targetColumnId, int? targetOrder = null)
        {
            var t = await _db.SprintTasks.FindAsync(taskId);
            if (t == null) return;
            t.ColumnId = targetColumnId;
            if (targetOrder.HasValue) t.Order = targetOrder.Value;
            _db.SprintTasks.Update(t);
            await _db.SaveChangesAsync();
        }
    }
}
