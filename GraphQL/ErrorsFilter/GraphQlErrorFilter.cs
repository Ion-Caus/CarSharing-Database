using System.Diagnostics;
using HotChocolate;

namespace CarSharing_Database_GraphQL.ErrorsFilter
{
    public class GraphQlErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            Debug.Assert(error.Exception?.Message != null, "Error is null");
            return error.WithMessage(error.Exception.Message);
        }
    }
}