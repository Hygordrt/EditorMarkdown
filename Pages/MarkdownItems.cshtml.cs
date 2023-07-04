using EditorMarkdown.Data;
using EditorMarkdown.ModelMkd;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EditorMarkdown.Pages
{
    public class MarkdownItemsModel : PageModel
    {
        [BindProperty]
        public Modelmkd cadastro { get; set; }
        public Modelmkd CadastroMkd { get; set; }

        private readonly ILogger<MarkdownItemsModel> _logger;
        private readonly Contexto _contexto;

        public MarkdownItemsModel(ILogger<MarkdownItemsModel> logger, Contexto contexto)
        {
            _contexto = contexto;
            _logger = logger;

            // Inicialização da propriedade CadastroMkd
            CadastroMkd = _contexto.Cadastro.FirstOrDefault(c => c.Id == 1);
        }

        public void OnGet()
        {
            CadastroMkd = _contexto.Cadastro.FirstOrDefault(c => c.Id == 1);
        }

        public async Task<IActionResult> OnPost()
        {
            var registroExistente = await _contexto.Cadastro.FirstOrDefaultAsync(c => c.Id == 1);
            if (registroExistente != null)
            {
                //Registro ja existe e vai ser alterado
                registroExistente.ConteudoMkd = cadastro.ConteudoMkd;
                await _contexto.SaveChangesAsync();

            }
            else { 
                var cadastroMkd = new Modelmkd()
                {
                    Id = 01,
                    ConteudoMkd = cadastro.ConteudoMkd
                };
            
                await _contexto.Cadastro.AddAsync(cadastroMkd);
                // Salvando
                await _contexto.SaveChangesAsync();

            }
            return Page();
        }
    }
}