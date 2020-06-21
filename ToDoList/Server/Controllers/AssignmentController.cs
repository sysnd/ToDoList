using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Server.Services.Assignments;
using ToDoList.Shared.Models;

namespace ToDoList.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly ILogger<AssignmentController> _logger;
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(ILogger<AssignmentController> logger,
            IAssignmentService assignmentService)
        {
            _logger = logger;
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public IActionResult GetAllAssignments()
        {
            try
            {
                var result = _assignmentService.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignmentById([FromRoute] Guid id)
        {
            try
            {
                var result = await _assignmentService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssignment([FromBody] Assignment assignment)
        {
            try
            {
                var result = await _assignmentService.Create(assignment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAssignment([FromBody] Assignment assignment)
        {
            try
            {
                var result = await _assignmentService.Update(assignment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment([FromRoute] Guid id)
        {
            try
            {
                var result = await _assignmentService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
