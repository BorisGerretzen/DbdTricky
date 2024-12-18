using System.Linq;
using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.Git.GitTasks;

[GitHubActions("Release",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = false,
    InvokedTargets = [nameof(Pack), nameof(Push)],
    EnableGitHubToken = true,
    OnWorkflowDispatchRequiredInputs = [nameof(PackageVersion)],
    ImportSecrets = [nameof(NugetApiKey)])]
[GitHubActions(
    "Test",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = false,
    InvokedTargets = [nameof(Test)],
    On = [GitHubActionsTrigger.Push, GitHubActionsTrigger.PullRequest])]
class Build : NukeBuild
{
    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")] readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
    [Parameter("API Key for the NuGet server.")] [Secret] readonly string NugetApiKey;
    [Parameter("NuGet server URL.")] readonly string NugetSource = "https://api.nuget.org/v3/index.json";
    [Parameter("NuGet package version.")] readonly string PackageVersion;
    [Solution] readonly Solution Solution;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
    Project GdsSharpProject => Solution.GetProject("DbdTricky.Lib");

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(path => path.DeleteDirectory());
            ArtifactsDirectory.CreateOrCleanDirectory();
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution)
            );
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .EnableNoRestore()
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .SetAssemblyVersion(PackageVersion)
                .SetInformationalVersion(PackageVersion)
            );
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore()
                .EnableNoBuild()
                .CombineWith(
                    from framework in GdsSharpProject.GetTargetFrameworks()
                    select new { framework }, (cs, v) => cs
                        .SetFramework(v.framework)
                )
            );
        });

    Target Pack => _ => _
        .DependsOn(Clean, Test)
        .Requires(() => Configuration == Configuration.Release)
        .Executes(() =>
        {
            DotNetPack(s => s
                .EnableNoRestore()
                .EnableNoBuild()
                .SetProject(GdsSharpProject)
                .SetConfiguration(Configuration)
                .SetOutputDirectory(ArtifactsDirectory)
                .SetProperty("PackageVersion", PackageVersion)
            );
        });

    Target Push => _ => _
        .After(Pack)
        .Executes(() =>
        {
            DotNetNuGetPush(s => s
                .SetSource(NugetSource)
                .SetApiKey(NugetApiKey)
                .CombineWith(ArtifactsDirectory.GlobFiles("*.nupkg"), (s, v) => s
                    .SetTargetPath(v)
                )
            );

            Git("config --global user.email 'gh@gerretzen.eu'");
            Git("config --global user.name 'GitHub Actions'");
            Git($"tag -a {PackageVersion} -m \"Created release {PackageVersion}\"");
            Git($"push --tags");
        });

    public static int Main() => Execute<Build>(x => x.Test);
}