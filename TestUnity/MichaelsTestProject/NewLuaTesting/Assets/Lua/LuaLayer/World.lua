--World in luaLayer
World = {}
function World:Start()
	--GameObjectC.Log("Adding RigidBody from Door")
	--World:Start()
end

function World:Update()
end

function World:CreateObject(prefabName, LocationX,LocationY,LocationZ)
	WorldC.Log("Adding RigidBody from Door")
	WorldEngine:CreateObject(prefabName, LocationX,LocationY,LocationZ)
end

return World