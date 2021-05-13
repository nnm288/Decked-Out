# Decked-Out
SE Group Project by Herman Lin, Nicholas Mihelich, &amp; Andrew Qu 

Created using Unity v2020.3.3f1

## Goal
For this project, we are going to create an online simulator for card playing. Players will be able to freely manipulate a standard deck of playing cards to play any card game
that requires only a deck of cards.


## User Requirements
### UI
#### Implemented
1. Players can always see their Hand and the Table
1. Players can always see where the Deck is
1. Players can shuffle the deck
1. Players can reset the table
1. *Players can see the names and color of other Players around the Table and the back of their Hand*
1. *Players should be able to see other players cursors (color coded)* 
1. *Players should be able to invite other players somehow*

### Cards
There is one standard deck of cards called the Deck
1. The Deck contains Cards
   1. The Deck is always in one spot on the table
   1. The Deck can be shuffled
   1. The Deck can have Cards placed on the top
1. Cards can be made into Stacks
1. Cards and Stacks can be either face up or face down
   1. This can be in a Hand or on the Table
   1. *Contents of face up Stacks can be viewed by hovering the mouse over the Stack*
   1. *Individual Cards can be pulled from this Stack view window*

### Hands
1. Each Player has a hand of up to 52 Cards
1. A hand can contain Cards and Stacks face up or face down
   1. When a card is face up in a Hand everybody can see it.
   1. When a card is face down in a Hand, only that Player can see it
1. Players can pick up Cards, Stacks, Cards from Stacks, or Cards from the top of the Deck (if it is on the Table)
1. Stacks can be formed in a Hand
1. Cards or Stacks can be played onto the Table or handed to other Player's Hands

### Table
There is a neutral space called the Table.
1. The Table is a grid of spaces that can have Cards, Stacks, or the Deck on them
1. On the Table any player can flip, move, pick up, or place Cards, Stacks, or the Deck
1. When the Deck is on the table Players will be able to:
   1. Pick up a single Card or Stack from the top
   1. Place a single Card or Stack on the *bottom or* top
   1. Shuffle the deck *(Warning prompt when there are >52 cards in the Deck)*

##Actionable Requirements
What the user can do with the current build.
1. The user can draw cards from the deck
2. The user can flip cards
3. The user can shuffle the deck using the shuffle button
4. The user can reset the table with the reset button
5. The user can make stacks by dragging and dropping

## System Requirements

### Online play
The game will be run using a Unity WebGL build and eventually hosted by Amazaon Web Services. 
For now, the game will be hosted on localhost when Built and hosted by Microsoft Internet Information Services.
https://docs.unity3d.com/Manual/webgl-building.html

### Functional Requirmenets
1. System shall easily be able to connect a user to a game with friends (possibly using lobbies or host codes)
1. System shall be able to create multiple games (lobbies) at once with no problems
1. Sytem shall create a game described in User Requirements that is updated live across all connected users for seamless gameplay
1. System shall handle input and output for multiple devices all at once
1. System shall be able to handle multiple data structures for each game

### Non-Functional Requirments
1. Working internet connection
1. Working PC with Internet Browser
1. Mouse and Keyboard

## Developer Setup
We know that asking to install Unity is a lot, but until a working build is created and hosted,
it may be hard to share our work without doing so.

### Environment
1. Install Unity Version 2020.3.3f1
1. Install Unity WebGL Package
1. Clone the github repo
1. Add a new Unity Project in Unity Hub and select the folder of the cloned repo

### GitHub for Unity
We are using GitHub for Unity to work together.
1. Install GitHub for Unity
2. Window > GitHub > Settings
3. Login to GitHub account and add this repo URL
4. Unity wants you to commit changes to the repo. Instead of committing and pushing, go to the changes, select all, right click and discard changes.
6. Pull the repo to make sure everything is up to date

### Building and Running
#### Unity
1. Go to the Unity Build menu and select Build settings
2. Make sure you are Building a WebGL package
3. Select Build and Run
4. Unity will automatically open a localhost page on your preferred browser (Google Chrome recomended)

#### ISS
1. In Unity, go to Build Settings and select Build
2. Create a new folder or use an existing one to create a new build in
3. Install Microsoft Internet Information Services
4. Create a new website by selecting Add Website
5. Name the site decked out
6. Select the path to the index.html file in the build
7. Go to web.config and replace all the text from "Server configuration for compressed WebGL builds without decompression fallback (IIS)" at this link: https://docs.unity3d.com/Manual/webgl-server-configuration-code-samples.html

### Commands
`make prod`
Currently stages and commits all modified files, and then pushes to the main repo
(functionality also available within github for Unity)

`make dev_env`
Installs requirements for running game.
Currently there are no installations

`git clone`
Create a clone of the repository for personal use or for setting up github for unity

### Testing
The easiest way to test the game is to use the built in Unity game player. This creates a simulated version of the current build without having to 
actually build and run the program. 
Full testing on Web Browser is possible by creating a Build and Running it using Unity. The game will run on localhost:5XXXX 
