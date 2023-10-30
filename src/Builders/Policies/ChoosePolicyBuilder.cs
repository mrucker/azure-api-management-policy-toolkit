namespace Mielek.Builders.Policies
{
    using System.Collections.Immutable;

    using Mielek.Generator.Attributes;
    using Mielek.Model.Expressions;
    using Mielek.Model.Policies;

    public partial class ChoosePolicyBuilder
    {
        private readonly ImmutableList<ChooseWhen>.Builder _whens = ImmutableList.CreateBuilder<ChooseWhen>();
        private ICollection<IPolicy>? _otherwise;

        public ChoosePolicyBuilder When(Action<ChooseWhenBuilder> configurator)
        {
            var builder = new ChooseWhenBuilder();
            configurator(builder);
            _whens.Add(builder.Build());
            return this;
        }

        public ChoosePolicyBuilder Otherwise(Action<PolicySectionBuilder> configurator)
        {
            var builder = new PolicySectionBuilder();
            configurator(builder);
            _otherwise = builder.Build();
            return this;
        }

        public ChoosePolicy Build()
        {
            return new ChoosePolicy(_whens.ToImmutable(), _otherwise);
        }
    }

    [GenerateBuilderSetters]
    public partial class ChooseWhenBuilder
    {
        private IExpression<bool>? _condition;

        [IgnoreBuilderField]
        private ICollection<IPolicy>? _policies;

        public ChooseWhenBuilder Policies(Action<PolicySectionBuilder> configurator)
        {
            var builder = new PolicySectionBuilder();
            configurator(builder);
            _policies = builder.Build();
            return this;
        }

        public ChooseWhen Build()
        {
            if(_condition == null) throw new NullReferenceException();
            if(_policies == null) throw new NullReferenceException();

            return new ChooseWhen(_condition, _policies);
        }
    }
}


namespace Mielek.Builders
{
    using Mielek.Builders.Policies;

    public partial class PolicySectionBuilder
    {
        public PolicySectionBuilder Choose(Action<ChoosePolicyBuilder> configurator)
        {
            var builder = new ChoosePolicyBuilder();
            configurator(builder);
            _sectionPolicies.Add(builder.Build());
            return this;
        }
    }
}

