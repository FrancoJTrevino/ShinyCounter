using ExcelDataReader;
using System.Text.Json;
using System.Runtime.InteropServices;
using System.Threading;

namespace ShinyCounter
{
    public partial class Form1 : Form
    {
        public int _counter = 0;
        List<SaveData> _savedData = new List<SaveData>();
        bool ThreadOpen = true;

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        int Key = 117; // F6
        int Key2 = 120; // F9
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string fileName = "Pokedex.xlsx";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            var PokemonExcel = new System.Data.DataSet();

            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                PokemonExcel = reader.AsDataSet(new ExcelDataSetConfiguration());
            }

            for (int i = 0; i < PokemonExcel.Tables[0].Rows.Count; i++)
            {
                string ID = PokemonExcel.Tables[0].Rows[i].ItemArray[0].ToString().PadLeft(4, '0');
                string Pokemon = PokemonExcel.Tables[0].Rows[i].ItemArray[1].ToString();
                string TextDisplay = $"#{ID} - {Pokemon}";

                cmbPokemon.Items.Add(TextDisplay);
            }

            Thread KB = new Thread(Keybind);
            KB.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadOpen = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _counter = 0;
            SaveData(cmbPokemon.Text, _counter);
            lblCounter.Text = _counter.ToString();
            lblStartingDate.Text = "Hunt started: ";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _counter++;
            if (lblCounter.Text == "0")
                SaveData(cmbPokemon.Text, _counter, DateTime.Now);
            else
                SaveData(cmbPokemon.Text, _counter);
            lblCounter.Text = _counter.ToString();
            lblStartingDate.Text = "Hunt started: " + _savedData.Find(x => x.Pokemon == cmbPokemon.Text).StarterDate?.ToString("dd/MM/yyyy hh:mm");
        }

        private void cmbPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            LoadData(cmbPokemon.Text);
            if (_savedData.Any(x => x.Pokemon == cmbPokemon.Text))
            {
                _counter = _savedData.Find(x => x.Pokemon == cmbPokemon.Text).Counter;
                lblCounter.Text = _counter.ToString();
                lblStartingDate.Text = "Hunt started: " + _savedData.Find(x => x.Pokemon == cmbPokemon.Text).StarterDate?.ToString("dd/MM/yyyy hh:mm");
            }
            else
            {
                _counter = 0;
                lblCounter.Text = _counter.ToString();
                lblStartingDate.Text = "Hunt started: ";
            }
        }

        private void SaveData(string Pokemon, int Counter, DateTime? StarterDate = null)
        {
            SaveData saveData;
            if (StarterDate == null)
                saveData = new SaveData(Pokemon, Counter);
            else
                saveData = new SaveData(Pokemon, Counter, StarterDate);
            if (_savedData.Any(x => x.Pokemon == saveData.Pokemon))
            {
                if (_savedData.Find(x => x.Pokemon == saveData.Pokemon).StarterDate != null)
                    saveData.StarterDate = _savedData.Find(x => x.Pokemon == saveData.Pokemon).StarterDate;
                _savedData.Remove(_savedData.Find(x => x.Pokemon == saveData.Pokemon));
            }
            _savedData.Add(saveData);
            string path = Path.Combine(Environment.CurrentDirectory, "SaveData.json");
            string json = JsonSerializer.Serialize(_savedData);
            File.WriteAllText(path, json);
        }

        private void LoadData(string Pokemon)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "SaveData.json");
            string json = "";
            try
            {
                json = File.ReadAllText(path);
            }
            catch (Exception)
            {
                return;
            }
            List<SaveData> saveData = JsonSerializer.Deserialize<List<SaveData>>(json);
            if (saveData != null)
            {
                _savedData = saveData;
            }
        }

        private void Keybind()
        {
            while (ThreadOpen)
            {
                Thread.Sleep(5);

                int KeyState = GetAsyncKeyState(Key);
                int KeyState2 = GetAsyncKeyState(Key2);

                if (KeyState == 32769)
                {
                    Invoke(new Action(() => btnAdd.PerformClick()));
                }
                if (KeyState2 == 32769)
                {
                    Invoke(new Action(() => btnReset.PerformClick()));
                }
            }
        }

        
    }
}
