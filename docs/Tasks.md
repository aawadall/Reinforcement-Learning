# Tasks to To Do
## Documentation
### Create Class Design Document 
## Build 
### Define a container
Define a container to run this application on a CI

## Agent Related 
## Environment Related
### Create a Facade for Agents
Agents are to interact with current environment through a facade object to simplify the process and not care about the exact action ID it uses 

### Define Action/Agent relation table
Implement an Action/Agent relation table such that agents has an ordered list of actions (starting from 0) and are directly mapped to their internal policy
while the internal action ID of an agent might have the same behaviour for a differerent action ID of another agent. 
