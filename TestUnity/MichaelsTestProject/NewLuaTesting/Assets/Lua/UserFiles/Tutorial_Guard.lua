Range = 5
SeePerson = 10
SpeedRunning = 5
SpeedWalking = 2.5
inRange = false

function Start()
	Guard:Patrol (Range, SpeedWalking)
	Guard:Sense (SeePerson)
	--GameObjectC.Log("Guard Initialized")
end

function Update ()
	inRange= false
	inRange = Guard:CheckRangeTarget ("Player")
	if(inRange) then
		Guard:Chase ("Player", SpeedRunning)
	--GameObjectC.Log("Should chase")
	else
		Guard:Patrol (Range, SpeedWalking)
		--GameObjectC.Log("Should Patrol")
	end


end