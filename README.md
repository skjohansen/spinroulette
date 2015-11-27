# SpinRoulette
SpinRoulette is a small webbased "russian" roulette, it consist of a webbackend written in .NET which exposes an API, and the API is consumed by a SPA (Single Page Application).

The game is developed with an API first approch. The first step have been to document the API using RAML.
Second step have been to build the backend (ASP.NET 5, on .NET core), and third step to build a simple frontend.

## Gameplay
The game is started by defining the size of the cylinder, and then the bullet is placed in a random spot in the cylinder. It then possible to pull the trigger untill the gun goes BANG, this will delete the game. If you are a chicken is it possible to reload the gun (restart the game).

## Backend
The game is developed using Visual Studio 2015, but it should be possible to also use Visual Studio Code to maintain it, and since it's running on .NET Core and ASP.NET 5, should it be possible to execute it on both Windows, Linux and MacOS.

The solution consists of two projects SpinLogic and SpinRoulette. SpinRoulette is the web project which implements the API structure and basic API behaviour. SpinLogic is the gamelogic, this is consumed by SpinRoulette and have no depencies to the API.

Testability have during development been a important focus. 

## Frontend

