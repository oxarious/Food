using Microsoft.AspNetCore.Mvc;
using Very_Interestin_API_and_APP.Models;

namespace Very_Interestin_API_and_APP.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class FoodController : ControllerBase
    {

        public static List<Food> Food = new()
    {
    new Food { Id = 1, Dish = "Spaghetti Carbonara", MainIngredient = "Pasta", PreparationTime = 20 },
    new Food { Id = 2, Dish = "Chicken Curry", MainIngredient = "Chicken", PreparationTime = 30 },
    new Food { Id = 3, Dish = "Margherita Pizza", MainIngredient = "Flour", PreparationTime = 50 },
    new Food { Id = 4, Dish = "Vegetable Stir Fry", MainIngredient = "Vegetables", PreparationTime = 15 },
    new Food { Id = 5, Dish = "Beef Stroganoff", MainIngredient = "Beef", PreparationTime = 40 },
    new Food { Id = 6, Dish = "Salmon Teriyaki", MainIngredient = "Salmon", PreparationTime = 25 },
    new Food{ Id = 7, Dish = "Tofu Pad Thai", MainIngredient = "Tofu", PreparationTime = 35 },
    new Food { Id = 8, Dish = "Lamb Kebabs", MainIngredient = "Lamb", PreparationTime = 45 },
    new Food{ Id = 9, Dish = "Shrimp Paella", MainIngredient = "Shrimp", PreparationTime = 60 },
    new Food { Id = 10, Dish = "Mushroom Risotto", MainIngredient = "Mushroom", PreparationTime = 55 }
};

        [HttpGet]
        public ActionResult<List<Food>> Get()
        {
            if (Food != null && Food.Any())
            {
                return Ok(Food);
            }
            return NotFound("Could not return Food");

        }
        [HttpGet("{id}")]
        public ActionResult<Food?> Get(int id)
        {
            Food food = Food.FirstOrDefault(f => f.Id == id);

            if (food == null)
            {
                return NotFound("Cant find that Food");
            }
            return Ok(food);
        }

        [HttpPost]
        public ActionResult Post(Food food)
        {
            if (food != null)
            {
                Food.Add(food);
                return Ok("Food Added");
            }
            return BadRequest("Could not add Food, Check your JSON and try again");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Find the item in the list or database
            var item = Food.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                // Item not found
                return NotFound();
            }
            return Ok("Food is deleted");



        }
    }
};