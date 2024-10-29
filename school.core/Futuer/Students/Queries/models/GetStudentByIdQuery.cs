using MediatR;
using school.core.Bass.Responce;
using school.core.Futuer.Students.Queries.ResultRespons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.core.Futuer.Students.Queries.models
{
    public class GetStudentByIdQuery:IRequest<Response<GetSingleStudentRespons>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id=id;
        }
    }
}
