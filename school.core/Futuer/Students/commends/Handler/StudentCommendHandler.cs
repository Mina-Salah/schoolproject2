using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using school.core.Bass.Responce;
using school.core.Futuer.Students.commends.Module;
using school.data.Entities;
using school.infrastructuer.Reposatiory.GenericRepository;
using school.service.StudentServicerepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.core.Futuer.Students.commends.Handler
{
    public class StudentCommendHandler : ResponseHandler,
                                            IRequestHandler<AddStudentCommend, Response<string>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommendHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddStudentCommend request, CancellationToken cancellationToken)
        {
            //mapping
            var studentMapping = _mapper.Map<Student>(request);
            //add
            var AddResult = await _studentService.AddStudentAsync(studentMapping);
            if (AddResult == "Exist") return UnProcessableEntity <string>("Name is Exist");
            else if (AddResult == "Success") return Created("added successfully");
            else return BadRequest<string>();

            
        }
    }
}
