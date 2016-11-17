--TransformComponent = this:AddCompoment("Transform")
--Assert(TransformComponent!=nil)
--AttachedComponents{}
--CsharpFile = nil
Name = nil

--Gets Called From Engine on start of script
function Start()
	cSharp:Log (Name)

--start call

end

--gets called once per fram
function Update()
--object logic
end

function OntriggerEnter()
--Gets Called when it hits a trigger
end