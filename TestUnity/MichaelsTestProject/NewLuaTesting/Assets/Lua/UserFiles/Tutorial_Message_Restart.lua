MessageBoard.Status = "dirty"

if(MessageBoard.Status == "dirty") then
MessageBoard:DontCleanBoard(MessageBoard.Status)
else
MessageBoard:CleanBoard(MessageBoard.Status)
end 