Guard = {}
function Start()
	GameObjectC.Log("Adding Transform from Door")
	GameObject:NewScript("Transform")
	GameObject:NewScript("RigidBody")
end


function Update()

end

function Guard:Sense(senseRange) 
	GameObject:Sense(senseRange)
end

function Guard:Patrol(guardRange,guardSpeedWalking)
	GameObject:Range(guardRange,guardSpeedWalking)
end

function Guard:Chase (gameObject, guardSpeedRunning)
	GameObject:Chase(gameObject,guardSpeedRunning)
end

function Guard:Evade (gameObject, guardSpeedRunning)
	GameObject:Evade(gameObject,guardSpeedRunning)
end

return Guard