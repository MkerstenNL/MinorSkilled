WorldEngine = {}

function World:Start()
	WorldC.Log("HelloWorld")
end

function WorldEngine:CreateObject(name, x,y,z)
	WorldC.Log("HelloWorld")
	WorldC.CreateObject(name, x,y,z)
end

function WorldEngine:FindObject(name)

end

function WorldEngine:LoadNewLevel(level)
	WorldC.LoadLevel(level)
end

return WorldEngine
