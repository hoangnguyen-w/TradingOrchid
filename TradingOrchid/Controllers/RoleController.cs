using Application.Common.Dto.Exception;
using Application.Common.Dto.Role;
using Application.Interfaces.Roles;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TradingOrchid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRoleRepository _roleRepository;
        public RoleController
            (IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Role>>> GetAll()
        {
            var list = await _roleRepository.GetAll();

            if (list == null)
            {
                throw new MyException("Không tìm thấy.", 404);
            }

            return Ok(list);
        }

        [HttpGet("GetByRoleID/{id}")]
        public async Task<ActionResult<Role>> GetByID(int id)
        {

            var list = await _roleRepository.GetRoleByID(id);

            if (list == null)
            {
                throw new MyException("RoleID không tồn tại, vui lòng kiểm tra lại RoleID.", 404);
            }

            return Ok(list);
        }

        [HttpGet("GetByRoleName/{name}")]
        public async Task<ActionResult<Role>> GetByName(string name)
        {
            var list = await _roleRepository.GetRoleByName(name);
            return Ok(list);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateRole(RoleDTO roleDTO)
        {
            await _roleRepository.CreateRole(roleDTO);
            throw new MyException("Tạo thành công '" + roleDTO.RoleName + "' .", 200);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditRole(int id, RoleDTO roleDTO)
        {

            var list = await _roleRepository.FindIDToResult(id);
            if (list == null)
            {
                throw new MyException("RoleID không tồn tại, vui lòng kiểm tra lại RoleID.", 404);
            }
            await _roleRepository.EditRole(id, roleDTO);

            //throw new MyException("Update thành công '" + id + "' .", 200);
            return Ok(roleDTO);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            var list = await _roleRepository.FindIDToResult(id);
            if (list == null)
            {
                throw new MyException("RoleID không tồn tại, vui lòng kiểm tra lại RoleID.", 404);
            }

            await _roleRepository.DeleteRole(id);

            throw new MyException("Xóa thành công '" + id + "' .", 200);
            //return Ok(list);
        }
    }
}


