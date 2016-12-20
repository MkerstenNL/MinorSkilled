HUD = {}

function HUD:Message (message)
	if(type (message) == "string")then
		HUDC.SetMessage(message)
		return "Message Set"
	end
	return"Not A String"
end

return HUD
