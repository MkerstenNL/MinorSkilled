Guard = {}
Guard.startPosition = {x=0,y=0,z=0}
Guard.endPosition = {x=0,z=0}

Guard.targetPos = nil
Guard.currentPos = {x=nil,y=nill,z=nil}
Guard.speed  = 0
Guard.state = "Patrol"
Guard.targetName = ""
Guard.range = 0
Guard.sightRange = 0
function Guard:Start()
	GameObject:NewScript("Transform")
	GameObject:NewScript ("RigidBody")
	--GameObjectC:Log("Guard Initialized")
	Guard.startPosition.x, Guard.startPosition.y, Guard.startPosition.z = Transform.GetPosition()
	a = Guard.startPosition.x 
	s = ""..a
	GameObjectC.Log(s)

--GameObject:NewScript("AI")
end


function Guard:Update ()
	--GameObjectC.Log ("Guard update")
	
	Guard.currentPos.x, Guard.currentPos.y, Guard.currentPos.z = Transform:GetPosition ()
	if(Guard.state == "Patrol")then
		--GameObjectC.Log("Update Patrol state")
		Guard:UpdatePatrolState()
	else
		--GameObjectC.Log("Update Evade or Chase state")
		Guard:UpdateChaseAndEvadeState()
	end


--if(state = "Patrol")then

--end


end

function Guard:Sense(senseRange) 
	Guard.sightRange = senseRange
end

function Guard:Patrol(guardRange,guardSpeedWalking)
	
	Guard.speed = guardSpeedWalking
	--GameObjectC.Log ("GuardRange = "..guardRange)
	if(Guard.endPosition.x==0)then
		
		local x,y,z = Transform:Forward()
		Guard.range = guardRange
		x = x * Guard.range
		z = z * Guard.range
		
		local tempx, tempy,tempz = Transform.GetPosition()
		x = x + tempx
		z = z + tempz
		
		Guard.endPosition.x = x
		Guard.endPosition.z = z

		Guard.targetPos = Guard.endPosition
		--GameObjectC.Log("Patrol range set"..Guard.targetPosition)
	end


end

function Guard:Chase (gameObject, guardSpeedRunning)
	Guard.speed = guardSpeedRunning
	Guard.state = "Chase"
	Guard.targetName = gameObject
--GameObject:Chase (gameObject,guardSpeedRunning)
end

function Guard:Evade (gameObject, guardSpeedRunning)
	Guard.speed = guardSpeedRunning
	Guard.targetName = gameObject
	Guard.state = "Evade"
--GameObject:Evade (gameObject,guardSpeedRunning)
end

function Guard:CheckRangeTarget(x,z)
	p=1
	if(type(x) == "string")then
		x,y,z = Transform:GetPosition(x)
		p=Guard.sightRange
	end

	GameObjectC.Log("CheckingRange")
	if(Guard.targetPos~=nil)then
		local diffX =x-Guard.currentPos.x
		local diffz = z -Guard.currentPos.z
		local length = math.sqrt(diffX*diffX + diffz*diffz)
		if(length<p)then
			--GameObjectC.Log("target in range")
			return true
		end
		return false
	end
	return false
end

function Guard:UpdatePatrolState()
	
	if(Guard:CheckRangeTarget(Guard.targetPos.x,Guard.targetPos.z))then
		if(Guard.targetPos == Guard.endPosition)then
			Guard.targetPos = Guard.startPosition
		else
			Guard.targetPos = Guard.endPosition
		end

	end
	--GameObjectC.Log("Testing sdfffffffffffffffffffffffffffffffffffffffffffffff")
	--GameObjectC.Log("Testing sdfffffffffffffffffffffffffffffffffffffffffffffff")
	Guard.currentPos.x, temp, Guard.currentPos.z = Transform:GetPosition()
	local diffX = Guard.targetPos.x-Guard.currentPos.x
	local diffz = Guard.targetPos.z -Guard.currentPos.z
	local length = math.sqrt(diffX*diffX + diffz*diffz)
	local normx = diffX/length
	local normz = diffz/length
	normx = normx*Guard.speed
	normz = normz*Guard.speed
	--if(state=="Evade")then
	--	normx = normx *-1
	--	normz = normz *-1
	--end

	Transform:Teleport(Guard.currentPos.x+normx,Guard.currentPos.y,Guard.currentPos.z+normz)
end

function Guard:UpdateChaseAndEvadeState()

	Guard.currentPos.x, temp, Guard.currentPos.z = Transform:GetPosition(Guard.targetName)
	local diffX = Guard.targetPos.x-Guard.currentPos.x
	local diffz = Guard.targetPos.z -Guard.currentPos.z
	local length = math.sqrt(diffX*diffX + diffz*diffz)
	local normx = diffX/length
	local normz = diffz/length
	normx = normx*Guard.speed
	normz = normz*Guard.speed
	--if(state=="Evade")then
	--	normx = normx *-1
	--	normz = normz *-1
	--end
	if(Guard.state=="Evade")then
		normx = normx*-1
		normz = normz*-1
	end

	Transform:Teleport(Guard.currentPos.x+normx,Guard.currentPos.y,Guard.currentPos.z+normz)
end


return Guard