using Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public userController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await Task.FromResult(_userRepository.GetUser());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetById(int Id)
        {
            var user = await Task.FromResult(_userRepository.GetById(Id));
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> post(User user)
        {
            _userRepository.AddUser(user);
            return await Task.FromResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<User>> Put(int Id, User User)
        {
            if (Id != User.Id)
            {
                return BadRequest();
            }
            try
            {
                _userRepository.EditUser(User);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckUser(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(User);
        }

        private bool CheckUser(int id)
        {
            return _userRepository.CheckUser(id);
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Delete(int Id)
        {
            var user = _userRepository.DeleteUser(Id);
            return await Task.FromResult(user);
        }
    }
}
