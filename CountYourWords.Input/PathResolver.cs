using System.Reflection;

namespace CountYourWords.Input;

public class PathResolver : IPathResolver
{
    public string ResolvePath(string fileName) =>
        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, fileName);
}
