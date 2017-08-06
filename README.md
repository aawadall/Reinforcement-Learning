[![BCH compliance](https://bettercodehub.com/edge/badge/aawadall/Reinforcement-Learning?branch=master)](https://bettercodehub.com/)
# _This repo is still new and it is poorly documented_

# Reinforcememnt Learning Library
Reinforcement Learning Experiments 
In this project, I am attempting to build a set of RL classes to pave the way to build a multi-agent simulator 

# Design
There are Eight classes defined in this system (so far)
## Action 
Is a hollow class that is used to simulate an action agent applied to an environment.
so far it has nothing useful except for its ID, which can be replaced by a simple integer
I am thinking of adding extra features to this class 

## Agent
main player in this simulator, using a policy it learns by time, it interacts with the environment using possible actions, and recieves a signal with current state, previous state, reward, and action applied

## Environment 
container of the entire simulator. 
Each environemnt is made of:
* One World Dynamics object 
* a set of agents
* a set of states 
* a set of actions 

## Policy
Each agent has one policy defined.
A policy will have:
* a state action pair value
* a state value
* a parameters object containing important parameters used by the policy
policies can learn and act based on optimal values

## Signal
a signal is a collection of objects used to declare the result of an action applied on the environment.
it contains:
* State after action
* PRevious state before action
* Reward signal
* Action used to make this change 

## State
A hollow class, similar to action.
this is used to represent a state.

## World Dynamics 
This is the main simulator 
