// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.ApiManagement.PolicyToolkit.Authoring;

[AttributeUsage(AttributeTargets.Class)]
public class DocumentAttribute(string? name = null, DocumentScope scope = DocumentScope.Any) : Attribute
{
    public string? Name { get; } = name;
}