using Mielek.Azure.ApiManagement.PolicyToolkit.Expressions.Context;

namespace Mielek.Azure.ApiManagement.PolicyToolkit.Expressions.Context.Mocks;

public class MockSubscription : ISubscription
{
    public DateTime CreatedDate => throw new NotImplementedException();

    public DateTime? EndDate => throw new NotImplementedException();

    public string Id => throw new NotImplementedException();

    public string Key => throw new NotImplementedException();

    public string Name => throw new NotImplementedException();

    public string PrimaryKey => throw new NotImplementedException();

    public string SecondaryKey => throw new NotImplementedException();

    public DateTime? StartDate => throw new NotImplementedException();
}