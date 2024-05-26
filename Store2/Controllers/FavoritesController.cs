using Microsoft.AspNet.Identity;
using Store2.Domain;
using Store2.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store2.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Favorites
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var favorites = db.Favorites.Where(f => f.UserId == userId).Include(f => f.Product).ToList();
            return View(favorites);
        }

        // POST: Favorites/Add
        [HttpPost]
        public JsonResult Add(int productId)
        {
            var userId = User.Identity.GetUserId();
            var existingFavorite = db.Favorites.FirstOrDefault(f => f.UserId == userId && f.ProductId == productId);

            if (existingFavorite != null)
            {
                return Json(new { success = false, message = "Товар уже в списке избранного" });
            }

            var favorite = new Favorite
            {
                UserId = userId,
                ProductId = productId
            };

            db.Favorites.Add(favorite);
            db.SaveChanges();

            return Json(new { success = true, message = "Товар добавлен в список избранного" });
        }

        // POST: Favorites/Remove
        [HttpPost]
        public async Task<ActionResult> Remove(int productId)
        {
            var userId = User.Identity.GetUserId();
            var favorite = db.Favorites.FirstOrDefault(f => f.UserId == userId && f.ProductId == productId);
            if (favorite != null)
            {
                db.Favorites.Remove(favorite);
                await db.SaveChangesAsync();
            }
            return new HttpStatusCodeResult(200);
        }
        [HttpGet]
        public ActionResult GetUserFavorites()
        {
            var userId = User.Identity.GetUserId();
            var favoriteProductIds = db.Favorites.Where(f => f.UserId == userId).Select(f => f.ProductId).ToList();
            return Json(favoriteProductIds, JsonRequestBehavior.AllowGet);
        }
    }
}
