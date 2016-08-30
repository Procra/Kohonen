using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;

namespace Kohonen
{
    public partial class Form1 : Form
    {
        private DistanceNetwork network;
        private Bitmap mapBitmap;
        private Random rand = new Random();
        private int reptotal = 5000;
        private double learningRate = 0.1;
        private double radius = 15;
        private bool stop = false;

        public Form1()
        {
            InitializeComponent();
            // Pour réduire le scintillement de l'image
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            // Création du réseau de neurones
            network = new DistanceNetwork(3, 100 * 100);

            // Création de la bitmap (image composée de pixels)
            mapBitmap = new Bitmap(200, 200, PixelFormat.Format24bppRgb);

            // Génération aléatoire de pixels
            RandomizeNetwork();
        }

        // Génération aléatoire des poids du réseau
        private void RandomizeNetwork()
        {
            Neuron.RandRange = new DoubleRange(0, 255);

            // Génération aléatoire du réseau
            network.Randomize();

            // Rafraichissement de la bitmap
            Refresh();
        }

        // Rafrachit la map à partir des poids du réseau
        private void Refresh()
        {
            // On verrouille l'image
            BitmapData mapData = mapBitmap.LockBits(new Rectangle(0, 0, 200, 200),ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = mapData.Stride;
            int offset = stride - 200 * 3;
            Layer layer = network[0];

            unsafe
            {
                byte* ptr = (byte*)mapData.Scan0;

                // pour chaque ligne
                for (int y = 0, i = 0; y < 100; y++)
                {
                    // pour chaque pixel
                    for (int x = 0; x < 100; x++, i++, ptr += 6)
                    {
                        Neuron neuron = layer[i];
                        // rouge
                        ptr[2] = ptr[2 + 3] = ptr[2 + stride] = ptr[2 + 3 + stride] = (byte)Math.Max(0, Math.Min(255, neuron[0]));
                        // vert
                        ptr[1] = ptr[1 + 3] = ptr[1 + stride] = ptr[1 + 3 + stride] = (byte)Math.Max(0, Math.Min(255, neuron[1]));
                        // bleu
                        ptr[0] = ptr[0 + 3] = ptr[0 + stride] = ptr[0 + 3 + stride] = (byte)Math.Max(0, Math.Min(255, neuron[2]));
                    }
                    ptr += offset;
                    ptr += stride;
                }
            }

            // on déverrouille l'image
            mapBitmap.UnlockBits(mapData);

            // Rafraichissement du contrôle
            map.Invalidate();
        }

        // Lorsque la bitmap est redessinée
        private void map_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics legraphe = e.Graphics;
            // on redessine
            legraphe.DrawImage(mapBitmap, 0, 0, 200, 200);
        }

        private void Démarrer_Click(object sender, EventArgs e)
        {
            reptotal = 50;
            learningRate = 0.1;
            radius = 15;
            // démarrage du thread
            stop = false;
            bgw1.RunWorkerAsync();
        }

        private void generer_Click(object sender, EventArgs e)
        {
            RandomizeNetwork();
        }

        private void bgw1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Algorythme d'apprentissage pour les cartes auto-organisatrices (SOM)
            SOMLearning apprentissage = new SOMLearning(network);

            // entrée
            double[] entree = new double[3];

            double fixedLearningRate = learningRate / 10;
            double driftingLearningRate = fixedLearningRate * 9;

            // Nombre de répétitions
            int répètes = 0;

            while (!stop){
                apprentissage.LearningRate = driftingLearningRate * (reptotal - répètes) / reptotal + fixedLearningRate;
                apprentissage.LearningRadius = (double)radius * (reptotal - répètes) / reptotal;

                entree[0] = rand.Next(256);
                entree[1] = rand.Next(256);
                entree[2] = rand.Next(256);

                apprentissage.Run(entree);

                // Rafraichissement de la bitmap toutes les 50 répétitions
                if ((répètes % 10) == 9){
                    Refresh();
                }
                répètes++;
                if (répètes >= reptotal)
                    break;
            }
        }
    }
}