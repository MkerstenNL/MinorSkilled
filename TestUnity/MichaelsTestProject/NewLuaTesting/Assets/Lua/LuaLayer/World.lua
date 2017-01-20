World = {}
function World:Start ()
	GameObjectC.Log("Test From THe World")
	GameObject:NewScript("World")
end

function World:Update ()
	GameObjectC.Log("World update")
end

function World:Call (prefabName, LocationX, LocationY, LocationZ)
	WorldEngine:CreateObject(prefabName, LocationX,LocationY,LocationZ)
end

return World