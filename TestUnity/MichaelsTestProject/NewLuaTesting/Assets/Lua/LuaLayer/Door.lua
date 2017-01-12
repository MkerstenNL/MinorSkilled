Door = {}
 Door.Opened = false
function Door:Start()
	------GameObjectC.Log("Adding Transform from Door")
	GameObject:NewScript("Transform")
	--World:Start()
end

function Door:Update()

end

function Door:Interactive()
	if(Door.Opened==true)then Close() return"Door Already open. Closing now"end
	------GameObjectC.Log("Opening Door")
	Door.Opened = true
	Transform:Teleport("Right",5)
	------GameObjectC.Log("Door openend")
end

function Door:Close()
	if(Door.Opened==false)then return"Door Already Closed."end
	Door.Opened = false
	Transform:Teleport ("Left", 5)
end

return Door