using AutoMapper;
using MediatR;
using school.core.Bass.Responce;
using school.core.Futuer.Students.commends.Module;
using school.data.Entities;
using school.service.StudentServicerepo;
using System.Threading;
using System.Threading.Tasks;

namespace school.core.Futuer.Students.commends.Handler
{
    public class StudentCommendHandler : ResponseHandler,
                                          IRequestHandler<AddStudentCommend, Response<string>>,
                                          IRequestHandler<UpdateStudentCommend, Response<string>>,
                                          IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommendHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        // Handle AddStudentCommend (add new student)
        public async Task<Response<string>> Handle(AddStudentCommend request, CancellationToken cancellationToken)
        {
            var studentMapping = _mapper.Map<Student>(request);

            var addResult = await _studentService.AddStudentAsync(studentMapping);
            if (addResult == "Exist")
                return UnProcessableEntity<string>("Name is already taken");
            else if (addResult == "Success")
                return Created("Student added successfully");
            else
                return BadRequest<string>("Failed to add student");
        }

        // Handle UpdateStudentCommend (update existing student)
        public async Task<Response<string>> Handle(UpdateStudentCommend request, CancellationToken cancellationToken)
        {
            // Ensure the student exists
            var existingStudent = await _studentService.GetStudentByIdAsync(request.Id);
            if (existingStudent == null)
                return NotFound<string>("Student not found");

            // Map the updated fields from the command to the student entity
            var studentMapper = _mapper.Map<Student>(request);

            // Update the student record
            var updateResult = await _studentService.UpdateAsync(studentMapper);

            if (updateResult == "Success")
                return Success("Student updated successfully");
            else
                return BadRequest<string>("Failed to update student");
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            // Ensure the student exists
            var existingStudent = await _studentService.GetStudentByIdAsync(request.Id);
            if (existingStudent == null)
                return new Response<string>("Student not found")
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Succeeded = false
                };

            // Call the service to delete the student
            await _studentService.DeleteStudentAsync(request.Id);

            return new Response<string>("Student deleted successfully")
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true
            };
        }
    }
}
