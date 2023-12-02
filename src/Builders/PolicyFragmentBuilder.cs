using System.Xml.Linq;

using Mielek.Model;

namespace Mielek.Builders;
public class PolicyFragmentBuilder
{
    public static PolicyFragmentBuilder Create() => new();

    private readonly PolicySectionBuilder _innerBuilder = new();

    private PolicyFragmentBuilder() { }

    public PolicyFragmentBuilder Policies(Action<PolicySectionBuilder> configurator)
    {
        configurator(_innerBuilder);
        return this;
    }

    public XElement Build()
    {
        return new XElement("fragment", _innerBuilder.Build().ToArray());
    }
}