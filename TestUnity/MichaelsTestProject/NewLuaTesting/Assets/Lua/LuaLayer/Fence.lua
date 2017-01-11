Fence = {}
function Fence:Start()
	GameObjectC.Log("Adding RigidBody from Door")
	GameObject:NewScript("RigidBody")
	--World:Start()
end

function Fence:Update()
end

function Fence:TurnOnCollider(TrueOfFalse)
	RigidBody:TurnOnCollider(TrueOfFalse)
	GameObjectC.Log("Adding RigidBody from Door")
end

return Fence