Range = 5
SeePerson = 10
SpeedRunning = 1
SpeedWalking = 0.5
inRange = false

function Start()
	Guard:Patrol (Range, SpeedWalking)
	Guard:Sense (SeePerson)
end

function Update ()
	inRange = Guard:CheckRangeTarget ("Player")
	if(inRange) then
		Guard:Chase ("Player", SpeedRunning)
	else
		Guard:Patrol (Range, SpeedWalking)
	end
end
