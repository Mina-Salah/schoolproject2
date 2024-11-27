using MediatR;
using school.core.Bass.Responce;

namespace school.core.Futuer.Students.commends.Module
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
