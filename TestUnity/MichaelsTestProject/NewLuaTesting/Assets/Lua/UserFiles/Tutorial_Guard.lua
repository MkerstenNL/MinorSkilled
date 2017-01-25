Range = 5
SeePerson = 10
SpeedRunning = 5
SpeedWalking = 2.5
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