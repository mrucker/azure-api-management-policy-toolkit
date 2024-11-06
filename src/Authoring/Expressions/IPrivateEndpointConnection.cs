// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;

public interface IPrivateEndpointConnection
{
    string Name { get; }
    string GroupId { get; }
    string MemberName { get; }
}