CreateObject = {}
function CreateObject:Start()
	GameObjectC.Log("Adding RigidBody from Door")
	--World:Start()
end

function CreateObject:Update()
end

function World:CreateObject(prefabName, LocationX,LocationY,LocationZ)
	World:CreateObject(prefabName, LocationX,LocationY,LocationZ)
end

return CreateObject