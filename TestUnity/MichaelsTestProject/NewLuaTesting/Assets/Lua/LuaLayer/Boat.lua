Boat = {}
function Boat:Start()
	GameObjectC.Log("Adding Transform from Door")
	GameObject:NewScript("RigidBody")
	--World:Start()
end

function Boat:Update()

end

function Boat:Move(direction,speed)
RigidBody:Move("Back",10)
end
return Boat