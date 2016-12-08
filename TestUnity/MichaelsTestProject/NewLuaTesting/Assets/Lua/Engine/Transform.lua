Transform = {}

function Transform:Start()
	--WorldC.Log ("Test")
	TransformC.Log ("Transform Initialized")
	
end

function Transform:Update()
end


function Transform:IsActive()

end

function Transform:Turn(x,y,z)
	if(type(x)=="string")then
		if(x=="Up")then
			TransformC.Rotate(1, 0, 0, -90)
		elseif(x=="Down")then
			TransformC.Rotate(1,0,0,90)
		elseif(x=="Left")then
			TransformC.Rotate(0,1,0,-90)
		elseif(x=="Right")then
			TransformC.Rotate(0,1,0,90)
		else
			return "Invalid direction."
		end

	elseif (type(x)=="number" and y == nil)then
		TransformC.Rotate(0,1,0,x)
		return "rotation succesfull"
	elseif(x~=nil and y~=nil and z~=nil)then
		rotx,roty,rotz = TransformC.GetRotation()
		rotx = rotx+x
		roty= roty+y
		rotz= rotz+z
		TransformC.SetRotation(rotx,roty,rotz)
	end

	return "Invalid amounts of parameters"
end

function Transform:Teleport (x, y, z, distance)
	if(z == nil and type (x) == "string")then
		distance = y
		x, y, z = TransformC.GetDirection (x)
		local oldx,oldy,oldz = TransformC.GetPosition()
		TransformC.Log(""..y)
		TransformC.Log(""..oldx)
		x = x * distance + oldx
		y = y * distance + oldy
		z = z * distance + oldz
		local message = TransformC.SetPosition(x, y, z)
	elseif(distance == nil) then
		local message = TransformC.SetPosition(x, y, z)
	
	else
		local oldx,oldy,oldz = TransformC.GetPosition()
		x = x * distance + oldx
		y = y * distance + oldy
		z = z * distance + oldz
		local message = TransformC.SetPosition(x, y, z)
	end

	return message
end

function Transform:Up()
	TransformC.GetDirection("Up")
end

function Transform:Down()
	TransformC.GetDirection ("Down")
end

function Transform:Left ()
	TransformC.GetDirection ("Left")
end

function Transform:Right ()
	TransformC.GetDirection ("Right")
end

function Transform:Forward ()
	TransformC.GetDirection ("Forward")
end

function Transform:Backward ()
	TransformC.GetDirection ("Backward")
end


return Transform
