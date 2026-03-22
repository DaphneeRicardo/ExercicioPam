using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Copahas.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Copahas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadoresController : ControllerBase
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
        
        [HttpGet("GetAll")]
        public IActionResult ObterJogadores()
        {
            List<Jogador> lista = listajogadores;
            return Ok(lista);
        }
        
        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            return Ok(listajogadores[0]);
        }
    
        [HttpPost]
        public IActionResult InserirJogador(Jogador j)
    {
        listajogadores.Add(j);
        return Ok(listajogadores);
    }

        [HttpGet("GetOrdenado")]
        public IActionResult GetOrdem()
        {
            List<Jogador> listafinal = listajogadores.OrderBy(j => j.Nome).ToList();
            return Ok(listafinal);
        }
    
        [HttpPut("AtualizarJogador")]
        public IActionResult Atualizar(Jogador j)
        {
            Jogador jEncontrado = listajogadores.Find(jBusca => jBusca.Id == j.Id);
            if(jEncontrado == null)
                return BadRequest("Jogador não encontrado");

            jEncontrado.Nome = j.Nome;
            jEncontrado.NumeroCamisa = j.NumeroCamisa;
            return Ok(listajogadores);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            listajogadores.RemoveAll(j => j.Id == id);
            return Ok(listajogadores);
        }

        [HttpGet("GetByNomeAproximado/{nome}")]
        public IActionResult GetByNomeAproximado(string nome)
        {
            List<Jogador> lista =
         listajogadores.FindAll(j => j.Nome.ToLower().Contains(nome.ToLower()));
         return Ok(lista);   
        }
        };
        }
