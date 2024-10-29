using MediatR;
using school.core.Bass.Responce;
using school.core.Futuer.Students.Queries.ResultRespons;
using school.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.core.Futuer.Students.Queries.models
{
    public class GetStudentQuery : IRequest<Response<List<GetListStudentResponce>>>
    {
    }
}
