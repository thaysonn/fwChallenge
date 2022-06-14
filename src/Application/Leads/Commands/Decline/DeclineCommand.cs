using MediatR;

namespace fw.Application.Leads.Commands.Decline;
public record DeclineCommand(int Id) : IRequest;
