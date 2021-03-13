#load "nuget:?package=PleOps.Cake&version=0.4.1"

Task("Define-Project")
    .Description("Fill specific project information")
    .Does<BuildInfo>(info =>
{
    info.AddLibraryProjects("Yarhl");
    info.AddLibraryProjects("Yarhl.Media");
    info.AddTestProjects("Yarhl.UnitTests");
    info.AddTestProjects("Yarhl.IntegrationTests");

    info.PreviewNuGetFeed = "https://pkgs.dev.azure.com/SceneGate/SceneGate/_packaging/SceneGate-Preview/nuget/v3/index.json";
});

Task("Prepare-IntegrationTests")
    .Description("Prepare the integration tests by copying an example of DLL")
    .IsDependeeOf("Test")
    .Does<BuildInfo>(info =>
{
    // Copy a good and bad plugin to test the assembly load logic
    string pluginPath = $"src/Yarhl.Media/bin/{info.Configuration}/netstandard2.0/Yarhl.Media.dll";
    string badPluginPath = info.SolutionFile; // this isn't a DLL for sure :D

    string outputBasePath = $"src/Yarhl.IntegrationTests/bin/{info.Configuration}";
    string testProjectPath = "src/Yarhl.IntegrationTests/Yarhl.IntegrationTests.csproj";

    foreach (string framework in GetTargetFrameworks(testProjectPath)) {
        string pluginDir = $"{outputBasePath}/{framework}/Plugins";
        CreateDirectory(pluginDir);
        CopyFile(pluginPath, $"{pluginDir}/Yarhl.Media.dll");
        CopyFile(badPluginPath, $"{pluginDir}/MyBadPlugin.dll");
    }
});

public IEnumerable<string> GetTargetFrameworks(string projectPath)
{
    var projectXml = System.Xml.Linq.XDocument.Load(projectPath).Root;
    List<string> frameworks = projectXml.Elements("PropertyGroup")
        .Where(x => x.Element("TargetFrameworks") != null)
        .SelectMany(x => x.Element("TargetFrameworks").Value.Split(';'))
        .ToList();

    string singleFramework = projectXml.Elements("PropertyGroup")
        .Select(x => x.Element("TargetFramework")?.Value)
        .FirstOrDefault();
    if (singleFramework != null && !frameworks.Contains(singleFramework)) {
        frameworks.Add(singleFramework);
    }

    return frameworks;
}

Task("Default")
    .IsDependentOn("Stage-Artifacts");

string target = Argument("target", "Default");
RunTarget(target);
