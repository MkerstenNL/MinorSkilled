----1 hint
----0 message
-- Hit = ""

-- function Update()
-- Hit = "triggerWalkedThroughDoorLevel1	"--RigidBody:LastHit()
-- OnHit()
-- end
function OnHit (Hit)
	if(Hit == "StartTrigger") then
	M.Message("Try to escape the prison the door looks unguarded",0)
	end
	if(Hit == "Door") then
	M.Message("Try opening the door by typing Door:Interactive()",1)
	end
	if(Hit == "triggerWalkedThroughDoorLevel1") then
	M.Message("Good Job. You used a function for an object. Is that a coin? Free money! Let's pick it up.",0)
	end
	if(Hit == "TriggerLevel1Coin") then
	M.Message("Tip:Coin.Interactive()",1)
	end
	if(Hit == "TriggerPickedUpCoin") then
	M.Message("Nice you have some money now and again you used the same function but for another object that does something else. Let's continue.",0)
	end
	if(Hit == "triggerWaterLevel3") then
	M.Message("The boat is coming our way. Someone is trying to help you. How does the boat operate?",0)
	end
	if(Hit == "Boat") then
	M.Message("Hee, someone programmed the boat that is was going in your direction. Now you need to go the opposite direction.",1)
	end
	if(Hit == "triggerWaterBoatEndLevel3") then
	M.Message("Using a function with parameters. Nice! but what did the text and number show you? The text was the direction and the number the amount in meters.",0)
	end
	if(Hit == "triggerLevel4") then
	M.Message("Did you see that? I think I saw a coin on the way here. That's unfair you weren't able to get there. Maybe you can go Toward the Coin, but how to get back? You can continue if you want to.",0)
	end
	if(Hit == "TriggerLevel4Coin") then
	M.Message("So you went for the coin and used the gameobject. But how to get back. If there is forward and backwards. Maybe there is also right and left. Try more then just one line of code.",1)
	end
	if(Hit == "triggerLevelCoinEnd4") then
	M.Message("You were able to get back. You used 2 lines of code. Now you know that there is more than only one line. Don't forget the choice that you made! Some functions gives you also a choice. Instead of direction you gave an object.",0)
	end
	if(Hit == "triggerLevelCoinEnd4") then
	M.Message("You were able to get back. You used 2 lines of code. Now you know that there is more than only one line. Don't forget the choice that you made! Some functions gives you also a choice. Instead of direction you gave an object.",0)
	end
	if(Hit == "TriggerDirtySign") then
	M.Message("There is a dirty sign what does it say?",0)
	end
	if(Hit == "TriggerMessage") then
	M.Message("It looks like a that if the sign is dirty it wouldn't show the text.",1)
	end
	--triggered after sign completed
	if(Hit == "TriggerMessageComplete") then
	M.Message("You did it! You changed a variable to change the if. Now there is more if and variables.",1)
	end
	
	if(Hit == "BeforeGuardTrigger") then
	M.Message("I hope you read the sign. There might me a usefull tip.",0)
	end
	
	--Triggered when guard caught you.
	if(Hit == "HitByGuard") then
	M.Message("Well they found you. Now we can say that the guards don't have to chase you.",1)
	end
	
	if(Hit == "BigGuardTrigger") then
	M.Message("Wow he is big!. Let's see what changed. Not everything is changed when facing another guard.",0)
	end
	if(Hit == "FenceTrigger") then
	M.Message("Freedom is on the other side of the fence!",0)
	end
	if(Hit == "FenceHitTrigger") then
	M.Message("The fence it to high to climb over and no door to open. Why can't you open the script editor to change the fence? Try walking along the fence for a weak spot.",0)
	end
	if(Hit == "FenceHitScriptTrigger") then
	M.Message("You found the weak spot. Colliders are a bitch sometimes, but without it we should have fallen of the boat. Why not trying to Turn off the collider for the fence? TurnOnCollider(TrueOrFalse)?",1)
	end
	if(Hit == "FreedomTrigger") then
	M.Message("YOU DID IT! Now get out fast! Get to the road",0)
	end
	
	if(Hit == "CreateObjectTrigger") then
	M.Message("Now we need a car to escape quickly. I have a car available for you. It is only not created! CreateObject('car')",1)
	end
	if(Hit == "InteractCarTrigger") then
	M.Message("You should be able to do this now!",1)
	end
	
	if(Hit == "EndAlphaGame") then
	M.Message("Congratz! You have finished the Alpha. We changed a lot but hoped that you learned anything. Might be not much, but if you liked? Try real programming. P.S. The person that was helping you was me and I am you!",0)
	end
	
	
end

