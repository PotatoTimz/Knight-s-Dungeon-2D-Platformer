# Instructions

## How to Set up a Level With TileMaps
* To create TileMaps, first find a image online which contains the tiles that you wanted to use for the levels then import it into Unity.
* After importing it into Unity, edit the Sprite Mode into multiple to allow the slicing of the image into multiple smaller parts then press apply.
* After pressing, apply a Sprite Editor tab can be found near the Scene tab which will let you slice the image into smaller parts so that you can use those smaller parts to customize your level.
* After slicing, go to the Tile Palette and create your own tile palette which will store the sliced parts into to be used as later on.
* After creating a Tile Palette, you can then make a gameObject in the scene and add 'Grid' into the components.
* After adding 'Grid', you can then create children GameObjects for it to fit the purposes you want to use it on such as 'Background' , 'Platform' or other uses.
* Once finished, click on the desired child GameObject you want to paint on then on the Tile Palette tab click on the brush and desired tile you want on the screen then you can paint your own level. (Be mindful on which child GameObject you are painting on!)
* Once finished, if you want the tiles to be interactable you can then add 'Tilemap Collider 2D' and 'Rigidbody 2D' through the Unity Inspector and adjust those accordingly.

## How to Set a Background Image For Your Game
* Make sure the image you want to use as a background is ready. It should be in a format Unity accepts like PNG or JPG. Keep your game's theme in mind when choosing your image!
* In Unity, go to the "Assets" folder in the Project window.
* Right-click inside the Assets folder and select 'Import New Asset'.
* Find your image file, select it, and click 'Import'.
* Unity treats images as 'Textures'. To use your image as a background, you need to convert it into a 'Sprite'.
    * Click on your imported image in the Assets folder. 
    * In the Inspector window (on the right side), find the 'Texture Type' dropdown and change it from 'Texture' to 'Sprite (2D and UI)'.
    * Click 'Apply.'
* Drag and drop your new sprite from the Assets folder onto your scene or the hierarchy window.
* You'll see your image appear in the game scene. But it might be too big or too small!
    * With your sprite selected in the scene, you can adjust its size.
    * In the Inspector window, find the Transform component.
    * Use the 'Scale' fields (X and Y) to adjust the size of your sprite to fit the scene as you like. You might need to experiment with these values to get it just right.
* Still in the 'Transform' component, use the 'Position' fields (X, Y, and maybe Z) to place your background exactly where you want it in the scene.
* Look at your game scene and make any final adjustments to the background's scale and position to make sure it's perfect for your level.

## How to Make a Player Object
* To make a Player Object, first import the desired sprite you plan to use as the player object.
* After importing the sprite into Unity, you can then left click on the imported sprite to adjust its settings in the Inspector Mode, which in this case the Sprite Mode should be set into multiple since there are multiple smaller sprites in the image which will be used later on then after finishing the changes in the inspector you can then press apply.
* After applying the changes, there should be a separate tab near the scene tab in Unity that says Sprite Editor, in the editor you are then supposed to slice the image you imported into smaller sprites to be used individually then press apply.
* After slicing the image into smaller sprites, you can then drag one of the smaller sprites into the Scene or in the hierarchy and this will put the sprite into the scene where you can then add animations or behaviors it needs for the game.

## How to Make the Camera Follow The Player (Sidescroller)
* Create a C# script. Then, attach the script to the Camera.
* Public Variables: 
    * playerTransform: A public variable where you assign the player's Transform component. This lets the camera know which object to follow.
    * offset: A public Vector3 variable that allows you to set the camera's position relative to the player. This is useful for keeping the camera at a consistent distance from the player, like above or behind.
* LateUpdate Method:
    * The LateUpdate() method is called once per frame, after all Update() methods have been called. This timing ensures that the player has moved for the current frame before the camera updates its position.
    * Inside LateUpdate(), the camera's position is set to the player's position plus the offset. This means the camera will follow the player's movement while maintaining the specified distance set in the offset.
* Essentially, this script keeps the camera focused on the player by updating the camera's position to the player's position with an added offset every frame.

## How to Animate the Player
* To animate the Player, first click on the player through the hierarchy and add an animator to the player this can be done through multiple ways but adding it through the Unity Inspector is one way then name the animator accordingly.
* After adding the animator, double click on the animator which will open an animator tab where the animation transitions will take place.
* To add the animations to the animator tab, you can click on the Window tab on the upper left corner of the screen which is on the same level where 'File' and 'Edit' can be found, where a choice 'Animations' can be found which should be clicked.
* Once clicked, an 'Animations' tab will open up and this is where the animations can be done.
* To create animations, click 'Create' and name what the animation is accordingly.
* Once created, you can then drag the sprites you sliced earlier into the animator and when played will show the sprite doing that action as an animation.
* After creating the animations, go back to the 'Animator' tab and you can then drag the animations or create a 'Blend Tree' which you can then assign the different animations that you just have made.
* Once finished, you can then right click on the options and click 'Make Transition' to allow the animations to transition from one animation to another depending on the action the player currently is doing.

## How to Make an Enemy Object
* To make an Enemy Object, first you have to import the sprite you are planning to use as the enemy object
* After importing the enemy sprite into Unity, left click the sprite that you just imported into Unity then set the Sprite Mode into the desired mode, which in this case is multiple since there are multiple sprites in a single image then press apply.
* After applying the changes, there should be a separate window just beside the scene tab in Unity that says Sprite Editor in the editor you are then supposed to slice the image into smaller portions which will then be used as assets for the scene.
* After slicing the image into smaller sprites, you can then drag one image into the Scene window or just under your Scene in the hierarchy doing this will put the desired sprite into the scene where you can then add scripts or behaviors that would be used for the game.

## How to Animate a GameObject
* To animate a GameObject, first you select the desired GameObject that you want to add an animation on, followed by adding an animator to it this can be then through multiple ways but one way is to add it through the Unity inspector and name it to the desired name which in this case is usually GameObjectNameController.
* After adding the animator, you can then double click the animator which will open an animator tab, this is the location where animation transitions will occur such as on certain movements certain animations will play.
* To add animations to the animator tab, you can click on the Window tab on the upper left corner of the screen on the same level where 'File' and 'Edit' can be found where a certain choice named 'Animations' need to be clicked.
* Once clicked, a 'Animations' tab will open and this is where animations can be done.
* To assign animations, click create then name it accordingly.
* Once named you can then drag multiple sprites, on each second to showcase the transition of one sprite to another to make the animations.
* Once finish making the animations go back to the 'Animator' window then you can drag the animations into the 'Animator' window or make a 'Blend Tree' that contains the animation (whichever is more comfortable for the user).
* Once finishing those you can then right click on each one which will reveal some options the user could do and the 'Make Transition' should be used here to allow the animations to transition from one to another depending on what the GameObject is currently using.

## How to Create a Win/Lose State
* First, we need to create the screen itself. In Unity, this will be a new UI (User Interface) element.
* Go to the Unity Editor and click on 'GameObject' in the menu. Hover over 'UI' and select 'Canvas'. This creates a new canvas in your scene, which is like an invisible layer for UI elements.
* With the Canvas selected, go back to 'GameObject' > 'UI' and choose 'Panel'. This panel will serve as the background for your win/lose state message. It will automatically become a child of the Canvas.
* In the Inspector window (on the right), you can change the Panel's color and transparency to fit the theme of your game.
* With the 'Panel' selected, add a text element by going to 'GameObject' > 'UI' and selecting 'Text - TextMeshPro'. This will create a text element as a child of the Panel.
* In the Inspector window, change the Text component's text to "Game Over" or "You Win!" depending on what you choose to do first. You can also adjust the font, size, color, and alignment to make it look great!
* To make the Lose State screen appear when the game is over, we'll need to write a little bit of code.
     * Right-click in the Assets folder, select 'Create' > 'C# Script'. Name it something like "GameOver" or whatever pertains to what you're making.
     * In your script, you'll need a way to refer to the Lose State panel. You'll do this by creating a variable that can hold a reference to the panel. This allows your script to show or hide the panel when needed.
     * To hide the screen, click on the 'Panel' and in the Inspector menu, uncheck the box next to its name.
     * For a 'lose state' ensure that you reference the 'Player' script, with its health. When the Player's HP is zero, trigger the Game Over screen.
         * Reference our script files for example.
* The core part of your Win State script will involve detecting when the player character collides with the trigger object. Unity has specific functions (such as OnTriggerEnter2D(Collider2D other)) that are called when one object enters the space of another object. You'll use one of these functions to check for collisions between your player and the trigger object.
     * Once you detect a collision between the player and the trigger object, you'll want to display the Win State screen.
     * Attach your script to the object that should trigger the Win State screen. This way, when the player touches or collides with this object, the script will run the logic you've written to show the Win State screen.

## How to Show a Counter of Collected Objects on the UI
For this game, we used coins to represent collected objects.
* Inside the Canvas, create a Text element for displaying the coin count. Go to 'GameObject' > 'UI' > 'Text - TextMeshPro'. This creates a 'Text' GameObject where your coin count will be displayed. You might name it "CoinCounterText".
    * Create two of these, one that represents the UI element for representing coins ("Coins: "), and the other anything you would like ("0" for example). This second text element will be used to show the counter.
* Create a script for Coin Collection. Right-click in the Assets folder and choose 'Create' > 'C# Script'. Name it "CoinCollector" or something similar. 
    * In your script, you'll need a few key pieces of information. First, a variable to keep track of the number of coins collected. Second, a reference to the Text UI element that displays the coin count.
    * You'll write a function that increases the coin count by one each time a coin is collected.
    * After increasing the coin count, the script should update the Text UI element to show the new count. This involves changing the text to reflect the current number of coins collected.
    * To detect when a coin is collected, you might use collision detection with triggers. When the player character collides with a coin, the coin calls the function to increase the count and then destroys itself.
* To assign the script, drag and drop the CoinCollector script onto a GameObject in your scene. This could be the player character or another manager object.
* In the Inspector for the GameObject with your script, you'll see a field to assign the Text UI element. Drag the CoinCounterText from the hierarchy into this field.
* If you haven't already, create a coin object in your game. It should have a Collider component set to "Is Trigger" to use trigger detection.
* You might create a simple script for the coin that detects when the player collides with it and then calls the function in the CoinCollector script to increase the count. After calling this function, the coin would destroy itself, disappearing from the game.

 ## How to Show the Player's HP on the UI
 * Within the Canvas, create a 'Slider' element for the HP display. Go to 'GameObject' > 'UI' > 'Slider'. This creates a 'Slider' GameObject, which will serve as the HP bar.
 * Select the Slider element you just created. In the Inspector window, you can customize its appearance. Adjust the Min Value to 0 and the Max Value to the maximum HP of the player. You can also customize the color of the fill to match the look you want for HP (in this exmaple, we used Red).
 * In your Player script, set up the following:
     * First, add a reference to the UI Slider component. This allows the script to adjust the Slider based on the player's current HP. You'll also need a variable to keep track of the player's current HP.
     * In the start function of your script, set the player's current HP to the maximum value. Also, make sure the Slider's value matches this initial HP.
     * Create a function to decrease the player's HP when they take damage. This function should subtract from the current HP and then update the Slider's value to reflect this new HP level.
     * Whenever the player's HP changes (like taking damage or healing), update the Slider's value to match the player's current HP. This keeps the visual display accurate.
* If you haven't attached the Player script to the Player Object already, do so.
* Link the slider to the script. In the inspector for the player character, you should see a field from your Player script waiting for a Slider component. Drag the slider you created from the hiearchy into this field to establish the connection.
* Within your script, whenever the player's HP changes (like after taking damage or receiving healing), you'll adjust the Slider's value property to match the player's current HP. This ensures that the Slider visually represents the current state of the player's health accurately.
