

using System.Globalization;

namespace GravityForm
{
    public partial class Form1 : Form
    {

        public const int groundY = 45;
        public const int FPS = 120;
        public float gravity;

        public float acceleration = 0;
        public float velocity = 0;

        public const int winbarHeight = 38;

        public int ScreenWidth  = Screen.PrimaryScreen.Bounds.Width, 
                   ScreenHeight = Screen.PrimaryScreen.Bounds.Height - winbarHeight;

        public int W, H;

        public float REBOUND;


        public Form1()
        {
            InitializeComponent();

            W = Width;
            H = Height;

   
        }

        public int Y
        {
            get { return this.Top; }
            set { this.Top = value; }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            REBOUND = float.Parse(RT.Text, CultureInfo.InvariantCulture.NumberFormat);
            gravity = float.Parse(GT.Text, CultureInfo.InvariantCulture.NumberFormat) / 10000;

            var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(1000 / FPS));

            while (await timer.WaitForNextTickAsync()) Tick();
        }

        public void Step(int y)
        {
            Y += y;
        }

        public void Tick()
        {

            acceleration += gravity;

            velocity += acceleration;

            Step((int)velocity);

            if (Y + H >= ScreenHeight)
            {
                velocity *=- REBOUND;
                Y = ScreenHeight - H;
            }
            
        }
    }
}