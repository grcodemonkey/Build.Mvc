cd "Build.Mvc"
del *.nupkg

START /WAIT nuget pack -Prop Configuration=Release -IncludeReferencedProjects
START /WAIT nuget push *.nupkg

cd "..\Build.Mvc.TwitterBootstrap"
del *.nupkg

START /WAIT nuget pack -Prop Configuration=Release -IncludeReferencedProjects
START /WAIT nuget push *.nupkg