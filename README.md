# SpinRoulette
SpinRoulette is a small webbased "russian" roulette, it consist of a webbackend written in .NET which exposes an API, and the API is consumed by a SPA (Single Page Application).

The game is developed with an API first approch. The first step have been to document the API using RAML.
Second step have been to build the backend (ASP.NET 5, on .NET core), and third step to build a simple frontend.

## Gameplay
The game is started by defining the size of the cylinder, and then the bullet is placed in a random spot in the cylinder. It then possible to pull the trigger untill the gun goes BANG, this will delete the game. If you are a chicken is it possible to reload the gun (restart the game).

## Running the application
Download the source (either as a ZIP file or use Git), open the backend project in Visual Studio and run the project, this should fireup a webserver on localhost port 50712.

To use the frontend simply open the SPA/game.html in a webbrowser, in the code is a variable called rouletteApiUrl, which contains the endpoint for the API, modifi this if the server should start on another port.

## Backend
The game is developed using Visual Studio 2015, but it should be possible to also use Visual Studio Code to maintain it, and since it's running on .NET Core and ASP.NET 5, should it be possible to execute it on both Windows, Linux and MacOS.

The solution consists of two projects SpinLogic and SpinRoulette. SpinRoulette is the web project which implements the API structure and basic API behaviour. SpinLogic is the gamelogic, this is consumed by SpinRoulette and have no depencies to the API.

Testability have during development been a important focus. And currently a few unittest of the API controller are implemented using the xUnit-framework, mainly for proof of concept.

## Frontend
The frontend is developed as a Single Page Application, and everything is hosted in the SPA/game.html.

The logic in the SPA is jQuery, HTML and embedded CSS. It makes request to the Backend API.
