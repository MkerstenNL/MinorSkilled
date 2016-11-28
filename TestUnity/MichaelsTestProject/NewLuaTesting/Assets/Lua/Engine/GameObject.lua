table = {}

function Start ()
	
	GameObjectC.Log ("GameObject")
	--message = NewComponent ("Transform")
	GameObjectC.Log ("Test")
	message = Update ()
	GameObjectC.Log (message)
	--NewComp ()

	message = NewComponent ("Transform")
	GameObjectC.Log(message)
--message = NewComponent ("Transform")
--GameObjectC.Log (message)
end

function Update ()
	--i = i + 1
	--message = "test"+tostring(i)
	GameObjectC.Log ("update")
	return "fuck it"
--GameObjectC.Log("Update From GameObject")
end

function NewComponent (name)
	if(type (name) == "string")then

		
		--local comp = Components[name]
		--if(comp~=nil)then
		--	return "component Already exists"
		--else
		GameObjectC.NewScript (name)
		--Transform = require ("")
		return "Succes"
	--end
	else
		return "NewComponent expects a string"
	end
end


--[[--]]



