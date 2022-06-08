using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;
namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEventosDisplay _eventosDisplay;

        public EventoController(ILogger<WeatherForecastController> logger, IEventosDisplay eventosDisplay)
        {
            _logger = logger;
            _eventosDisplay = eventosDisplay;
        }

        ///Requisitar Recursos (Request Resource)
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventosDisplay.Eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return _eventosDisplay.Eventos.FirstOrDefault(f => f.EventoId == id);
        }

        //Criar Recurso (Create Resource)
        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        //Atualizar Recurso (Update Resource)
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put id = {id}";
        }

        //Atualizar Recursos Parcial (Update Partial)
        [HttpPatch("{id}")]
        public string Patch(int id)
        {
            return $"Exemplo de Patch id = {id}";
        }

        //Deletar Recurso (Delete Resource)
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }

        /*
        Conteúdo da Request
        
        ***Verbos do Padrão Restful
        GET (Request)
        POST (Create)
        PUT (Update)
        PATCH (Update Partial)
        DELETE (Remover)

        ***Headers
        Content Type: Formato do Conteúdo
        Content Length: Tamanho de Conteúdo
        Authorization: Quem fez a chamada
        Accept: Quais tipos sáo aceitáveis
        Cookies: Passagem de dados por Requisição

        ***Content
        HTML, CSS, Javascript, XML, JSON
        O conteúdo enviado neste local da requisição não é validado pelo verbo.
        Informações para ajudar a entender a requisição.
        Onde passar tipos Binários e Blobs comuns.

        Conteúdo da Response
        
        ***Status Code
        Situação da Operação
        100-199: Informação (Informational)
        200-299: Sucesso (Success)
        300-399: Redirecionamento (Redirection)
        400-499: Erro do Cliente (Client Errors)
        500-599: Erro do Servidor (Internal Server Errors)

        ***Headers
        Content Type: Formato do Conteúdo
        Content Length: Tamanho do Conteúdo
        Expires: Quando considerar obsoleto
        Accept: Quais tipos sáo aceitáveis
        Cookies: Passagem de dados pela Resposta

        ***Content
        HTML, CSS, Javascript, XML, JSON
        Onde passar tipos Binários o Blobs (Binário muito grande) comuns
        API's frequentemente tem seus próprios tipos
        JSON é muito comum (senão o mais comum)
        */
    
    }
}