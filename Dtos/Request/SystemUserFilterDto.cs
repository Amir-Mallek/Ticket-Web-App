using System.ComponentModel.DataAnnotations;

namespace Ticket_Web_App.Dtos.Request
{
    public class SystemUserFilterDto
    {
        public string? FullName { get; set; }
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;
        public string? OrderBy { get; set; }
        public bool Descending { get; set; } = false;
    }
}
