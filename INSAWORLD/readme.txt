%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%														 %
%						 README						     %
%														 %
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

----------------------------------
		Loading Playboard
----------------------------------

- Creation of the two players (with races but no coordinates fir the units)
- Creation of the game (choose which player starts)
- initialization of the game with its type
- fill the map with tiles
- give starting coordinates to the units 

----------------------------------
		  Game progress
----------------------------------

Each player can use 3 commands : 
	- AttackUnit
	- MoveUnit
	- NextTurn (pass turn to next player)

----------------------------------
			Save/Load
----------------------------------

Regular Save : 
	- SaveCommand : save a file in a folder named "Save" with the given name
	- LoadCommand : load a saved file
/!\ Save only the state of the game, not the steps (not replayable) /!\

Replay : 
	- SaveCommand : save a file in a folder named "Replay" with the given name
	- LoadCommand : load a saved file
/!\ Save all the steps (replayable) /!\