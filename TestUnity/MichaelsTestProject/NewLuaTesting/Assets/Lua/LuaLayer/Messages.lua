function OnHit (Hit)
	if(Hit == "StartTrigger") then
	M.Message("Why do you need to be in the holding cell. You did nothing, they tricked you. Let's try to escape the door looks unguarded. Maybe you can open it.",0)
	end
	if(Hit == "Door") then
	M.Message("Hint - Door opens on command. Use the field on the left to program. Try typing Door:Interact() to open the door.",1)
	end
	if(Hit == "triggerWalkedThroughDoorLevel1") then
	M.Message("Good Job. You used the function interact for the door object.",0)
	end
	if(Hit == "triggerSeeCoin") then
	M.Message("Is that a coin? Free money! Let's pick it up. You can use as much as possible if you want to survive outside.",0)
	end
	if(Hit == "TriggerLevel1Coin") then
	M.Message("Hint - To pickup we can use the same function Coin.Interact(). Use the same field to program",1)
	end
	if(Hit == "TriggerPickedUpCoin") then
	M.Message("Nice you have some money now and again you used the same function but for another object that does something else. Let's continue.",0)
	end
	if(Hit == "triggerWaterLevel3") then
	M.Message("The boat is coming our way. Someone is trying to help you.",0)
	end
	if(Hit == "Boat") then
	M.Message("Hint - Move the boat forward with a speed of 10. Boat:Move('Forward',10)",1)
	end
	if(Hit == "triggerWaterBoatEndLevel3") then
	M.Message("We are on the other side, We moved the boat using speed.",0)
	end
	-- if(Hit == "triggerLevel4") then
	-- M.Message("Did you see that? I think I saw a coin on the way here. That's unfair you weren't able to get there. Maybe you can use other directions, but how to get back? You can continue if you want to.",1)
	-- end
	-- if(Hit == "TriggerLevel4Coin") then
	-- M.Message("So you went for the coin and used the more directions. But how to get back. Try more then just one line of code. To go faster.",1)
	-- end
	-- if(Hit == "triggerLevelCoinEnd4") then
	-- M.Message("You were able to get back. You used 2 lines of code. Now you know that there is more than only one line. Don't forget the choice that you made! Some functions gives you also a choice. Instead of direction you gave an object.",1)
	-- end
	if(Hit == "TriggerDirtySign") then
	M.Message("There is a messageboard. Maybe we there is a hint how to get pass the guards?",0)
	end
	if(Hit == "TriggerMessage") then
	M.Message("Hint - The sign is dirt and wouldn't show the text. ",1)
	end
	--triggered after sign completed
	if(Hit == "TriggerMessageComplete") then
	M.Message("You did it! You changed a variable to change the if statement. Now there is more if and variables.",1)
	end
	if(Hit == "BeforeGuardTrigger") then
	M.Message("I hope you read the sign. There might be a usefull hint.",1)
	end
	
	--Triggered when guard caught you.
	if(Hit == "Guard") then
	M.Message("Well they found you. Wouldn't it be fun if they run away instead? Evade you instead of Chase you.",1)
	end
	if(Hit == "BigGuard") then
	M.Message("Well they found you. Wouldn't it be fun if they run away instead? Evade you instead of Chase you.",1)
	end
	--Not perfect explained
	if(Hit == "BigGuardTrigger") then
	M.Message("Wow he is big!. Let's see what changed. Not everything is changed when facing another guard and what are Update en Start doing? Start can be used set things that are needed once. Update is called every time. That means that if you add 1 to speed. It will go faster every time.",1)
	end
	if(Hit == "FenceTrigger") then
	M.Message("Freedom is on the other side of the fence!",1)
	end
	if(Hit == "FenceHitTrigger") then
	M.Message("The fence it to high to climb over and no door to open. Why can't you open the script editor to change the fence? Try walking along the fence for a weak spot.",1)
	end
	if(Hit == "FenceHitScriptTrigger") then
	M.Message("You found the weak spot. real life can be a bitch sometimes, Luckily this is a game. Why not trying to get through? TurnOnCollider(TrueOrFalse)?",1)
	end
	if(Hit == "FreedomTrigger") then
	M.Message("YOU DID IT! You passed an object even though it's still there. That is called a collider that wouldn't let you pass. Now that you said that it was not a collider you were able to get through. Now get out fast! Get to the road",1)
	end
	if(Hit == "CreateObjectTrigger") then
	M.Message("Now we need a car to escape quickly. I have a car available for you. It is only not created! CreateObject('car',x,y,z) X,Y,Z is the position in the world. But I already did that for you.",1)
	end
	if(Hit == "InteractCarTrigger") then
	M.Message("You should be able to do this now!",1)
	end
	if(Hit == "EndAlphaGame") then
	M.Message("Congratz! You have finished the Alpha. We changed a lot but hoped that you learned anything. Might be not much, but if you liked? Try real programming.",1	)
	end
	
	if(Hit == "TriggerLevel2Coin") then
	M.Message("Pick up the coin you need how to do it.",1)
	end
	if(Hit == "TriggerLevel3Coin") then
	M.Message("You're still reading this? Expect to something to change?",1)
	end
	if(Hit == "TriggerLevel5Coin") then
	M.Message("Collecting coins I see and still thinks that I have another hint for you.",1)
	end
	if(Hit == "TriggerLevel6Coin") then
	M.Message("Almost free and still reading this. No more tips anymore for the coins. You know what to do.",1)
	end
end