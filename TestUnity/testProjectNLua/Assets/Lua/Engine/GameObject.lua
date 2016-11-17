--TransformComponent = this:AddCompoment("Transform")
--Assert(TransformComponent!=nil)
--AttachedComponents{}
--CsharpFile = nil
Transform = nil
local parent = nil
function Init(pparent)
	parent = pparent
end


--Gets Called From Engine on start of script
function Start()
cSharp:Log("test")
--start call

end

--gets called once per fram
function Update()
	if(parent == nil) then
		cSharp:Log("parent not initialized")
	end

	parent:Update()

end

--Gets Called when it hits a trigger
function OntriggerEnter(OtherName)

	parent:OntriggerEnter(OtherName)
end