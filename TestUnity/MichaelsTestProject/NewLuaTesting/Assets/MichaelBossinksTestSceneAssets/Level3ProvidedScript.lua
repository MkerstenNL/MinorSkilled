--There are 6 turrets. But only 5 are in the list. One needs to be activated manually
amountOfPoeple = 1--insert number
dataOfPeopleCollected = false
turretActiveList = {Turret1 = false,Turret2 = false,Turret3 = false,Turret4 = false,Turret5 = false}
amountOfTurretsActive = 0

function Start()
end

function Update()
  if(amountOfPoeple > 10) then --insert number) then
  CollectData()
  else 
  Message('Wrong!')
  end
for i, Value in pairs( turretActiveList ) do
  if(turretActiveList[i] == false) then
  turretActiveList[i] = true
  amountOfTurretsActive = amountOfTurretsActive + 1
  end
  if (amountOfTurretsActive == 6) then
  OpenDoor()

  else
  ClosedDoor()
  end
end
end