GuardRange = 30
GuardSense = 3
GuardSpeedRunning = 2
GuardSpeedWalking = 1


function Start()
	Guard:Patrol (GuardRange, GuardSpeedWalking)
	Guard:Sense (GuardSense)
	GameObjectC.Log("Guard Initialized")
end

function Update()
--IsSense = Guard:Sense(GuardSense)
--StillPatrol = Guard:Patrol(GuardRange, GuardSpeedWalking)
	--if(StillPatrol == false or IsSense == true) then
	--StillChasing = Guard:Chase("Player",GuardSpeedRunning)
	--if(Guard.Hit() == "Player") then
	--Player:TeleportTo(10,1,10)
	--end
	--else
	--Guard:Patrol (GuardRange, GuardSpeedWalking)
	GameObjectC.Log("UserFile Updating")
--end
end