

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Patient.Queries.GetByIdentificationNumber;
public record GetByIdentificationNumberQuery(string identificationNumber) : IRequest<Result<PatientResponse>>;
