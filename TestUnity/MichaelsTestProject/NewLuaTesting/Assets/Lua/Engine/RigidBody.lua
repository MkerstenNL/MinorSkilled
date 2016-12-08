RigidBody = {}

function RigidBody:Start()
	--WorldC.Log ("Test")
	RigidBodyC.Log ("RigidBody Initialized")
	
end

function RigidBody:Update()
end


function RigidBody:IsActive()

end

function RigidBody:Turn(x,y,z)

end

function RigidBody:Move (x,y,z, distance)

end

function RigidBody:Up()
	RigidBodyC.GetDirection("Up")
end

function RigidBody:Down()
	RigidBodyC.GetDirection ("Down")
end

function RigidBody:Left ()
	RigidBodyC.GetDirection ("Left")
end

function RigidBody:Right ()
	RigidBodyC.GetDirection ("Right")
end

function RigidBody:Forward ()
	RigidBodyC.GetDirection ("Forward")
end

function RigidBody:Backward ()
	RigidBodyC.GetDirection ("Backward")
end


return RigidBody
