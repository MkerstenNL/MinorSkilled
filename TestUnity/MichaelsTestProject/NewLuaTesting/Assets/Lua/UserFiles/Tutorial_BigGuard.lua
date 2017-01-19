Range = 4
GuardSense = 6
SpeedRunning = 3
SpeedWalking = 1
inRange = false

function Start()
	Guard:Patrol (Range, SpeedWalking)
	Guard:Sense (SeePerson)
	GameObjectC.Log("BigGuard Initialized")
end

function Update ()

	inRange = Guard:CheckRangeTarget ("Player")
	if(inRange) then
	GameObjectC.Log("ZIT IN DE INRANGE")
		Guard:Chase ("Player", SpeedRunning)
	else
	GameObjectC.Log("NU IN DE ELSE")
		Guard:Patrol (Range, SpeedWalking)
		--GameObjectC.Log("Should Patrol")
	end


end