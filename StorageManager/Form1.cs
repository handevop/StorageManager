using System.Diagnostics;

namespace StorageManager
{
    public partial class Form1 : Form
    {
        private string directory = "";
        private string download_directory = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            download_directory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).ToString() + "\\Downloads";
            directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + "\\FileManager";

            Create_directory(directory);
            Copy_files(download_directory);
        }

        private void Create_directory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                Directory.CreateDirectory(directory + "\\Privatno");
                Directory.CreateDirectory(directory + "\\Poslovno");
                Directory.CreateDirectory(directory + "\\Temporary");
            }
        }

        private void Copy_files(string download_directory)
        {
            if (Directory.Exists(download_directory))
            {
                string[] download_files = Directory.GetFiles(download_directory);

                foreach (var file in download_files)
                {
                    Debug.WriteLine(file.ToString());
                    Copy_file(file);
                }

            }
        }

        private void Copy_file(string file)
        {
            if (!file.EndsWith("ini") && !file.EndsWith("exe"))
            {
                string naziv_datoteke = file[file.LastIndexOf("\\")..];
                string ime = naziv_datoteke[..naziv_datoteke.IndexOf(".")];
                string ekstenzija = naziv_datoteke[naziv_datoteke.IndexOf(".")..];
                int iterator = 1;

                if (File.Exists(directory + "\\Temporary" + naziv_datoteke))
                {
                    while (File.Exists(directory + "\\Temporary" + ime + "_" + iterator.ToString() + ekstenzija))
                    {
                        iterator++;
                    }
                    File.Copy(file, directory + "\\Temporary" + ime + "_" + iterator.ToString() + ekstenzija, true);
                }
                else
                {
                    File.Copy(file, directory + "\\Temporary" + naziv_datoteke, true);
                }

                File.Delete(file);
            }
        }

        private void Select_profile(object sender, EventArgs e)
        {
            ComboBox profil = (ComboBox)sender;

            if (profil.SelectedItem.ToString() == "Privatno")
            {
                Privatno privatno = new();
                privatno.Show();

                this.Hide();
            }
            else if (profil.SelectedItem.ToString() == "Poslovno")
            {
                Poslovno poslovno = new();
                poslovno.Show();

                this.Hide();
            }
            else
            {
                throw new Exception("Greška u odabiru profila", new AccessViolationException());
            }
        }

    }
}