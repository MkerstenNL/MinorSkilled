GameObject = {}
function GameObject:Start ()
	
	----GameObjectC.Log ("GameObject Initialized")
	--message = GameObject.NewScript (self, "RigidBody")
	--message = GameObject:NewScript("Transform")
	------GameObjectC.Log (message)
	--RigidBody:Move("Forward",5)
end

function GameObject:Update ()
	--Transform:Turn(2,10,1)
end

function GameObject:NewScript (name)
	if(name == nil)then --GameObjectC.Log("name == nil")
	end
	if(type (name) == "string")then
		----GameObjectC.Log("adding component:"..name)
		local  table, message = GameObjectC.NewComponent (name)
		
		----GameObjectC.Log (message)
		----GameObjectC.Log (table)
		return "Succes" 
	else
		return "NewComponent expects a string"
	end
end

function GameObject:MessageBoard()
GameObjectC.Log ("GameObjectMessageBoard")
MessageBoardText = [[GuardRange = 30
		GuardSense = 3
		GuardSpeedRunning = 2
		GuardSpeedWalking = 1


		function Start()
			Guard:Patrol (GuardRange, GuardSpeedWalking)
			Guard:Sense (GuardSense)
			GameObjectC.Log("Guard Initialized")
		end

		function Update ()
			GameObjectC.Log("Guard update from userfile")
		-- IsSense = Guard:Sense(GuardSense)
		-- StillPatrol = Guard:Patrol(GuardRange, GuardSpeedWalking)
		-- if(StillPatrol == false or IsSense == true) then
		-- StillChasing = Guard:Chase("Player",GuardSpeedRunning)
		-- if(Guard.Hit() == "Player") then
		-- Player:TeleportTo(10,1,10)
		-- end
		-- else
		-- Guard:Patrol (GuardRange, GuardSpeedWalking)
		-- GameObjectC.Log("UserFile Updating")
		-- end
		end
		"]]
return GameObjectC.MessageBoard(MessageBoardText)
end

return GameObject