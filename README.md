Thanks very much for your consideration! I'm going to put a general overview of the project in here. There are comments throughout the body of the actual code that explain my thinking as well.

My first thought about the structure of this project was that there would be two pages - one where you'd interact with the vending machine and one where you could view the statistics requested in the assignment prompt. I added the manage inventory page for ease manipulation of the candy data and to view the qty of each item in stock. I could have added all this functionality to the vending machine page, but I think it would have gotten too cluttered.

I have three classes - Candy, Shelf, and Wrapper. The candy class carries the name of the candy, the wrapper color, the price and the qty in stock. I could have gone about the qty property differently. The way I set it up, the shelf has max 4 candies. I could have made it so a shelf has four slots, and the slots have a candy, and I could have used the count of candies in a slot to keep track of the qty property. But, the way I have it works out and I don't have an intermediary class between shelf and cnady to just hold a list of candies, so I think it works out. It propbably makes data parsing easier too for the purposes of this project.

The shelf class hold the flavor property and it's up to the user to put the correct flavor of candy on the the right shelf. 

The conceptual "trash can" is just the data I have about wrappers. It's a separate data table with no relation to the other classes, but I set up the buy-candy method so that it will either create a new warpper with the color of the wrapper of the candy that was bought if none exists, or add 1 to the qty property of the wrapper with the corresponding color. For the report section, I just had to query the DB for the wrapper with the largest Qty.

Some of the functionality for the app is in the wwwroot/js folder. I used AJAX to load the pages. I don't have a ton of experience doing this. I'm sure my processes can be made more efficient.

I'm not super into styling and CSS (maybe obvious from the presentation of the app), but there's some rudimentary css in the wwwroot/css file. I'm actually kind of happy with how the vending machine looks! It's a little clunky, but it works.

If I were to start over, I'd have a Vending Machine Class that has shelves, a property that stores the deposited amount, and a trash can to store discarded candies. I'd have a slot class - the shelves would have four each. The slots would store candies and instead of a candy qty, I'd just take the count of candies in a given slot. No wrapper class, just keep track of discarded candies in the trash can.

