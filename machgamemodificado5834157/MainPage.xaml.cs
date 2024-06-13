namespace machgamemodificado5834157
{
    public partial class MainPage : ContentPage
    {
     IDispatcherTimer timer;
        int milisegundos;
        int pares;

        public MainPage()
        {

            timer = Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            InitializeComponent();
            SetUpGame();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            milisegundos++;
            timerLabel.Text=(milisegundos/10f).ToString("0.00s");
            if (pares == 8)
            {
                timer.Stop();
                timerLabel.Text = timerLabel.Text + "- ha finalizado el juego";
                btnReiniciar.IsVisible = true;
            }
        }


        private void SetUpGame()
        {
            // Lista de emojis de animales en pares.
            List<string> animalEmoji = new List<string>()
            {
                "🐶","🐶",

                "🙈","🙈",

                "😂","😂",

                "😊","😊",

                "😎","😎",

                "👀","👀",

                "💩","💩",

                "🐱‍👤","🐱‍👤",

            };

            // Crear una instancia de la clase Random para generar números aleatorios.
            Random random = new Random();
            foreach (Button view in Grid1.Children)
            {
                view.IsVisible = true;
                // Genera un índice aleatorio dentro del rango de la lista animalEmoji.
                int index = random.Next(animalEmoji.Count);

                string nextEmoji = animalEmoji[index];
                // Asigna el emoji al texto del botón.
                view.Text = nextEmoji;
                //Elimina el emoji
                animalEmoji.RemoveAt(index);
            }

            timer.Start();
            milisegundos = 0;
            pares = 0;
        }

        // Variable para almacenar el último botón clicado.
        Button ultimoButtonClicked;
        // Variable para determinar si se encontró una coincidencia.
        bool encontradoMatch = false;


        private void Button_Clicked(object sender, EventArgs e)
        {
            // Convierte el sender a un objeto Button.
            Button button = sender as Button;
            if (encontradoMatch == false)
            {
                // Hace el botón invisible.
                button.IsVisible = false;

                // Guarda el botón actual como el último botón clicado.
                ultimoButtonClicked = button;

                // Indica que se ha encontrado una coincidencia
                encontradoMatch = true;
            }

            else if (button.Text == ultimoButtonClicked.Text)
            {
                pares++;
                // Si el texto del botón actual coincide con el del último botón clicado, hace el botón invisible.
                button.IsVisible = false;

                // Restablece la variable de coincidencia.
                encontradoMatch = false;
            }

            else
            {
                // Si no coinciden, hace visible nuevamente el último botón clicado.
                ultimoButtonClicked.IsVisible = true;

                // Restablece la variable de coincidencia.
                encontradoMatch = false;
            }
        }


        private void btnReiniciar_Clicked(object sender, EventArgs e)
        {
            SetUpGame();
            btnReiniciar.IsVisible = false;
        }
    }

}
