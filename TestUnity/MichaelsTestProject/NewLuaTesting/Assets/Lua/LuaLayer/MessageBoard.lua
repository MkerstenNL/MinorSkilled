MessageBoard = {}
function MessageBoard:Start()
	GameObjectC.Log("Adding Transform from Door")
	GameObject:NewScript("Transform")
	--World:Start()
end

function MessageBoard:Update()

end

function MessageBoard:NoMessage(status) 
	GameObject.Log("NoMessage")
end
function MessageBoard:ShowMessage(status) 
	if(status ~= dirty) then
	--showmessage
	GameObject.Log("ShowMessage")
	end
end

function MessageBoard:Interactive()
	if(Door.Opened==true)then Close() return"Door Already open. Closing now"end
	GameObjectC.Log("Opening Door")
	Door.Opened = true
	Transform:Teleport("Right",5)
	GameObjectC.Log("Door openend")
end

return MessageBoard