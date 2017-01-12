World = {}
function World:Start ()
	GameObjectC.Log("Test")
	GameObject:NewScript("World")
	
--World:Start()
end

function World:Update()
end

function World:CreateObject(prefabName, LocationX,LocationY,LocationZ)
	--WorldC.Log("Creating Car")
	--WorldEngine:CreateObject(prefabName, LocationX,LocationY,LocationZ)
end

return World