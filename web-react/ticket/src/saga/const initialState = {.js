const initialState = {
callScriptList: [
{
create_by: "5f98f1b2f2d36a024423e5e3",
create_time: { $date: 1607612294867 },
description: "Base business solution",
last_modify_by: "5f98f1b2f2d36a024423e5e3",
last_modify_time: { $date: 1611582139358 },
callscript_name: "Basebs",
tenant_id: "5f98f1b2f2d36a024423e5dc",
_id: "5fac9d6c3b3dee80223a1fb8",
}
],
links: [
{ input: "port-1", output: "port-0", callscript_id: 'call-script-1' },
{ input: "port-2", output: "port-11", callscript_id: 'call-script-1' },
{ input: "port-3", output: "port-12", callscript_id: 'call-script-1' }
],
nodes: [
{
id: 'node-0',
callscript_id: 'call-script-1',
content: 'node-0',
coordinates: [100, 100],
inputs: [],
outputs: [{ id: 'port-0', label: 'Always' }],
},
{
id: 'node-1',
callscript_id: 'call-script-1',
content: 'node-1',
coordinates: [300, 100],
inputs: [{ id: 'port-1' }],
outputs: [{ id: 'port-11', label: 'Success' }, { id: 'port-12', label: 'Failure' }],
},
{
id: 'node-2',
callscript_id: 'call-script-1',
content: 'node-2',
coordinates: [500, 50],
inputs: [{ id: 'port-2' }],
outputs: [{ id: 'port-21', label: 'Success' }, { id: 'port-22', label: 'Failure' }],
},
{
id: 'node-3',
callscript_id: 'call-script-1',
content: 'node-3',
coordinates: [500, 300],
inputs: [{ id: 'port-3' }],
outputs: [{ id: 'port-31', label: 'Success' }, { id: 'port-32', label: 'Failure' }],
}
]
}