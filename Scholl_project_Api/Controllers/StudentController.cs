using MediatR;
using Microsoft.AspNetCore.Mvc;
using school.core.Bass.Responce;
using school.core.Futuer.Students.commends.Module;
using school.core.Futuer.Students.Queries.models;
using school.core.Futuer.Students.Queries.ResultRespons;
using school.data.AppMetaData; // Import Router class
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school.api.Controllers
{
  //  [Route(Router.StudentRouting.StudentRoot)] // Use the route from the Router class
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Constructor to inject MediatR
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add a new student
        /// </summary>
        [HttpPost(Router.StudentRouting.AddStudent)]
        public async Task<ActionResult<Response<string>>> AddStudent([FromBody] AddStudentCommend command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                return StatusCode((int)result.StatusCode, result);
            }

            return CreatedAtAction(nameof(GetStudentById), new { id = command.DepartmentId }, result);
        }

        /// <summary>
        /// Get a list of all students
        /// </summary>
        [HttpGet(Router.StudentRouting.GetAllStudents)]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _mediator.Send(new GetStudentQuery());

            if (!result.Succeeded)
            {
                return StatusCode((int)result.StatusCode, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get a single student by ID
        /// </summary>
        [HttpGet(Router.StudentRouting.GetStudentById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));

            if (!result.Succeeded)
            {
                return StatusCode((int)result.StatusCode, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Update student information
        /// </summary>
        [HttpPut(Router.StudentRouting.UpdateStudent)]  
        public async Task<ActionResult<Response<string>>> UpdateStudent(int id, [FromBody] UpdateStudentCommend command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            // Ensure the command uses the correct `UpdateStudentCommend`
            command.Id = id;  // Set the `Id` in the command, since it might not be included in the body

            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                return StatusCode((int)result.StatusCode, result);
            }

            return Ok(result);
        }
        /// <summary>
        /// Delete a student by ID
        /// </summary>
     
        [HttpDelete(Router.StudentRouting.DeleteStudent)]
        public async Task<ActionResult<Response<string>>> DeleteStudent([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(id));

            if (!result.Succeeded)
            {
                return StatusCode((int)result.StatusCode, result);
            }

            return Ok(result);
        }
    }
}
