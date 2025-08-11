using System.ComponentModel.DataAnnotations;
using Ticket_Web_App.Enums;

namespace Ticket_Web_App.Dtos.Request.Filter
{
    public class ContactFilterDto
    {
        public string? FullName { get; set; }
        public Guid? ParentClientId { get; set; }
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;
        public string? OrderBy { get; set; }
        public bool Descending { get; set; } = false;
    }
}
