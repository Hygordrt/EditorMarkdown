using EditorMarkdown.Data;
using EditorMarkdown.ModelMkd;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EditorMarkdown.Pages;

public class TabelasModel : PageModel
{
    [BindProperty]
    public Modelmkd cadastro { get; set; }
    public Modelmkd CadastroMkd { get; set; }

    private readonly ILogger<TabelasModel> _logger;
    private readonly Contexto _contexto;

    public TabelasModel(ILogger<TabelasModel> logger, Contexto contexto)
    {
        _contexto = contexto;
        _logger = logger;

        CadastroMkd = _contexto.Cadastro.FirstOrDefault(c => c.Id == 5);
        if (CadastroMkd == null)
        {
            CadastroMkd = new Modelmkd(); // Inicializa uma nova instância vazia
        }
    }

    public void OnGet()
    {
        var cadastro = _contexto.Cadastro.FirstOrDefault(c => c.Id == 5);
        if (cadastro != null)
        {
            CadastroMkd = cadastro; // Atribui o valor do banco de dados, caso exista
        }
    }

    public async Task<IActionResult> OnPost()
    {
        var registroExistente = await _contexto.Cadastro.FirstOrDefaultAsync(c => c.Id == 5);
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
            var cadastroMkd = new Modelmkd()
            {
                Id = 5,
                ConteudoMkd = cadastro.ConteudoMkd
            };

            await _contexto.Cadastro.AddAsync(cadastroMkd);
            // Salvando
            await _contexto.SaveChangesAsync();

        }
        return Page();
    }
}
