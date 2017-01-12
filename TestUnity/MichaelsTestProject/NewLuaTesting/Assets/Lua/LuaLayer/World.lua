World = {}
function World:Start ()
	GameObjectC.Log("Test From THe World")
	GameObject:NewScript("World")
	
--World:Start()
end

function World:Update()
end

function World:CreateObject()
	
	GameObjectC.Log("Creating Car Fuck Unity 2.0")
	--WorldEngine:CreateObject(prefabName, LocationX,LocationY,LocationZ)
end

return World