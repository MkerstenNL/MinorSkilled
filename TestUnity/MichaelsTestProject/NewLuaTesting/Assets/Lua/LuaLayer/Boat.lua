Boat = {}
function Boat:Start()
	------GameObjectC.Log("Adding Transform from Door")
	GameObject:NewScript ("RigidBody")
	Boat:Move("Back", 5, 200)
--World:Start()
end

function Boat:Update()

end

function Boat:Move(direction,speed)
	RigidBody:Move(direction,speed,200)
end
return Boat