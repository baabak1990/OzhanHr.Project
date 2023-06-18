using OzhanHr.Application.IServiceConfiguration;
using OzhanHR.Infrasturcutre.ServiceConfiguration;
using OzhanItHr.Persistence.ServiceConfiguration;
using System.Reflection;
using MediatR;
using OzhanHr.Application.Features.LeaveAllocation.Handler.Commands;
using OzhanHr.Application.Features.LeaveAllocation.Handler.Queries;
using OzhanHr.Application.Features.LeaveAllocation.Request.Commands;
using OzhanHr.Application.Features.LeaveAllocation.Request.Queries;
using OzhanHr.Application.Features.LeaveRequest.Handler.Commands;
using OzhanHr.Application.Features.LeaveRequest.Handler.Queries;
using OzhanHr.Application.Features.LeaveRequest.Request.Commands;
using OzhanHr.Application.Features.LeaveRequest.Request.Queries;
using OzhanHr.Application.Features.LeaveType.Handler.Commands;
using OzhanHr.Application.Features.LeaveType.Request.Commands;
using OzhanHr.Application.Features.LeaveType.Request.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region IoC

var con = builder.Configuration;
builder.Services.ApplicationLayerConfiguration();
builder.Services.InfrastructureServices(con);
builder.Services.PersistenceService(con);
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
#endregion

#region MediaTR
builder.Services.AddMediatR(typeof(GetLeaveTypeRequest).Assembly,
    typeof(GetLeaveTypeByIdRequest).Assembly,
    typeof(CreateLeaveTypeCommand).Assembly,
    typeof(RemoveLeaveTypeCommand).Assembly,
    typeof(UpdateLeaveTypeCommand).Assembly,
    typeof(CreateLeaveTypeCommandHandler).Assembly,
    typeof(RemoveLeaveTypeCommandHandler).Assembly,
    typeof(UpdateLeaveTypeCommandHandler).Assembly,
    typeof(GetLeaveRequestsListRequest).Assembly,
    typeof(CreateLeaveRequestCommand).Assembly,
    typeof(RemoveLeaveRequestCommand).Assembly,
    typeof(UpdateLeaveRequestCommand).Assembly,
    typeof(GetLeaveRequestsListHandler).Assembly,
    typeof(CreateLeaveRequestCommandHandler).Assembly,
    typeof(RemoveLeaveRequestCommandHandler).Assembly,
    typeof(UpdateLeaveRequestCommandHandler).Assembly,
    typeof(GetLeaveAllocationRequest).Assembly,
    typeof(GetLeaveAllocationByIdRequest).Assembly,
    typeof(CreateLeaveAllocationCommand).Assembly,
    typeof(RemoveLeaveAllocationCommand).Assembly,
    typeof(UpdateLeaveAllocationCommand).Assembly,
    typeof(GetLeaveAllocationByIdRequestHandler).Assembly,
    typeof(GetLeaveAllocationRequestHandler).Assembly,
    typeof(CreateLeaveAllocationCommandHandler).Assembly,
    typeof(RemoveLeaveAllocationCommandHandler).Assembly,
    typeof(UpdateLeaveAllocationCommandHandler).Assembly

);


#endregion

builder.Services.AddCors(o =>
    {
        o.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
    }
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
