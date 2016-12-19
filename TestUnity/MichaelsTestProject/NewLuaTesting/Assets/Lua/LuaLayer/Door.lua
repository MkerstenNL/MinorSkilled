Door = {}
 Door.Opened = false
function Door:Start()
	GameObjectC.Log("Adding Transform from Door")
	GameObject:NewScript("Transform")
	--World:Start()
end

function Door:Update()

end

function Door:Open()
	if(Door.Opened==true)then return"Door Already open."end
	GameObjectC.Log("Opening Door")
	Door.Opened = true
	Transform:Turn(90)
	GameObjectC.Log("Door openend")
end

function Door:Close()
	if(Door.Opened==false)then return"Door Already Closed."end
	Door.Opened = false
	Transform:Turn(-90)
end

return Door