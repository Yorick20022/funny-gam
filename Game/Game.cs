using SFML.Graphics;
using SFML.System;
using SFML.Window;
using View = SFML.Graphics.View;

namespace Game
{
    internal class Game
    {
        public void Start()
        {
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Yorick RPG");
            window.SetFramerateLimit(120);
            window.Closed += Window_Closed;

            Map map = new Map();
            View view = new View(new Vector2f(0, 0), new Vector2f(800, 600));
            Player player = new Player();
            
            Chicken chicken = new Chicken();
            chicken.Waypoints = new List<Waypoint>();
            chicken.Waypoints.Add(new Waypoint(0, 0));
            chicken.Waypoints.Add(new Waypoint(100, 0));
            chicken.Waypoints.Add(new Waypoint(100, 100));
            chicken.Waypoints.Add(new Waypoint(0, 100));
            

            Clock clock = new Clock();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(new SFML.Graphics.Color(43, 130, 53));
                float deltaTime = clock.Restart().AsSeconds();
                chicken.Update(deltaTime);
                player.Update(deltaTime);

                view.Center = new Vector2f(player.Xpos, player.Ypos);
                window.SetView(view);

                map.Draw(window);
                chicken.Draw(window);
                player.Draw(window);
                window.Display();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
    }
}