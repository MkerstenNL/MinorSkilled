Status = "clean"

if(Status == "dirty") then
 GameObjectC.Log("testDirty")
MessageBoard:NoMessage(Status)
else
GameObjectC.Log("testClean")
MessageBoard:ShowMessage(Status)
end 