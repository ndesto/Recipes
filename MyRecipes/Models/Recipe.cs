using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MyRecipes.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}