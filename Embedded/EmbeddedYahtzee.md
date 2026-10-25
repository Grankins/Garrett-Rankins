## Arduino-Based Yahtzee Game System | Embedded C++, Arduino, LCD, Keypad

[View Project Documentation](https://docs.google.com/document/d/1Qxlvhn-VIuihZKwssFtwqC-rDDw4KS7c1QwSv_uIMF8/edit?usp=sharing)

This project was for a Microprocessor class in College

-Developed an interactive Yahtzee game using embedded C++ on an Arduino microcontroller.
-Integrated a keypad and LCD screen to support player input, game interaction, and score display.
-Implemented game logic and scoring functionality to replicate the core Yahtzee experience.

Key Functions

This project uses the keypad as an input and the LCD screen as an output. 
When the code is started, the program will first ask for the number of players. 
Using keypad numbers “2-4”, you can select that number of players for the game. 
Afterwards, the game starts with player 1’s turn, and the first roll is automatically done. 
After a roll is made, several options are available:

You can use the numbered keys “1-5” to choose what dice to keep.
You can use the “*” key to reroll (up to three per turn).
You can use the “#” key to score the dice.

During scoring, different inputs on the keypad correspond to different scoring slots. 
The scores are automatically added up and stored for each player to be displayed at the end of the game for all to see. 

The “1-6” keys do number score slots.
The “7” and “8” keys are for three and four of a kind respectively.
The “9” key is a full house (three of a kind with a pair). 
“A” and “B” are the small and large straights respectively.
“C” is for the coveted “Yahtzee” worth 50 points.
“D” is to use your chance to add up your numbered rolls for that turn. 

Each score slot can only be filled once and the game ends when all slots have been filled.
