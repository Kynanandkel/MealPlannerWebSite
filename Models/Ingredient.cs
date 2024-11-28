using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Models
{
    
  

    public class Ingredient 
    {
        

        public int ID { get; set; }
        public string Name { get; set; }

    }
    
}
