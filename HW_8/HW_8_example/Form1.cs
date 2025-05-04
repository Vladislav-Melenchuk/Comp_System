namespace HW_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Animka();
            Animka2();
        }


        async void Animka()
        {
            while (progressBar1.Value != 100)
            {
                progressBar1.Value++;
                await Task.Delay(50);
            }
        }

        async void Animka2()
        {
            string baseText = "Loading";
            int dotCount = 0;

            while (progressBar1.Value < 100)
            {
                dotCount = (dotCount + 1) % 4;
                label1.Text = baseText + new string('.', dotCount);
                await Task.Delay(300);
            }

            if (progressBar1.Value == 100)
            {
                label1.Text = "Done";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
