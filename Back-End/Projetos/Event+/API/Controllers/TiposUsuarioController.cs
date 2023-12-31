﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuario _tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposUsuarioRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposUsuario);
                return StatusCode(201);
            }
            catch (Exception e)

            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(TiposUsuario tipoUsuario, Guid id)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(id, tipoUsuario);
                return Ok(201);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id) 
        {
         try
            {
        _tiposUsuarioRepository.Deletar(id);
            return StatusCode(201);

            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult GetById(Guid id) 
        {
            try
            {

            return Ok(_tiposUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception e) 
            {
                return BadRequest($"{e.Message}");
            }
        }
    }
}
