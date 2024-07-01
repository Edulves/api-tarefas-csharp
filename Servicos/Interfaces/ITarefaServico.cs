using ApiTarefas.Database;
using ApiTarefas.Dto;
using ApiTarefas.Model.Erros;
using ApiTarefas.Models;

namespace ApiTarefas.Servicos.interfaces;

public interface ITarefaServico
{
    List<Tarefa> Lista(int page);


    Tarefa Incluir(TarefaDto tarefaDto);

    Tarefa Update(int Id, TarefaDto tarefaDto);

    Tarefa BuscaPorId(int Id);

    void Delete(int Id);
}