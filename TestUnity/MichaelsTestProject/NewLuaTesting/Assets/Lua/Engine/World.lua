World = {}

function World:Start()
	WorldC.Log("HelloWorld")
end

function World:CreateObject(name, x,y,z)
	WorldC:CreateObject(name, x,y,z)
end

function World:FindObject(name)

end

function World:LoadNewLevel(level)
	WorldC.LoadLevel(level)
end

return World
