FileInfo? FindFile(string filePattern, DirectoryInfo directoryInfo)
{
    var splits = filePattern.Split('.');
    var fileName = splits[0];
    var ext = (splits.Length > 1 ? "." + splits[1] : "");

    var file = directoryInfo.EnumerateFiles()
        .FirstOrDefault(fileInfo => Path.GetFileNameWithoutExtension(fileInfo.Name) == fileName &&
                                    (ext == "" || fileInfo.Extension == ext));

    if (file != null)
    {
        return file;
    }

    return directoryInfo.GetDirectories()
        .Select(innerDirectoryInfo => FindFile(filePattern, innerDirectoryInfo))
        .FirstOrDefault(resultFile => resultFile != null);
}

var examples = new[]
{
    "Program.cs",
    "README",
    "krakozyabra",
};

foreach (var example in examples)
{
    var file = FindFile(example, new DirectoryInfo("../../../../"));
    Console.Out.WriteLine($"{example} => {file?.FullName}");
}