using AutoMapper;
using MediatR;
using school.core.Bass.Responce;
using school.core.Futuer.Students.Queries.models;
using school.core.Futuer.Students.Queries.ResultRespons;
using school.data.Entities;
using school.service.StudentServicerepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.core.Futuer.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
                                                IRequestHandler<GetStudentQuery,Response< List<GetListStudentResponce>>>,
                                                IRequestHandler<GetStudentByIdQuery,Response<GetSingleStudentRespons>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IStudentService studentService,IMapper mapper )
        {
            _studentService = studentService;
            _mapper = mapper;
        }


        public async Task<Response<List<GetListStudentResponce>>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
           var studentRespons = await _studentService.GetStudentListAsync();
            var resultStudentmapper = _mapper.Map<List<GetListStudentResponce>>(studentRespons);
            return Success( resultStudentmapper); 
        }

        public async Task<Response<GetSingleStudentRespons>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {

            var studentById =await _studentService.GetStudentByIdAsync(request.Id);
            if (studentById == null) return NotFound<GetSingleStudentRespons>("Object not found");
            var resultMapping = _mapper.Map<GetSingleStudentRespons>(studentById);
            return Success( resultMapping); 
        }
    }
}
