Param(
	[ValidateSet('add','updateDatabase', 'remove', 'list')]
    $command,
	$additional
)

if (-not $command) 
{
	"Type the command!"
	Exit
}

function ChangeProjectType ($newProject, $temporary) 
{
	Move-Item .\project.json $temporary
	Move-Item $newProject .\project.json
	dotnet restore
}

function ExecuteCommand($commandName, $additionalParameter)
{
	if ($commandName -eq "add")
	{
		if (-not $additionalParameter)
		{
			"Migration name not informed"
			Exit
		}

		dotnet ef migrations add $additional
	}

	elseif ($commandName -eq "updateDatabase")
	{
		dotnet ef database update
	}

	elseif ($commandName -eq "remove")
	{
		dotnet ef migrations remove
	}
	elseif ($commandName -eq "list")
	{
		dotnet ef migrations list
	}

}

$projectDll = ".\project-dll.json"
$projectExec = ".\projectMigration.json"

ChangeProjectType -newProject $projectExec -temporary $projectDll
ExecuteCommand -commandName $command -additionalParameter $additional
ChangeProjectType -newProject $projectDll -temporary $projectExec
