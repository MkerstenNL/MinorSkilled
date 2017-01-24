MessageBoard = {}
function MessageBoard:Start()
	----GameObjectC.Log("Adding Transform from Door")
	GameObject:NewScript("Transform")
	--World:Start()
end

function MessageBoard:Update()

end

function MessageBoard:DontCleanBoard(status) 
	GameObjectC.Log("NoMessage")
end
function MessageBoard:CleanBoard(status)
	if(status ~= dirty) then
	--showmessage
	GameObjectC.Log("ShowMessage")
	GameObject:MessageBoard()
	end
end

return MessageBoard