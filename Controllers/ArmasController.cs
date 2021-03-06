using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;


namespace RpgApi.Controllers
{
    [Authorize]
   [ApiController]
    [Route("[controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextoAccessor; 

        public ArmasController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; 
            _httpContextoAccessor = httpContextAccessor;
        }

        private int ObterUsusarioId()
        {
            return int.Parse(_httpContextoAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)//using using System.Threading.Tasks;
        {
            try
            {
                Arma a = await _context.Armas                        
                       .FirstOrDefaultAsync(aBusca => aBusca.Id == id);
                //using Microsoft.EntityFrameworkCore;

                return Ok(a);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                //using System.Collections.Generic;
                List<Arma> lista = await _context.Armas                    
                    .ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       [HttpPost]
        public async Task<IActionResult> Add(Arma novaArma)
        {
            try
            {
                if (novaArma.Dano == 0)
                {
                    throw new System.Exception("O dano da arma n??o pode ser 0.");
                }

                Personagem personagem = await _context.Personagens.FirstOrDefaultAsync(p => p.Id == novaArma.PersonagemId);

                if(personagem == null)
                    throw new System.Exception("Seu usu??rio n??o cont??m personagens com o Id de personagem informado.");
                
                Arma buscaArma = await _context.Armas.FirstOrDefaultAsync(a => a.PersonagemId == novaArma.PersonagemId);

                if(buscaArma != null)
                    throw new System.Exception("O personagem informado j?? cont??m uma arma atribu??do a ele.");

                await _context.Armas.AddAsync(novaArma);
                await _context.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Arma novaArma)
        {
            try
            {
                if (novaArma.Dano == 0)
                {
                    throw new System.Exception("O dano da arma n??o pode ser 0");
                }

                _context.Armas.Update(novaArma);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Arma aRemover = await _context.Armas
                   .FirstOrDefaultAsync(p => p.Id == id);

                _context.Armas.Remove(aRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}