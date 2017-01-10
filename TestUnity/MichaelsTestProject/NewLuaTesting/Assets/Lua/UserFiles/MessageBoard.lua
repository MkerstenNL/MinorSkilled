MessageBoard = {}
Status = dirty
function Start()
end


function Update()

	if(Status ~= dirty) then
	Status = dirty
	ShowMessage()
	end
	
end

function MessageBoard:NoMessage() 
	--DirtTexture
end
function MessageBoard:ShowMessage() 
	--enable trigger for new message and a texture that shows a message
end



return MessageBoard