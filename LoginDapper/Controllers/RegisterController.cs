using LoginDapper.Model;
using LoginDapper.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository repo;
        public RegisterController(IRegisterRepository repo)
        {
            this.repo = repo;
        }


        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var obj=await repo.GetByEmail(email);
                return Ok(obj);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var obj = await repo.ShowAll();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpOptions("{email}")]
        public async Task<IActionResult> Login(string email, Login login)
        {
            try
            {
                var res = await repo.Login(email, login);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewRegister(NewRegister register)
        {
            try
            {
                var res=await repo.NewRegister(register);
                return Ok(res);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePassword(string email,string password)
        {
            try
            {
                await repo.UpdatePassword(email, password);
                return Ok();
            }catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            await repo.Delete(id);
            return NoContent();
        }


        

    }
}
