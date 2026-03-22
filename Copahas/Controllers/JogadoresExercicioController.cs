using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Copahas.Models;

namespace Copahas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadoresExercicioController : ControllerBase
    {
        private static List<Jogador> listajogadores = new List<Jogador>
        {
          new Jogador(){Id=1, Nome = "Daphne Benitez", NumeroCamisa = 7, Posicao = "atacante", Status=Models.Enums.StatusJogador.Titular},

          new Jogador(){Id=2, Nome = "Ricardo Katayama", NumeroCamisa = 47, Posicao = "Lateral direito", Status=Models.Enums.StatusJogador.Titular
          },
          new Jogador(){Id=3, Nome = "Cachorro Perro Dog Benitez", NumeroCamisa = 77, Posicao = "Meio Campo", Status=Models.Enums.StatusJogador.Titular},
          new Jogador(){Id=4, Nome = "Bruno Ferreira", NumeroCamisa = 1, Posicao = "Goleiro", Status=Models.Enums.StatusJogador.Titular},

          new Jogador(){Id=5, Nome = "Matheus Santos", NumeroCamisa = 4, Posicao = "Zagueiro", Status=Models.Enums.StatusJogador.Reserva},

        new Jogador(){Id=6, Nome = "Pedro Henrique", NumeroCamisa = 2, Posicao = "Lateral direito", Status=Models.Enums.StatusJogador.Reserva},

        new Jogador(){Id=7, Nome = "Rafael Costa", NumeroCamisa = 6, Posicao = "Lateral esquerdo", Status=Models.Enums.StatusJogador.Reserva},

        new Jogador(){Id=8, Nome = "Diego Martins", NumeroCamisa = 8, Posicao = "Meio Campo", Status=Models.Enums.StatusJogador.Reserva},

        new Jogador(){Id=9, Nome = "Thiago Ribeiro", NumeroCamisa = 11, Posicao = "Atacante", Status=Models.Enums.StatusJogador.Reserva}
        };


        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            
            List<Jogador> lista = listajogadores.FindAll(j => j.Nome.ToLower().Contains(nome.ToLower()));
            if(lista.Count == 0)
            {
            return BadRequest("Jogador nao encontrado");
            }
            else
            {
                return Ok(lista);
            }

        }
        [HttpGet("GetTitulares")]
        public IActionResult GetTitular()
        {
            List<Jogador> titulares = listajogadores.FindAll(j => j.Status == Models.Enums.StatusJogador.Titular);
            titulares = titulares.OrderByDescending(j => j.NumeroCamisa).ToList();
            return Ok(titulares);
        }
        [HttpGet("GetEstatistica")]
        public IActionResult GetEstatistica()
        {
            int quantidade = listajogadores.Count;
            int somaCamisa = listajogadores.Sum(j => j.NumeroCamisa);
            return Ok(quantidade + " " + somaCamisa);
        }
        [HttpPost("PostValidacao")]
        public IActionResult InserirJogador(Jogador j)
    {
        
        if (j.NumeroCamisa > 100)
        {
            return BadRequest("O numero da camisa nao pode ser maior que 100");
        }
        else{
            listajogadores.Add(j);
        }
        return Ok(listajogadores);
    }
        [HttpPost("PostValidacaoNome")]
        public IActionResult InserirGoleiro(Jogador j)
        {
            if(j.NumeroCamisa == 1 && j.Posicao.ToLower() == "goleiro")
            {
                listajogadores.Add(j);
                return Ok(listajogadores);
            }
            else
                return BadRequest("O jogador de camisa 1 tem que ser goleiro");
        }
    
        [HttpGet("GetByStatus/{status}")]
        public IActionResult GetByStatus(string status)
        {
            status = status.ToLower();
            if(status == "titular")
            {
            List<Jogador> lista = listajogadores.FindAll(j => j.Status == Models.Enums.StatusJogador.Titular);
            return Ok(lista);
            }
            else if(status == "reserva")
            {
            List<Jogador> lista = listajogadores.FindAll(j => j.Status == Models.Enums.StatusJogador.Reserva);
            return Ok(lista);
            }
            else if(status == "departamentomedico")
            {
            List<Jogador> lista = listajogadores.FindAll(j => j.Status == Models.Enums.StatusJogador.DepartamentoMedico);
            return Ok(lista);
            }
            else if(status == "naorelacionado")
            {
            List<Jogador> lista = listajogadores.FindAll(j => j.Status == Models.Enums.StatusJogador.NaoRelacionado);
            return Ok(lista);
            }
            else{
                return BadRequest("Status não encontrado");
            }

        }
        
    }
}