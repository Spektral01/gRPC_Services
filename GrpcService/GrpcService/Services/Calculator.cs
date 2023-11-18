using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcService.Services
{
    public class CalculatorServiceImpl : Calculator.CalculatorBase
    {
        private readonly ILogger<CalculatorServiceImpl> _logger;

        public CalculatorServiceImpl(ILogger<CalculatorServiceImpl> logger)
        {
            _logger = logger;
        }

        public override Task<MultiplyResponse> Multiply(MultiplyRequest request, ServerCallContext context)
        {
            int result = request.Number1 * request.Number2;
            _logger.LogInformation($"Received request to multiply {request.Number1} and {request.Number2}. Result: {result}");
            return Task.FromResult(new MultiplyResponse { Result = result });
        }
    }
}
