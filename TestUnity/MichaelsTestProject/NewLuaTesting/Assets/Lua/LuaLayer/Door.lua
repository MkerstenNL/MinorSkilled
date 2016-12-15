Door = {}
 Door.Open = false
function Door:Start()
	GameObjectC.Log("Adding Transform from Door")
	GameObject:NewScript("Transform")
	Door:Open()
	GameObjectC.Log("Transform added from door")
end

function Door:Update()

end

function Door:Open()
	if(Door.Open==true)then return"Door Already open."end
	GameObjectC.Log("Opening Door")
	--Door.Open = true
	Transform:Turn(90)
	GameObjectC.Log("Door openend")
end

function Door:Close()
	if(Door.Open==false)then return"Door Already Closed."end
	Door.Open = false
	Transform:Turn(-90)
end

return Door