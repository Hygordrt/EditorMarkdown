using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EditorMarkdown.Pages
{
    public class MarkdownItemsModel : PageModel
    {
        private readonly ILogger<MarkdownItemsModel> _logger;

        public MarkdownItemsModel(ILogger<MarkdownItemsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}