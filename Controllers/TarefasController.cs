using ApiTarefas.Database;
using ApiTarefas.Dto;
using ApiTarefas.Model.Erros;
using ApiTarefas.Models;
using ApiTarefas.ModelViews;
using ApiTarefas.Servicos;
using ApiTarefas.Servicos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers;

[ApiController]
[Route("/Tarefas")]
public class TarefasController : ControllerBase
{
    public TarefasController(ITarefaServico servico)
    {
        _servico = servico;
    }

    private ITarefaServico _servico;

    [HttpGet("")]
    public IActionResult Index(int page = 1)
    {
        var tarefas = _servico.Lista(page);
        return StatusCode(200, tarefas);
    }

    [HttpPost]
    public IActionResult Create([FromBody] TarefaDto tarefadto)
    {
        try
        {
            var tarefa = _servico.Incluir(tarefadto);
            return StatusCode(201, tarefa);
        }
        catch (TarefaErro erro)
        {
            return StatusCode(400, new ErrorView { Mensagem = erro.Message });
        }
    }

    [HttpGet("{id}")]
    public IActionResult Show([FromRoute] int id)
    {
        try
        {
            var tarefaDb = _servico.BuscaPorId(id);
            return StatusCode(201, tarefaDb);
        }
        catch (TarefaErro erro)
        {
            return StatusCode(400, new ErrorView { Mensagem = erro.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] TarefaDto tarefaDto)
    {
        try
        {
            var tarefaDb = _servico.Update(id, tarefaDto);
            return StatusCode(201, tarefaDb);
        }
        catch (TarefaErro erro)
        {
            return StatusCode(400, new ErrorView { Mensagem = erro.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            _servico.Delete(id);
            return StatusCode(204);
        }
        catch (TarefaErro erro)
        {
            return StatusCode(400, new ErrorView { Mensagem = erro.Message });
        }
    }
}
