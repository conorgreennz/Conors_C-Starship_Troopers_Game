using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace DiveBomb
{
    public partial class Form1 : Form
    {
        Random RandomNumber;  // create a new random number generator
        Bitmap OGShipImage; // create a new variable as the orignal ship image incase ship image is damaged during rotation
        Bitmap ShipImage; // create a new variable as the ship image 
        Ship myShip; // create new variable called my ship
        Bitmap OGBirdImage; // create a new vairable called original bird image incase bird image gets damaged during rotation
        Bitmap OGBulletImage; // create a new variable called original bullet image incse bullet image gets damaged during rotation
        List<Bird> birdList; // create a new list variable called birdlist ( this is to hold the many birds used on the form)
        List<Bullet> bulletList; // create a new list for the bullets on the game panel and call it bullet list
        

        int BirdSpeed;

        int Points, lives;

        const int maxBirds = 3;

        public Form1()
        {
            InitializeComponent();
            // secondary image provides as a base for the computer to reference as the image rotates in a pixelated format 

            OGShipImage = GetResourceImageByName("Ship"); //collect and load the ship image.
            // Transparent example googled from http://csharphelper.com/blog/2017/01/give-an-image-a-transparent-background-in-c/
            OGShipImage.MakeTransparent(Color.Black);
            OGBirdImage = GetResourceImageByName("Bird"); // collect and load the bird image
            OGBirdImage.MakeTransparent(Color.Black);
            OGBulletImage = GetResourceImageByName("Bullet"); //collect and load the bullet image
            OGBulletImage.MakeTransparent(Color.Black);

            // create the ship and set variables
            myShip = new Ship();
            myShip.X = 50;
            myShip.Y = 140;
            myShip.Angle = 0;
            ShipImage = RotateImage(OGShipImage, myShip.Angle); // rotate the image to the required angle, using the og image as a reference guide 

            // make the bird list
            birdList = new List<Bird>();

            // make the bullet list
            bulletList = new List<Bullet>();

            // create the bird and set its position variables
            RandomNumber = new Random(); // set random bird angle as a new random function to be set on its spawn rotations

            // draw it on the screen
            UpdatePositionLabel();
            //
            //pictureBox1.Focus();

            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\rolem_-_Neoishiki.wav";
            player.Play();
        }

        public Bitmap GetResourceImageByName(string imageName) // collect the resource image, found by name. 
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string resourceName = asm.GetName().Name + ".Properties.Resources";
            var rm = new System.Resources.ResourceManager(resourceName, asm);
            return (Bitmap)rm.GetObject(imageName);
        }
        private Bitmap RotateImage(Bitmap bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height); //create a new bitmap as a rotated image
            using (Graphics g = Graphics.FromImage(rotatedImage)) // create the new image using graphics
            {
                // Set the rotation point to the center in the matrix
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                // Rotate
                g.RotateTransform(angle);
                // Restore rotation point in the matrix
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                // Draw the image on the bitmap
                g.DrawImage(bmp, new Point(0, 0));
            }

            return rotatedImage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // check for player model key presses and exicute move orders
            byte[] keys = new byte[256];
            GetKeyboardState(keys);

            if (((keys[(int)Keys.A]) & 128) == 128)
            {
                if (myShip.X > 0)
                {
                    myShip.MoveLeft(); // change the position of the ship using the sequence described as move left in the ships class 
                    pictureBox1.Invalidate(); // invalidate the picture box with the new image of the moved images and label
                }
            }
            if (((keys[(int)Keys.D]) & 128) == 128)
            {
                if (myShip.X < 708)
                {
                    myShip.MoveRight(); // change the position of the ship using the sequence described as move right in the ships class
                    pictureBox1.Invalidate(); // invalidate the picture box with the new image of the moved images and label
                }
            }
            if (((keys[(int)Keys.W]) & 128) == 128)
            {
                if (myShip.Y > 0)
                {
                    myShip.MoveUp(); // change position of the ship using the sequence described as move up in the ships class
                    pictureBox1.Invalidate(); // invalidate the picture box with the new image of the moved images and label
                }
            }
            if (((keys[(int)Keys.S]) & 128) == 128)
            {
                if (myShip.Y < 392)
                {
                    myShip.MoveDown(); // change position of the ship using the sequence described as move down in the ships class                
                    pictureBox1.Invalidate(); // invalidate the picture box with the new image of the moved images and label
                }
            }
            if (((keys[(int)Keys.Left]) & 128) == 128)
            {
                myShip.RotateLeft();
                ShipImage = RotateImage(OGShipImage, myShip.Angle); // rotate the image to the required angle.              
                pictureBox1.Invalidate(); // invalidate the picture box with the new image of the moved images and label
            }
            if (((keys[(int)Keys.Right]) & 128) == 128)
            {
                myShip.RotateRight();
                ShipImage = RotateImage(OGShipImage, myShip.Angle); // rotate the image to the required angle.              
                pictureBox1.Invalidate(); // invalidate the picture box with the new image of the moved images and label
            }
            if (((keys[(int)Keys.Space]) & 128) == 128)
            {
                if (bulletList.Count < 25)
                {
                    Bullet myBullet;

                    myBullet = new Bullet(); // create and instantiate the Bullet
                    myBullet.X = myShip.X + 112;// set the x value to the same as the ship
                    myBullet.Y = myShip.Y + 48; // set the bullets y value to be in line with the ship 
                    myBullet.Angle = myShip.Angle; // set the bullets angle to the same as the shaip
                    myBullet.Image = RotateImage(OGBulletImage, myBullet.Angle); // rotate the image to the required angle. using the OG image as a reference 

                    bulletList.Add(myBullet); // add my bullet to the list named bulletlist

                }

            }


            // move all of the birds images naturally  
            for (int i = 0; i < birdList.Count; i++)
            {
                Bird myBird = birdList[i];
                myBird.Move(); // take the value of the bird from the list and enable it to move 

                if (
                    // off the top
                    (myBird.Y < -74)
                    // off the bottom
                    || (myBird.Y > pictureBox1.Height + 10)
                    // off the left
                    || (myBird.X < -74)
                    // off the right
                    || (myBird.X > pictureBox1.Width + 10)

                )
                { // then reset the birds position on the y and x axis and give it a new random angle 
                    ResetBird(myBird);
                }
            }

            // move all of the bullets images naturally 
            for (int i = 0; i < bulletList.Count; i++)
            {
                Bullet myBullet = bulletList[i];
                myBullet.Move(); // take the value of the bullet from the list and enable it to move 

                // if the bullet has gone off the screen
                if (myBullet.X > pictureBox1.Width
                    || myBullet.Y > pictureBox1.Height
                    || myBullet.X < 0
                    || myBullet.Y < 0
                     )
                {
                    // delete the bullet
                    bulletList.Remove(myBullet);
                }

            }

            // check for colisions between the bullets and the birds
            for (int i = bulletList.Count - 1; i >= 0; i--)
            {
                Bullet myBullet = bulletList[i];
                for (int j = birdList.Count - 1; j >= 0; j--)
                {
                    Bird myBird = birdList[j];

                    Rectangle birdRec = new Rectangle(myBird.X, myBird.Y, 59, 51);
                    Rectangle bulletRec = new Rectangle(myBullet.X, myBullet.Y, 32, 32);


                    if (bulletRec.IntersectsWith(birdRec)) // if the bullet intersects with the bird then remove the bullet and the bird 
                    {
                        bulletList.Remove(myBullet);
                        ResetBird(myBird);

                        Points = Points + 1; // add oneto the points value and display it on the game panel
                        LblPoints.Text = Points.ToString();

                        CheckPoints();
                    }


                }

            }

            // check for collisions between the ship and the birds
            for (int i = birdList.Count - 1; i >= 0; i--)
            {
                Bird myBird = birdList[i];

                Rectangle birdRec = new Rectangle(myBird.X, myBird.Y, 59, 51); // set the rectangle for the bird 
                Rectangle shipRec = new Rectangle(myShip.X, myShip.Y, 118, 128); // set the rectangle for the ship

                if (shipRec.IntersectsWith(birdRec))
                {
                    // ship has collided with a bird, lose a life, reset the bird
                    lives = lives - 1;
                    TxtLives.Text = lives.ToString();
                    ResetBird(myBird);

                    if (lives == 0) // if the lives value is equal to 0 then tell the timer to stop and say the game is over 
                    {
                        TmrGame.Enabled = false;
                        MessageBox.Show("Game Over");
                        startToolStripMenuItem.Enabled = false;
                        stopToolStripMenuItem.Enabled = false;

                    }


                }

            }

            pictureBox1.Invalidate(); // update the picturebox to show the new improvements made to the birds positions
            UpdatePositionLabel();
        }

        void CheckPoints()
        {
            // check point value and introduce increased difficulty
            if (Points == 20)
            {
                // if points = 20 increase the speed of the birds
                IncreaseBirdSpeed();
                // max bird = +1
                IncreaseBirdCount();
            }

            else if (Points == 40)
            {
                IncreaseBirdSpeed();
                // max bird = +1
                IncreaseBirdCount();
            }

            else if (Points == 50)
            {
                // spawn birds from the top of the form
                IncreaseBirdCountTop();
                IncreaseBirdCountTop();
                IncreaseBirdCountTop();
                // increase ship speed
                IncreaseShipSpeed();

            }

            else if (Points == 60)
            {
                IncreaseBirdSpeed();
            }

            else if (Points == 80)
            {
                IncreaseBirdSpeed();
            }

            else if (Points == 100)
            {
                //if points = 100  spawn birds from the left of the form
                IncreaseBirdSpeed();
                IncreaseShipSpeed();
            }

            else if (Points == 120)
            {
                //if points = 120 increase the speed of the birds
                IncreaseBirdSpeed();
            }

            else if (Points == 140)
            {
                // if points = 140 increase the speed of the birds
                IncreaseBirdSpeed();
            }

            else if (Points == 150)
            {
                // if points = 150 spawn birds from the bottom of the form and increase the speed of the birds
                IncreaseBirdSpeed();
                IncreaseShipSpeed();
                // create birds from the bottom
                IncreaseBirdCountBottom();
                IncreaseBirdCountBottom();
                IncreaseBirdCountBottom();

            }

            else if (Points == 160)
            {
                // if points = 160 increase the speed of the birds
                IncreaseBirdSpeed();
            }

            else if (Points == 180)
            {
                // if points = 180 increase the speed of the birds
                IncreaseBirdSpeed();
            }

            else if (Points == 200)
            {
                //f points = 200 increase the speed of the birds 
                IncreaseBirdSpeed();
                IncreaseShipSpeed();
                // create birds form the left
                IncreaseBirdCountLeft();
                IncreaseBirdCountLeft();
                IncreaseBirdCountLeft();
            }
            else if (Points == 210)
            {
                IncreaseBirdSpeed();
            }
            else if (Points == 220)
            {
                IncreaseBirdSpeed();
            }
            else if (Points == 230)
            {
                IncreaseBirdSpeed();
            }
            else if (Points == 240)
            {
                IncreaseBirdSpeed();
            }
            else if (Points == 250)
            {
                IncreaseBirdSpeed();
            }
            else if (Points == 260)
            {
                IncreaseBirdSpeed();
            }
            else if (Points == 270)
            {
                IncreaseBirdSpeed();
            }
            else if (Points == 280)
            {
                IncreaseBirdSpeed();
            }
            else if (Points == 290)
            {
                IncreaseBirdSpeed();
            }
            else if (Points == 300)
            {
                IncreaseBirdSpeed();
            }

        }

        void ResetBird(Bird myBird)
        {
            myBird.X = myBird.SpawnX; // set the spawn points for the bird using the x, y and angle of the my bird as it spawns 
            myBird.Y = myBird.SpawnY;
            myBird.Angle = myBird.SpawnAngle;
        }

        void IncreaseBirdSpeed()
        {
            BirdSpeed = BirdSpeed + 1;
            for (int i = birdList.Count - 1; i >= 0; i--) // for every bird in the list increase the speed by one 
            {
                Bird myBird = birdList[i];
                myBird.MoveRate = BirdSpeed;
            }
        }

        void IncreaseShipSpeed()
        {

            myShip.ShipMoveRate = myShip.ShipMoveRate + 1;
           
        }

        void IncreaseBirdCount()
        {
            Bird myBird;

            myBird = new Bird(); // create and instantiate the bird 
            myBird.SpawnX = pictureBox1.Width + 10;// set its x value to the full width of the picturebox to which it is displayed plus ten so it does not stat visable to the player 
            myBird.SpawnY = RandomNumber.Next(0, pictureBox1.Height); // set the birds y to a random number on the y axis within the paraeters of 0 and the top of the picturebox 
            myBird.X = myBird.SpawnX;
            myBird.Y = myBird.SpawnY;

            myBird.SpawnAngle = RandomNumber.Next(-45, 45); // set the birds angle to a random variable using the random number generator 
            myBird.Angle = myBird.SpawnAngle;
            myBird.Image = RotateImage(OGBirdImage, myBird.Angle); // rotate the image to the required angle. using the OG image as a reference 
            myBird.MoveRate = BirdSpeed;

            birdList.Add(myBird); // add my bird to the list named birdlist 

        }

        void IncreaseBirdCountTop()
        {
            Bird myBird;

            myBird = new Bird(); // create and instantiate the bird 
            myBird.SpawnX = RandomNumber.Next(10, pictureBox1.Width);// set its x value to the widthof the picturebox to which it is displayed between a number of the width of the picture box and ten so it does not start visable to the player 
            myBird.SpawnY = -64 - 10; // set the birds y axis to start at the top of the picturebox not visable by the player  
            myBird.X = myBird.SpawnX;
            myBird.Y = myBird.SpawnY;
            myBird.SpawnAngle = RandomNumber.Next(-150, -60); // set the birds angle to a random variable using the random number generator 
            myBird.Angle = myBird.SpawnAngle;

            myBird.Image = (Bitmap)OGBirdImage.Clone();
            if (myBird.Angle >= -90)
            {
                myBird.Image = RotateImage(myBird.Image, myBird.Angle); // rotate the image to the required angle. using the OG image as a reference 
            }
            else
            {
                myBird.Image.RotateFlip(RotateFlipType.RotateNoneFlipX); // flip it on the x axis and then display it 
                myBird.Image = RotateImage(myBird.Image, myShip.Angle); // rotate to the  required angle 
            }
            myBird.MoveRate = BirdSpeed;

            birdList.Add(myBird); // add my bird to the list named birdlist 

        }

        void IncreaseBirdCountBottom()
        {
            Bird myBird;

            myBird = new Bird(); // create and instantiate the bird 
            myBird.SpawnX = RandomNumber.Next(1, pictureBox1.Width);// set its x value to the full width of the picturebox to which it is displayed plus ten so it does not stat visable to the player 
            myBird.SpawnY = pictureBox1.Height; // set the birds y to a random number on the y axis within the parameters of 0 and the top of the picturebox 
            myBird.X = myBird.SpawnX; // set a x position spawn point
            myBird.Y = myBird.SpawnY; // set a y position spawn point 

            myBird.SpawnAngle = RandomNumber.Next(80, 170); // set the birds angle to a random variable using the random number generator 
            myBird.Angle = myBird.SpawnAngle; // tell that the spawn point is equal to the given angle 
            myBird.Image = (Bitmap)OGBirdImage.Clone();
            if (myBird.Angle <= 90)
            {
                myBird.Image = RotateImage(myBird.Image, myBird.Angle); // rotate the image to the required angle. using the OG image as a reference 
            }
            else
            {
                myBird.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                myBird.Image = RotateImage(myBird.Image, myBird.Angle - 180);
            }
            myBird.MoveRate = BirdSpeed; // tell that the bird speed is the new move rate 

            birdList.Add(myBird); // add my bird to the list named birdlist 
        }

        void IncreaseBirdCountLeft()
        {
            Bird myBird;

            myBird = new Bird(); // create and instantiate the bird 
            myBird.SpawnX = 0 - 10;// set its x value to the left side of the picturebox to which it is displayed minus ten so it does not start visable to the player 
            myBird.SpawnY = RandomNumber.Next(1, pictureBox1.Height); // set the birds y to a random number on the y axis within the parameters of 0 and the top of the picturebox 
            myBird.X = myBird.SpawnX; // set a x position spawn point
            myBird.Y = myBird.SpawnY; // set a y position spawn point 

            myBird.SpawnAngle = RandomNumber.Next(135, 225); // set the birds angle to a random variable using the random number generator 
            myBird.Angle = myBird.SpawnAngle; // tell that the spawn point is equal to the given angle 
            myBird.Image = (Bitmap)OGBirdImage.Clone();
            myBird.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);           
            myBird.Image = RotateImage(myBird.Image, myBird.Angle - 180); // rotate the image to the required angle. using the OG image as a reference 
            myBird.MoveRate = BirdSpeed; // tell that the bird speed is the new move rate 

            birdList.Add(myBird); // add my bird to the list named birdlist 
        }

        void IncreaseBonusCount()
        {

        }
        
       

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < birdList.Count; i++)
            {
                Bird myBird = birdList[i]; // collect information of the bird from the list
                e.Graphics.DrawImage(myBird.Image, myBird.X, myBird.Y); // draw the bird image in the picturebox at the set x and y values 
           }

            for (int i = 0; i < bulletList.Count; i++)
            {
                Bullet myBullet = bulletList[i]; // collect information of the bullet from the list
                e.Graphics.DrawImage(myBullet.Image, myBullet.X, myBullet.Y);
            }

            e.Graphics.DrawImage(ShipImage, myShip.X, myShip.Y); // draw the ship image in the picturebox at x value and y value.
        }

        void UpdatePositionLabel()
        {
            label1.Text = String.Format("x = {0}, y = {1}, angle = {2}, birds = {3}, bullets = {4}; lives = {5}, birdSpeed = {6}", myShip.X, myShip.Y, myShip.Angle, birdList.Count, bulletList.Count, lives, BirdSpeed);
        }

        // example stolen from https://stackoverflow.com/questions/709540/capture-multiple-key-downs-in-c-sharp
        // this enables me to read multiple key presses simultaneously 
        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);
        // end of example 

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(" Game Instructions \n-Enter your name and press enter \n-Enter the amount of lives you would like between 1 and 15 \n-To turn the spaceship use the side arrow keys \n-To move the space ship use the W,A,S,D keys \n-To Shoot Lasers press the spacebar \n-Aim to shoot the birds with the lasers \n-Dont get hit by the birds or lose a life \n-Every bird you avoid or shoot you gain a point \n-Be careful, the better score you get the faster they move \n-Goodluck Player!!!");
            TxtName.Focus(); // once the instruction message has been shown to the player then focus the cursor onto TxtName
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TmrGame.Enabled = true; // if the start key is pressed then enable the timer 
            TxtName.Focus();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TmrGame.Enabled = false; // if the stop key is pressed then stop the game timer 
        }

       private void BtnReset_Click(object sender, EventArgs e)
        {
            // if the reset button is clicked 
            //stop the game
            //clear the textbox for the name and lives
            //enable the textbox for the name and lives
            //reset points 

            TmrGame.Enabled = false;
            
            TxtName.Enabled = true;
            TxtName.Clear();

            TxtLives.Enabled = true;
            TxtLives.Clear();

            LblPoints.Text = "0";

            TxtName.Focus();

            //reset the ships position
            myShip.X = 50;
            myShip.Y = 140;
            myShip.Angle = 0;
            ShipImage = RotateImage(OGShipImage, myShip.Angle);
           
           

        }

       private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TmrGame.Enabled)
            {
                e.Handled = true;
                return;
            }

            if (
                    (e.KeyChar >= 'A' && e.KeyChar <= 'Z') // check if enetered character is between A and Z and let it be entered if it is 
                    || (e.KeyChar >= 'a' && e.KeyChar <= 'z') // check if the entered character is between a and z and let it be entered if it is
                    || (e.KeyChar == (char)Keys.Back) // convert the int to a character and let it be entered
                    || (e.KeyChar == (char)Keys.Space) // convert the int ot a character and let it be entered
                )
            {
                return; // if it is then let it be added to the textbox
            }

            else if ( e.KeyChar == (char)Keys.Enter)
            {
                TxtName.Enabled = false; // if the eneter key is pressed then disable the text name textbox 
                TxtLives.Focus(); // focus on the text lives textbox 
                e.Handled = true; // say that the character has been handled 
            }

            else
            {
                e.Handled = true; // if not then present the task as already done 
            }

        }

        private void TxtLives_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TmrGame.Enabled)
            {
                e.Handled = true;
                return;
            }

            if (
                  (e.KeyChar >= '0' && e.KeyChar <= '9') // check if enetered character is between 1 and 9 and let it be entered if it is 
                  || (e.KeyChar == (char)Keys.Back) // convert the int to a character and let it be entered
              )
            {
                return; // if it is then let it be added to the textbox
            }
            

            else if (e.KeyChar == (char)Keys.Enter)
            {
                // get number from box
                String x = TxtLives.Text;
                lives = Int32.Parse(x);
                //check number is acceptable
                if (lives >= 1 && lives <= 15)
                {
                    // - disable box
                    TxtLives.Enabled = false;

                    // - start game
                    TmrGame.Enabled = true;

                    BirdSpeed = 5;
                    for (int i = 0; i < maxBirds; i++)
                    {
                        IncreaseBirdCount();
                    }
                }
                else
                {
                    e.Handled = true;
                    // - show error message
                    MessageBox.Show(" Sorry this value is not accepted. \n Please enter a number between 1 and 15.");
                    // - put cursor back in box
                    TxtLives.Focus();
                }
              
            
                e.Handled = true;
            }

            else
            {
                e.Handled = true; // if not then present the task as already done 
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TmrGame.Enabled)
            {
                e.Handled = true;
                return;
            }
        }
       
    }
}
