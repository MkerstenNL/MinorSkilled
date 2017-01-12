World = {}
function World:Start ()
	GameObjectC.Log("Test From THe World")
	GameObject:NewScript("World")
end

function World:Update ()
	GameObjectC.Log("World update")
end

function World:CreateObject (prefabName, LocationX, LocationY, LocationZ)
	GameObjectC.Log("Creating Car Fuck Unity 2.0")
	WorldEngine:CreateObject(prefabName, LocationX,LocationY,LocationZ)
end

return World