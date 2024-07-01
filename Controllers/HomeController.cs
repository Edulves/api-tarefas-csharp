using ApiTarefas.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public HomeView index()
    {
        return new HomeView
        {
            Mensagem = "bem vindo a API de tarefas",
            Documentacao = "/swagger"
        };
    }
}
