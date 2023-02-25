using System.Reflection.Emit;

public class Form
{
}public class MyForm : Form
{
    private System.Reflection.Emit.Label label1;
    private TextBox textBox1;
    private Button button1;

    public MyForm()
    {
        // Initialize the components of the form
        this.label1 = new Label();
        this.label1.Text = "Enter your name:";
        this.label1.Location = new System.Drawing.Point(10, 10);
        this.Controls.Add(this.label1);

        this.textBox1 = new TextBox();
        this.textBox1.Location = new System.Drawing.Point(10, 30);
        this.Controls.Add(this.textBox1);

        this.button1 = new Button();
        this.button1.Text = "Say Hello";
        this.button1.Location = new System.Drawing.Point(10, 60);
        this.button1.Click += new EventHandler(button1_Click);
        this.Controls.Add(this.button1);

        // Set the properties of the form
        this.Text = "My Form";
        this.Size = new System.Drawing.Size(200, 150);
    }

    public object Controls { get; }

    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Hello, " + this.textBox1.Text + "!");
    }
}

internal class Button
{
    public string Text { get; internal set; }
}

public class Program
{
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new MyForm());
    }
}
