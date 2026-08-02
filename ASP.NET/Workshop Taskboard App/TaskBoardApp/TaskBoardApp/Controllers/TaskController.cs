using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;


namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext context;

        public TaskController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(taskModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            if (!GetBoards().Any(b=>b.Id==taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board doesn't exist");
            }
            string currentUserId = GetUserId();

            if (ModelState.IsValid)
            { 
                taskModel.Boards = GetBoards();
                return View(taskModel);
            }

            var task = new TaskBoardApp.Data.Models.Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn= DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();

            var boards = GetBoards();

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(int id)
        {
            var task=await context
                .Tasks
                .Where(t=>t.Id== id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Owner = t.Owner.UserName,
                    Board = t.Board.Name
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

                return View(task);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await context
                .Tasks
                .FindAsync(id);

            string currentUserId = GetUserId();
            if(currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(int id,TaskFormModel taskModel)
        {
            var task = await context.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board doesn't exist");
            }

            if (ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();
                return View(taskModel);
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await context.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await context.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };
            return View(taskModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            var task = await context.Tasks.FindAsync(taskModel.Id);

            if (task == null)
            {
                return Unauthorized();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }
        private IEnumerable<TaskBoardModel> GetBoards()
        {
            var boards = context.Boards
                 .Select(b => new TaskBoardModel()
                 {
                     Id = b.Id,
                     Name = b.Name
                 });

            return boards;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
