﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;
using webapi.health_clinic.Repositories;

namespace webapi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private IMedico _medicoRepostiory { get; set; }

        public MedicoController()
        {
            _medicoRepostiory = new MedicoRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {

            try
            {
                return Ok(_medicoRepostiory.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepostiory.Cadastrar(medico);
                return Ok("Médico cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepostiory.Deletar(id);
                return Ok("Médico excluído com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Medico medico, Guid id)
        {
            try
            {
                _medicoRepostiory.Atualizar(id, medico);
                return Ok("Médico atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                return Ok(_medicoRepostiory.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
