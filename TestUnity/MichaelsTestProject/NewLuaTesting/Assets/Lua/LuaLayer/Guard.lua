Guard = {}
local startPosition = {x=0,y=0,z=0}
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
	

--GameObject:NewScript("AI")
end


function Guard:Update()
	currentPos.x, currentPos.y, currentPos.z = Transform:GetPosition()
	if(Guard:targetPos ~= nil)then
		if(state=="Chase" and targetName~="")then
		targetPos.x,nvt,targetPos.z = Transform:GetPosition(targetName)
		end

		currentPos.x, temp, currentPos.z = Transform:GetPosition()
		local diffX = targetPos.x-currentPos.x
		local diffz = targetPos.z -currentPos.z
		local length = math.sqrt(diffX*diffX + diffz*diffz)
		local normx = diffX/length
		local normz = diffz/length
		normx = normx*speed/60
		normz = normz*speed/60
		if(state=="Evade")then
			normx = normx *-1
			normz = normz *-1
		end

		Transform:Teleport(currentPos.x+normx,currentPos.y,currentPos.z+normz)--todo calculations and speed
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
		x = x * guardRange
		z = z * guardRange
		local tempx, tempy,tempz = Transform.GetPosition()
		x= x + tempx
		z= z + tempz
		endPosition.x = x
		endPosition.z = z
	end
	state = "Patrol"

end

function Guard:Chase (gameObject, guardSpeedRunning)
	speed = guardSpeedRunning
	state = "Chase"
	targetName = gameObject
--GameObject:Chase (gameObject,guardSpeedRunning)
end

function Guard:Evade (gameObject, guardSpeedRunning)
	speed = guardSpeedRunning
	targetName = gameObject
	state = "Evade"
	--GameObject:Evade (gameObject,guardSpeedRunning)
end

return Guard