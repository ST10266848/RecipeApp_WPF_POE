using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp_WPF
{
    class StepDescriptions
    {
        public string RecipeName { get; set; } = null!;

        //stores the description of a step that the user enters
        public string Description { get; set; } = null!;

        public StepDescriptions(string recipeName, string description)
        {
            this.RecipeName = recipeName;
            this.Description = description;
        }
    }
}
