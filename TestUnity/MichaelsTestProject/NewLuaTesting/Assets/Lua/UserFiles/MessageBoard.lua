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

end
function MessageBoard:ShowMessage() 

end



return MessageBoard