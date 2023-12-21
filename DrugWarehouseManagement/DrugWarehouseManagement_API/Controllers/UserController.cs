using AutoMapper;
using DrugWarehouseManagement_API.Entities;
using DrugWarehouseManagement_API.Repositories;
using DrugWarehouseManagement_ViewModel.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugWarehouseManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository
            , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAll();

                var userViewModels = _mapper.Map<List<UserViewModel>>(users);
                return Ok(userViewModels);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // route: api/users/id
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            try
            {
                var user = await _userRepository.GetById(id);
                if (user == null)
                {
                    return NotFound($"user have {id} not found");
                }
                else
                {
                    var userViewModel = _mapper.Map<UserViewModel>(user);
                    return Ok(userViewModel);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserViewModel createUserViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    User user = _mapper.Map<User>(createUserViewModel);
                    user.Id = Guid.NewGuid();
                    await _userRepository.Create(user);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserViewModel updateUserViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var userExist = await _userRepository.GetById(id);
                    if (userExist == null)
                    {
                        return NotFound($"user have {id} not found");
                    }
                    else
                    {
                        userExist.FirstName = updateUserViewModel.FirstName;
                        userExist.LastName = updateUserViewModel.LastName;
                        userExist.FullName = updateUserViewModel.FullName;
                        userExist.UserName = updateUserViewModel.UserName;
                        userExist.PasswordHash = updateUserViewModel.PasswordHash;
                        userExist.Email = updateUserViewModel.Email;
                        await _userRepository.Update(userExist);
                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var userExist = await _userRepository.GetById(id);
            if (userExist == null)
            {
                return NotFound($"user have {id} not found");
            }
            else
            {
                await _userRepository.Delete(userExist);
                return Ok();
            }
        }
    }
}
