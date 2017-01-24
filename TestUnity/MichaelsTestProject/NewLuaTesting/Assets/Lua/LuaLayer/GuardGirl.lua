GuardGirl = {}
GuardGirl.startPosition = {x=0,y=0,z=0}
GuardGirl.endPosition = {x=0,z=0}
GuardGirl.tempEndPosition = {x=0,z=0}

GuardGirl.targetPos = nil
GuardGirl.currentPos = {x=nil,y=nill,z=nil}
GuardGirl.speed  = 0
GuardGirl.state = "Patrol"
GuardGirl.targetName = ""
GuardGirl.range = 0
GuardGirl.sightRange = 0
GuardGirl.Money = 0
function GuardGirl:Start()
	GameObject:NewScript("Transform")
	GameObject:NewScript ("RigidBody")
	GameObject:NewScript("HUD")
	GuardGirl.startPosition.x, GuardGirl.startPosition.y, GuardGirl.startPosition.z = Transform.GetPosition()
	a = GuardGirl.startPosition.x 
	s = ""..a
	GameObjectC.Log(s)

--GameObject:NewScript("AI")
end


function GuardGirl:Update ()
	--GameObjectC.Log ("GuardGirl update")
	
	GuardGirl.currentPos.x, GuardGirl.currentPos.y, GuardGirl.currentPos.z = Transform:GetPosition ()
	if(GuardGirl.state == "Patrol")then
		--GameObjectC.Log("Update Patrol state")
		GuardGirl:UpdatePatrolState()
	else
		--GameObjectC.Log("Update Evade or Chase state")
		GuardGirl:UpdateChaseAndEvadeState()
	end


--if(state = "Patrol")then

--end


end

function GuardGirl:Sense(senseRange) 
	GuardGirl.sightRange = senseRange
end

function GuardGirl:Patrol(GuardGirlRange,GuardGirlSpeedWalking)
	
	GuardGirl.speed = GuardGirlSpeedWalking
	--GameObjectC.Log ("GuardGirlRange = "..GuardGirl.endPosition.x)
	if(GuardGirl.endPosition.x==0)then
		
		local x,y,z = Transform:Forward()
		GuardGirl.range = GuardGirlRange
		x = x * GuardGirl.range
		z = z * GuardGirl.range
		
		local tempx, tempy,tempz = Transform.GetPosition()
		x = x + tempx
		z = z + tempz
		
		GuardGirl.endPosition.x = x
		GuardGirl.endPosition.z = z

		--GameObjectC.Log("Patrol range set"..GuardGirl.targetPosition)
		GuardGirl.targetPos = GuardGirl.endPosition
		elseif GuardGirl.targetPos.x ~= GuardGirl.startPosition.x or GuardGirl.targetPos.x~= GuardGirl.endPosition.x then
		GuardGirl.targetPos = GuardGirl.endPosition

	end



end

function GuardGirl:Bribe (money)

	if(money == 3) then	
	GuardGirl.Money = HUDC:Score(-3)
	if (GuardGirl.Money  > -1) then
		GuardGirlSpeedRunning = 30
		gameObject = "Player"
		GuardGirl.speed = GuardGirlSpeedRunning
		GuardGirl.state = "Evade"
		GuardGirl.targetName = gameObject
		GuardGirl.Money = HUDC:Score(-3)
		return "true"
		else
		return "false"
		end
	end
return "false"
end

function GuardGirl:Chase (gameObject, GuardGirlSpeedRunning)
	GuardGirl.speed = GuardGirlSpeedRunning
	GuardGirl.state = "Chase"
	GuardGirl.targetName = gameObject
--GameObject:Chase (gameObject,GuardGirlSpeedRunning)
end

function GuardGirl:Evade (gameObject, GuardGirlSpeedRunning)
	GuardGirl.speed = GuardGirlSpeedRunning
	GuardGirl.targetName = gameObject
	--	GuardGirl.state = "Evade"
--GameObject:Evade (gameObject,GuardGirlSpeedRunning)
end

function GuardGirl:CheckRangeTarget(x,z)
	p=1
	if(type(x) == "string")then
		x,y,z = Transform:GetPosition(x)
		p = GuardGirl.sightRange
	end

	--GameObjectC.Log("CheckingRange")
	if(GuardGirl.targetPos~=nil)then
		local diffX =x-GuardGirl.currentPos.x
		local diffz = z -GuardGirl.currentPos.z
		local length = math.sqrt(diffX*diffX + diffz*diffz)
		if(length<p)then
			--GameObjectC.Log("target in range")
			return true
		end
		return false
	end
	return false
end

function GuardGirl:UpdatePatrolState()
	--GameObjectC.Log("TargetPos"..GuardGirl.targetPos.x)
	if(GuardGirl:CheckRangeTarget(GuardGirl.targetPos.x,GuardGirl.targetPos.z))then
		if(GuardGirl.targetPos == GuardGirl.endPosition)then
			GuardGirl.tempEndPosition = GuardGirl.endPosition
			GuardGirl.endPosition = nil
			GuardGirl.targetPos = GuardGirl.startPosition
	--GameObjectC.Log("at end "..GuardGirl.targetPos.x)
		else
	--GameObjectC.Log("new pos "..GuardGirl.startPosition.x)
			GuardGirl.endPosition = GuardGirl.tempEndPosition
			GuardGirl.targetPos = GuardGirl.endPosition
		end

	else 
	
	--GameObjectC.Log("Testing else")
	end
	--GameObjectC.Log("Testing sdfffffffffffffffffffffffffffffffffffffffffffffff")
	GuardGirl.currentPos.x, temp, GuardGirl.currentPos.z = Transform:GetPosition()
	local diffX = GuardGirl.targetPos.x-GuardGirl.currentPos.x
	local diffz = GuardGirl.targetPos.z -GuardGirl.currentPos.z
	local length = math.sqrt(diffX*diffX + diffz*diffz)
	local normx = diffX/length
	local normz = diffz/length
	normx = normx*GuardGirl.speed/60
	normz = normz*GuardGirl.speed/60
	--if(state=="Evade")then
	--	normx = normx *-1
	--	normz = normz *-1
	--end

	Transform:Teleport(GuardGirl.currentPos.x+normx,GuardGirl.currentPos.y,GuardGirl.currentPos.z+normz)
end

function GuardGirl:UpdateChaseAndEvadeState()

	GuardGirl.targetPos.x, temp, GuardGirl.targetPos.z = Transform:GetPosition(GuardGirl.targetName)
	local diffX = GuardGirl.targetPos.x-GuardGirl.currentPos.x
	local diffz = GuardGirl.targetPos.z -GuardGirl.currentPos.z
	local length = math.sqrt(diffX*diffX + diffz*diffz)
	local normx = diffX/length
	local normz = diffz/length
	normx = normx*GuardGirl.speed/60
	normz = normz*GuardGirl.speed/60
	--if(state=="Evade")then
	--	normx = normx *-1
	--	normz = normz *-1
	--end
	if(GuardGirl.state=="Evade")then
		normx = normx*-1
		normz = normz*-1
	end

	Transform:Teleport(GuardGirl.currentPos.x+normx,GuardGirl.currentPos.y,GuardGirl.currentPos.z+normz)
end


return GuardGirl