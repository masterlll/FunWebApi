﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunWebApi.Models;
using FunWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FunWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;

        }
        [HttpGet("test")]
        public IActionResult Test(string test )
        {
            // await 
            return Ok("test is ok");
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var value = await  _context.Values.ToListAsync();
            // await 
            return Ok(value);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x=>x.Id ==id);
          //  await 
           return Ok(value);
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
