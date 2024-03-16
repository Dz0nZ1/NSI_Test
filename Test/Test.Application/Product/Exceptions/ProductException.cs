using Test.Application.Common.Exceptions;

namespace Test.Application.Product.Exceptions;

public class ProductException : BaseException
{
    public ProductException(IDictionary<string, string[]> failures) : base("One or more validation failures have occured while accessing Product Entity", failures)
    {
    }
}