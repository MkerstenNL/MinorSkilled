require '\lua\UserFiles\message.lua'
MessageBoard = {}
Status = dirty
function Start()
end


function Update()

	if(Status ~= dirty) then
	Status = dirty
	ShowMessage()
	else
	NoMessage()
	end
end

function MessageBoard:NoMessage() 
	--DirtTexture
	return Status
end
function MessageBoard:ShowMessage() 
	--enable trigger for new message and a texture that shows a message
	return Status
end



return MessageBoard