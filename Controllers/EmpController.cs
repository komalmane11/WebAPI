using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEB_API_Database_Connection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly EmpdbContext empdbContext;
        public EmpController(EmpdbContext empdbContext)
        {
            this.empdbContext = empdbContext;
        }
        [HttpGet]
        public async Task<IActionResult>Getasync()
        {
            var emps = await empdbContext.Employe.ToListAsync();
            return Ok(emps);
        }
        [HttpGet]
        [Route("get-emp-by-id")]
        public async Task<IActionResult>GetempbyidAsync(int ID)
        {
            var emps = await empdbContext.Employe.FirstOrDefaultAsync(s =>s.Emp_ID ==ID);
            return Ok(emps);
        }
        [HttpPost]
        public async Task<IActionResult>Postasync(Employe employe)
        {
            empdbContext.Employe.Add(employe);
            await empdbContext.SaveChangesAsync();
            return Created($"/get-emp-by-id?id={employe.Emp_ID}", employe);
        }
        [HttpPut]
        public async Task<IActionResult>Putasync(Employe emptoupdate)
        {
            empdbContext.Employe.Update(emptoupdate);
            await empdbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Deleteasync(int ID)
        {
            var emptodelete = await empdbContext.Employe.FindAsync(ID);
            if(emptodelete ==null)
                return NotFound();
            empdbContext.Employe.Remove(emptodelete);
            await empdbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
