using CascadingDropdownCore.Models;

namespace CascadingDropdownCore.ViewModels
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Country> Countries { get; set; }
        public List<State> States { get; set; }
        public List<City> Cities { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
    }
}
