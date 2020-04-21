namespace UpcomingGamesSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using UpcomingGamesSystem.Services.Data;
    using UpcomingGamesSystem.Web.ViewModels.Comments;

    public class CommentsController : Controller
    {
        private readonly ICommentsServices commentsServices;

        public CommentsController(ICommentsServices commentsServices)
        {
            this.commentsServices = commentsServices;
        }

        [Authorize]
        public IActionResult CreateComment()
        {
            return this.Redirect("/");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.commentsServices.CreateAsync(input);

            return this.Redirect("/");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteComment()
        {
            return this.Redirect("/");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteComment(string commentContent, string userId, int gameId)
        {
            await this.commentsServices.DeleteCommentAsync(commentContent, userId, gameId);

            return this.Redirect("/");
        }
    }
}
