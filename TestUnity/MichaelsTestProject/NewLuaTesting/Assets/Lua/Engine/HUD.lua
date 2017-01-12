HUD = {}

function HUD:Message (message, id)
	if(type (message) == "string" and type(id)=="number")then
		if(id == 0)then
			HUDC.SetMessage (message)
		else
			HUDC.SetHint(message)
		end
		
		return "Message Set"
	end
	return"Not A String"
end

function HUD:Score(Score)
------GameObjectC.Log("Coin Score Engine")
CurrentScore = HUDC:Score(Score)
return CurrentScore
end

return HUD
