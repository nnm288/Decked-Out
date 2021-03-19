# Decked-Out
SE Group Project by Herman Lin, Nicholas Mihelich, &amp; Andrew Qu

## Goal
For this project, we are going to create an online simulator for card playing. Players will be able to freely manipulate a standard deck of playing cards to play all of the card games that a standard deck of cards can be used for.


## Requirements

### Online play
Game can be run on the web somehow. We are thinking about a Unity WebGL, but are still unsure about what to use.

### UI

1. Players can always see their Hand and the Table
1. Players can always see where the Deck is and/or who the Dealer is
1. Players can see the names and color of other Players around the Table and the back of their Hand
1. Players should be able to see other players cursors (color coded) 
1. Players should be able to invite other players somehow

### Cards
There is one standard deck of cards called the Deck
   1. The Deck contains Cards
     1. The Deck is always faced down
     1. The Deck can be shuffled
     1. The Deck can have Cards or Stacks placed on the bottom or the top
     1. Either one Player has the Deck and deals to other Players or the Deck is on the Table
   1. Cards can be made into Stacks
   1. Cards and Stacks can be either face up or face down
     1. This can be in a Hand or on the Table
     1. Contents of face up Stacks can be viewed by hovering the mouse over the Stack
     1. Individual Cards can be pulled from this Stack view window

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
   1. Place a single Card or Stack on the bottom or top
   1. Shuffle the deck (Warning prompt when there are >52 cards in the Deck)
