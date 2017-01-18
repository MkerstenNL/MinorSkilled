Status = "clean"

if(Status == "dirty") then
MessageBoard:NoMessage(Status)
else
MessageBoard:ShowMessage(Status)
end 