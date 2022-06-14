using MediatR;
namespace fw.Application.Leads.Commands.Accept;
public record AcceptCommand(int Id) : IRequest;