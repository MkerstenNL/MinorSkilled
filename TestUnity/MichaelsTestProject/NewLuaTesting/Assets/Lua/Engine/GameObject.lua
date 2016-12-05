GameObject = {}
GameObject.x = 0;
function GameObject:Start ()
	
	GameObjectC.Log ("GameObject")
	GameObjectC.Log ("Calling function")
	message = GameObject.NewScript(self,"Transform")
	GameObjectC.Log (message)
	
end

function GameObject:Update ()
	GameObject.x = GameObject.x + 0.02
	Transform:Teleport(GameObject.x,1,1)

end

function GameObject:NewScript (name)
	if(name == nil)then GameObjectC.Log("name == nil")end
	if(type (name) == "string")then
		GameObjectC.Log("adding component:"..name)
		local  table, message = GameObjectC.NewComponent (name)
		
		GameObjectC.Log (message)
		GameObjectC.Log (table)
		
		Transform:Start ()
		return "Succes" 
	else
		return "NewComponent expects a string"
	end
end

return GameObject

--[[--]]



