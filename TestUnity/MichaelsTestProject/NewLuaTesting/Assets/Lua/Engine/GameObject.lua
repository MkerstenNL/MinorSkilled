GameObject = {}
GameObject.IsInteractive = false
function GameObject:Start ()
	
	GameObjectC.Log ("GameObject")
	--message = NewComponent ("Transform")
	GameObjectC.Log ("Calling function")
	--NewComp ()
	message = GameObject.NewScript(self,"Transform")
	GameObjectC.Log(message)
--message = NewComponent ("Transform")
--GameObjectC.Log (message)
end

function GameObject:Update ()
	--i = i + 1
	--message = "test"+tostring(i)
	GameObjectC.Log ("update")
	return "fuck it"
--GameObjectC.Log("Update From GameObject")
end

function GameObject:NewScript (name)
	if(name == nil)then GameObjectC.Log("name == nil")end
	if(type (name) == "string")then
		GameObjectC.Log("adding component:"..name)
		local  table, message = GameObjectC.NewComponent (name)
		
		GameObjectC.Log (message)
		GameObjectC.Log (table)
		Transform:Start ()
		Transform:Test()
		return "Succes" 
	else
		return "NewComponent expects a string"
	end
end

return GameObject

--[[--]]



