using System.Reflection;

namespace StreamAPI.Features;

public static class FeatureAssemblyReference
{
    public static readonly Assembly Assembly = typeof(FeatureAssemblyReference).Assembly;
}