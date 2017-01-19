Range = 4
SeePerson = 15
SpeedRunning = 8
SpeedWalking = 1
inRange = false

function Start()
	Guard:Patrol (Range, SpeedWalking)
	Guard:Sense (SeePerson)
end

function Update ()

	inRange = Guard:CheckRangeTarget ("Player")
	if(inRange) then
		Guard:Evade ("Player", SpeedRunning)
	else
		Guard:Patrol (Range, SpeedWalking)
	end
end	