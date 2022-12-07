// Name : Hoang Nguyen
// Email : Hnguyen1193@csu.fullerton.edu
/*
Program name : CollideBallFrame.cs
Language : C#

List of the File :
    CollideBall.cs
    CollideBallFrame.cs
    CollideBallLogic.cs
    r.sh
*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class CollideBallFrame : Form
{
    //UI SIZE
    private static int formheight = 1200;
    private static int formwidth = 200 + formheight;
    private Size ui_size = new Size(formwidth,formheight);


    //Labels
    //position paramater
    private const int horizontal_displacement_label = 100;
    private const int vertical_displacement_label = 30;
    private const int label_text_size = 8;
    //Title
    private Label title_label = new Label();
    private Size title_label_size = new Size(600, 100);
    private Point title_label_location = new Point(400,10);
    private Font title_label_font = new Font("Arial", 30 ,FontStyle.Bold);
    private Color title_label_color =  Color.FromArgb(239,245,245);
    //Enter Speed Red Ball
    private Label enter_speed_red_ball = new Label();
    private Size enter_speed_red_ball_size = new Size(170,20);
    private Point enter_speed_red_ball_location = new Point(horizontal_displacement_label, vertical_displacement_label);
    private Font enter_speed_red_ball_font = new Font("Arial", label_text_size ,FontStyle.Bold);
    //Enter Speed Blue Ball
    private Label enter_speed_blue_ball = new Label();
    private Size enter_speed_blue_ball_size = new Size(170,20);
    private Point enter_speed_blue_ball_location = new Point(horizontal_displacement_label + 200, vertical_displacement_label);
    private Font enter_speed_blue_ball_font = new Font("Arial", label_text_size ,FontStyle.Bold);
    //Red Ball Location
    private Label red_ball_position = new Label();
    private Size red_ball_position_size = new Size(170,20);
    private Point red_ball_position_location = new Point(horizontal_displacement_label + 400, vertical_displacement_label);
    private Font red_ball_position_font = new Font("Arial", label_text_size ,FontStyle.Bold);
    //Blue Ball Location
    private Label blue_ball_position = new Label();
    private Size blue_ball_position_size = new Size(170,20);
    private Point blue_ball_position_location = new Point(horizontal_displacement_label + 600, vertical_displacement_label);
    private Font blue_ball_position_font = new Font("Arial", label_text_size ,FontStyle.Bold);


    //Buttons
    //Start Button
    private Button start_button = new Button();
    private Size start_button_size = new Size(70,50);
    private Color start_button_color = Color.FromArgb(229,217,182);
    private Point start_button_location = new Point(10,30);
    private Font start_button_font = new Font("Arial", 10 ,FontStyle.Bold);
    //Quit Button
    private Button quit_button = new Button();
    private Size quit_button_size = new Size(50,50);
    private Color quit_button_color = Color.FromArgb(233 , 119 , 119);
    private Point quit_button_location = new Point(1300, 30);
    private Font quit_button_font = new Font("Arial", 10 ,FontStyle.Bold);
    
    //Texts Field
    // Constant Paramaters
    private const int horizontal_displacement_textfield = 100;
    private const int vertical_displacement_textfield = 50;
    //Enter Speed Red Ball Text Field
    private TextBox enter_speed_red_ball_box = new TextBox();
    private Size enter_speed_red_ball_box_size = new Size(100, 20);
    private Font enter_speed_red_ball_box_font = new Font("Arial", 10 ,FontStyle.Bold);
    private Point enter_speed_red_ball_box_location = new Point(horizontal_displacement_textfield , vertical_displacement_textfield);
    //Enter Speed Blue Ball Text Field
    private TextBox enter_speed_blue_ball_box = new TextBox();
    private Size enter_speed_blue_ball_box_size = new Size(100, 20);
    private Font enter_speed_blue_ball_box_font = new Font("Arial", 10 ,FontStyle.Bold);
    private Point enter_speed_blue_ball_box_location = new Point(horizontal_displacement_textfield + 200, vertical_displacement_textfield);
    //Red Ball Position box
    private TextBox red_ball_position_box = new TextBox();
    private Size red_ball_position_box_size = new Size(100,20);
    private Font red_ball_position_box_font = new Font("Arial" , 10, FontStyle.Bold);
    private Point red_ball_position_box_location = new Point(horizontal_displacement_textfield + 400, vertical_displacement_textfield);
    //private static String red_ball_position_input;
    //Blue Ball Position box
    private TextBox blue_ball_position_box = new TextBox();
    private Size blue_ball_position_box_size = new Size(100, 20);
    private Font blue_ball_position_box_font = new Font("Arial", 10, FontStyle.Bold);
    private Point blue_ball_position_box_location = new Point(horizontal_displacement_textfield + 600, vertical_displacement_textfield);
    //private static String blue_ball_position_input;

    //Panel
    //Form Height is 1200
    //The UI is still messed up
    private const int panel_width = 1400;
    private const int graphic_panel_height = 850;
    private const int control_panel_height = 200;
    private const int header_panel_height = 150;
    //Header Panel
    private Panel header_panel = new Panel();
    private Size header_panel_size = new Size(panel_width, header_panel_height);         
    private Point header_panel_location = new Point(0,0);
    private Color header_panel_color = Color.FromArgb(239,245,245);
    //Control Panel
    private Panel control_panel = new Panel();
    private Size control_panel_size = new Size(panel_width , control_panel_height);
    private Point control_panel_location = new Point(0,header_panel_height + graphic_panel_height);
    private Color control_panel_color = Color.FromArgb(214,228,229);
    //Graphic Panel
    private Graphicpanel graphic_panel = new Graphicpanel();
    private Size graphic_panel_size = new Size(panel_width, graphic_panel_height);
    private Point graphic_panel_location = new Point(0, header_panel_height);
    private Color graphic_panel_color = Color.FromArgb(229,217,182);
    //Clock
    //Refresh Rate Clock
    private const double refresh_rate_clock_speed = 60.8;
    private int refresh_rate_interval = (int)System.Math.Round(1000.0 / refresh_rate_clock_speed);      //refresh rate clock
    private static System.Timers.Timer refresh_rate_clock = new System.Timers.Timer();
    //Ball Clock
    private const double ball_clock_speed = 24.0;
    private int ball_clock_interval = (int)System.Math.Round(1000.0 / ball_clock_speed);        //Ball clock for both balls
    private static System.Timers.Timer ball_clock = new System.Timers.Timer();
    //Program State
    private enum Program_State{Executing, Waiting_to_terminate};
    private Program_State current_status = Program_State.Executing;
    

    //Paramaters
    //Coordinates Paramaters
    //Coordindates of the first ball
    private static int center_first_ball_x = formwidth /3;
    private static int center_first_ball_y = formheight / 2;
    //Coordinates of the second ball
    private static int center_second_ball_x = (formwidth*2)/3;
    private static int center_second_ball_y = formheight / 2;
    private static int ball_diameter = 70;
    //speed of the ball
    private static double first_ball_per_tic = 0.0;
    private static double second_ball_per_tic = 0.0;
    //Direction paramaters for the first ball
    private static double delta_x_first_ball = 0.0;
    private static double delta_y_first_ball = 0.0;
    //Direction paramaters for the second ball
    private static double delta_x_second_ball = 0.0;
    private static double delta_y_second_ball = 0.0;
    //Angle in radians
    private static double first_ball_angle_radians;
    private static double second_ball_angle_radians;
    //Brush
    private static SolidBrush first_brush = new SolidBrush(Color.Red); 
    private static SolidBrush second_brush = new SolidBrush(Color.Blue);
    //Logic Direction 
    CollideBallLogic direction_generator = new CollideBallLogic();
    //Ball Visible
    private static bool ball_visible = false;
    //Constructor
    public CollideBallFrame()
    {
        //Main Frame
        Text = "RicochetBall";
        Size = new Size(100,100);
        MaximumSize = ui_size;
        MinimumSize = ui_size;

        //Labels
        //Title Label
        title_label.Size = title_label_size;
        title_label.Font = title_label_font;
        title_label.Location = title_label_location;
        title_label.BackColor = title_label_color;
        title_label.Text = "Collide ball by Kyle Nguyen";
        //Enter speed red ball
        enter_speed_red_ball.Size = enter_speed_red_ball_size;
        enter_speed_red_ball.Font = enter_speed_red_ball_font;
        enter_speed_red_ball.Location = enter_speed_red_ball_location;
        enter_speed_red_ball.Text = "Enter speed red ball";
        //Enter speed blue balls
        enter_speed_blue_ball.Size = enter_speed_blue_ball_size;
        enter_speed_blue_ball.Font = enter_speed_blue_ball_font;
        enter_speed_blue_ball.Location = enter_speed_blue_ball_location;
        enter_speed_blue_ball.Text = "Enter speed blue ball";
        //Blue Ball location
        blue_ball_position.Size = blue_ball_position_size;
        blue_ball_position.Font = blue_ball_position_font;
        blue_ball_position.Location = blue_ball_position_location;
        blue_ball_position.Text = "Blue Ball Location";
        //Red Ball location
        red_ball_position.Size = red_ball_position_size;
        red_ball_position.Font = red_ball_position_font;
        red_ball_position.Location = red_ball_position_location;
        red_ball_position.Text = "Red Ball Location";

        //Buttons
        //Start Button
        start_button.Size = start_button_size;
        start_button.Font = start_button_font;
        start_button.BackColor = start_button_color;
        start_button.Location = start_button_location;
        start_button.Text = "Start";
        start_button.Click += new EventHandler(start);
        //Quit Button
        quit_button.Size = quit_button_size;
        quit_button.Font = quit_button_font;
        quit_button.BackColor = quit_button_color;
        quit_button.Location = quit_button_location;
        quit_button.Text = "Quit";
        quit_button.Click += new EventHandler(closeapp);
        //TextBox
        //Enter Speed Red Ball Text Field
        enter_speed_red_ball_box.Size = enter_speed_red_ball_box_size;
        enter_speed_red_ball_box.Font = enter_speed_red_ball_box_font;
        enter_speed_red_ball_box.Location = enter_speed_red_ball_box_location;
        //Enter Speed Blue Ball Text Field
        enter_speed_blue_ball_box.Size = enter_speed_blue_ball_box_size;
        enter_speed_blue_ball_box.Font = enter_speed_blue_ball_box_font;
        enter_speed_blue_ball_box.Location = enter_speed_blue_ball_box_location;
        //red ball position box
        red_ball_position_box.Size = red_ball_position_box_size;
        red_ball_position_box.Font = red_ball_position_box_font;
        red_ball_position_box.Location = red_ball_position_box_location;
        red_ball_position_box.ReadOnly = true;
        //blue ball position box
        blue_ball_position_box.Size = blue_ball_position_box_size;
        blue_ball_position_box.Font = blue_ball_position_box_font;
        blue_ball_position_box.Location = blue_ball_position_box_location;
        blue_ball_position_box.ReadOnly = true;

        //Panels
        //Header Panel
        header_panel.Size = header_panel_size;
        header_panel.BackColor = header_panel_color;
        header_panel.Location = header_panel_location; 
        //Control Panel
        control_panel.Size = control_panel_size;
        control_panel.BackColor = control_panel_color;
        control_panel.Location = control_panel_location;
        //Graphic Panel
        graphic_panel.Size = graphic_panel_size;
        graphic_panel.BackColor = graphic_panel_color;
        graphic_panel.Location = graphic_panel_location;
        

        //Add Controls
        Controls.Add(quit_button);
        Controls.Add(start_button);
        Controls.Add(title_label);
        Controls.Add(enter_speed_red_ball);
        Controls.Add(enter_speed_blue_ball);
        Controls.Add(enter_speed_red_ball_box);
        Controls.Add(enter_speed_blue_ball_box);
        Controls.Add(red_ball_position);
        Controls.Add(blue_ball_position);
        Controls.Add(red_ball_position_box);
        Controls.Add(blue_ball_position_box);
        Controls.Add(enter_speed_red_ball_box);
        Controls.Add(enter_speed_blue_ball_box);
        //Add Controls for panels
        Controls.Add(header_panel);
        Controls.Add(graphic_panel);
        Controls.Add(control_panel);
        //Content Alignment
        title_label.TextAlign = ContentAlignment.MiddleCenter;
        enter_speed_red_ball.TextAlign = ContentAlignment.MiddleLeft;
        enter_speed_blue_ball.TextAlign = ContentAlignment.MiddleLeft;
        red_ball_position.TextAlign = ContentAlignment.MiddleLeft;
        blue_ball_position.TextAlign = ContentAlignment.MiddleLeft;
        //Control Panel 
        control_panel.Controls.Add(start_button);
        control_panel.Controls.Add(quit_button);
        control_panel.Controls.Add(enter_speed_red_ball);
        control_panel.Controls.Add(enter_speed_blue_ball);
        control_panel.Controls.Add(red_ball_position);
        control_panel.Controls.Add(blue_ball_position);
        control_panel.Controls.Add(enter_speed_red_ball_box);
        control_panel.Controls.Add(enter_speed_blue_ball_box);
        control_panel.Controls.Add(red_ball_position);
        control_panel.Controls.Add(blue_ball_position);
        control_panel.Controls.Add(red_ball_position_box);
        control_panel.Controls.Add(blue_ball_position_box);
        //refresh rate clock
        refresh_rate_clock.Enabled = false;
        refresh_rate_clock.Interval = refresh_rate_interval;
        refresh_rate_clock.Elapsed += new ElapsedEventHandler(refresh);
        //ball clock
        ball_clock.Enabled = false;
        ball_clock.Interval = ball_clock_interval;
        ball_clock.Elapsed += new ElapsedEventHandler(update);
        //center of the screen
        
        CenterToScreen();
    }

    //close app
    //Terminate the program and exit the application. 
    protected void closeapp(System.Object sender, EventArgs e)
    {
        System.Console.WriteLine("Quit button is clicked");
        System.Console.WriteLine("Thank you for using our program");
        Close();

    }
    //plug and play
    //Update ball direction
    //what happen if two balls hit each other
    protected void update(System.Object sender, EventArgs e)
    {
        // update first ball direction 
        center_first_ball_x += (int)delta_x_first_ball;
        center_first_ball_y += (int)delta_y_first_ball;

        // update second ball direction
        center_second_ball_x += (int)delta_x_second_ball;
        center_second_ball_y += (int)delta_y_second_ball;

        //first ball bounce if it hit border
        if (center_first_ball_x <= 0 || (center_first_ball_x + ball_diameter) > formwidth) // first ball hit at the side bar 
        {
            delta_x_first_ball = -delta_x_first_ball;
        }
        if(center_first_ball_y < 0 || (center_first_ball_y + ball_diameter) > graphic_panel_height) // first ball hit at the top and bottom bar
        {
            delta_y_first_ball = -delta_y_first_ball;
        }
        //bounce effect for second ball
        if(center_second_ball_x <= 0 || (center_second_ball_x + ball_diameter) > formwidth) // second ball hit at the side bar
        {
            delta_x_second_ball = -delta_x_second_ball;
        }
        if(center_second_ball_y <= 0 || (center_second_ball_y + ball_diameter) > graphic_panel_height) // second ball hit at the top and bottom bar
        {
            delta_y_second_ball = -delta_y_second_ball;
        }

        //Collide Ball Effect
        //if two balls collide each other, the color will temporary change.
        //when the ball is no longer in contact, the colors will be reverted back 
        //to the orginal color
        if( (center_first_ball_x - center_second_ball_x) < 0 || (center_first_ball_x - center_second_ball_x) == 0)    // if the ball coordinates + ball_diameter 
        {
            

        }

        //Tracking red ball position
        red_ball_position_box.Text = "(" + center_first_ball_x +", " + center_first_ball_y + ")";
        //Tracking blue ball position
        blue_ball_position_box.Text = "(" + center_second_ball_x + ", " + center_second_ball_y + ")";

    }
    //refresh the graphic panel
    protected void refresh(System.Object sender, EventArgs e)
    {
        graphic_panel.Invalidate();
    }
    //Start
    //setting up paramaters for both balls
    //setting up direction from two balls
    //what else ? 
    protected void start(System.Object sender, EventArgs e)
    {
        try
        {
            if((enter_speed_red_ball_box ?? enter_speed_blue_ball_box) != null)
            {
                //getting speed for both balls
                first_ball_per_tic = float.Parse(enter_speed_red_ball_box.Text);    //setting speed for the first ball
                second_ball_per_tic = float.Parse(enter_speed_blue_ball_box.Text);

                //Direction of the first ball
                first_ball_angle_radians = direction_generator.get_random_direction();
                delta_x_first_ball = first_ball_per_tic  * System.Math.Cos(first_ball_angle_radians);
                delta_y_first_ball = first_ball_per_tic * System.Math.Sin(first_ball_angle_radians);

                //Direction of the second ball
                second_ball_angle_radians = direction_generator.get_random_direction();
                delta_x_second_ball = second_ball_per_tic * System.Math.Cos(second_ball_angle_radians);
                delta_y_second_ball = second_ball_per_tic * System.Math.Sin(second_ball_angle_radians);

                //setting ball visile
                ball_visible = true;
                graphic_panel.Invalidate();

            }
        }
        catch (System.Exception)
        {
            //No input
            //Bad Input
            System.Console.WriteLine("ERROR: Please enter input again.");

            
        }

        //Program Status
        //current_status will let the user know at which state is the program now
        switch (current_status)
        {
            
            case Program_State.Executing:
            //set visible for both balls to True
            //start the clock
            //set text of button from Start to Pause
            start_button.Text = "Pause";
            refresh_rate_clock.Enabled = true;
            ball_clock.Enabled = true;
            current_status = Program_State.Waiting_to_terminate; //set the enum for the next time the user hit the start button.
            break;

            case Program_State.Waiting_to_terminate:
            //pause all the clock
            //set text from "Pause" to "Resume"
            start_button.Text = "Resume";
            refresh_rate_clock.Enabled = false;
            ball_clock.Enabled = false;
            current_status = Program_State.Executing;   //second behavior when the user the start button agian. 
            break;

        }
    }

    //graphic panel
    //Drawing palls on the graphic panels
    public class Graphicpanel: Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics board = e.Graphics;
            if(ball_visible)
            {
                board.FillEllipse(first_brush,center_first_ball_x, center_first_ball_y, ball_diameter,ball_diameter);
                board.FillEllipse(second_brush,center_second_ball_x,center_second_ball_y,ball_diameter,ball_diameter);
            }
        }
    }

}


