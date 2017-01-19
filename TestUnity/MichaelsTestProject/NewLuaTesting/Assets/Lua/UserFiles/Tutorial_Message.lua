MessageBoard.Status = "clean"

if(MessageBoard.Status == "dirty") then
MessageBoard:NoMessage(MessageBoard.Status)
else
MessageBoard:ShowMessage(MessageBoard.Status)
end 