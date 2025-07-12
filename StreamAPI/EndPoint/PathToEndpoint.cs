namespace StreamAPI.EndPoint;

public static class ApiVersion
{
    public const int V1 = 1;
    public const int V2 = 2;
}

public static class RootPath
{
    public const string Root = "api/{version:apiVersion}";
}
public static class MediaPath
{
    private const string Root = $"{RootPath.Root}/Media";
    public const string Create = $"{Root}/Create";
    public const string Get = $"{Root}/GetAll";
    public const string GetById = $"{Root}/Get/"+"{id}";
}