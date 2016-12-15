GameObject = {}
function GameObject:Start ()
	
	GameObjectC.Log ("GameObject Initialized")
	--message = GameObject.NewScript (self, "RigidBody")
	--message = GameObject:NewScript("Transform")
	--GameObjectC.Log (message)
	--RigidBody:Move("Forward",5)
end

function GameObject:Update ()
	--Transform:Turn(2,10,1)
end

function GameObject:NewScript (name)
	if(name == nil)then GameObjectC.Log("name == nil")end
	if(type (name) == "string")then
		GameObjectC.Log("adding component:"..name)
		local  table, message = GameObjectC.NewComponent (name)
		
		GameObjectC.Log (message)
		GameObjectC.Log (table)
		return "Succes" 
	else
		return "NewComponent expects a string"
	end
end

return GameObject