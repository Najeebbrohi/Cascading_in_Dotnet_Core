using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace CascadingDropdownCore.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int StateId { get; set; }
        [ForeignKey("StateId")]
        [ValidateNever]
        public State State { get; set; }
        [ValidateNever]
        public ICollection<Employee> Employees { get; set; }
    }
}
