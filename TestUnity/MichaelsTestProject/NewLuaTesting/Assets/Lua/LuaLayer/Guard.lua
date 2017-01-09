Guard = {}
local startPosition = {x=0,z=0}
local endPosition = {x=0,z=0}

local targetPos = nil
local currentPos = {x=nil,z=nil}
local speed  = 0
local state = "Patrol"
local targetName = ""
function Guard:Start()
	GameObjectC.Log("Adding Transform from Door")
	GameObject:NewScript("Transform")
	GameObject:NewScript ("RigidBody")
	startPosition.x, temp, startPosition.z = Transform.GetPosition() 
	endPosition.x endPosition.z = startPosition.x, startPosition.z

--GameObject:NewScript("AI")
end


function Guard:Update()
	if(Guard:targetPos ~= nil)then
		if(state=="Chase")then
		targetPos.x,nvt,targetpos.z = Transform:findPositionOfObject(targetName)
		end

		currentPos.x, temp, currentPos.z = Transform:GetPosition()
		local diffX = targetPos.x-currentPos.x
		local diffz = targetPos.z -currentPos.z
		if(state=="Evade")then
			diffX = diffX *-1
			diffz = diffz *-1
		end


		Transform:Teleport()--todo calculations and speed
	else
		targetPos = endPosition

	end


end

function Guard:Sense(senseRange) 
	RigidBody:SetScaleCollider(senseRange)
end

function Guard:Patrol(guardRange,guardSpeedWalking)
	speed= guardSpeedWalking
	if(endPosition.x==nil)then
		local x,y,z = Transform:GetDirection()
		x = x*guardRange
		z = z*guardRange
		local tempx, tempy,tempz = Transform.GetPosition()
		x= x+ tempx
		z= z+ tempz
		endPosition.x = x
		endPosition.z = z
	end
	state = "Patrol"

end

function Guard:Chase (gameObject, guardSpeedRunning)
	speed = guardSpeedRunning
	state = "Chase"
	GameObject:Chase (gameObject,guardSpeedRunning)
end

function Guard:Evade (gameObject, guardSpeedRunning)
	speed = guardSpeedRunning
	state = "Evade"
	GameObject:Evade (gameObject,guardSpeedRunning)
end

return Guard