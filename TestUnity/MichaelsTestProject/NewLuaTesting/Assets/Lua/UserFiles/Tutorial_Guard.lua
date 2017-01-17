Range = 5
SeePerson = 10
SpeedRunning = 1
SpeedWalking = 0.5
inRange = false

function Start()
	Guard:Patrol (Range, SpeedWalking)
	Guard:Sense (SeePerson)
	--GameObjectC.Log("Guard Initialized")
end

function Update ()
	
	inRange = Guard:CheckRangeTarget ("Player")
	--GameObjectC.Log ("Userfile updating")
	if(inRange) then
		Guard:Chase ("Player", SpeedRunning)
	--GameObjectC.Log("Should chase")
	else
		Guard:Patrol (Range, SpeedWalking)
		--GameObjectC.Log("Should Patrol")
	end


end