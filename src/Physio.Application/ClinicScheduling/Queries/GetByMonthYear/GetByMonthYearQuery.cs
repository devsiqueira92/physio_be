﻿
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Queries.GetByMonthYear;

public record GetByMonthYearQuery(SchedulingMonthYearRequest scheduling, string userId) : IRequest<Result<List<SchedulingResponse>>>;
