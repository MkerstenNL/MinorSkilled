Transform = {}

function Transform:Start()
	--WorldC.Log ("Test")
	TransformC.Log ("Transform")
	GameObject:Start()
end

function Transform:IsActive()

end

function Transform:Turn(x,y,z)

end

function Transform:Teleport (x,y,z, distance)


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
