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
	--if(type(x)==""

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
