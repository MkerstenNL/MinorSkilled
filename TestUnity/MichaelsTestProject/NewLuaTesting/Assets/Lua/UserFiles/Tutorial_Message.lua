MessageBoard.Status = dirty

if(MessageBoard.Status == dirty) then
MessageBoard:NoMessage()
else
MessageBoard:ShowMessage()
end