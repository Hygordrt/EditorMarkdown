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
        public Modelmkd CadastroMkd2 { get; set; }

        private readonly ILogger<MarkdownItemsModel> _logger;
        private readonly Contexto _contexto;

        public MarkdownItemsModel(ILogger<MarkdownItemsModel> logger, Contexto contexto)
        {
            _contexto = contexto;
            _logger = logger;

            CadastroMkd = _contexto.Cadastro.FirstOrDefault(c => c.Id == 1);
            CadastroMkd2 = _contexto.Cadastro.FirstOrDefault(c => c.Id == 2);

            if (CadastroMkd == null)
            {
                CadastroMkd = new Modelmkd(); // Inicializa uma nova instância vazia
            }
            
            if (CadastroMkd2 == null)
            {
                CadastroMkd2 = new Modelmkd(); // Inicializa uma nova instância vazia
            }
        }
        public void OnGet()
        {
            var cadastro = _contexto.Cadastro.FirstOrDefault(c => c.Id == 1);
            var cadastro2 = _contexto.Cadastro.FirstOrDefault(c => c.Id == 2);

            if (cadastro != null)
            {
                CadastroMkd = cadastro; 
            }

            if (cadastro2 != null)
            {
                CadastroMkd2 = cadastro2;
            }
        }

        public async Task<IActionResult> OnPostMKD1()
        {
            var registroExistente = await _contexto.Cadastro.FirstOrDefaultAsync(c => c.Id == 1);
            if (registroExistente != null)
            {
                //Registro ja existe e vai ser alterado
                registroExistente.ConteudoMkd = cadastro.ConteudoMkd;
                if (registroExistente.ConteudoMkd == null)
                {
                    registroExistente.ConteudoMkd = "";
                    await _contexto.SaveChangesAsync();
                }
                else
                {
                    await _contexto.SaveChangesAsync();
                }
            }
            else { 
                var cadastroMkd = new Modelmkd()
                {
                    Id = 1,
                    ConteudoMkd = cadastro.ConteudoMkd
                };
            
                await _contexto.Cadastro.AddAsync(cadastroMkd);
                // Salvando
                await _contexto.SaveChangesAsync();

            }
            return Page();
        }

        public async Task<IActionResult> OnPostMKD2()
        {
            var registroExistente = await _contexto.Cadastro.FirstOrDefaultAsync(c => c.Id == 2);
            if (registroExistente != null)
            {
                //Registro ja existe e vai ser alterado
                registroExistente.ConteudoMkd = cadastro.ConteudoMkd;
                if (registroExistente.ConteudoMkd == null)
                {
                    registroExistente.ConteudoMkd = "";
                    await _contexto.SaveChangesAsync();
                }
                else
                {
                    await _contexto.SaveChangesAsync();
                }
            }
            else
            {
                var cadastroMkd2 = new Modelmkd()
                {
                    Id = 2,
                    ConteudoMkd = cadastro.ConteudoMkd
                };

                await _contexto.Cadastro.AddAsync(cadastroMkd2);
                // Salvando
                await _contexto.SaveChangesAsync();

            }
            return Page();
        }
    }
}