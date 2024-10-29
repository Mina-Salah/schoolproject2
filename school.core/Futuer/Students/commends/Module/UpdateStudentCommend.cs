﻿using MediatR;
using school.core.Bass.Responce;

namespace school.core.Futuer.Students.commends.Module
{
    public class UpdateStudentCommend : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string? Phone { get; set; }

        public int? DepartmentId { get; set; }
    }
}