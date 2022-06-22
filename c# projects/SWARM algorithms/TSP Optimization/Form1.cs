using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSP_Optimization.Classes;

namespace TSP_Optimization
{
    public partial class tsp_optimization : Form
    {

        #region Attributes

        private Random rnd;
        private Thread thread;
        private bool isRunning;
        private bool isCreated;
        private bool isFinished;
        private Stopwatch timer;
        private ACO aco;
        private ManualResetEvent rst;
        private bool isPaused;

        #endregion

        #region Threads functions

        private void Process()
        {
            int city = Decimal.ToInt32(numPlaces.Value);
            int ant = Decimal.ToInt32(numAnts.Value);
            int alp = Decimal.ToInt32(numAlpha.Value);
            int bet = Decimal.ToInt32(numBeta.Value);
            double dec = Decimal.ToDouble(numDecrease.Value);
            double inc = Decimal.ToDouble(numIncrease.Value);
            this.aco = new ACO(city,ant,alp,bet,dec,inc);
            try
            {
                this.aco.make_graph_distances(this.rnd);

                this.aco.initialize_ants(this.rnd);


                int[] bestTrail = this.aco.best_trail();
                double bestLength = this.aco.length(bestTrail);
                // the length of the best trail

                this.lbxInfo.Items.Add("\nBest initial trail length: " + bestLength.ToString("F1") + "\n");
                string bestTrailStr = this.aco.Display(bestTrail);

                this.lblBestInit.Text = bestTrailStr;

                this.aco.initialize_pheromones();

                int max_iterations = Decimal.ToInt32(numIterations.Value);
                int iteration = 0;
     
                while (iteration <max_iterations )
                {

                    this.aco.update_ants(rnd);
                    this.aco.update_pheromones();

                    int[] currBestTrail = this.aco.best_trail();
                    double currBestLength = this.aco.length(currBestTrail);
                    if (currBestLength < bestLength)
                    {
                        bestLength = currBestLength;
                        bestTrail = currBestTrail;
                        this.lbxInfo.Items.Add("New best length of " + bestLength.ToString("F1") + " found at iteration " + iteration);
                        string currbestTrailStr = this.aco.Display(bestTrail);
                        this.lblBestFound.Text = currbestTrailStr;
                    }
                    iteration += 1;
                    this.rst.WaitOne();
                }

                lock (this)
                {
                    this.isFinished = true;
                    this.lblStatus.Text = "Status: Finished";
                    this.isRunning = false;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private void Start()
        {
            if (this.isRunning)
            {
                return;
            }

            if (this.isPaused || this.isFinished)
            {
                this.rst.Set();
                this.timer.Reset();
                this.thread.Abort();
            }
            this.isRunning = true;

            this.thread = new Thread(Process);

            this.isCreated = true;
            this.lblStatus.Text = "Status: Running";
            this.timer.Start();
            this.thread.Start();
        }

        private void Pause()
        {
            if (this.isRunning)
            {
                this.rst.Reset();
                this.timer.Stop();
                this.isRunning = false;
                this.lblStatus.Text = "Status: Paused";
                this.isPaused = true;
            }
        }

        private void Resume()
        {
            if (!this.isRunning)
            {
                this.rst.Set();
                this.timer.Start();
                this.isRunning = true;
                this.lblStatus.Text = "Status: Running";
            }
        }

        private void Stop()
        {

            this.isRunning = false;
            this.lblStatus.Text = "Status: Stopped";

            this.rst.Set();

            this.thread.Abort();
            this.timer.Reset();
        }

        #endregion

        #region Form functions

        public tsp_optimization()
        {
            InitializeComponent();
            this.rst = new ManualResetEvent(true);
            this.timer = new Stopwatch();
            this.isFinished = false;
            this.rnd = new Random();
            this.isRunning = false;
            this.isCreated = false;

            this.lblStatus.Text = "Status: Not running";
            this.lbxInfo.Items.Clear();
            this.numAlpha.Value = 3;
            this.numBeta.Value = 2;
            this.numDecrease.Value = (decimal)0.01;
            this.numIncrease.Value = 2;
            this.numIterations.Value = 10000;
            this.numPlaces.Value = 60;
            this.numAnts.Value = 4;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.lblBestFound.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.lblBestInit.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.lblStatus.Text = "Status: Not running";
            this.lbxInfo.Items.Clear();
            this.numAlpha.Value = 3;
            this.numBeta.Value = 2;
            this.numDecrease.Value = (decimal)0.01;
            this.numIncrease.Value = 2;
            this.numIterations.Value = 10000;
            this.numPlaces.Value = 60;
            this.numAnts.Value = 4;

            this.timer.Reset();

            if (this.isCreated)
                this.thread.Abort();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (this.isCreated)
                this.Stop();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (this.isCreated)
                this.Pause();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if (this.isCreated)
                this.Resume();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.Start();
        }

        private void tsp_optimization_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isCreated)
                this.Stop();
        }

        #endregion
    }
}
