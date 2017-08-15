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

### Define Action/State relation table 
similar to the agent/action matrix, define a state/action matrix also starting from 0.
this can allow the environment to define valid actions on a state and define illegal moves as well. 
an illegal move is any action that is not defined at a state/action relation table or an agent/action table. 

### Environment has Interactive States
Define an environment as having one or more interactive states capable of:
1. Interacting directly with an action based on its own internal logic
1. Set next state 
1. deals with an Event object 

## State 
### Shift World Dynamics into State
move the World Dynamics object defining world behaviour based on actions on states inside a state instead of being a global matrix in an environment.
i.e. define a matrix inside the state that provide the trnsmission probability from current state to another state based on an action.
note that an action in this context is the internal action ID to the state. 
