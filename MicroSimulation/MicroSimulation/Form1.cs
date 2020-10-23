using MicroSimulation.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroSimulation
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        Random rnd = new Random(1234);

        List<int> maleNbrs = new List<int>();
        List<int> femaleNbrs = new List<int>();

        public Form1()
        {
            InitializeComponent();
            

            Population = GetPopulation(textBox1.Text);
            BirthProbabilities = GetBirthProbabilities(@"C:\Windows\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Windows\Temp\halál.csv");

            
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        yearOfBirth = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        numberOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        public List<BirthProbability> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbability> birthprobabilites = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birthprobabilites.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        numberOfChildren = int.Parse(line[1]),
                        Probability = double.Parse(line[2])

                    });
                }
            }

            return birthprobabilites;
        }

        public List<DeathProbability> GetDeathProbabilities(string csvpath)
        {
            List<DeathProbability> deathprobabilities = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deathprobabilities.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        Probability = double.Parse(line[2])
                    });
                }
            }

            return deathprobabilities;
        }

        public void SimStep(int year, Person person) {
            if (!person.isALive) return;

            int age = year - person.yearOfBirth;

            double deathprob = (from x in DeathProbabilities where x.Age==age && x.Gender == person.Gender select x.Probability).FirstOrDefault();

            if (rnd.NextDouble() <= deathprob) {
                person.isALive = false;
            }

            if (person.isALive && person.Gender == Gender.Female) {
                double birthprob = (from x in BirthProbabilities where x.Age == age && x.numberOfChildren == person.numberOfChildren select x.Probability).FirstOrDefault();

                if (rnd.NextDouble() <= birthprob)
                {
                    person.numberOfChildren++;
                    Person newBorn = new Person();
                    newBorn.yearOfBirth = year;
                    newBorn.Gender = (Gender)(rnd.Next(1,3));
                    newBorn.numberOfChildren = 0;
                    Population.Add(newBorn);

                }

            }


        }

        public void Simulation()
        {
            for (int year = 2005; year < int.Parse(textBox2.Text); year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                int maleNbr = (from x in Population where x.Gender == Gender.Male && x.isALive select x).Count();
                int femaleNbr = (from x in Population where x.Gender == Gender.Female && x.isALive select x).Count();

                maleNbrs.Add(maleNbr);
                femaleNbrs.Add(femaleNbr);

                Console.WriteLine(
                string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, maleNbr, femaleNbr));
            }
        }

        public void DisplayResults() {
            var i = 0;
            for (int year = 2005; year < int.Parse(textBox2.Text); year++)
            {
                
                richTextBox1.AppendText(string.Format("Szimulációs év: {0} \n \t Fiúk: {1} \n \t Lányok: {2} \n \n", year,maleNbrs[i],femaleNbrs[i]));
                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            maleNbrs.Clear();
            femaleNbrs.Clear();
            Simulation();
            DisplayResults();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            textBox1.Text = ofd.FileName;

        }

      
    }
}
