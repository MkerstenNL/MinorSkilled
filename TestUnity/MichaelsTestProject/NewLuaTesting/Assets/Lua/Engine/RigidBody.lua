RigidBody = {}

function RigidBody:Start()
	--WorldC.Log ("Test")
	RigidBodyC.Log ("RigidBody Initialized")
	
end

function RigidBody:Update()

end

function RigidBody:IsMoving()
	return RigidBodyC.IsMoving()
end


function RigidBody:TurnOnCollider (bool)
	RigidBodyC.Log ("RigidBody Initialized")
	return RigidBodyC.TurnOnCollider(bool)
end

function RigidBody:UseGravity(bool)
	return RigidBodyC.UseGravity(bool)
end

function RigidBody:Move (x,y,z, distance)
	--direction and speed and distance
	if(type (x) == "string" and type (y) == "number" and type (z) == "number")then
		local dirx,diry,dirz = RigidBodyC.GetDirection(x)
		local message = RigidBodyC.Move (dirx, diry, dirz, y, z)
		return message
	--direction and speed distance will be an absurd amount to handle it in c#
	elseif(type (x) == "string" and type (y) == "number" and type (z) == "nil")then
		local dirx, diry, dirz = RigidBodyC.GetDirection (x)
		local message = RigidBodyC.Move (dirx, diry, dirz, y, 34028234663852885981170418348451692544)
		return message
	--targetPosition and speed
	elseif(type(x)=="number" and type(y)=="number" and type(z)=="number" and type(distance)=="number")then
		local message = RigidBodyC.MoveToTarget (x, y, z, distance)
		return message
	else
		return "Invalid parameters"
	end

end

return RigidBody
