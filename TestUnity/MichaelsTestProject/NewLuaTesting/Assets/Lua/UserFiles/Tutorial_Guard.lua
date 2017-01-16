GuardRange = 30
GuardSense = 3
GuardSpeedRunning = 2
GuardSpeedWalking = 1
inRange = false

function Start()
	Guard:Patrol (GuardRange, GuardSpeedWalking)
	Guard:Sense (GuardSense)
	--GameObjectC.Log("Guard Initialized")
end

function Update ()
	
	inRange = Guard:CheckRangeTarget ("Player")
	--GameObjectC.Log ("Userfile updating")
	if(inRange) then
		Guard:Chase ("Player", GuardSpeedRunning)
	--GameObjectC.Log("Should chase")
	else
		Guard:Patrol (GuardRange, GuardSpeedWalking)
		--GameObjectC.Log("Should Patrol")
	end


end