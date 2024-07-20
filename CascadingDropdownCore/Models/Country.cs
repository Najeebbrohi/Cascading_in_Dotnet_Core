using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CascadingDropdownCore.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        [ValidateNever]
        public ICollection<State> States { get; set; }
        [ValidateNever]
        public ICollection<Employee> Employees { get; set; }
    }
}
