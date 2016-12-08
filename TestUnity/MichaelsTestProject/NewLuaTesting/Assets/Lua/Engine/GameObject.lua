GameObject = {}

GameObject.x = 0;
function GameObject:Start ()
	
	GameObjectC.Log ("GameObject")
	GameObjectC.Log ("Calling function")
	message = GameObject.NewScript(self,"RigidBody")
	GameObjectC.Log (message)
	RigidBody:Move("Forward", 10, 100)
end

function GameObject:Update ()

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